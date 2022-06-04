using Application.Interaction.Gardens.Queries;
using Application.Interaction.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Reservations.Queries
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public int ClientId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Price { get; set; }

        public GardenDTO Garden { get; set; }
        public UserDTO User { get; set; }
    }
}

