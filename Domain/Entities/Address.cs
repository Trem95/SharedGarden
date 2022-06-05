using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Address")]
    public class Address
    {
        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("PostalCode")]
        public string PostalCode { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Street")]
        public string Street { get; set; }
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        public Address()
        {
            Country = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            Garden = new Garden();
        }

        public Garden Garden;
    }
}
