using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConectApiCupomMarketing.Models
{
    public class ResultPostResgataCupom
    {
        public string code_coupon { get; set; }
        public string end_date { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }
}