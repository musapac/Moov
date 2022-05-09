using Moov.Application.Moov.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPiTest.Models.Moov.Request;

namespace Moov.Application.Interfaces
{
    public interface IAccountService
    {
        public Task<string> CreateAccount();
        public Task AddCapabilities(string accountId);
        public Task<string> LinkBankAccount(string accountId);
        public Task<string> PlaidToken();
        public Task<string> PublicToken();
        public Task<string> ExchangePublicToken(string publicToken);
        public Task<string> ProcessorToken(string accountId, string accessToken);
        Task AutoMicroDepositAsync(string accountId, string bankId);
    }
}
