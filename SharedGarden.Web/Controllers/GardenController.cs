using Microsoft.AspNetCore.Mvc;
using SharedGarden.Web.Models;
using SharedGarden.Web.Services;
using System.Collections.Generic;

namespace SharedGarden.Web.Controllers
{
    public class GardenController : Controller
    {
        IList<GardenModel> gardenList = GardenServices.GetAllGardens();
        public IActionResult Index()
        {
            ViewBag.Message = gardenList;
            return View();
        }
    }
}
