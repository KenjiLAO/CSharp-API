﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using monAPI.Context;

#nullable disable

namespace monAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("monAPI.Entities.Characters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("regionId")
                        .HasColumnType("int");

                    b.Property<int?>("visionId")
                        .HasColumnType("int");

                    b.Property<int?>("weaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("regionId");

                    b.HasIndex("visionId");

                    b.HasIndex("weaponId");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("monAPI.Entities.Region", b =>
                {
                    b.Property<int>("regionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("regionId");

                    b.ToTable("region");
                });

            modelBuilder.Entity("monAPI.Entities.Vision", b =>
                {
                    b.Property<int>("visionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("VisionType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("visionId");

                    b.ToTable("vision");
                });

            modelBuilder.Entity("monAPI.Weapon", b =>
                {
                    b.Property<int>("weaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("WeaponName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("weaponId");

                    b.ToTable("weapon");
                });

            modelBuilder.Entity("monAPI.Entities.Characters", b =>
                {
                    b.HasOne("monAPI.Entities.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionId");

                    b.HasOne("monAPI.Entities.Vision", "vision")
                        .WithMany()
                        .HasForeignKey("visionId");

                    b.HasOne("monAPI.Weapon", "weapon")
                        .WithMany()
                        .HasForeignKey("weaponId");

                    b.Navigation("region");

                    b.Navigation("vision");

                    b.Navigation("weapon");
                });
#pragma warning restore 612, 618
        }
    }
}
