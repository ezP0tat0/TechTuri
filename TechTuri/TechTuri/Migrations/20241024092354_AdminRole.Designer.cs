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
    [Migration("20241024092354_AdminRole")]
    partial class AdminRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("TechTuri.Model.Data.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("condition")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("price")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TechTuri.Model.Data.Picture", b =>
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

                    b.Property<decimal>("size")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("TechTuri.Model.Data.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("stars")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TechTuri.Model.Data.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
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

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
