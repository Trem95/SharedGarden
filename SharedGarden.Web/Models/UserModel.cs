using System.Collections.Generic;

namespace SharedGarden.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
        public List<GardenModel> Gardens { get; set; }
        public List<ReservationModel> ReservationsAsClient { get; set; }
    }
}
