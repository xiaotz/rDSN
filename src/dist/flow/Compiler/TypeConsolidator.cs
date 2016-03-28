using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using rDSN.Tron.Utility;
using rDSN.Tron.Contract;

namespace rDSN.Tron.Compiler
{
    public class TypeConsolidator
    {
        public bool Consolidate(List<string> compositionStubAssemblies, string outputCompositionStubAssembly)
        {
            Debug.Assert(compositionStubAssemblies.Count > 0, "composition stub collection cannot be empty");

            // load all asms
            var asms = new List<Assembly>();
            foreach (var cs in compositionStubAssemblies)
            {
                try
                {
                    var asm = Assembly.LoadFile(cs);
                    asms.Add(asm);
                }
                catch (Exception e)
                {
                    Trace.WriteLine("exception happens during load composititon sub '" + cs + "', msg = " + e.Message);
                    return false;
                }
            }

            // build type graphs
            var g = BuildTypeGraph(asms);

            // type consolidation
            DoTypeConsolidation(g);

            return true;
        }

        private void DoTypeConsolidation(TypeGraph g)
        {
            // check service type confliction
            var css = g.Services.GroupBy(t => t.Key.FullName).Where(ig => ig.Count() > 1).ToArray();

            // resolve service type confliction
            foreach (var ss in css)
            {
                Trace.WriteLine("service name conflict: '" + ss.Key+ "'");

                int i = 1;
                foreach (var s in ss)
                {                    
                    g.Services[s.Key] = s.Value + "_" + i;

                    Trace.WriteLine("\t" + i + ". defined in " + s.Key.Assembly.FullName + ", rename to '" + s.Value + "_" + i + "'");

                    i++;
                }
            }
            
            // check req/resp type confliction
            var crs = g.Types.GroupBy(t => t.Key.FullName).Where(ig => ig.Count() > 1).ToArray();

            // resolve req/resp type confliction
            foreach (var rs in crs)
            { 
                Trace.WriteLine("type conflict: '" + rs.Key + "'");

                int i = 1;
                foreach (var s in rs)
                {
                    Trace.WriteLine("\t" + i + ". defined in " + s.Key.Assembly.FullName + " ");

                    i++;

                    //g.Services[s.Key] = s.Value + "_" + i;

                    //Trace.WriteLine("\t" + i + ". defined in " + s.Key.Assembly.FullName + ", rename to '" + s.Value + (i++) + "'");
                }
            }
        }
        
        public class TypeGraph : GenericGraph<TypeVertex, TypeEdge, TypeGraph>
        {
            public TypeGraph()
            {
                Services = new Dictionary<Type, string>();
                Types = new Dictionary<Type, TypeVertex>();
            }

            public Dictionary<Type, string> Services { get; set; }
            public Dictionary<Type, TypeVertex> Types { get; set; }
        }

        public class TypeVertex : GenericVertex<TypeVertex, TypeEdge, TypeGraph>
        {
            public TypeVertex(TypeGraph g, UInt64 id) :
                base(g, id)
            {
            }

            public Type Owner { get; set; }
        }

        public class TypeEdge : GenericEdge<TypeVertex, TypeEdge, TypeGraph>
        {
            public TypeEdge(TypeGraph graph, TypeVertex startVertex, TypeVertex endVertex)
                : base(graph, startVertex, endVertex)
            { }
        }

        private static bool IsDependentOfPrimitiveTypes(Type type)
        {
            if (type.IsSimpleType())
                return true;
            else if (type.IsGenericType)
            {
                foreach (var p in type.GetGenericArguments())
                {
                    if (!IsDependentOfPrimitiveTypes(p))
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        private static TypeGraph BuildTypeGraph(List<Assembly> asms)
        {
            TypeGraph g = new TypeGraph();
            var tobetracked = new Queue<Type>();

            // collect request/response types
            foreach (var type in asms.SelectMany(asm => asm.GetTypes()).Where(t => ServiceContract.IsTronService(t)))
            {
                g.Services.Add(type, type.Name);

                foreach (var m in ServiceContract.GetServiceCalls(type))
                {
                    var return_value_type = m.ReturnType.GetGenericArguments()[0];
                    var parameter_type = m.GetParameters()[0].ParameterType.GetGenericArguments()[0];

                    if (!IsDependentOfPrimitiveTypes(return_value_type) && !g.Types.ContainsKey(return_value_type))
                    {
                        tobetracked.Enqueue(return_value_type);
                        g.Types.Add(return_value_type, null);
                    }

                    if (!IsDependentOfPrimitiveTypes(parameter_type) && !g.Types.ContainsKey(parameter_type))
                    {
                        tobetracked.Enqueue(parameter_type);
                        g.Types.Add(parameter_type, null);
                    }
                }
            }

            while (tobetracked.Count > 0)
            {
                var t = tobetracked.Dequeue();
                foreach (var fld in t.GetFields())
                {
                    if (!IsDependentOfPrimitiveTypes(fld.FieldType) && !g.Types.ContainsKey(fld.FieldType))
                    {
                        if (fld.FieldType.IsGenericType)
                        {
                            foreach (var p in fld.FieldType.GetGenericArguments())
                            {
                                if (!IsDependentOfPrimitiveTypes(p) && !g.Types.ContainsKey(p))
                                {
                                    tobetracked.Enqueue(p);
                                    g.Types.Add(p, null);
                                }
                            }
                        }
                        else
                        {

                            tobetracked.Enqueue(fld.FieldType);
                            g.Types.Add(fld.FieldType, null);
                        }
                    }
                }
            }

            // create type vertices
            var ts = g.Types.Where(t0 => t0.Value == null).ToArray();
            foreach (var t in ts)
            {
                var v = g.CreateVertex(typeof(TypeVertex), (ulong)t.GetHashCode());
                v.Owner = t.Key;
                g.Types[t.Key] = v;
            }

            // create edges for type dependencies
            foreach (var t in g.Types)
            {
                var fv = g.Vertices.Where(v => v.Value.Owner == t.Key).First();

                foreach (var fld in t.Key.GetFields())
                {
                    if (!IsDependentOfPrimitiveTypes(fld.FieldType))
                    {
                        if (fld.FieldType.IsGenericType)
                        {
                            foreach (var p in fld.FieldType.GetGenericArguments())
                            {
                                if (!IsDependentOfPrimitiveTypes(p))
                                {
                                    var tv = g.Vertices.Where(v => v.Value.Owner == p).First();
                                    if (tv.Value.OutEdges.Where(e => e.EndVertex == fv.Value).Count() == 0)
                                        tv.Value.ConnectTo<TypeEdge>(fv.Value);
                                }
                            }
                        }
                        else
                        {

                            var tv = g.Vertices.Where(v => v.Value.Owner == fld.FieldType).First();
                            if (tv.Value.OutEdges.Where(e => e.EndVertex == fv.Value).Count() == 0)
                                tv.Value.ConnectTo<TypeEdge>(fv.Value);
                        }
                    }
                }
            }

            return g;
        }

    }
}
