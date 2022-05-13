

using Microsoft.Extensions.Configuration;
using Moov.Application.Interfaces;
using Moov.Application.Moov;
using Moov.Application.Moov.Request;
using Moov.Application.Moov.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _Config;
        private readonly ITokenService _tokenService;

        public AccountService(IConfiguration configuration, ITokenService tokenService)
        {
            _Config = configuration;
            _tokenService = tokenService;

        }
 
            public async Task<string> CreateAccount(string tosToken)
        {
            var token = await _tokenService.ScopeToken("/accounts.write");
            if (token is not null)
            {
                string accountbaseURL = "https://api.moov.io/accounts";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(accountbaseURL);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", value: _Config["Accounts:OriginUri"]);
                    client.DefaultRequestHeaders.Add("Referer", value: _Config["Accounts:BaseUri"]);

                    var request = new CreateAccount
                    {
                        mode = "sandbox",
                        accountType = "individual",
                        profile = new Profile()
                        {
                            individual = new Individual()
                            {
                                name = new Name()
                                {
                                    firstName = "Bank",
                                    middleName = "",
                                    lastName = "Account 1",
                                    suffix = "B.Acc 1"
                                },
                                phone = new Phone()
                                {
                                    number = "8185551212",
                                    countryCode = "1"

                                },
                                email = "bankAccoun1@gmail.com",
                                address = new Address()
                                {
                                    addressLine1 = "123 Main Street",
                                    addressLine2 = "Apt 302",
                                    city = "Boulder",
                                    stateOrProvince = "CO",
                                    postalCode = "80301",
                                    country = "US"
                                },
                                birthDate = new BirthDate()
                                {
                                    day = 9,
                                    month = 11,
                                    year = 1989
                                },
                                governmentID = new GovernmentID()
                                {
                                    ssn = new Ssn()
                                    {
                                        full = "123-45-6789",
                                        lastFour = "1234"
                                    },

                                },
                      
                            },

                        },
                        termsOfService = new TermsOfService
                        {
                            token = "QXNK0eksqiRhK6OZ93gFqd-3aev8uEVtCU4Xz7VzZlRa9NDgN7GI6_eE_hvZpJnqlih-7oH0gsNdeOu4mhMto0LZLwn-PVVxNzXN7JxuuTaE1E1USdzhAwRMx44yoM0DZ7PESDcFb0e-ud-vAgIzDBgXql_J"
                        },
                        foreignID = "1122aba-b9a1-11eb-8529-0121ac13014",

                    };
                    var rnd = new Random();
                    var s = rnd.Next(1000, 5000);
                    var f = rnd.Next(5000, 9000);
                    request.foreignID = $"1122aba-{s}-11eb-{f}-0121ac13014";
                    var requestBody = JsonConvert.SerializeObject(request);
                    var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(accountbaseURL, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                        var getAccountId = data.accountID;
                        return getAccountId;
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);

                    }

                }
            }
            return null;
        }
        public async Task AddCapabilities(string accountId)
        {
            var accountID = accountId;
            var token = await _tokenService.ScopeToken($"/accounts/{accountID}/capabilities.write");
            if (token is not null)
            {
                string accountbaseURL = $"https://api.moov.io/accounts/{accountID}/capabilities";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(accountbaseURL);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", value: _Config["Accounts:OriginUri"]);
                    client.DefaultRequestHeaders.Add("Referer", value: _Config["Accounts:BaseUri"]);

                    var request = new CapabilitiesRequest
                    {

                        capabilities = new List<string>
                            {  "transfers","wallet","send-funds" }

                    };
                    var requestBody = JsonConvert.SerializeObject(request);
                    var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(accountbaseURL, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);

                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                    }
                }
            }
        }


        public async Task<string> LinkBankAccount(string accountId)
        {
            var accountID = accountId;
            var token = await _tokenService.ScopeToken($"/accounts/{accountID}/bank-accounts.write");
            if (token is not null)
            {
                string accountbaseURL = $"https://api.moov.io/accounts/{accountID}/bank-accounts";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(accountbaseURL);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", value: _Config["Accounts:OriginUri"]);
                    client.DefaultRequestHeaders.Add("Referer", value: _Config["Accounts:BaseUri"]);

                    var request = new LinkBankAccountRequest
                    {
                        account = new Account()
                        {
                            holderName = "Musa",
                            holderType = "individual",
                            accountNumber = "0004321567000",
                            bankAccountType = "checking",
                            routingNumber = "000000000",
                        }

                    };
                    var requestBody = JsonConvert.SerializeObject(request);
                    var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(accountbaseURL, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                        var bankId = data.bankAccountID;
                        return bankId;

                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                    }

                }

            }
            return null;
        }
        public async Task<string> PlaidToken()
        {
            var client_id = "5f630e745f6405001006a53f";
            //var token = await _tokenService.ScopeToken($"/accounts/{accountID}/bank-accounts.write");
            //if (token is not null)
            //{
            string accountbaseURL = "https://sandbox.plaid.com/link/token/create";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(accountbaseURL);
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Origin", value: _Config["Accounts:OriginUri"]);
                //client.DefaultRequestHeaders.Add("Referer", value: _Config["Accounts:BaseUri"]);

                var request = new PlaidTokenRequest
                {

                    client_id = "5f630e745f6405001006a53f",
                    secret = "4df1af77f1f2adf27c6c6241f624f0",
                    client_name = "user_good",
                    country_codes = new List<string> { "US" },
                    language = "en",
                    products = new List<string> { "auth" },
                    user = new User
                    {
                        client_user_id = "5f630e745f6405001006a53f",
                    }
                };


                var requestBody = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync(accountbaseURL, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                    var getPlaidToken = data.link_token;
                    return getPlaidToken;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                }
                return null;
            }

        }
        //Creating public token
        public async Task<string> PublicToken()
        {
            string accountbaseURL = "https://sandbox.plaid.com/sandbox/public_token/create";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(accountbaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new PublicTokenRequest

                {
                    client_id = "5f630e745f6405001006a53f",
                    secret = "4df1af77f1f2adf27c6c6241f624f0",
                    institution_id = "ins_3",
                    initial_products = new List<string> { "auth" },
                    options = new Options
                    {
                        webhook = "https://www.genericwebhookurl.com/webhook"
                    }

                };
                var requestBody = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync(accountbaseURL, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                    var getPublicToken = data.public_token;
                    return getPublicToken;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                }
                return null;
            }

        }
        public async Task<string> ExchangePublicToken(string publicToken)
        {
            string accountbaseURL = "https://sandbox.plaid.com/item/public_token/exchange";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(accountbaseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new ExchangePubTokenRequest
                {
                    client_id = "5f630e745f6405001006a53f",
                    secret = "4df1af77f1f2adf27c6c6241f624f0",
                    public_token = publicToken
                };
                var requestBody = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync(accountbaseURL, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                    var accessToken = data.access_token;
                    return accessToken;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                }
                return null;
            }

        }
        public async Task<string> ProcessorToken(string plaidAccountId, string accessToken)
        {
            //var token = await _tokenService.ScopeToken("/accounts.write");
            //if (token is not null)
            //{
                string accountbaseURL = "https://sandbox.plaid.com/processor/token/create";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(accountbaseURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new ProcessorTokenRequest
                    {
                        client_id = "5f630e745f6405001006a53f",
                        secret = "4df1af77f1f2adf27c6c6241f624f0",
                        access_token = accessToken,
                        account_id = plaidAccountId,
                        processor = "moov"
                    };
                    var requestBody = JsonConvert.SerializeObject(request);
                    var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(accountbaseURL, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                        var processortoken = data.processor_token;
                        return processortoken;
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                    }
                    return null;
                }
            
            
           
        }
        public async Task AutoMicroDeposit(string accountId, string bankId)
        {
            var token = await _tokenService.ScopeToken($"/accounts/{accountId}/bank-accounts.write");
            if (token is not null)
            {
                string accountbaseURL = $"https://api.moov.io/accounts/{accountId}/bank-accounts/{bankId}/micro-deposits";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(accountbaseURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                }
            }
            else
            {
                
            }
            
        }
        public async Task<string> CompleteMicroDeposit(string accountId, string bankId)
        {
            var bankAccountID = bankId;
            var token = await _tokenService.ScopeToken($"/accounts/{accountId}/bank-accounts.write");
            if (token is not null)
            {
                string accountbaseURL = $"https://api.moov.io/accounts/{accountId}/bank-accounts/{bankAccountID}/micro-deposits";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(accountbaseURL);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Origin", value: _Config["Accounts:OriginUri"]);
                    client.DefaultRequestHeaders.Add("Referer", value: _Config["Accounts:BaseUri"]);

                    var request = new MicroDepositRequest
                    { 
                        amounts = new List<int>
                        {
                           0,0
                        }
                    };                     
                    var requestBody = JsonConvert.SerializeObject(request);
                    var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(accountbaseURL, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                        //var status = data.status;
                        //return status;
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                    }
                    return null;
                }
            }
            return null;
        }
        public async Task<string> GetPlaidAccountId(string accessToken)
        {            
            //var token = await _tokenService.ScopeToken($"/accounts/{accountID}/bank-accounts.write");
            //if (token is not null)
            //{
            string accountbaseURL = "https://sandbox.plaid.com/accounts/get";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(accountbaseURL);
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Origin", value: _Config["Accounts:OriginUri"]);
                //client.DefaultRequestHeaders.Add("Referer", value: _Config["Accounts:BaseUri"]);

                var request = new getPlaidAccountRequest
                {
                    client_id="5f630e745f6405001006a53f",
                    secret="4df1af77f1f2adf27c6c6241f624f0",
                    access_token= accessToken
                };
                var requestBody = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync(accountbaseURL, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<getPlaidAccountResponse>(result);
                    
                    var accountId = data.accounts[0].account_id;

                    return accountId;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                }
                return null;
            }

        }
        public async Task<string> PlaidProcessorLink(string processorToken, string plaidAccountId, string accountId)
        {
            var token = await _tokenService.ScopeToken($"/accounts/{accountId}/bank-accounts.write");
            if (token is not null)
            {
                string accountbaseURL = $"https://api.moov.io/accounts/{accountId}/bank-accounts";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(accountbaseURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    client.DefaultRequestHeaders.Add("Origin", "https://api.moov.io");
                    client.DefaultRequestHeaders.Add("Referer", "https://api.moov.io");

                    var request = new PlaidProcessorLinkRequest
                    {
                        plaid = new Plaid
                        {
                            token = processorToken
                        }
                    };
                    var requestBody = JsonConvert.SerializeObject(request);
                    var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(accountbaseURL, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                        
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<dynamic>(result);
                    }
                    return null;
                }
            }
            else{
            return null;
            }
         

        }

        public Task<string> TermOfServiceToken()
        {
            throw new NotImplementedException();
        }
    } 
    
}
//}



