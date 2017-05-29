using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectApiCupomMarketing.Models
{
    public class RequestResumoCupom
    {
        public string api_key { get; set; }
        public string code_coupon { get; set; }
    }
}