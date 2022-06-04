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
        private int id;

        private int gardenId;

        private string country;

        private string postalCode;

        private string city;

        private string street;


        [PrimaryKey]
        [Column("Id")]
        public int Id { get => id; set => id = value; }
        [Column("GardenId")]
        public int GardenId { get => gardenId; set => gardenId = value; }
        [Column("Country")]
        public string Country { get => country; set => country = value; }
        [Column("PostalCode")]
        public string PostalCode { get => postalCode; set => postalCode = value; }
        [Column("City")]
        public string City { get => city; set => city = value; }
        [Column("Street")]
        public string Street { get => street; set => street = value; }
        
        
        public Garden Garden;
    }
}
