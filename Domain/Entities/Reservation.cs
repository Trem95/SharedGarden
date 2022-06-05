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
        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }
        [Column("GardenId")]
        public int GardenId { get; set; }
        [Column("ClientId")]
        public int ClientId { get; set; }
        [Column("ReservationDate")]
        public DateTime ReservationDate { get; set; }

        [Column("IsCompleted")]
        public bool IsCompleted{ get; set; }
        [Column("IsAcceptedByOwner")]
        public bool IsAcceptedByOwner { get; set; }

        public Reservation()
        {
            ReservationDate = new DateTime();
            Garden = new Garden();
            Client = new User();
        }

        public Garden Garden;

        public User Client;

    }
}
