﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240403194058_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("MyProject.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsSubscribedToNewsletter")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte>("MembershipTypeId")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MyProject.Models.Genre", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MyProject.Models.MembershipType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("DiscountRate")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("DurationInMonths")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<short>("SignUpFee")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("MembershipType");
                });

            modelBuilder.Entity("MyProject.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("GenreId")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("NumberInStock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MyProject.Models.Customer", b =>
                {
                    b.HasOne("MyProject.Models.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("MyProject.Models.Movie", b =>
                {
                    b.HasOne("MyProject.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
