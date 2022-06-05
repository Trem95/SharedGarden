using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Garden")]
    public class Garden
    {
        //private int id;

        //private int ownerId;

        //private int addressId;

        //private string name;

        //private string fire;

        //private string shelter;

        //private string description;

        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OwnerId")]
        public int OwnerId { get; set; }
        [Column("AddressId")]
        public int AddressId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Fire")]
        public string Fire { get; set; }
        [Column("Shelter")]
        public string Shelter { get; set; }
        [Column("Description")]
        public string Description { get; set; }


        public User Owner;
        public Address Address;
        public List<Reservation> Reservations;
    }
}
