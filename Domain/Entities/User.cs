using AutoMapper;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    [Table("User")]
    public class User
    {
        [PrimaryKey]

        [Column("Id")]
        public int Id { get ; set ; }
        [Column("Name")]
        public string Name { get ; set; }
        [Column("LastName")]
        public string LastName { get ; set ; }
        [Column("Email")]
        public string Email { get ; set ; }
        [Column("IsAdmin")]
        public bool IsAdmin { get ; set ; }
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        //public User()
        //{
        //    Name = string.Empty;
        //    LastName = string.Empty;
        //    Email = string.Empty;
        //    Gardens = new List<Garden>();
        //    ReservationsAsClient = new List<Reservation>();
        //}

        public List<Garden> Gardens;

        public List<Reservation> ReservationsAsClient; 
    }
}
