using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Reservation")]
    public class Reservation
    {
        private int id;

        private int gardenId;

        private int clientId;

        private DateTime reservationDate;

        private int price;


        [PrimaryKey]
        [Column("Id")]
        public int Id { get => id; set => id = value; }
        [Column("GardenId")]
        public int GardenId { get => gardenId; set => gardenId = value; }
        [Column("ClientId")]
        public int ClientId { get => clientId; set => clientId = value; }
        [Column("ReservationDate")]
        public DateTime ReservationDate { get => reservationDate; set => reservationDate = value; }
        [Column("Price")]
        public int Price { get => price; set => price = value; }


        public Garden Garden;

        public User Client;

    }
}
