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
        private int id;

        private int ownerId;

        private int addressId;

        private string name;

        private string fire;

        private string shelter;

        private string description;

        [PrimaryKey]
        [Column("Id")]
        public int Id { get => id; set => id = value; }
        [Column("OwnerId")]
        public int OwnerId { get => ownerId; set => ownerId = value; }
        [Column("AddressId")]
        public int AddressId { get => addressId; set => addressId = value; }
        [Column("Name")]
        public string Name { get => name; set => name = value; }
        [Column("Fire")]
        public string Fire { get => fire; set => fire = value; }
        [Column("Shelter")]
        public string Shelter { get => shelter; set => shelter = value; }
        [Column("Description")]
        public string Description { get => description; set => description = value; }
        
        
        public User Owner;
        public Address Address;
        public  List<Reservation> Reservations;
    }
}
