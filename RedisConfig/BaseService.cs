/******************************************************************
** auth: Frank
** date: 1/6/2018 7:36:00 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using StackExchange.Redis;

namespace RedisConfig
{
    public abstract class BaseService<T>
    {
        protected string Name = typeof(T).Name;
        protected PropertyInfo[] Properties = typeof(T).GetProperties();
        protected Type InstanceType = typeof(T);

        protected string GenerateKey(string key)
        {
            return string.Concat(key.ToLower(), ":", this.Name.ToLower());
        }

        protected HashEntry[] GenerateHash(T obj)
        {
            PropertyInfo[] props = this.Properties;
            HashEntry[] hash = new HashEntry[props.Count()];

            for (int i = 0; i < props.Count(); i++)
                hash[i] = new HashEntry(props[i].Name, props[i].GetValue(obj).ToString());

            return hash;
        }

        protected T MapFromHash(HashEntry[] hash)
        {
            T obj = (T)Activator.CreateInstance(this.InstanceType);
            PropertyInfo[] props = this.Properties;

            for (int i = 0; i < props.Count(); i++)
                for (int j = 0; j < hash.Count(); j++)
                {
                    if (props[i].Name.Equals(hash[j].Name))
                    {
                        RedisValue val = hash[i].Value;
                        Type type = props[i].PropertyType;

                        if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            if (string.IsNullOrEmpty(val))
                                props[i].SetValue(obj, null);
                        }

                        props[i].SetValue(obj, Convert.ChangeType(val, type));
                    }
                }

            return obj;

        }
    }
}
