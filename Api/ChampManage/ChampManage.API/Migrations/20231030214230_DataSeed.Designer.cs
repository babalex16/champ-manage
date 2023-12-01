﻿// <auto-generated />
using System;
using ChampManage.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChampManage.API.Migrations
{
    [DbContext(typeof(ChampManageContext))]
    [Migration("20231030214230_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("ChampionshipUser", b =>
                {
                    b.Property<int>("ParticipantsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegisteredChampionshipsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParticipantsId", "RegisteredChampionshipsId");

                    b.HasIndex("RegisteredChampionshipsId");

                    b.ToTable("ChampionshipUser");
                });

            modelBuilder.Entity("ChampManage.API.Entities.Championship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegistrationDeadline")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RegistrationFee")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Championships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTime = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description of Championship 1",
                            Location = "Location 1",
                            OrganizerId = 1,
                            RegistrationDeadline = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationFee = 50.00m,
                            Title = "Championship 1"
                        },
                        new
                        {
                            Id = 2,
                            DateTime = new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description of Championship 2",
                            Location = "Location 2",
                            OrganizerId = 2,
                            RegistrationDeadline = new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationFee = 40.00m,
                            Title = "Championship 2"
                        },
                        new
                        {
                            Id = 3,
                            DateTime = new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description of Championship 3",
                            Location = "Location 3",
                            OrganizerId = 3,
                            RegistrationDeadline = new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationFee = 60.00m,
                            Title = "Championship 3"
                        });
                });

            modelBuilder.Entity("ChampManage.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Belt")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Belt = 0,
                            Birthdate = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john@example.com",
                            FirstName = "John",
                            Gender = 0,
                            LastName = "Doe",
                            Phone = "123-456-7890",
                            TeamName = "Team A",
                            UserType = 0,
                            Weight = 80
                        },
                        new
                        {
                            Id = 2,
                            Belt = 1,
                            Birthdate = new DateTime(1995, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane@example.com",
                            FirstName = "Jane",
                            Gender = 1,
                            LastName = "Smith",
                            Phone = "987-654-3210",
                            TeamName = "Team B",
                            UserType = 0,
                            Weight = 50
                        },
                        new
                        {
                            Id = 3,
                            Belt = 2,
                            Birthdate = new DateTime(1985, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bob@example.com",
                            FirstName = "Bob",
                            Gender = 0,
                            LastName = "Johnson",
                            Phone = "555-123-4567",
                            TeamName = "Team C",
                            UserType = 1,
                            Weight = 99
                        },
                        new
                        {
                            Id = 4,
                            Belt = 1,
                            Birthdate = new DateTime(1998, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice@example.com",
                            FirstName = "Alice",
                            Gender = 1,
                            LastName = "Johnson",
                            Phone = "789-012-3456",
                            TeamName = "Team D",
                            UserType = 1,
                            Weight = 55
                        },
                        new
                        {
                            Id = 5,
                            Belt = 2,
                            Birthdate = new DateTime(1992, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michael@example.com",
                            FirstName = "Michael",
                            Gender = 0,
                            LastName = "Smith",
                            TeamName = "Team E",
                            UserType = 1,
                            Weight = 78
                        },
                        new
                        {
                            Id = 6,
                            Belt = 0,
                            Birthdate = new DateTime(1989, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "samantha@example.com",
                            FirstName = "Samantha",
                            Gender = 1,
                            LastName = "Brown",
                            TeamName = "Team F",
                            UserType = 1,
                            Weight = 68
                        });
                });

            modelBuilder.Entity("ChampionshipUser", b =>
                {
                    b.HasOne("ChampManage.API.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChampManage.API.Entities.Championship", null)
                        .WithMany()
                        .HasForeignKey("RegisteredChampionshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChampManage.API.Entities.Championship", b =>
                {
                    b.HasOne("ChampManage.API.Entities.User", "Organizer")
                        .WithMany("CreatedChampionships")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("ChampManage.API.Entities.User", b =>
                {
                    b.Navigation("CreatedChampionships");
                });
#pragma warning restore 612, 618
        }
    }
}
