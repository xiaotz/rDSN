using System;
using System.IO;
using dsn.dev.csharp;

namespace dsn.app.search 
{
    // server app example
    public class searchServerApp : ServiceApp
    {
        public override ErrorCode Start(string[] args)
        {
            _IFEXServer.OpenService();
            _ALTAServer.OpenService();
            _IsCacheServer.OpenService();
            _QUServer.OpenService();
            _QU2Server.OpenService();
            _TLAServer.OpenService();
            _WebCacheServer.OpenService();
            _SaaSServer.OpenService();
            _RaaSServer.OpenService();
            _CDGServer.OpenService();
            return ErrorCode.ERR_OK;
        }

        public override void Stop(bool cleanup = false)
        {
            _IFEXServer.CloseService();
            _IFEXServer.Dispose();
            _ALTAServer.CloseService();
            _ALTAServer.Dispose();
            _IsCacheServer.CloseService();
            _IsCacheServer.Dispose();
            _QUServer.CloseService();
            _QUServer.Dispose();
            _QU2Server.CloseService();
            _QU2Server.Dispose();
            _TLAServer.CloseService();
            _TLAServer.Dispose();
            _WebCacheServer.CloseService();
            _WebCacheServer.Dispose();
            _SaaSServer.CloseService();
            _SaaSServer.Dispose();
            _RaaSServer.CloseService();
            _RaaSServer.Dispose();
            _CDGServer.CloseService();
            _CDGServer.Dispose();
        }

        private IFEXServer _IFEXServer = new IFEXServer();
        private ALTAServer _ALTAServer = new ALTAServer();
        private IsCacheServer _IsCacheServer = new IsCacheServer();
        private QUServer _QUServer = new QUServer();
        private QU2Server _QU2Server = new QU2Server();
        private TLAServer _TLAServer = new TLAServer();
        private WebCacheServer _WebCacheServer = new WebCacheServer();
        private SaaSServer _SaaSServer = new SaaSServer();
        private RaaSServer _RaaSServer = new RaaSServer();
        private CDGServer _CDGServer = new CDGServer();
    }

    // client app example
    public class searchClientApp : ServiceApp
    {
        public override ErrorCode Start(string[] args)
        {
            if (args.Length < 2)
            {
                throw new Exception("wrong usage: server-url or server-host server-port");                
            }

            if (args.Length == 2)
            {
                _server = new RpcAddress(args[1]);
            }
            else
            {
                _server = new RpcAddress(args[1], ushort.Parse(args[2]));
            }

            _IFEXClient = new IFEXClient(_server);
            _ALTAClient = new ALTAClient(_server);
            _IsCacheClient = new IsCacheClient(_server);
            _QUClient = new QUClient(_server);
            _QU2Client = new QU2Client(_server);
            _TLAClient = new TLAClient(_server);
            _WebCacheClient = new WebCacheClient(_server);
            _SaaSClient = new SaaSClient(_server);
            _RaaSClient = new RaaSClient(_server);
            _CDGClient = new CDGClient(_server);
            _timer = Clientlet.CallAsync2(searchHelper.LPC_SEARCH_TEST_TIMER, null, this.OnTestTimer, 0, 0, 1000);
            return ErrorCode.ERR_OK;
        }

        public override void Stop(bool cleanup = false)
        {
            _timer.Cancel(true);
            _IFEXClient.Dispose();
            _IFEXClient = null;
            _ALTAClient.Dispose();
            _ALTAClient = null;
            _IsCacheClient.Dispose();
            _IsCacheClient = null;
            _QUClient.Dispose();
            _QUClient = null;
            _QU2Client.Dispose();
            _QU2Client = null;
            _TLAClient.Dispose();
            _TLAClient = null;
            _WebCacheClient.Dispose();
            _WebCacheClient = null;
            _SaaSClient.Dispose();
            _SaaSClient = null;
            _RaaSClient.Dispose();
            _RaaSClient = null;
            _CDGClient.Dispose();
            _CDGClient = null;
        }

        private void OnTestTimer()
        {
            // test for service 'IFEX'
            {
                IFEX.OnSearchQuery_args req = new IFEX.OnSearchQuery_args();
                //sync:
                IFEX.OnSearchQuery_result resp;
                var err = _IFEXClient.OnSearchQuery(req, out resp);
                Console.WriteLine("call RPC_SEARCH_IFEX_ONSEARCHQUERY end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            // test for service 'ALTA'
            // test for service 'IsCache'
            {
                IsCache.Get_args req = new IsCache.Get_args();
                //sync:
                IsCache.Get_result resp;
                var err = _IsCacheClient.Get(req, out resp);
                Console.WriteLine("call RPC_SEARCH_ISCACHE_GET end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            {
                IsCache.Put_args req = new IsCache.Put_args();
                //sync:
                IsCache.Put_result resp;
                var err = _IsCacheClient.Put(req, out resp);
                Console.WriteLine("call RPC_SEARCH_ISCACHE_PUT end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            // test for service 'QU'
            {
                QU.OnQueryUnderstanding_args req = new QU.OnQueryUnderstanding_args();
                //sync:
                QU.OnQueryUnderstanding_result resp;
                var err = _QUClient.OnQueryUnderstanding(req, out resp);
                Console.WriteLine("call RPC_SEARCH_QU_ONQUERYUNDERSTANDING end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            // test for service 'QU2'
            {
                QU2.OnQueryAnnotation_args req = new QU2.OnQueryAnnotation_args();
                //sync:
                QU2.OnQueryAnnotation_result resp;
                var err = _QU2Client.OnQueryAnnotation(req, out resp);
                Console.WriteLine("call RPC_SEARCH_QU2_ONQUERYANNOTATION end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            // test for service 'TLA'
            // test for service 'WebCache'
            {
                WebCache.Get_args req = new WebCache.Get_args();
                //sync:
                WebCache.Get_result resp;
                var err = _WebCacheClient.Get(req, out resp);
                Console.WriteLine("call RPC_SEARCH_WEBCACHE_GET end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            {
                WebCache.Put_args req = new WebCache.Put_args();
                //sync:
                WebCache.Put_result resp;
                var err = _WebCacheClient.Put(req, out resp);
                Console.WriteLine("call RPC_SEARCH_WEBCACHE_PUT end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            // test for service 'SaaS'
            {
                SaaS.OnL1Selection_args req = new SaaS.OnL1Selection_args();
                //sync:
                SaaS.OnL1Selection_result resp;
                var err = _SaaSClient.OnL1Selection(req, out resp);
                Console.WriteLine("call RPC_SEARCH_SAAS_ONL1SELECTION end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            // test for service 'RaaS'
            {
                RaaS.OnL2Rank_args req = new RaaS.OnL2Rank_args();
                //sync:
                RaaS.OnL2Rank_result resp;
                var err = _RaaSClient.OnL2Rank(req, out resp);
                Console.WriteLine("call RPC_SEARCH_RAAS_ONL2RANK end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            // test for service 'CDG'
            {
                CDG.Get_args req = new CDG.Get_args();
                //sync:
                CDG.Get_result resp;
                var err = _CDGClient.Get(req, out resp);
                Console.WriteLine("call RPC_SEARCH_CDG_GET end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
            {
                CDG.Put_args req = new CDG.Put_args();
                //sync:
                CDG.Put_result resp;
                var err = _CDGClient.Put(req, out resp);
                Console.WriteLine("call RPC_SEARCH_CDG_PUT end, return " + err.ToString());
                //async: 
                // TODO:
           
            }
        }

        private SafeTaskHandle _timer;
        private RpcAddress  _server = new RpcAddress();
        
        private IFEXClient _IFEXClient;
        private ALTAClient _ALTAClient;
        private IsCacheClient _IsCacheClient;
        private QUClient _QUClient;
        private QU2Client _QU2Client;
        private TLAClient _TLAClient;
        private WebCacheClient _WebCacheClient;
        private SaaSClient _SaaSClient;
        private RaaSClient _RaaSClient;
        private CDGClient _CDGClient;
    }

    /*
    class IFEX_perf_testClientApp :
        public ::dsn::service_app<IFEX_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        IFEX_perf_testClientApp()
        {
            _IFEXClient= null;
        }

        ~IFEX_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _IFEXClient= new IFEX_perf_testClient(_server);
            _IFEXClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_IFEXClient!= null)
            {
                delete _IFEXClient;
                _IFEXClient= null;
            }
        }
        
    private:
        IFEX_perf_testClient*_IFEXClient;
        RpcAddress _server;
    }
    class ALTA_perf_testClientApp :
        public ::dsn::service_app<ALTA_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        ALTA_perf_testClientApp()
        {
            _ALTAClient= null;
        }

        ~ALTA_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _ALTAClient= new ALTA_perf_testClient(_server);
            _ALTAClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_ALTAClient!= null)
            {
                delete _ALTAClient;
                _ALTAClient= null;
            }
        }
        
    private:
        ALTA_perf_testClient*_ALTAClient;
        RpcAddress _server;
    }
    class IsCache_perf_testClientApp :
        public ::dsn::service_app<IsCache_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        IsCache_perf_testClientApp()
        {
            _IsCacheClient= null;
        }

        ~IsCache_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _IsCacheClient= new IsCache_perf_testClient(_server);
            _IsCacheClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_IsCacheClient!= null)
            {
                delete _IsCacheClient;
                _IsCacheClient= null;
            }
        }
        
    private:
        IsCache_perf_testClient*_IsCacheClient;
        RpcAddress _server;
    }
    class QU_perf_testClientApp :
        public ::dsn::service_app<QU_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        QU_perf_testClientApp()
        {
            _QUClient= null;
        }

        ~QU_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _QUClient= new QU_perf_testClient(_server);
            _QUClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_QUClient!= null)
            {
                delete _QUClient;
                _QUClient= null;
            }
        }
        
    private:
        QU_perf_testClient*_QUClient;
        RpcAddress _server;
    }
    class QU2_perf_testClientApp :
        public ::dsn::service_app<QU2_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        QU2_perf_testClientApp()
        {
            _QU2Client= null;
        }

        ~QU2_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _QU2Client= new QU2_perf_testClient(_server);
            _QU2Client->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_QU2Client!= null)
            {
                delete _QU2Client;
                _QU2Client= null;
            }
        }
        
    private:
        QU2_perf_testClient*_QU2Client;
        RpcAddress _server;
    }
    class TLA_perf_testClientApp :
        public ::dsn::service_app<TLA_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        TLA_perf_testClientApp()
        {
            _TLAClient= null;
        }

        ~TLA_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _TLAClient= new TLA_perf_testClient(_server);
            _TLAClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_TLAClient!= null)
            {
                delete _TLAClient;
                _TLAClient= null;
            }
        }
        
    private:
        TLA_perf_testClient*_TLAClient;
        RpcAddress _server;
    }
    class WebCache_perf_testClientApp :
        public ::dsn::service_app<WebCache_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        WebCache_perf_testClientApp()
        {
            _WebCacheClient= null;
        }

        ~WebCache_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _WebCacheClient= new WebCache_perf_testClient(_server);
            _WebCacheClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_WebCacheClient!= null)
            {
                delete _WebCacheClient;
                _WebCacheClient= null;
            }
        }
        
    private:
        WebCache_perf_testClient*_WebCacheClient;
        RpcAddress _server;
    }
    class SaaS_perf_testClientApp :
        public ::dsn::service_app<SaaS_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        SaaS_perf_testClientApp()
        {
            _SaaSClient= null;
        }

        ~SaaS_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _SaaSClient= new SaaS_perf_testClient(_server);
            _SaaSClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_SaaSClient!= null)
            {
                delete _SaaSClient;
                _SaaSClient= null;
            }
        }
        
    private:
        SaaS_perf_testClient*_SaaSClient;
        RpcAddress _server;
    }
    class RaaS_perf_testClientApp :
        public ::dsn::service_app<RaaS_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        RaaS_perf_testClientApp()
        {
            _RaaSClient= null;
        }

        ~RaaS_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _RaaSClient= new RaaS_perf_testClient(_server);
            _RaaSClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_RaaSClient!= null)
            {
                delete _RaaSClient;
                _RaaSClient= null;
            }
        }
        
    private:
        RaaS_perf_testClient*_RaaSClient;
        RpcAddress _server;
    }
    class CDG_perf_testClientApp :
        public ::dsn::service_app<CDG_perf_testClientApp>, 
        public virtual ::dsn::service::clientlet
    {
    public:
        CDG_perf_testClientApp()
        {
            _CDGClient= null;
        }

        ~CDG_perf_testClientApp()
        {
            stop();
        }

        virtual ErrorCode start(int argc, char** argv)
        {
            if (argc < 2)
                return ErrorCode.ERR_INVALID_PARAMETERS;

            dsn_address_build(_server.c_addr_ptr(), argv[1], (uint16_t)atoi(argv[2]));

            _CDGClient= new CDG_perf_testClient(_server);
            _CDGClient->start_test();
            return ErrorCode.ERR_OK;
        }

        virtual void stop(bool cleanup = false)
        {
            if (_CDGClient!= null)
            {
                delete _CDGClient;
                _CDGClient= null;
            }
        }
        
    private:
        CDG_perf_testClient*_CDGClient;
        RpcAddress _server;
    }
    */
} // end namespace
