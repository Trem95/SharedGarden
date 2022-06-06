using SQLite;
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

        public User Owner;
        public Address Address;
        public List<Reservation> Reservations;
    }
}
