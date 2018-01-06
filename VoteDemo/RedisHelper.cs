/******************************************************************
** auth: Frank
** date: 1/6/2018 4:24:47 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;
using VoteDemo.Models;

namespace VoteDemo
{
    public class RedisHelper
    {
        private static ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");
        private static IDatabase _db = _redis.GetDatabase();

        public static Vote GetVote()
        {
            Vote vote = new Vote();
            if (_db.HashExists("Vote", "YesFlag") && _db.HashExists("Vote", "NoFlag") && _db.HashExists("Vote", "UndecidedFlag"))
            {
                vote.YesFlag = (int)_db.HashGet("Vote", "YesFlag");
                vote.NoFlag = (int)_db.HashGet("Vote", "NoFlag");
                vote.UndecidedFlag = (int)_db.HashGet("Vote", "UndecidedFlag");
            }
            else
            {
                _db.HashSet("Vote", "YesFlag", 0);
                _db.HashSet("Vote", "NoFlag", 0);
                _db.HashSet("Vote", "UndecidedFlag", 0);
            }

            return vote;
        }

        public static long SetVote(string voteValue)
        {
            long result = 0;
            switch (voteValue)
            {
                case "Y":
                    result = _db.HashIncrement("Vote", "YesFlag");
                    break;
                case "N":
                    result = _db.HashIncrement("Vote", "NoFlag");
                    break;
                case "U":
                    result = _db.HashIncrement("Vote", "UndecidedFlag");
                    break;
            }

            return result;
        }
    }
}
