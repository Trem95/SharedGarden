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
        private int id;

        private string name;

        private string lastName;

        private string email;

        private bool isAdmin;

        [PrimaryKey]

        [Column("Id")]
        public int Id { get => id; set => id = value; }
        [Column("Name")]
        public string Name { get => name; set => name = value; }
        [Column("LastName")]
        public string LastName { get => lastName; set => lastName = value; }
        [Column("Email")]
        public string Email { get => email; set => email = value; }
        [Column("IsAdmin")]
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }


        public List<Garden> Gardens;

        public List<Reservation> ReservationsAsClient;
    }
}
