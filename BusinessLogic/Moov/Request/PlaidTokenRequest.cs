using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Moov.Request
{
        public class User
        {
            public string client_user_id { get; set; }
        }
        
        public class PlaidTokenRequest
        {
            public string client_id { get; set; }
            public string secret { get; set; }
            public string client_name { get; set; }
            public List<string> country_codes { get; set; }
            public string language { get; set; }
            public User user { get; set; }
            public List<string> products { get; set; }
        }
}
