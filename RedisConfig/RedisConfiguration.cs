/******************************************************************
** auth: Frank
** date: 1/6/2018 8:19:45 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConfig
{
    public class RedisConfiguration
    {
        public RedisConfiguration()
        { }

        public string Host { set; get; }
        public string Port { set; get; }
        public string Name { set; get; }

        public string ConfigurationString
        {
            get { return string.Concat(this.Host, ":", this.Port); }
        }
    }
}
