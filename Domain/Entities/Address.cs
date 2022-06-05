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
        //    private int id;

        //    private int gardenId;

        //    private string country;

        //    private string postalCode;

        //    private string city;

        //    private string street;


        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }
        [Column("GardenId")]
        public int GardenId { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("PostalCode")]
        public string PostalCode { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Street")]
        public string Street { get; set; }


        public Garden Garden;
    }
}
