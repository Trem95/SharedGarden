using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDbContext
    {

        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Address> Addresses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Garden> Gardens { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Reservation> Reservations { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=LAPTOP-39S56KLD\SQL_ATR;Initial Catalog=SharedGardenDB;Persist Security Info=True;User ID=sa;Password=280715");
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.LastName).HasColumnName("LastName");
                entity.Property(x => x.Name).HasColumnName("Name");
                entity.Property(x => x.IsAdmin).HasColumnName("IsAdmin");
                entity.Property(x => x.IsDeleted).HasColumnName("IsDeleted");
            });
            builder.Entity<User>()
                .HasKey(b => b.Id);

            builder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Country).HasColumnName("Country");
                entity.Property(x => x.Street).HasColumnName("Street");
                entity.Property(x => x.PostalCode).HasColumnName("PostalCode");
                entity.Property(x => x.City).HasColumnName("City");
                entity.Property(x => x.IsDeleted).HasColumnName("IsDeleted");


                entity.HasOne(x => x.Garden)
                .WithOne(p => p.Address)
                .HasForeignKey<Garden>(b => b.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<Address>()
                .HasKey(b => b.Id);


            builder.Entity<Garden>(entity =>
            {
                entity.ToTable("Garden");

                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Name).HasColumnName("Name");
                entity.Property(x => x.Price).HasColumnName("Price");
                entity.Property(x => x.AddressId).HasColumnName("AddressId");
                entity.Property(x => x.OwnerId).HasColumnName("OwnerId");
                entity.Property(x => x.Fire).HasColumnName("Fire");
                entity.Property(x => x.Shelter).HasColumnName("Shelter");
                entity.Property(x => x.Description).HasColumnName("Description");
                entity.Property(x => x.IsDeleted).HasColumnName("IsDeleted");

                entity.HasOne(x => x.Owner)
                .WithMany(p => p.Gardens)
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);


            });
            builder.Entity<Garden>()
                .HasKey(b => b.Id);

            builder.Entity<Reservation>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.GardenId).HasColumnName("GardenId");
                entity.Property(x => x.ClientId).HasColumnName("ClientId");
                entity.Property(x => x.ReservationDate).HasColumnName("ReservationDate");
                entity.Property(x => x.IsCompleted).HasColumnName("IsCompleted");
                entity.Property(x => x.IsAcceptedByOwner).HasColumnName("IsAcceptedByOwner");

                entity.HasOne(x => x.Garden)
                .WithMany(p => p.Reservations)
                .HasForeignKey(b => b.GardenId);

                entity.HasOne(x => x.Client)
                .WithMany(p => p.ReservationsAsClient)
                .HasForeignKey(b => b.ClientId)
                .OnDelete(DeleteBehavior.NoAction);


            });
            builder.Entity<Reservation>()
                .HasKey(b => b.Id);



            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //    ////Define FK or other key
            base.OnModelCreating(builder);
        }
    }
}
