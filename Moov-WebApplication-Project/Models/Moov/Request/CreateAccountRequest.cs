using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPiTest.Models.Moov.Request
{
    public class CreateAccountRequest
    {
        public string mode { get; set; }
        public string accountType { get; set; }
        public Profile profile { get; set; }
        public string foreignID { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string website { get; set; }
    }

}


