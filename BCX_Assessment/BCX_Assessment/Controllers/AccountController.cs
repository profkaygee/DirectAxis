using BCX_Api.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace BCX_Assessment.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(string userName, string password)
        {
            var client = new RestClient("http://localhost:64190/");
            var request = new RestRequest($"Account/Login?userName={userName}&password={password}", DataFormat.Json);

            var response = await client.GetAsync<User>(request, cancellationToken: CancellationToken.None);
            return Json(response);
        }
    }
}