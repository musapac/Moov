using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Moov.Request
{ 
        public class Options
        {
            public string webhook { get; set; }
        }

        public class PublicTokenRequest
        {
            public string client_id { get; set; }
            public string secret { get; set; }
            public string institution_id { get; set; }
            public List<string> initial_products { get; set; }
            public Options options { get; set; }
        }

 
}
