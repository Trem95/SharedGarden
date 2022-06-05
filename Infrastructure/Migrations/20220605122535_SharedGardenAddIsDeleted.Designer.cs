﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220605122535_SharedGardenAddIsDeleted")]
    partial class SharedGardenAddIsDeleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GardenId")
                        .HasColumnType("int")
                        .HasColumnName("GardenId");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PostalCode");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Street");

                    b.HasKey("Id");

                    b.HasIndex("GardenId")
                        .IsUnique();

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Garden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Fire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Fire");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("OwnerId");

                    b.Property<string>("Shelter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Shelter");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Garden", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("ClientId");

                    b.Property<int>("GardenId")
                        .HasColumnType("int")
                        .HasColumnName("GardenId");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsCompleted");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ReservationDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("GardenId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("IsAdmin");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.HasOne("Domain.Entities.Garden", "Garden")
                        .WithOne("Address")
                        .HasForeignKey("Domain.Entities.Address", "GardenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Garden");
                });

            modelBuilder.Entity("Domain.Entities.Garden", b =>
                {
                    b.HasOne("Domain.Entities.User", "Owner")
                        .WithMany("Gardens")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Domain.Entities.User", "Client")
                        .WithMany("ReservationsAsClient")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Garden", "Garden")
                        .WithMany("Reservations")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Garden");
                });

            modelBuilder.Entity("Domain.Entities.Garden", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Gardens");

                    b.Navigation("ReservationsAsClient");
                });
#pragma warning restore 612, 618
        }
    }
}
