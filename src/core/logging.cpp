/*
 * The MIT License (MIT)

 * Copyright (c) 2015 Microsoft Corporation

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
# include <dsn/internal/logging_provider.h>
# include "service_engine.h"

namespace dsn {

    void logv(const char *file, const char *function, const int line, logging_level logLevel, const char* title, const char* fmt, va_list args)
    {
        logging_provider* logger = service_engine::instance().logging();
        if (logger != nullptr)
        {
            logger->logv(file, function, line, logLevel, title, fmt, args);
        }        
    }

    void logv(const char *file, const char *function, const int line, logging_level logLevel, const char* title, const char* fmt, ...)
    {
        va_list ap;
        va_start(ap, fmt);
        logv(file, function, line, logLevel, title, fmt, ap);
        va_end(ap);
    }

    void logv(const char *file, const char *function, const int line, logging_level logLevel, const char* title)
    {
        // TODO: using logging provider
        printf ("assertion at %s:%u in %s\n", function, line, file);
    }

} // end name
