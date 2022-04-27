using System;
using System.Linq;
using System.Web;

namespace WebAPiTest.Models.Moov
{
    public class CreateAccountResponse
    {
        public string mode { get; set; }
        public string accountID { get; set; }
        public string accountType { get; set; }
        public string displayName { get; set; }
        public Metadata metadata { get; set; }
        public TermsOfService termsOfService { get; set; }
        public Verification verification { get; set; }
        public string foreignID { get; set; }
        public CustomerSupport customerSupport { get; set; }
        public Settings settings { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
    }

}