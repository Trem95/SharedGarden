using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SharedGarden.Web.Models
{
    public class ReservationsModelsVm
    { 
        public IList<ReservationModel> ReservationList { get; set; }
    }
}
