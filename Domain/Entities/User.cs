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
        //private int id;

        //private string name;

        //private string lastName;

        //private string email;

        //private bool isAdmin;

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


        public List<Garden> Gardens;

        public List<Reservation> ReservationsAsClient;
    }
}
