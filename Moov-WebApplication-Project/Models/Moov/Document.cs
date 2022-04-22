using System;
using System.Collections.Generic;

namespace WebAPiTest.Models.Moov
{
    public class Document
    {
        public string documentID { get; set; }
        public string type { get; set; }
        public string contentType { get; set; }
        public List<string> parseErrors { get; set; }
        public DateTime uploadedAt { get; set; }
    }


}