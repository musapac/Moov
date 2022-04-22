using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moov.Application.Interfaces
{
    public interface ITokenService
    {
        public Task<string> TokenGen();
        public Task<string> ScopeToken(string scopes);
    }
}
