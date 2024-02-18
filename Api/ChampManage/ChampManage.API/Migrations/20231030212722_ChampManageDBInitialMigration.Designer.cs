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
    [Migration("20231030212722_ChampManageDBInitialMigration")]
    partial class ChampManageDBInitialMigration
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