﻿// <auto-generated />
using System;
using BackendASP.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendASP.Migrations
{
    [DbContext(typeof(PetCareContext))]
    [Migration("20231121132852_RequiredPetType")]
    partial class RequiredPetType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendASP.Models.AppointmentPets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentPets");
                });

            modelBuilder.Entity("BackendASP.Models.Appointments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("varchar(254)");

                    b.Property<int>("PetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("Preference")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetTypeId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentNumber = 1,
                            CustomerName = "Corbijn Bulsink",
                            Date = new DateOnly(2023, 11, 20),
                            Email = "corbijn.bullie@hoi.nl",
                            PetTypeId = 1,
                            PhoneNumber = "0611330161",
                            Preference = 1,
                            Status = 0
                        });
                });

            modelBuilder.Entity("BackendASP.Models.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Plural")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("PetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "dog.png",
                            Name = "hond",
                            Plural = "honden"
                        },
                        new
                        {
                            Id = 2,
                            Image = "black-cat.png",
                            Name = "kat",
                            Plural = "katten"
                        },
                        new
                        {
                            Id = 3,
                            Image = "rabbit.png",
                            Name = "konijn",
                            Plural = "konijnen"
                        },
                        new
                        {
                            Id = 4,
                            Image = "guinea-pig.png",
                            Name = "cavia",
                            Plural = "cavia's"
                        },
                        new
                        {
                            Id = 5,
                            Image = "hamster.png",
                            Name = "hamster",
                            Plural = "hamsters"
                        },
                        new
                        {
                            Id = 6,
                            Image = "rat.png",
                            Name = "rat",
                            Plural = "ratten"
                        },
                        new
                        {
                            Id = 7,
                            Image = "muis.png",
                            Name = "muis",
                            Plural = "muizen"
                        },
                        new
                        {
                            Id = 8,
                            Image = "dog.png",
                            Name = "kleine hond",
                            ParentId = 1,
                            Plural = "kleine honden"
                        },
                        new
                        {
                            Id = 9,
                            Image = "dog.png",
                            Name = "grote hond",
                            ParentId = 1,
                            Plural = "grote honden"
                        });
                });

            modelBuilder.Entity("BackendASP.Models.AppointmentPets", b =>
                {
                    b.HasOne("BackendASP.Models.Appointments", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("BackendASP.Models.Appointments", b =>
                {
                    b.HasOne("BackendASP.Models.PetType", "PetType")
                        .WithMany("Appointment")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetType");
                });

            modelBuilder.Entity("BackendASP.Models.PetType", b =>
                {
                    b.HasOne("BackendASP.Models.PetType", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("BackendASP.Models.PetType", b =>
                {
                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
