/******************************************************************
** auth: Frank
** date: 1/6/2018 8:28:40 PM
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
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory(RedisConfiguration configuration)
        {
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configuration.ConfigurationString));
        }

        public ConnectionMultiplexer GetConnection()
        {
            return _connection.Value;
        }
    }
}
