using Application.Common.Mapping;
using Application.Interaction.Gardens.Queries.DTO;
using Application.Interaction.Reservations.Queries.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Users.Queries.DTO
{
    public class UserDTO : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public List<GardenDTO> Gardens { get; set; }
        public List<ReservationDTO> Reservations { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDTO>();
        }
    }
}
