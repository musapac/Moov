using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Moov.Request
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CreateAccount
    {
        public string mode { get; set; }
        public string accountType { get; set; }
        public Profile profile { get; set; }
        public Metadata metadata { get; set; }
        public TermsOfService termsOfService { get; set; }
        public string foreignID { get; set; }
        public CustomerSupport customerSupport { get; set; }
        public Settings settings { get; set; }
    }

    public class Name
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
    }

    public class Phone
    {
        public string number { get; set; }
        public string countryCode { get; set; }
    }

    public class Address
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string stateOrProvince { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    public class BirthDate
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }

    public class Ssn
    {
        public string full { get; set; }
        public string lastFour { get; set; }
    }

    public class Itin
    {
        public string full { get; set; }
        public string lastFour { get; set; }
    }

    public class GovernmentID
    {
        public Ssn ssn { get; set; }
        public Itin itin { get; set; }
    }

    public class Individual
    {
        public Name name { get; set; }
        public Phone phone { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public BirthDate birthDate { get; set; }
        public GovernmentID governmentID { get; set; }
    }

    public class Ein
    {
        public string number { get; set; }
    }

    public class TaxID
    {
        public Ein ein { get; set; }
    }

    public class IndustryCodes
    {
        public string naics { get; set; }
        public string sic { get; set; }
        public string mcc { get; set; }
    }

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
        public TaxID taxID { get; set; }
        public IndustryCodes industryCodes { get; set; }
    }

    public class Profile
    {
        public Individual individual { get; set; }
        public Business business { get; set; }
    }

    public class Metadata
    {
        public string property1 { get; set; }
        public string property2 { get; set; }
    }

    public class TermsOfService
    {
        public string token { get; set; }
    }

    public class CustomerSupport
    {
        public Phone phone { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string website { get; set; }
    }

    public class CardPayment
    {
        public string statementDescriptor { get; set; }
    }

    public class Settings
    {
        public CardPayment cardPayment { get; set; }
    }

   


}
