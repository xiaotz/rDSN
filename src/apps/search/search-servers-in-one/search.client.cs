using System;
using System.IO;
using dsn.dev.csharp;

namespace dsn.app.search 
{
    public class IFEXClient : Clientlet
    {
        private RpcAddress _server;
        
        public IFEXClient(RpcAddress server) { _server = server; }
        public IFEXClient() { }
        ~IFEXClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(IFEX.OnSearchQuery_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_IFEX_ONSEARCHQUERY ------------
        // - synchronous 
        public ErrorCode OnSearchQuery(
            IFEX.OnSearchQuery_args Query,
            out IFEX.OnSearchQuery_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_IFEX_ONSEARCHQUERY, timeout_milliseconds, hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(IFEX.OnSearchQuery_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack IFEX.OnSearchQuery_args and IFEX.OnSearchQuery_result 
        public delegate void OnSearchQueryCallback(ErrorCode err, IFEX.OnSearchQuery_result resp);
        public void OnSearchQuery(
            IFEX.OnSearchQuery_args Query,
            OnSearchQueryCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_IFEX_ONSEARCHQUERY,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                IFEX.OnSearchQuery_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle OnSearchQuery2(
            IFEX.OnSearchQuery_args Query,
            OnSearchQueryCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_IFEX_ONSEARCHQUERY,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                IFEX.OnSearchQuery_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

    public class ALTAClient : Clientlet
    {
        private RpcAddress _server;
        
        public ALTAClient(RpcAddress server) { _server = server; }
        public ALTAClient() { }
        ~ALTAClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!

        
    }

    public class IsCacheClient : Clientlet
    {
        private RpcAddress _server;
        
        public IsCacheClient(RpcAddress server) { _server = server; }
        public IsCacheClient() { }
        ~IsCacheClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(IsCache.Get_args key) { return 0; }
    public virtual UInt64 GetPartitionHash(IsCache.Put_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_ISCACHE_GET ------------
        // - synchronous 
        public ErrorCode Get(
            IsCache.Get_args Query,
            out IsCache.Get_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_ISCACHE_GET, timeout_milliseconds, hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(IsCache.Get_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack IsCache.Get_args and IsCache.Get_result 
        public delegate void GetCallback(ErrorCode err, IsCache.Get_result resp);
        public void Get(
            IsCache.Get_args Query,
            GetCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_ISCACHE_GET,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                IsCache.Get_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle Get2(
            IsCache.Get_args Query,
            GetCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_ISCACHE_GET,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                IsCache.Get_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       

        // ---------- call searchHelper.RPC_SEARCH_ISCACHE_PUT ------------
        // - synchronous 
        public ErrorCode Put(
            IsCache.Put_args Result,
            out IsCache.Put_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_ISCACHE_PUT, timeout_milliseconds, hash, GetPartitionHash(Result));
            s.Write(Result);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(IsCache.Put_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack IsCache.Put_args and IsCache.Put_result 
        public delegate void PutCallback(ErrorCode err, IsCache.Put_result resp);
        public void Put(
            IsCache.Put_args Result,
            PutCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_ISCACHE_PUT,timeout_milliseconds, request_hash, GetPartitionHash(Result));
            s.Write(Result);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                IsCache.Put_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle Put2(
            IsCache.Put_args Result,
            PutCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_ISCACHE_PUT,timeout_milliseconds, request_hash, GetPartitionHash(Result));
            s.Write(Result);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                IsCache.Put_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

    public class QUClient : Clientlet
    {
        private RpcAddress _server;
        
        public QUClient(RpcAddress server) { _server = server; }
        public QUClient() { }
        ~QUClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(QU.OnQueryUnderstanding_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_QU_ONQUERYUNDERSTANDING ------------
        // - synchronous 
        public ErrorCode OnQueryUnderstanding(
            QU.OnQueryUnderstanding_args Query,
            out QU.OnQueryUnderstanding_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_QU_ONQUERYUNDERSTANDING, timeout_milliseconds, hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(QU.OnQueryUnderstanding_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack QU.OnQueryUnderstanding_args and QU.OnQueryUnderstanding_result 
        public delegate void OnQueryUnderstandingCallback(ErrorCode err, QU.OnQueryUnderstanding_result resp);
        public void OnQueryUnderstanding(
            QU.OnQueryUnderstanding_args Query,
            OnQueryUnderstandingCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_QU_ONQUERYUNDERSTANDING,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                QU.OnQueryUnderstanding_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle OnQueryUnderstanding2(
            QU.OnQueryUnderstanding_args Query,
            OnQueryUnderstandingCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_QU_ONQUERYUNDERSTANDING,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                QU.OnQueryUnderstanding_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

    public class QU2Client : Clientlet
    {
        private RpcAddress _server;
        
        public QU2Client(RpcAddress server) { _server = server; }
        public QU2Client() { }
        ~QU2Client() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(QU2.OnQueryAnnotation_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_QU2_ONQUERYANNOTATION ------------
        // - synchronous 
        public ErrorCode OnQueryAnnotation(
            QU2.OnQueryAnnotation_args Query,
            out QU2.OnQueryAnnotation_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_QU2_ONQUERYANNOTATION, timeout_milliseconds, hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(QU2.OnQueryAnnotation_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack QU2.OnQueryAnnotation_args and QU2.OnQueryAnnotation_result 
        public delegate void OnQueryAnnotationCallback(ErrorCode err, QU2.OnQueryAnnotation_result resp);
        public void OnQueryAnnotation(
            QU2.OnQueryAnnotation_args Query,
            OnQueryAnnotationCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_QU2_ONQUERYANNOTATION,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                QU2.OnQueryAnnotation_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle OnQueryAnnotation2(
            QU2.OnQueryAnnotation_args Query,
            OnQueryAnnotationCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_QU2_ONQUERYANNOTATION,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                QU2.OnQueryAnnotation_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

    public class TLAClient : Clientlet
    {
        private RpcAddress _server;
        
        public TLAClient(RpcAddress server) { _server = server; }
        public TLAClient() { }
        ~TLAClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!

        
    }

    public class WebCacheClient : Clientlet
    {
        private RpcAddress _server;
        
        public WebCacheClient(RpcAddress server) { _server = server; }
        public WebCacheClient() { }
        ~WebCacheClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(WebCache.Get_args key) { return 0; }
    public virtual UInt64 GetPartitionHash(WebCache.Put_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_WEBCACHE_GET ------------
        // - synchronous 
        public ErrorCode Get(
            WebCache.Get_args Query,
            out WebCache.Get_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_WEBCACHE_GET, timeout_milliseconds, hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(WebCache.Get_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack WebCache.Get_args and WebCache.Get_result 
        public delegate void GetCallback(ErrorCode err, WebCache.Get_result resp);
        public void Get(
            WebCache.Get_args Query,
            GetCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_WEBCACHE_GET,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                WebCache.Get_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle Get2(
            WebCache.Get_args Query,
            GetCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_WEBCACHE_GET,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                WebCache.Get_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       

        // ---------- call searchHelper.RPC_SEARCH_WEBCACHE_PUT ------------
        // - synchronous 
        public ErrorCode Put(
            WebCache.Put_args Result,
            out WebCache.Put_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_WEBCACHE_PUT, timeout_milliseconds, hash, GetPartitionHash(Result));
            s.Write(Result);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(WebCache.Put_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack WebCache.Put_args and WebCache.Put_result 
        public delegate void PutCallback(ErrorCode err, WebCache.Put_result resp);
        public void Put(
            WebCache.Put_args Result,
            PutCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_WEBCACHE_PUT,timeout_milliseconds, request_hash, GetPartitionHash(Result));
            s.Write(Result);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                WebCache.Put_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle Put2(
            WebCache.Put_args Result,
            PutCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_WEBCACHE_PUT,timeout_milliseconds, request_hash, GetPartitionHash(Result));
            s.Write(Result);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                WebCache.Put_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

    public class SaaSClient : Clientlet
    {
        private RpcAddress _server;
        
        public SaaSClient(RpcAddress server) { _server = server; }
        public SaaSClient() { }
        ~SaaSClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(SaaS.OnL1Selection_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_SAAS_ONL1SELECTION ------------
        // - synchronous 
        public ErrorCode OnL1Selection(
            SaaS.OnL1Selection_args Query,
            out SaaS.OnL1Selection_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_SAAS_ONL1SELECTION, timeout_milliseconds, hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(SaaS.OnL1Selection_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack SaaS.OnL1Selection_args and SaaS.OnL1Selection_result 
        public delegate void OnL1SelectionCallback(ErrorCode err, SaaS.OnL1Selection_result resp);
        public void OnL1Selection(
            SaaS.OnL1Selection_args Query,
            OnL1SelectionCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_SAAS_ONL1SELECTION,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                SaaS.OnL1Selection_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle OnL1Selection2(
            SaaS.OnL1Selection_args Query,
            OnL1SelectionCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_SAAS_ONL1SELECTION,timeout_milliseconds, request_hash, GetPartitionHash(Query));
            s.Write(Query);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                SaaS.OnL1Selection_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

    public class RaaSClient : Clientlet
    {
        private RpcAddress _server;
        
        public RaaSClient(RpcAddress server) { _server = server; }
        public RaaSClient() { }
        ~RaaSClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(RaaS.OnL2Rank_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_RAAS_ONL2RANK ------------
        // - synchronous 
        public ErrorCode OnL2Rank(
            RaaS.OnL2Rank_args Pos,
            out RaaS.OnL2Rank_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_RAAS_ONL2RANK, timeout_milliseconds, hash, GetPartitionHash(Pos));
            s.Write(Pos);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(RaaS.OnL2Rank_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack RaaS.OnL2Rank_args and RaaS.OnL2Rank_result 
        public delegate void OnL2RankCallback(ErrorCode err, RaaS.OnL2Rank_result resp);
        public void OnL2Rank(
            RaaS.OnL2Rank_args Pos,
            OnL2RankCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_RAAS_ONL2RANK,timeout_milliseconds, request_hash, GetPartitionHash(Pos));
            s.Write(Pos);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                RaaS.OnL2Rank_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle OnL2Rank2(
            RaaS.OnL2Rank_args Pos,
            OnL2RankCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_RAAS_ONL2RANK,timeout_milliseconds, request_hash, GetPartitionHash(Pos));
            s.Write(Pos);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                RaaS.OnL2Rank_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

    public class CDGClient : Clientlet
    {
        private RpcAddress _server;
        
        public CDGClient(RpcAddress server) { _server = server; }
        public CDGClient() { }
        ~CDGClient() {}

        // from requests to partition index
    // PLEASE DO RE-DEFINE THEM IN A SUB CLASS!!!
    public virtual UInt64 GetPartitionHash(CDG.Get_args key) { return 0; }
    public virtual UInt64 GetPartitionHash(CDG.Put_args key) { return 0; }

    
        // ---------- call searchHelper.RPC_SEARCH_CDG_GET ------------
        // - synchronous 
        public ErrorCode Get(
            CDG.Get_args Id,
            out CDG.Get_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_CDG_GET, timeout_milliseconds, hash, GetPartitionHash(Id));
            s.Write(Id);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(CDG.Get_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack CDG.Get_args and CDG.Get_result 
        public delegate void GetCallback(ErrorCode err, CDG.Get_result resp);
        public void Get(
            CDG.Get_args Id,
            GetCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_CDG_GET,timeout_milliseconds, request_hash, GetPartitionHash(Id));
            s.Write(Id);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                CDG.Get_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle Get2(
            CDG.Get_args Id,
            GetCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_CDG_GET,timeout_milliseconds, request_hash, GetPartitionHash(Id));
            s.Write(Id);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                CDG.Get_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       

        // ---------- call searchHelper.RPC_SEARCH_CDG_PUT ------------
        // - synchronous 
        public ErrorCode Put(
            CDG.Put_args Caption,
            out CDG.Put_result resp, 
            int timeout_milliseconds = 0, 
            int hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_CDG_PUT, timeout_milliseconds, hash, GetPartitionHash(Caption));
            s.Write(Caption);
            s.Flush();
            
            var respStream = RpcCallSync(server != null ? server : _server, s);
            if (null == respStream)
            {
                resp = default(CDG.Put_result);
                return ErrorCode.ERR_TIMEOUT;
            }
            else
            {
                respStream.Read(out resp);
                return ErrorCode.ERR_OK;
            }
        }
        
        // - asynchronous with on-stack CDG.Put_args and CDG.Put_result 
        public delegate void PutCallback(ErrorCode err, CDG.Put_result resp);
        public void Put(
            CDG.Put_args Caption,
            PutCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_CDG_PUT,timeout_milliseconds, request_hash, GetPartitionHash(Caption));
            s.Write(Caption);
            s.Flush();
            
            RpcCallAsync(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                CDG.Put_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }        
        
        public SafeTaskHandle Put2(
            CDG.Put_args Caption,
            PutCallback callback,
            int timeout_milliseconds = 0, 
            int reply_hash = 0,
            int request_hash = 0,
            RpcAddress server = null)
        {
            RpcWriteStream s = new RpcWriteStream(searchHelper.RPC_SEARCH_CDG_PUT,timeout_milliseconds, request_hash, GetPartitionHash(Caption));
            s.Write(Caption);
            s.Flush();
            
            return RpcCallAsync2(
                        server != null ? server : _server, 
                        s,
                        this, 
                        (err, rs) => 
                            { 
                                CDG.Put_result resp;
                                rs.Read(out resp);
                                callback(err, resp);
                            },
                        reply_hash
                        );
        }       
    
    }

} // end namespace
