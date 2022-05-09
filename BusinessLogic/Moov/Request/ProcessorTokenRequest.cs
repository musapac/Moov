using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Moov.Request
{
    public class ProcessorTokenRequest
    { 
        public string client_id { get; set; }
        public string secret { get; set; }
        public string access_token { get; set; }
        public string account_id { get; set; }
        public string processor { get; set; }
    }


}
