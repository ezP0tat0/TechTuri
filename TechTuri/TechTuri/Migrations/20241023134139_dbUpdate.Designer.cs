﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechTuri.Model;

#nullable disable

namespace TechTuri.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241023134139_dbUpdate")]
    partial class dbUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("TechTuri.Model.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("price")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("sold")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TechTuri.Model.Picture", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("bytes")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("fileExtension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("fize")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("TechTuri.Model.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("joinDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("pwHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("pwSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TechTuri.Model.ProfilexItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfileID")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("ProfileItemConnections");
                });

            modelBuilder.Entity("TechTuri.Model.ProfilexReview", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfileID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReviewID")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("ProfileReviewConnections");
                });

            modelBuilder.Entity("TechTuri.Model.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("stars")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
