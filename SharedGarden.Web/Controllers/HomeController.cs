using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedGarden.Web.Models;
using SharedGarden.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SharedGarden.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GardenController GardenController;
        private UserModel currentUser = new UserModel { Id = -1 };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            GardenController.delegateGetCurrentUser = GetCurrentUser;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accesTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind
                    );
                string idToken = await HttpContext.GetTokenAsync("id_token");

                List<System.Security.Claims.Claim> list = User.Claims.ToList();
                currentUser = UserServices.GetUserByEmail(list[1].ToString().Replace("name: ", String.Empty));
            }
            else
                currentUser = new UserModel { Id = -1 };

            return View();
        }
        public int GetData()
        {
            return currentUser.Id;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private UserModel GetCurrentUser()
        {
            return currentUser;
        }
    }
}
