using Application.Interaction.Addresses.Queries;
using Application.Interaction.Reservations.Queries;
using Application.Interaction.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Gardens.Queries
{
    public class GardenDTO
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fire { get; set; }
        public string Shelter { get; set; }

        public UserDTO Owner { get; set; }
        public AddressDTO Address { get; set; }
        public List<ReservationDTO> Reservations { get; set; }
    }
}
