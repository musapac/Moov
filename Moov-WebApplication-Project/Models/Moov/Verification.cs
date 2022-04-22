using System.Collections.Generic;

namespace WebAPiTest.Models.Moov
{
    public class Verification
    {
        public string status { get; set; }
        public string details { get; set; }
        public List<Document> documents { get; set; }
    }

}