using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SharedGarden.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task login(string returnUrl ="/")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });
        }

       
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            });

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public IActionResult SignIn()
        {
            return View();
        }



        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
