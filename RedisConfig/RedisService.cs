/******************************************************************
** auth: Frank
** date: 1/6/2018 9:24:41 PM
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
    public class RedisService<T> : BaseService<T>, IRedisService<T>
    {
        internal readonly IDatabase Db;
        protected readonly IRedisConnectionFactory ConnectionFactory;
        public RedisService(IRedisConnectionFactory connectionFactory)
        {
            this.ConnectionFactory = connectionFactory;
            this.Db = this.ConnectionFactory.GetConnection().GetDatabase();
        }

        public void Delete(string key)
        {
            if (string.IsNullOrEmpty(key) || key.Contains(":"))
                throw new ArgumentException("invalid key");

            key = this.GenerateKey(key);
            this.Db.KeyDelete(key);
        }

        public T Get(string key)
        {
            key = this.GenerateKey(key);
            var hash = this.Db.HashGetAll(key);
            return this.MapFromHash(hash);
        }

        public void Save(string key, T obj)
        {
            if (obj != null)
            {
                HashEntry[] hash = this.GenerateHash(obj);
                key = this.GenerateKey(key);

                // if no fields of key in hash, then set
                if (this.Db.HashLength(key) == 0)
                {
                    this.Db.HashSet(key, hash);
                }
                else
                {
                    var props = this.Properties;
                    foreach (var item in props)
                    {
                        if (this.Db.HashExists(key, item.Name))
                        {
                            this.Db.HashSet(key, item.Name, (RedisValue)item.GetValue(obj));
                        }
                    }
                }
            }
        }

        public long HashIncrease(string key, string field)
        {
            key = this.GenerateKey(key);
            return this.Db.HashIncrement(key, field);
        }
    }
}
