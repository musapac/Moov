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
        public Task AddCapabilities(string getId);
        public Task LinkBankAccount(string getId);
    }
}
