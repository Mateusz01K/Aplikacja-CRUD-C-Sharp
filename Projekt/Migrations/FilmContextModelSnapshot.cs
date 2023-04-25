﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.Context;

#nullable disable

namespace Projekt.Migrations
{
    [DbContext(typeof(FilmContext))]
    partial class FilmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Projekt.Models.Films.FilmsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearOfProduction")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Films", (string)null);
                });

            modelBuilder.Entity("Projekt.Models.Users.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });
            modelBuilder.Entity("Projekt.Models.Rents.RentsModel", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("FilmId")
                    .HasColumnType("INTEGER");

                b.Property<int>("UserId")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("FilmId");

                b.HasIndex("UserId");

                b.ToTable("Rentals", "dbo");
            });

            modelBuilder.Entity("Projekt.Models.Rents.RentsModel", b =>
            {
                b.HasOne("Projekt.Models.Films.Film", "Film")
                    .WithMany("Rentals")
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Projekt.Models.Users.User", "User")
                    .WithMany("Rentals")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("DateOfRental")
                    .HasColumnType("DATETIME");

                b.Property<DateTime>("DueDate")
                    .HasColumnType("DATETIME");

                b.HasKey("Id");

                b.ToTable("Rentals", (string)null);
            });
#pragma warning restore 612, 618
        }
    }
}