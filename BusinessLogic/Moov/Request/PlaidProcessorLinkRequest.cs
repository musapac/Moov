using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Moov.Request
{
    public class PlaidProcessorLinkRequest
    {
        public Plaid plaid { get; set; }
    }
    public class Plaid
    {
        public string token { get; set; }
    }

  

}
