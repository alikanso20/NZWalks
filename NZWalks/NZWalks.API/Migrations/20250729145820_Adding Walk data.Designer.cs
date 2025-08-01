﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20250729145820_Adding Walk data")]
    partial class AddingWalkdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36e7f51c-f4cd-4869-9bb3-fa77b2c5f4f8"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("d905c976-6303-45e4-b7ae-a2333549b092"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1544305d-b597-49cb-829f-cf299f103b1b"),
                            Code = "NI",
                            Name = "North Island",
                            RegionImageUrl = "https://example.com/north-island.jpg"
                        },
                        new
                        {
                            Id = new Guid("26031ecb-2754-4431-852f-dce2729a45ec"),
                            Code = "SI",
                            Name = "South Island",
                            RegionImageUrl = "https://example.com/south-island.jpg"
                        },
                        new
                        {
                            Id = new Guid("495c11c8-1e70-4aa3-805f-2cd85c51050e"),
                            Code = "AU",
                            Name = "Auckland",
                            RegionImageUrl = "https://example.com/auckland.jpg"
                        },
                        new
                        {
                            Id = new Guid("5b164fea-7e3b-43bd-9582-000d580d5184"),
                            Code = "WK",
                            Name = "Waikato",
                            RegionImageUrl = "https://example.com/waikato.jpg"
                        },
                        new
                        {
                            Id = new Guid("8006eb7f-ba5a-444d-888c-8436c1ce13d0"),
                            Code = "BP",
                            Name = "Bay of Plenty",
                            RegionImageUrl = "https://example.com/bay-of-plenty.jpg"
                        },
                        new
                        {
                            Id = new Guid("8053d0ef-a054-4b87-bd16-bd76da7ba654"),
                            Code = "MW",
                            Name = "Manawatu-Whanganui",
                            RegionImageUrl = "https://example.com/manawatu-whanganui.jpg"
                        },
                        new
                        {
                            Id = new Guid("fed10ff2-47f5-4a6f-b3fb-ed14e3dc655c"),
                            Code = "CA",
                            Name = "Canterbury",
                            RegionImageUrl = "https://example.com/canterbury.jpg"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1e1b2c3-d4e5-6789-0123-456789abcdef"),
                            Description = "A challenging day hike across volcanic terrain.",
                            DifficultyId = new Guid("d905c976-6303-45e4-b7ae-a2333549b092"),
                            LengthInKm = 19.399999999999999,
                            Name = "Tongariro Alpine Crossing",
                            RegionId = new Guid("1544305d-b597-49cb-829f-cf299f103b1b"),
                            WalkImageUrl = "https://example.com/tongariro.jpg"
                        },
                        new
                        {
                            Id = new Guid("b2f2c3d4-e5f6-7890-1234-567890abcdef"),
                            Description = "A multi-day walk through Fiordland National Park.",
                            DifficultyId = new Guid("3b6f32c4-764c-4c19-841e-b4e475ab4a6e"),
                            LengthInKm = 53.5,
                            Name = "Milford Track",
                            RegionId = new Guid("26031ecb-2754-4431-852f-dce2729a45ec"),
                            WalkImageUrl = "https://example.com/milford.jpg"
                        },
                        new
                        {
                            Id = new Guid("c3d4e5f6-7890-1234-5678-90abcdef1234"),
                            Description = "A scenic walk along Auckland's coastline.",
                            DifficultyId = new Guid("36e7f51c-f4cd-4869-9bb3-fa77b2c5f4f8"),
                            LengthInKm = 10.199999999999999,
                            Name = "Auckland Coast Walk",
                            RegionId = new Guid("495c11c8-1e70-4aa3-805f-2cd85c51050e"),
                            WalkImageUrl = "https://example.com/auckland-coast.jpg"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
