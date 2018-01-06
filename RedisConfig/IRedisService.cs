/******************************************************************
** auth: Frank
** date: 1/6/2018 8:18:05 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConfig
{
    public interface IRedisService<T>
    {
        T Get(string key);
        void Save(string key, T obj);
        void Delete(string key);
        long HashIncrease(string key, string field);
    }
}
