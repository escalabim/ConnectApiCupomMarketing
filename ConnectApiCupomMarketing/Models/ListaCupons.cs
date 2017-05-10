using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConectApiCupomMarketing.Models
{
    public class ListaCupons
    {
        public string name_coupon { get; set; }
        public string quantity { get; set; }
        public string end_date { get; set; }
        public string discount { get; set; }
        public string id_coupon { get; set; }
    }
}