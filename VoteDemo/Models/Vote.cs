/******************************************************************
** auth: wei.huazhong
** date: 1/5/2018 2:57:56 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteDemo.Models
{
    public class Vote
    {
        public int YesFlag { set; get; }
        public int NoFlag { set; get; }
        public int UndecidedFlag { set; get; }
    }
}
