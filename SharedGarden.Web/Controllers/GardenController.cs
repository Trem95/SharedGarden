using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedGarden.Web.Models;
using SharedGarden.Web.Services;
using System.Collections.Generic;

namespace SharedGarden.Web.Controllers
{
    public class GardenController : Controller
    {
        IList<GardenModel> gardenList = GardenServices.GetAllGardens();
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Message = gardenList;
            return View();
        }
        [Authorize]
        public IActionResult GardenDetails(int id)
        {
            GardenModel garden = GardenServices.GetGardenById(id);
            ViewBag.Garden = garden;
            string address = garden.Address.Country + " " + garden.Address.PostalCode + " " + garden.Address.City + " " + garden.Address.Street;
            ViewBag.GardenAddress = address.Replace("\'"," ") ;
            return View();
        }

    }
}
