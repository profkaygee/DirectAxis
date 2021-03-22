using BCX_Api.Models;
using BCX_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BCX_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var loginMember = await _accountRepository.LoginUser(userName, password);
            return Json(loginMember);
        }
    }
}