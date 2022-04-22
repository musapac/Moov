using Microsoft.AspNetCore.Mvc;
using Moov.Application.Interfaces;
using System.Threading.Tasks;

namespace Moov_WebApp.Controllers
{
    public class MoovController : Controller
    {
        private readonly ITokenService _tokenService;
        public MoovController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        /// <summary>
        /// creating access_token and sending to view;
        /// </summary>
        /// <returns></returns>        
        public async Task<IActionResult> Onboarding()
        {
            var tokenRet = await _tokenService.TokenGen();
            ViewBag.TokenRet = tokenRet;
            return View();
        }
        /// <summary>
        /// generating token after receving scopes from onboarding view;
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns></returns>
        public async Task<string> Token([FromBody] string scopes)
        {
            var getScToken = await _tokenService.ScopeToken(scopes);
            return getScToken;
        }
    }
}
