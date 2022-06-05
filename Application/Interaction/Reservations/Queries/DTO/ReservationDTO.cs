
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

namespace Application.Interaction.Reservations.Queries.DTO
{
    public class ReservationDTO : IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public int ClientId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Price { get; set; }

        public GardenDTO Garden { get; set; }
        public UserDTO User { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reservation, ReservationDTO>();
        }
    }
}

