using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPiTest.Models.Moov
{
    public class CreateAccessTokenRes
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public  string  scope { get; set; }
        public string refresh_token { get; set; }
 
    }
}