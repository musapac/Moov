using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Moov.Request
{
    public class ExchangePubTokenRequest
    {
        public string client_id { get; set; }
        public string secret { get; set; }
        public string public_token { get; set; }
    }
}
