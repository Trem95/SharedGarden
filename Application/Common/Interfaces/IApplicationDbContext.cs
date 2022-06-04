using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Garden> Garden { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Reservation> Reservations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
