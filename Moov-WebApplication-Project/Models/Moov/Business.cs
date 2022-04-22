using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPiTest.Models.Moov
{
    public class Business
    {
        public string legalBusinessName { get; set; }
        public string doingBusinessAs { get; set; }
        public string businessType { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public bool taxIDProvided { get; set; }
        public List<object> representatives { get; set; }
        public bool ownersProvided { get; set; }
        public IndustryCodes industryCodes { get; set; }
    }
}