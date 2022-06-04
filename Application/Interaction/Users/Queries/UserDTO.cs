using Application.Interaction.Gardens.Queries;
using Application.Interaction.Reservations.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Users.Queries
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public List<GardenDTO> Gardens { get; set; }
        public List<ReservationDTO> Users { get; set; }
    }
}
