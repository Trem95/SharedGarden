using Application.Common.Mapping;
using Application.Interaction.Addresses.Queries.DTO;
using Application.Interaction.Reservations.Queries.DTO;
using Application.Interaction.Users.Queries.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Gardens.Queries.DTO
{
    public class GardenDTO : IMapFrom<Garden>
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fire { get; set; }
        public string Shelter { get; set; }
        public bool IsDeleted { get; set; }

        public UserDTO Owner { get; set; }
        public AddressDTO Address { get; set; }
        public List<ReservationDTO> Reservations { get; set; }

        public GardenDTO()
        {
            Name = String.Empty;
            Description = String.Empty;
            Fire = String.Empty;
            Shelter = String.Empty;
            Reservations = new List<ReservationDTO>();
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Garden, GardenDTO>();
        }
    }
}
