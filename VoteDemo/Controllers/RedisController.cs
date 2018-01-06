using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Redis;
using VoteDemo.Models;
using RedisConfig;
using System.Configuration;

namespace VoteDemo.Controllers
{
    public class RedisController : Controller
    {
        private readonly IRedisConnectionFactory _redisConnectionFactory;
        private readonly RedisConfiguration _redisConfiguration;
        private readonly IRedisService<Vote> _redisService;
        private readonly string _redisKey = "redisVote";
        public RedisController()
        {
            //TODO: use IOC
            _redisConfiguration = new RedisConfiguration();
            _redisConfiguration.Host = ConfigurationManager.AppSettings["redisHost"];
            _redisConfiguration.Port = ConfigurationManager.AppSettings["redisPort"];
            _redisConfiguration.Name = ConfigurationManager.AppSettings["redisName"];
            _redisConnectionFactory = new RedisConnectionFactory(_redisConfiguration);
            _redisService = new RedisService<Vote>(_redisConnectionFactory);
        }

        // GET: Redis
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vote()
        {
            return View();
        }

        public ActionResult GetVote()
        {
            Vote vote = _redisService.Get(_redisKey);

            return new JsonCamelCaseResult(vote, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public long DoVote(string voteValue)
        {
            long result = 0;
            switch (voteValue)
            {
                case "Y":
                    result = _redisService.HashIncrease(_redisKey, "YesFlag");
                    break;
                case "N":
                    result = _redisService.HashIncrease(_redisKey, "NoFlag");
                    break;
                case "U":
                    result = _redisService.HashIncrease(_redisKey, "UndecidedFlag");
                    break;
            }

            return result;
        }

        /*
        public ActionResult GetVote()
        {
            Vote vote = RedisHelper.GetVote();

            return new JsonCamelCaseResult(vote, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public long DoVote(string voteValue)
        {
            return RedisHelper.SetVote(voteValue);
        }
        */
    }
}