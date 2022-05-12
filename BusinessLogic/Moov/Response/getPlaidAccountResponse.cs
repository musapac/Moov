using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Moov.Response
{
    public class getPlaidAccountResponse
    {
        public List<Accounts> accounts { get; set; }
        public Item item { get; set; }
        public string request_id { get; set; }
    }
    public class Accounts
    {
        public string account_id { get; set; }
        public Balances balances { get; set; }
        public string mask { get; set; }
        public string name { get; set; }
        public string official_name { get; set; }
        public string subtype { get; set; }
        public string type { get; set; }
    }

    public class Balances
    {
        public int? available { get; set; }
        public double current { get; set; }
        public string iso_currency_code { get; set; }
        public int? limit { get; set; }
        public object unofficial_currency_code { get; set; }
    }

    public class Item
    {
        public List<string> available_products { get; set; }
        public List<string> billed_products { get; set; }
        public object consent_expiration_time { get; set; }
        public object error { get; set; }
        public string institution_id { get; set; }
        public string item_id { get; set; }
        public object optional_products { get; set; }
        public List<string> products { get; set; }
        public string update_type { get; set; }
        public string webhook { get; set; }
    }

 


}
