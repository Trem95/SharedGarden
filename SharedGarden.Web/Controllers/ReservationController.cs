using Microsoft.AspNetCore.Mvc;
using SharedGarden.Web.Models;
using SharedGarden.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SharedGarden.Web.Controllers
{
    public class ReservationController : Controller
    {
        IList<ReservationModel> allUserRes = new List<ReservationModel>();
        IList<ReservationModel> resAsOwner = new List<ReservationModel>();
        IList<ReservationModel> resAsClient = new List<ReservationModel>();
        public static DelegateGetCurrentUser delegateGetCurrentUser;
        UserModel currentUser = new UserModel { Id = -1 };

        public IActionResult Index()
        {
            if (delegateGetCurrentUser !=null)
            {
                currentUser = delegateGetCurrentUser.Invoke();
                allUserRes = currentUser.Id > 0 ? ReservationServices.GetReservationsByUserId(currentUser.Id) : new List<ReservationModel>();
                if(allUserRes.Count > 0)
                {
                    resAsOwner = allUserRes.Where(r => r.Garden.OwnerId == currentUser.Id).ToList<ReservationModel>();
                    resAsClient = allUserRes.Where(r => r.ClientId== currentUser.Id).ToList<ReservationModel>();
                }
            }
            ViewBag.ReservationAsOwner = resAsOwner;
            ViewBag.ReservationAsClient = resAsClient;
            return View();
        }
    }
}
