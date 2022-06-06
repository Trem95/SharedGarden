using System;

namespace SharedGarden.Web.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public int ClientId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsAcceptedByOwner { get; set; }
        public GardenModel Garden { get; set; }
        public UserModel Client { get; set; }

    }
}
