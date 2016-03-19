using System;
using System.IO;
using dsn.dev.csharp;

namespace dsn.app.search 
{
    public static partial class searchHelper
    {    
        public static TaskCode LPC_SEARCH_TEST_TIMER;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'IFEX'
        public static TaskCode RPC_SEARCH_IFEX_ONSEARCHQUERY;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'ALTA'
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'IsCache'
        public static TaskCode RPC_SEARCH_ISCACHE_GET;
        public static TaskCode RPC_SEARCH_ISCACHE_PUT;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'QU'
        public static TaskCode RPC_SEARCH_QU_ONQUERYUNDERSTANDING;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'QU2'
        public static TaskCode RPC_SEARCH_QU2_ONQUERYANNOTATION;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'TLA'
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'WebCache'
        public static TaskCode RPC_SEARCH_WEBCACHE_GET;
        public static TaskCode RPC_SEARCH_WEBCACHE_PUT;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'SaaS'
        public static TaskCode RPC_SEARCH_SAAS_ONL1SELECTION;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'RaaS'
        public static TaskCode RPC_SEARCH_RAAS_ONL2RANK;
        // define your own thread pool using DEFINE_THREAD_POOL_CODE(xxx)
        // define RPC task code for service 'CDG'
        public static TaskCode RPC_SEARCH_CDG_GET;
        public static TaskCode RPC_SEARCH_CDG_PUT;
    

        public static void InitCodes()
        {
            LPC_SEARCH_TEST_TIMER = new TaskCode("LPC_SEARCH_TEST_TIMER", dsn_task_type_t.TASK_TYPE_COMPUTE, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_IFEX_ONSEARCHQUERY = new TaskCode("RPC_SEARCH_IFEX_ONSEARCHQUERY", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_ISCACHE_GET = new TaskCode("RPC_SEARCH_ISCACHE_GET", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_ISCACHE_PUT = new TaskCode("RPC_SEARCH_ISCACHE_PUT", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_QU_ONQUERYUNDERSTANDING = new TaskCode("RPC_SEARCH_QU_ONQUERYUNDERSTANDING", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_QU2_ONQUERYANNOTATION = new TaskCode("RPC_SEARCH_QU2_ONQUERYANNOTATION", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_WEBCACHE_GET = new TaskCode("RPC_SEARCH_WEBCACHE_GET", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_WEBCACHE_PUT = new TaskCode("RPC_SEARCH_WEBCACHE_PUT", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_SAAS_ONL1SELECTION = new TaskCode("RPC_SEARCH_SAAS_ONL1SELECTION", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_RAAS_ONL2RANK = new TaskCode("RPC_SEARCH_RAAS_ONL2RANK", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_CDG_GET = new TaskCode("RPC_SEARCH_CDG_GET", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
            RPC_SEARCH_CDG_PUT = new TaskCode("RPC_SEARCH_CDG_PUT", dsn_task_type_t.TASK_TYPE_RPC_REQUEST, dsn_task_priority_t.TASK_PRIORITY_COMMON, ThreadPoolCode.THREAD_POOL_DEFAULT);
        }
    }    
}

