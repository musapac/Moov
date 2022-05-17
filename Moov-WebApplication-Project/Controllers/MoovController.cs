using Microsoft.AspNetCore.Mvc;
using Moov.Application.Interfaces;
using Moov.Application.Moov.Request;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPiTest.Models.Moov.Request;
 
namespace Moov_WebApp.Controllers
{
    public class MoovController : Controller
    {
        string tosToken ="";
        private object tok;
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;
        public MoovController(ITokenService tokenService, IAccountService accountService)
        {
            _tokenService = tokenService;
            _accountService = accountService;
        }

        /// <summary>
        /// This is the Main Menu
        /// </summary>
        /// <returns></returns>
        public IActionResult Menu()
        {
            return View();
        }
        /// <summary>
        /// creating account and link bank account by MOOV DROP
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
        /// <summary>
        /// Account creating and linking bank account from one function
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> BackendByPass()
        {        
            var tosToken = "y6z5CQpPOyvcxWzTBkOmOXyURR9w5a7Zdu9ArmRtggVncMbhtZDES757ZA9LImdojfBCfrsCVDIW6J7lNSjQ3xG0TePurz0wv2xLZKpMHGRpl9XcT6yF--bFB8HHKN9AKRz8gt2nHoTa5bDun2LUBWsLryN3";
            var accountId = await UserAccount(tosToken);
            await _accountService.AddCapabilities(accountId);
            var publicToken = await GenPublicToken();
            var accessToken = await _accountService.ExchangePublicToken(publicToken);
            var plaidAccountId = await _accountService.GetPlaidAccountId(accessToken);
            var processorToken = await _accountService.ProcessorToken(plaidAccountId, accessToken);
            var processortoken = await ProcessorToken(accountId);
            return View();
        }
        /// <summary>
        /// TermOfServices Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> TermOfServiceToken()
        {
            var s = await _accountService.TermOfServiceToken();
            return s;
        }
        /// <summary>
        /// getting new user's accountID
        /// </summary>
        /// <param name="tosToken"></param>
        /// <returns></returns>
        public async Task<string> UserAccount(string tosToken)
        {
            var accId=await _accountService.CreateAccount(tosToken);
            return accId;
        }          
        public async Task<IActionResult> MenuMoov()
        {
            var getId = await UserAccount(tosToken);
            await _accountService.AddCapabilities(getId);
            await _accountService.LinkBankAccount(getId);
            return View();

        }
        /// <summary>
        /// Adding specific capabilities to enable transfer, collect and payout funds.
        /// </summary>
        /// <returns></returns>
        public async Task Capabilities()
        
        {
            var getId = await UserAccount(tosToken);
            await _accountService.AddCapabilities(getId);
        }
        /// <summary>
        /// Account created and linked with bank account
        /// </summary>
        /// <returns></returns>
        public async Task BankAccount()
        {
            var getId = await UserAccount(tosToken);
            await _accountService.LinkBankAccount(getId);

        }
        /// <summary>
        /// Custom Error Page
        /// </summary>
        /// <returns></returns>
        public IActionResult ErrorPage()
        {
            return View();
        }
        /// <summary>
        /// Calling Plaid Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> Plaid()
        {
           var s= await _accountService.PlaidToken();
            return s;
        }
        /// <summary>
        /// Plaid Token Generater
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPlaidToken()
        {
            var getLinkToken = await Plaid();
            //ViewBag.getLinkToken = getLinkToken;
            return getLinkToken;
        }
        /// Generating processor token for plaid linking
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<string> ProcessorToken(string accountId)
        {
            var publicToken = await GenPublicToken();
            var accessToken = await _accountService.ExchangePublicToken(publicToken);
            var plaidAccountId = await _accountService.GetPlaidAccountId(accessToken);
            var processorToken = await _accountService.ProcessorToken(plaidAccountId, accessToken);
            await _accountService.PlaidProcessorLink(processorToken, plaidAccountId, accountId);
            return null;
        }
        /// <summary>
        /// Generating Public Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GenPublicToken()
        {
            var getPublicToken = await _accountService.PublicToken();          
            return getPublicToken;
        }
        /// <summary>
        /// Public Token Exchange from Access Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> ExchangePublicTok()
        {
            var publicToken = await GenPublicToken();
            var accessToken = await _accountService.ExchangePublicToken(publicToken);
            return accessToken;
        }
        /// <summary>
        /// Testing 
        /// </summary>
        /// <param name="tok"></param>
        /// <returns></returns>
        public IActionResult TosTokenGen(string tok)
        {
            if (tok is not null)
            {
                string tosToken = tok;
            }
            return View();

        }
        /// <summary>
        /// 
        /// Testing token
        /// </summary>
        /// <param name="tosToken"></param>
        /// <returns></returns>
        public Task<string> Ios(string tosToken)
        {
            var i = tosToken;
            return null;

        }
    }
}