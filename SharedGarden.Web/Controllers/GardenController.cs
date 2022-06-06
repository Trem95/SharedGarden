using Microsoft.AspNetCore.Mvc;

namespace SharedGarden.Web.Controllers
{
    public class GardenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
