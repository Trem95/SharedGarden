using Application.Common.Mapping;
using Application.Interaction.Gardens.Queries.DTO;
using Application.Interaction.Users.Queries.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Addresses.Queries.DTO
{
    public class AddressDTO : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool IsDeleted { get; set; }

        public GardenDTO Garden { get; set; }

        //public AddressDTO()
        //{
        //    Country = String.Empty;
        //    PostalCode = String.Empty;
        //    City = String.Empty;
        //    Street = String.Empty;
        //    Garden = new GardenDTO();
        //}

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDTO>();
        }
    }
}
