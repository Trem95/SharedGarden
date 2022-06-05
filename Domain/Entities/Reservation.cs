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
        //private int id;

        //private int gardenId;

        //private int clientId;

        //private DateTime reservationDate;

        //private int price;


        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }
        [Column("GardenId")]
        public int GardenId { get; set; }
        [Column("ClientId")]
        public int ClientId { get; set; }
        [Column("ReservationDate")]
        public DateTime ReservationDate { get; set; }
        [Column("Price")]
        public int Price { get; set; }


        public Garden Garden;

        public User Client;

    }
}
