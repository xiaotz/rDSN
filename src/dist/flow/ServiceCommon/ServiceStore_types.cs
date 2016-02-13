



//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
// 
//     Tool     : bondc, Version=3.0.1, Build=bond-git.retail.not
//     Template : Microsoft.Bond.Rules.dll#Rules_Bond_CSharp.tt
//     File     : ServiceStore_types.cs
//
//     Changes to this file may cause incorrect behavior and will be lost when
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using global::Microsoft.Bond;
using global::System;
using global::System.Collections;
using global::System.Collections.Generic;
using global::System.Text;

namespace rDSN
{
namespace Tron
{

/// <summary>
/// ServiceList
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("bondc.exe", null)]
public partial class ServiceList : IBondSerializable, IGenericSerializer
{
    //
    // Fields
    //

    // 1: Optional vector<rDSN.Tron.ServiceDsptr> Services
    private List<global::rDSN.Tron.ServiceDsptr> m_Services;

    /// <summary>
    /// Services
    /// </summary>
    public List<global::rDSN.Tron.ServiceDsptr> Services
    {
        get { return this.m_Services; }
        set { this.m_Services = value; }
    }

    public static string GetFullyQualifiedName()
    {
        return __internal.sc_structQualifiedName;
    }

    /// <summary>
    /// Meta schema.
    /// </summary>
    private static class Schema
    {
        public static readonly Metadata meta = new Metadata();
        public static readonly Metadata Services_meta = new Metadata();

        static Schema()
        {
            StringBuilder runtimeName = new StringBuilder();
            runtimeName.Append("ServiceList");
 
            meta.name = runtimeName.ToString();
            meta.qualified_name = "rDSN.Tron." + meta.name;


            // Services
            Services_meta.name = "Services";
            Services_meta.modifier = global::Microsoft.Bond.Modifier.Optional;
        }   // ~static Schema()

    }   // ~Schema


    private static class __ordinals
    {
        public const int Services = 1;
    }   // ~__ordinals


    private static class __internal
    {

        public static readonly String sc_structName = Schema.meta.name;
        public static readonly String sc_structQualifiedName = Schema.meta.qualified_name;

        public const String s_Services = "Services";
    }   // ~__internal

    // Constructor
    public ServiceList()
    {
        Reset();
    }

    /// <summary>
    /// Reset instance and re-initialize the members.
    /// </summary>
    public virtual void Reset()
    {
        Reset(__internal.sc_structName, __internal.sc_structQualifiedName);
    }

    protected  void Reset(string name, string qualifiedName)
    {
        
        ResetImpl(name, qualifiedName);
    }

    private void ResetImpl(string name, string qualifiedName)
    {
        if (m_Services == null)
        {
            m_Services = new List<global::rDSN.Tron.ServiceDsptr>();
        }
        else
        {
            m_Services.Clear();
        }
    } // ResetImpl()

    public virtual IBondSerializable Clone()
    {
        global::rDSN.Tron.ServiceList cloned = new global::rDSN.Tron.ServiceList();
        CopyTo(cloned);
        return cloned;
    }

    public void CopyTo(global::rDSN.Tron.ServiceList that)
    {
        if (that == null)
        {
            throw new  ArgumentNullException("that");
        }
        
        // 1: vector<rDSN.Tron.ServiceDsptr> Services
        if (this.Services != null)
        {
            if (that.Services == null)
            {
                that.Services = new List<global::rDSN.Tron.ServiceDsptr>();
            }
            else
            {
                that.Services.Clear();
            }
            foreach (var iter1 in this.Services)
            {
                global::rDSN.Tron.ServiceDsptr tmpItem2 = default(global::rDSN.Tron.ServiceDsptr);
                tmpItem2 = (iter1 == null ? null : (global::rDSN.Tron.ServiceDsptr)iter1.Clone());
                that.Services.Add(tmpItem2);
            }
        }
        else
        {
            that.Services = null;
        }
    }    // ~CopyTo


    public virtual void Unmarshal(System.IO.Stream input)
    {
        global::Microsoft.Bond.Marshaler.Unmarshal(input, this);
    }

    public virtual void Unmarshal(System.IO.Stream input, IBondSerializable schema)
    {
        global::Microsoft.Bond.Marshaler.Unmarshal(input, schema as SchemaDef, this);
    }

    public virtual void Read(global::Microsoft.Bond.IProtocolReader reader)
    {
        if (!reader.HasCapability(global::Microsoft.Bond.Protocol.Tagged))
        {
            ReadUntagged(reader);
        }
        else
        {
            bool isPartialStruct;

            if (reader.HasCapability((global::Microsoft.Bond.Protocol)global::Microsoft.Bond.ProtocolInternal.CloneableBonded))
            {
                reader = reader.Clone();
            }
            
            Read(reader, out isPartialStruct);
            
            if (isPartialStruct)
            {
                global::Microsoft.Bond.ReadHelper.SkipPartialStruct(reader);
            }
        }
    }

    public virtual void Read(global::Microsoft.Bond.IProtocolReader reader, IBondSerializable schema)
    {
        Read(ProtocolHelper.CreateReader(reader, schema));
    }

    protected  void ReadUntagged(global::Microsoft.Bond.IProtocolReader reader)
    {
        bool canOmitFields = reader.HasCapability(global::Microsoft.Bond.Protocol.CanOmitFields);
        Reset();
        

        reader.ReadStructBegin();

        if (!canOmitFields || !reader.ReadFieldOmitted())
        {
            this.ReadField_impl_Services(reader, global::Microsoft.Bond.BondDataType.BT_LIST);
        }
        reader.ReadStructEnd();
    }   // ~ReadUntagged()


    protected  void Read(global::Microsoft.Bond.IProtocolReader reader, out bool isPartialStruct)
    {
        Reset();

        reader.ReadStructBegin(true);
        
        while (true)
        {
            BondDataType type = BondDataType.BT_STOP;
            UInt16 id = UInt16.MaxValue;

            reader.ReadFieldBegin(out type, out id);

            if (type == BondDataType.BT_STOP || type == BondDataType.BT_STOP_BASE)
            {
                isPartialStruct = (type == BondDataType.BT_STOP_BASE);
                break;
            }

            switch (id)
            {
                case __ordinals.Services:  // id=1
                    this.ReadField_impl_Services(reader, type);
                    break;
                default:
                    reader.Skip(type);
                    break;
            } // ~switch

            reader.ReadFieldEnd();

        } // ~while

        reader.ReadStructEnd();

    }   // ~Read()


    private void ReadField_impl_Services(global::Microsoft.Bond.IProtocolReader reader, global::Microsoft.Bond.BondDataType typeInPayload)
    {
        global::Microsoft.Bond.ReadHelper.ValidateType(typeInPayload, global::Microsoft.Bond.BondDataType.BT_LIST);
 
        BondDataType elemType1;
        UInt32 count2;
    
        reader.ReadContainerBegin(out count2, out elemType1);
        global::Microsoft.Bond.ReadHelper.ValidateType(elemType1, global::Microsoft.Bond.BondDataType.BT_STRUCT);
        if (this.m_Services.Capacity < count2)
        {
            this.m_Services.Capacity = (int)count2;
        }
    
        for (UInt32 i4 = 0; i4 < count2; i4++)
        {
            global::rDSN.Tron.ServiceDsptr element3 = new global::rDSN.Tron.ServiceDsptr();
             
            ReadHelper.ReadStruct(reader, element3, elemType1);
            this.m_Services.Add(element3);
        }
    
        reader.ReadContainerEnd();
    } // ReadField_impl_Services


    virtual public void Marshal(IProtocolWriter writer)
    {
        global::Microsoft.Bond.Marshaler.Marshal(this, writer);
    }

    virtual public void Write(global::Microsoft.Bond.IProtocolWriter writer)
    {
        Write(writer, true);
    }

    public void Write(global::Microsoft.Bond.IProtocolWriter writer, bool isTopLevel)
    {
        global::Microsoft.Bond.IProtocolWriter pass0; 
        
        if (isTopLevel && (pass0 = writer.GetPass0Writer()) != null)
        {
            WriteInternal(pass0, isTopLevel);
            WriteInternal(writer, isTopLevel);
            writer.EndDoublePass();
        }
        else
        {
            WriteInternal(writer, isTopLevel);
        }
    }   // ~Write()

    virtual public void Write(global::Microsoft.Bond.IProtocolWriter writer, System.Type type)
    {
        if (type == typeof(ServiceList))
        {
            Write(writer, true);
        }
    }

    protected void WriteInternal(global::Microsoft.Bond.IProtocolWriter writer, bool isTopLevel)
    {
	                

        bool writeAllFields = !writer.MayOmitFields;

        writer.WriteStructBegin(Schema.meta, !isTopLevel, true);

        UInt32 count1 = ((UInt32)m_Services.Count);
        if (writeAllFields || count1 != 0)
        {
            writer.WriteFieldBegin(global::Microsoft.Bond.BondDataType.BT_LIST, __ordinals.Services, Schema.Services_meta);
                writer.WriteContainerBegin(count1, global::Microsoft.Bond.BondDataType.BT_STRUCT);
            for (int idx2 = 0; idx2 < count1; idx2++)
            {
                    m_Services[idx2].Write(writer, true);
            }
            writer.WriteContainerEnd();
            writer.WriteFieldEnd();
        }
        else
        {
            writer.WriteFieldOmitted(global::Microsoft.Bond.BondDataType.BT_LIST, __ordinals.Services, Schema.Services_meta);
        }

        writer.WriteStructEnd(!isTopLevel);
    }   // ~Write()

    private static volatile global::Microsoft.Bond.SchemaDef __schema;

    public virtual IBondSerializable GetSchema()
    {
        return GetRuntimeSchema();
    }

    static public global::Microsoft.Bond.SchemaDef GetRuntimeSchema()
    {
        if (__schema == null)
        {
            var schema = new global::Microsoft.Bond.SchemaDef();
            schema.root = GetTypeDef(schema);
            __schema = schema;
        }
        return __schema;
    }

    static public global::Microsoft.Bond.TypeDef GetTypeDef(global::Microsoft.Bond.SchemaDef schema)
    {
        global::Microsoft.Bond.TypeDef type = new global::Microsoft.Bond.TypeDef();
        type.id = global::Microsoft.Bond.BondDataType.BT_STRUCT;
        type.struct_def = GetStructDef(schema);
        return type;
    }

    static protected UInt16 GetStructDef(global::Microsoft.Bond.SchemaDef schema)
    {
        UInt16 pos;

        for(pos = 0; pos < schema.structs.Count; pos++)
        {
            if (schema.structs[pos].metadata.qualified_name == __internal.sc_structQualifiedName)
            {
                return pos;
            }
        }
        // pos == schema.structs.Count

        global::Microsoft.Bond.StructDef structDef = new global::Microsoft.Bond.StructDef();
        structDef.metadata.name = __internal.sc_structName;
        structDef.metadata.qualified_name = __internal.sc_structQualifiedName;
        schema.structs.Add(structDef);

        global::Microsoft.Bond.FieldDef field;


        field = new global::Microsoft.Bond.FieldDef();
        field.id = 1;
        field.metadata.name="Services";
        field.metadata.modifier = global::Microsoft.Bond.Modifier.Optional;
        field.metadata.default_value.nothing = false;

        field.type.id = global::Microsoft.Bond.BondDataType.BT_LIST;
        field.type.element = new global::Microsoft.Bond.TypeDef();
        field.type.element = global::rDSN.Tron.ServiceDsptr.GetTypeDef(schema);

        structDef.fields.Add(field);

        return pos;
    }
 
    public virtual bool MemberwiseCompare(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        
        ServiceList that = obj as ServiceList;
        if (that == null)
        {
            return false;
        }
        
        return this.MemberwiseCompare(that);
    }
    
    public bool MemberwiseCompare(ServiceList other)
    {
        if (!MemberwiseCompareQuick(other))
        {
            return false;
        }
        
        return MemberwiseCompareDeep(other);
    }
    

    protected bool MemberwiseCompareQuick(ServiceList that)
    {
        bool equals = true;
        
        equals = equals && ((this.Services == null) == (that.Services == null));
        equals = equals && ((this.Services == null) ? true : (this.Services.Count == that.Services.Count));
        return equals;
    }    // ~MemberwiseCompareQuick
    
    protected bool MemberwiseCompareDeep(ServiceList that)
    {
        bool equals = true;
        
        if (equals && this.Services != null && this.Services.Count != 0)
        {
            var enum_1_1 = this.Services.GetEnumerator();
            var enum_2_2 = that.Services.GetEnumerator();
            while (enum_1_1.MoveNext() && enum_2_2.MoveNext())
            {
                    equals = equals && ((enum_1_1.Current == null) == (enum_2_2.Current == null));
                equals = equals && (enum_1_1.Current == null ? true : enum_1_1.Current.MemberwiseCompare(enum_2_2.Current));
                if (!equals)
                {
                    break;
                }
            }
        }
        return equals;
    }    // ~MemberwiseCompareDeep
    
    public override string ToString()
    {
        return ToString(false, '\n');
    }

    public  string ToString(bool valuesOnly, char separator)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
   
        if (!valuesOnly)
        {
            sb.AppendFormat("{0}{1}{2}{1}", base.ToString(), separator, __internal.sc_structName);
        }
        
        string format = valuesOnly ? "{1}{2}" : "{0} = {1}{2}";
        sb.AppendFormat(format, __internal.s_Services, DumpList(this.Services), separator);
        
        return sb.ToString();
    } // ToString()

    private string DumpList<T_DumpList_Type>(IEnumerable<T_DumpList_Type> list)
    {
        if (list == null)
        {
            return "-";
        }
        
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        
        bool isFirst = true;
        foreach (var item in list)
        {
            if (!isFirst)
            {
                sb.Append(';');
            }
            
            sb.Append(item.ToString());
            isFirst = false;
        }
        
        return sb.ToString();
    }
}; // class ServiceList
} // namespace Tron
} // namespace rDSN