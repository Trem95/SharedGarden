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
        [Column("Price")]
        public int Price { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        public Garden()
        {
            Name = string.Empty;
            Fire = string.Empty;
            Shelter = string.Empty;
            Description = string.Empty;
            Owner = new User();
            Address = new Address();
        }

        public User Owner;
        public Address Address;
        public List<Reservation> Reservations;
    }
}
