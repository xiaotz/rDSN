using System;
using System.IO;
using System.Linq;
using dsn.dev.csharp;

namespace dsn.app.search 
{
    class Program
    {
        static void Main(string[] args)
        {
            searchHelper.InitCodes();

            ServiceApp.RegisterApp<searchServerApp>("server");
            ServiceApp.RegisterApp<searchClientApp>("client");        
            // ServiceApp.RegisterApp<IFEXPerfTestClientApp>("client.IFEX.perf.test");
            // ServiceApp.RegisterApp<ALTAPerfTestClientApp>("client.ALTA.perf.test");
            // ServiceApp.RegisterApp<IsCachePerfTestClientApp>("client.IsCache.perf.test");
            // ServiceApp.RegisterApp<QUPerfTestClientApp>("client.QU.perf.test");
            // ServiceApp.RegisterApp<QU2PerfTestClientApp>("client.QU2.perf.test");
            // ServiceApp.RegisterApp<TLAPerfTestClientApp>("client.TLA.perf.test");
            // ServiceApp.RegisterApp<WebCachePerfTestClientApp>("client.WebCache.perf.test");
            // ServiceApp.RegisterApp<SaaSPerfTestClientApp>("client.SaaS.perf.test");
            // ServiceApp.RegisterApp<RaaSPerfTestClientApp>("client.RaaS.perf.test");
            // ServiceApp.RegisterApp<CDGPerfTestClientApp>("client.CDG.perf.test");

            string[] args2 = (new string[] { "search" }).Union(args).ToArray();
            Native.dsn_run(args2.Length, args2, true);
        }
    }
}
