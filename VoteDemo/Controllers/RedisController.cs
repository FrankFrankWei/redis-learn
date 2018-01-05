using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoteDemo.Controllers
{
    public class RedisController : Controller
    {
        // GET: Redis
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vote()
        {
            return View();
        }

        public ActionResult DoVote()
        {
            string s = "placeholder";
            return Json(s);
        }
    }
}