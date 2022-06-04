using Application.Interaction.Gardens.Queries;
using Application.Interaction.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Addresses.Queries
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public GardenDTO Garden { get; set; }
        public UserDTO User { get; set; }

    }
}
