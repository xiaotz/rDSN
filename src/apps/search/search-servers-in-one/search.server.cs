using System;
using System.IO;
using dsn.dev.csharp;

namespace dsn.app.search  
{
    public class IFEXServer : Serverlet<IFEXServer>
    {
        public IFEXServer() : base("IFEX") {}
        ~IFEXServer() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_IFEX_ONSEARCHQUERY 
        private void OnOnSearchQueryInternal(RpcReadStream request, RpcWriteStream response)
        {
            IFEX.OnSearchQuery_args Query;
            
            try 
            {
                request.Read(out Query);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnOnSearchQuery(Query, new RpcReplier<IFEX.OnSearchQuery_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnOnSearchQuery(IFEX.OnSearchQuery_args Query, RpcReplier<IFEX.OnSearchQuery_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_IFEX_ONSEARCHQUERY ... (not implemented) ");
            var resp =  new IFEX.OnSearchQuery_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_IFEX_ONSEARCHQUERY, "OnSearchQuery", this.OnOnSearchQueryInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_IFEX_ONSEARCHQUERY);
        }
    }

    public class ALTAServer : Serverlet<ALTAServer>
    {
        public ALTAServer() : base("ALTA") {}
        ~ALTAServer() { CloseService(); }
    
        // all service handlers to be implemented further
        
        public void OpenService()
        {
        }

        public void CloseService()
        {
        }
    }

    public class IsCacheServer : Serverlet<IsCacheServer>
    {
        public IsCacheServer() : base("IsCache") {}
        ~IsCacheServer() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_ISCACHE_GET 
        private void OnGetInternal(RpcReadStream request, RpcWriteStream response)
        {
            IsCache.Get_args Query;
            
            try 
            {
                request.Read(out Query);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnGet(Query, new RpcReplier<IsCache.Get_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnGet(IsCache.Get_args Query, RpcReplier<IsCache.Get_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_ISCACHE_GET ... (not implemented) ");
            var resp =  new IsCache.Get_result();
            replier.Reply(resp);
        }
        
        // RPC_SEARCH_ISCACHE_PUT 
        private void OnPutInternal(RpcReadStream request, RpcWriteStream response)
        {
            IsCache.Put_args Result;
            
            try 
            {
                request.Read(out Result);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnPut(Result, new RpcReplier<IsCache.Put_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnPut(IsCache.Put_args Result, RpcReplier<IsCache.Put_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_ISCACHE_PUT ... (not implemented) ");
            var resp =  new IsCache.Put_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_ISCACHE_GET, "Get", this.OnGetInternal);
            RegisterRpcHandler(searchHelper.RPC_SEARCH_ISCACHE_PUT, "Put", this.OnPutInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_ISCACHE_GET);
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_ISCACHE_PUT);
        }
    }

    public class QUServer : Serverlet<QUServer>
    {
        public QUServer() : base("QU") {}
        ~QUServer() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_QU_ONQUERYUNDERSTANDING 
        private void OnOnQueryUnderstandingInternal(RpcReadStream request, RpcWriteStream response)
        {
            QU.OnQueryUnderstanding_args Query;
            
            try 
            {
                request.Read(out Query);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnOnQueryUnderstanding(Query, new RpcReplier<QU.OnQueryUnderstanding_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnOnQueryUnderstanding(QU.OnQueryUnderstanding_args Query, RpcReplier<QU.OnQueryUnderstanding_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_QU_ONQUERYUNDERSTANDING ... (not implemented) ");
            var resp =  new QU.OnQueryUnderstanding_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_QU_ONQUERYUNDERSTANDING, "OnQueryUnderstanding", this.OnOnQueryUnderstandingInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_QU_ONQUERYUNDERSTANDING);
        }
    }

    public class QU2Server : Serverlet<QU2Server>
    {
        public QU2Server() : base("QU2") {}
        ~QU2Server() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_QU2_ONQUERYANNOTATION 
        private void OnOnQueryAnnotationInternal(RpcReadStream request, RpcWriteStream response)
        {
            QU2.OnQueryAnnotation_args Query;
            
            try 
            {
                request.Read(out Query);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnOnQueryAnnotation(Query, new RpcReplier<QU2.OnQueryAnnotation_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnOnQueryAnnotation(QU2.OnQueryAnnotation_args Query, RpcReplier<QU2.OnQueryAnnotation_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_QU2_ONQUERYANNOTATION ... (not implemented) ");
            var resp =  new QU2.OnQueryAnnotation_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_QU2_ONQUERYANNOTATION, "OnQueryAnnotation", this.OnOnQueryAnnotationInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_QU2_ONQUERYANNOTATION);
        }
    }

    public class TLAServer : Serverlet<TLAServer>
    {
        public TLAServer() : base("TLA") {}
        ~TLAServer() { CloseService(); }
    
        // all service handlers to be implemented further
        
        public void OpenService()
        {
        }

        public void CloseService()
        {
        }
    }

    public class WebCacheServer : Serverlet<WebCacheServer>
    {
        public WebCacheServer() : base("WebCache") {}
        ~WebCacheServer() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_WEBCACHE_GET 
        private void OnGetInternal(RpcReadStream request, RpcWriteStream response)
        {
            WebCache.Get_args Query;
            
            try 
            {
                request.Read(out Query);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnGet(Query, new RpcReplier<WebCache.Get_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnGet(WebCache.Get_args Query, RpcReplier<WebCache.Get_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_WEBCACHE_GET ... (not implemented) ");
            var resp =  new WebCache.Get_result();
            replier.Reply(resp);
        }
        
        // RPC_SEARCH_WEBCACHE_PUT 
        private void OnPutInternal(RpcReadStream request, RpcWriteStream response)
        {
            WebCache.Put_args Result;
            
            try 
            {
                request.Read(out Result);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnPut(Result, new RpcReplier<WebCache.Put_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnPut(WebCache.Put_args Result, RpcReplier<WebCache.Put_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_WEBCACHE_PUT ... (not implemented) ");
            var resp =  new WebCache.Put_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_WEBCACHE_GET, "Get", this.OnGetInternal);
            RegisterRpcHandler(searchHelper.RPC_SEARCH_WEBCACHE_PUT, "Put", this.OnPutInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_WEBCACHE_GET);
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_WEBCACHE_PUT);
        }
    }

    public class SaaSServer : Serverlet<SaaSServer>
    {
        public SaaSServer() : base("SaaS") {}
        ~SaaSServer() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_SAAS_ONL1SELECTION 
        private void OnOnL1SelectionInternal(RpcReadStream request, RpcWriteStream response)
        {
            SaaS.OnL1Selection_args Query;
            
            try 
            {
                request.Read(out Query);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnOnL1Selection(Query, new RpcReplier<SaaS.OnL1Selection_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnOnL1Selection(SaaS.OnL1Selection_args Query, RpcReplier<SaaS.OnL1Selection_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_SAAS_ONL1SELECTION ... (not implemented) ");
            var resp =  new SaaS.OnL1Selection_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_SAAS_ONL1SELECTION, "OnL1Selection", this.OnOnL1SelectionInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_SAAS_ONL1SELECTION);
        }
    }

    public class RaaSServer : Serverlet<RaaSServer>
    {
        public RaaSServer() : base("RaaS") {}
        ~RaaSServer() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_RAAS_ONL2RANK 
        private void OnOnL2RankInternal(RpcReadStream request, RpcWriteStream response)
        {
            RaaS.OnL2Rank_args Pos;
            
            try 
            {
                request.Read(out Pos);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnOnL2Rank(Pos, new RpcReplier<RaaS.OnL2Rank_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnOnL2Rank(RaaS.OnL2Rank_args Pos, RpcReplier<RaaS.OnL2Rank_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_RAAS_ONL2RANK ... (not implemented) ");
            var resp =  new RaaS.OnL2Rank_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_RAAS_ONL2RANK, "OnL2Rank", this.OnOnL2RankInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_RAAS_ONL2RANK);
        }
    }

    public class CDGServer : Serverlet<CDGServer>
    {
        public CDGServer() : base("CDG") {}
        ~CDGServer() { CloseService(); }
    
        // all service handlers to be implemented further
        // RPC_SEARCH_CDG_GET 
        private void OnGetInternal(RpcReadStream request, RpcWriteStream response)
        {
            CDG.Get_args Id;
            
            try 
            {
                request.Read(out Id);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnGet(Id, new RpcReplier<CDG.Get_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnGet(CDG.Get_args Id, RpcReplier<CDG.Get_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_CDG_GET ... (not implemented) ");
            var resp =  new CDG.Get_result();
            replier.Reply(resp);
        }
        
        // RPC_SEARCH_CDG_PUT 
        private void OnPutInternal(RpcReadStream request, RpcWriteStream response)
        {
            CDG.Put_args Caption;
            
            try 
            {
                request.Read(out Caption);
            } 
            catch (Exception e)
            {
                // TODO: error handling
                return;
            }
            
            OnPut(Caption, new RpcReplier<CDG.Put_result>(response, (s, r) => 
            {
                s.Write(r);
                s.Flush();
            }));
        }
        
        protected virtual void OnPut(CDG.Put_args Caption, RpcReplier<CDG.Put_result> replier)
        {
            Console.WriteLine("... exec RPC_SEARCH_CDG_PUT ... (not implemented) ");
            var resp =  new CDG.Put_result();
            replier.Reply(resp);
        }
        
        
        public void OpenService()
        {
            RegisterRpcHandler(searchHelper.RPC_SEARCH_CDG_GET, "Get", this.OnGetInternal);
            RegisterRpcHandler(searchHelper.RPC_SEARCH_CDG_PUT, "Put", this.OnPutInternal);
        }

        public void CloseService()
        {
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_CDG_GET);
            UnregisterRpcHandler(searchHelper.RPC_SEARCH_CDG_PUT);
        }
    }


} // end namespace
