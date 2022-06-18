using Microsoft.AspNetCore.Authorization;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Mvc;
using SharedGarden.Web.Models;
using SharedGarden.Web.Services;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SharedGarden.Web.Controllers
{
    public delegate UserModel DelegateGetCurrentUser();
    public class GardenController : Controller
    {
        IList<GardenModel> gardenList = new List<GardenModel>();
        IList<GardenModel> userGardens = new List<GardenModel>();
        public static DelegateGetCurrentUser delegateGetCurrentUser;
        [Authorize]
        public IActionResult Index()
        {

            gardenList = GardenServices.GetAllGardens();
            if (delegateGetCurrentUser != null )
                userGardens = delegateGetCurrentUser.Invoke().Id > 0 ? GardenServices.GetGardenByUserId(delegateGetCurrentUser.Invoke().Id) : new List<GardenModel>();

            ViewBag.AllGardensList = gardenList;
            ViewBag.UserGardenList = userGardens;

            return this.View();
        }
        [Authorize]
        public IActionResult GardenDetails(int id)
        {
            GardenModel garden = GardenServices.GetGardenById(id);
            ViewBag.Garden = garden;
            string address = garden.Address.Country + " " + garden.Address.PostalCode + " " + garden.Address.City + " " + garden.Address.Street;
            ViewBag.GardenAddress = address.Replace("\'", " ");
            return View();
        }


        #region AddGarden

        [Authorize]
        public IActionResult AddGarden()
        {
            return View();
        }
        
        public static void Test(string? result)
        {
            Console.WriteLine(result);
        }
        #endregion



    }
}
