using System.Collections.Generic;

namespace SharedGarden.Web.Models
{
    public class GardenModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Fire { get; set; }
        public string Shelter { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
        public UserModel Owner { get; set; }
        public AddressModel Address { get; set; }
        public List<ReservationModel> Reservations { get; set; }

    }
}
