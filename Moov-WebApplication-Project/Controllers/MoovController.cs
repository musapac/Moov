using Microsoft.AspNetCore.Mvc;
using Moov.Application.Interfaces;
using Moov.Application.Moov.Request;
using System.Threading.Tasks;
using WebAPiTest.Models.Moov.Request;

namespace Moov_WebApp.Controllers
{
    public class MoovController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;
        public MoovController(ITokenService tokenService, IAccountService accountService)
        {
            _tokenService = tokenService;
            _accountService = accountService;
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
        public async Task<IActionResult> BackendByPass()
        {
            var getres=await UserAccount();
            if (getres is not null)
            {
                return View();
            }
            else
            {
                return Redirect("/Moov/ErrorPage");
            }
           
        }
        public async Task<string> UserAccount()
        {
            var accId=await _accountService.CreateAccount();
            return accId;
        }
         
        /// <summary>
        /// This is the Main Menu
        /// </summary>
        /// <returns></returns>
        public IActionResult Menu()
        { 
           return View();

        }
        public async Task Capabilities()
        {
            var getId = await UserAccount();
            await _accountService.AddCapabilities(getId);
        }
        public async Task BankAccount()
        {
            var getId = await UserAccount();
            await _accountService.LinkBankAccount(getId);

        }
        public IActionResult ErrorPage()
        {
            return View();

        }
    }
}