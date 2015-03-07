# pragma once

# include <rdsn/internal/utils.h>
# include <rdsn/internal/threadpool_code.h>
# include <rdsn/internal/enum_helper.h>
# include <rdsn/internal/perf_counter.h>
# include <rdsn/internal/customizable_id.h>
# include <rdsn/internal/singleton_vector_store.h>
# include <rdsn/internal/join_point.h>
# include <rdsn/internal/extensible_object.h>

namespace rdsn {

enum task_type
{
    TASK_TYPE_COMPUTE,
    TASK_TYPE_AIO,
    TASK_TYPE_RPC_REQUEST,
    TASK_TYPE_RPC_RESPONSE,
    TASK_TYPE_CONTINUATION,
    TASK_TYPE_COUNT,
    TASK_TYPE_INVALID,
};

ENUM_BEGIN(task_type, TASK_TYPE_INVALID)
    ENUM_REG(TASK_TYPE_COMPUTE)
    ENUM_REG(TASK_TYPE_AIO)
    ENUM_REG(TASK_TYPE_RPC_REQUEST)
    ENUM_REG(TASK_TYPE_RPC_RESPONSE)
    ENUM_REG(TASK_TYPE_CONTINUATION)
ENUM_END(task_type)

enum task_priority
{
    TASK_PRIORITY_LOW,
    TASK_PRIORITY_COMMON,
    TASK_PRIORITY_HIGH,
    TASK_PRIORITY_COUNT,
    TASK_PRIORITY_INVALID,
};

ENUM_BEGIN(task_priority, TASK_PRIORITY_INVALID)
    ENUM_REG(TASK_PRIORITY_LOW)
    ENUM_REG(TASK_PRIORITY_COMMON)
    ENUM_REG(TASK_PRIORITY_HIGH)
ENUM_END(task_priority)

enum task_state
{
    TASK_STATE_READY,
    TASK_STATE_RUNNING,
    TASK_STATE_FINISHED,
    TASK_STATE_CANCELLED,

    TASK_STATE_COUNT,
    TASK_STATE_INVALID
};

ENUM_BEGIN(task_state, TASK_STATE_INVALID)
    ENUM_REG(TASK_STATE_READY)
    ENUM_REG(TASK_STATE_RUNNING)
    ENUM_REG(TASK_STATE_FINISHED)
    ENUM_REG(TASK_STATE_CANCELLED)
ENUM_END(task_state)

#define MAX_TASK_CODE_NAME_LENGTH 47

struct task_code : public rdsn::utils::customized_id<task_code>
{
    task_code(const char* xxx, task_type type, threadpool_code pool, task_priority pri, int rpcPairedCode);

    task_code(const task_code& source) 
        : rdsn::utils::customized_id<task_code>(source) 
    {
    }

    task_code(int code) : rdsn::utils::customized_id<task_code>(code) {}

    static task_code from_string(const char* name, task_code invalid_value)
    {
        rdsn::utils::customized_id<task_code> id = rdsn::utils::customized_id<task_code>::from_string(name, invalid_value);
        return task_code(id);
    }

private:
    // no assignment operator
    task_code& operator=(const task_code& source);
};

#define DEFINE_TASK_CODE(x, priority, pool) __selectany const rdsn::task_code x(#x, rdsn::TASK_TYPE_COMPUTE, pool, priority, 0);
#define DEFINE_TASK_CODE_AIO(x, priority, pool) __selectany const rdsn::task_code x(#x, rdsn::TASK_TYPE_AIO, pool, priority, 0);

// RPC between client and server, usually use different pools for server and client callbacks
#define DEFINE_TASK_CODE_RPC(x, priority, pool) \
    __selectany const rdsn::task_code x##_ACK(#x"_ACK", rdsn::TASK_TYPE_RPC_RESPONSE, pool, priority, 0); \
    __selectany const rdsn::task_code x(#x, rdsn::TASK_TYPE_RPC_REQUEST, pool, priority, x##_ACK);

#define DEFINE_TASK_CODE_RPC_PRIVATE(x, priority, pool) \
    static const rdsn::task_code x##_ACK(#x"_ACK", rdsn::TASK_TYPE_RPC_RESPONSE, pool, priority, 0); \
    static const rdsn::task_code x(#x, rdsn::TASK_TYPE_RPC_REQUEST, pool, priority, x##_ACK);


DEFINE_TASK_CODE(TASK_CODE_INVALID, TASK_PRIORITY_COMMON, THREAD_POOL_DEFAULT)

// define network channel types for RPC
DEFINE_CUSTOMIZED_ID_TYPE(rpc_channel)
DEFINE_CUSTOMIZED_ID(rpc_channel, RPC_CHANNEL_TCP)
DEFINE_CUSTOMIZED_ID(rpc_channel, RPC_CHANNEL_UDP)

class task;
class aio_task;
class rpc_request_task;
class rpc_response_task;
class message;
class admission_controller;
typedef void (*task_rejection_handler)(task*, admission_controller*);

class task_spec : public extensible_object<task_spec, 4>
{
public:
    static task_spec* get(int ec);

public:
    task_code              code;
    task_type              type;
    const char*            name;    
    task_code              rpc_paired_code;
    task_priority          priority;
    threadpool_code        pool_code; 
    bool                   allow_inline; // allow task executed in other thread pools or tasks

    task_rejection_handler rejection_handler;
    rpc_channel            rpc_message_channel;
    int32_t                rpc_default_timeout_milliseconds;
    int32_t                rpc_retry_interval_milliseconds;
    int32_t                rpc_min_timeout_milliseconds_for_retry;
    int32_t                async_rpc_max_send_time_milliseconds;

    // COMPUTE
    join_point<void, task*, task*>               on_task_enqueue;    
    join_point<void, task*>                      on_task_begin; // TODO: parent task
    join_point<void, task*>                      on_task_end;
    join_point<void, task*>                      on_task_cancelled;

    join_point<bool, task*, task*, uint32_t>     on_task_wait_pre;
    join_point<void, task*, task*, bool>         on_task_wait_post; // wait succeeded or timedout
    join_point<void, task*, task*, bool>         on_task_cancel_post; // cancel succeeded or not
    

    // AIO
    join_point<bool, task*, aio_task*>           on_aio_call; // return true means continue, otherwise early terminate with task::set_error_code
    join_point<void, aio_task*>                  on_aio_enqueue; // aio done, enqueue callback
    //join_point           on_task_begin;
    //join_point           on_task_end;

    // RPC_REQUEST
    join_point<bool, task*, message*, rpc_response_task*>  on_rpc_call; // return true means continue, otherwise dropped and (optionally) timedout
    join_point<void, rpc_request_task*>          on_rpc_request_enqueue;
    //join_point           on_task_begin; 
    //join_point           on_task_end;
    
    // RPC_RESPONSE
    join_point<bool, task*, message*>            on_rpc_reply;
    join_point<bool, rpc_response_task*>         on_rpc_response_enqueue; // response, task
    //join_point           on_task_begin;
    //join_point           on_task_end;

public:    
    task_spec(int code, const char* name, task_type type, threadpool_code pool, int paired_code, task_priority pri);
    
public:
    static bool init(configuration_ptr config);
    void init_profiling(bool profile);
};

} // end namespace

