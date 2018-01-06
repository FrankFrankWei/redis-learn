/******************************************************************
** auth: Frank
** date: 1/6/2018 8:27:33 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisConfig
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer GetConnection();
    }
}
