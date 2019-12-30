﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Paint.Data;

namespace Paint.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Paint.Domain.BidArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BidSheetId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BidSheetId");

                    b.ToTable("BidArea");
                });

            modelBuilder.Entity("Paint.Domain.BidItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BidAreaId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Sub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("BidAreaId");

                    b.ToTable("BidItem");
                });

            modelBuilder.Entity("Paint.Domain.BidSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BedBath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("LockBox")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RenoTotal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("SquareFoot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("BidSheets");
                });

            modelBuilder.Entity("Paint.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Paint.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int>("ClientTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasColumnType("ntext");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.HasIndex("ParentId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            ClientTypeId = 1,
                            CompanyName = "OfferPad"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            ClientTypeId = 1,
                            CompanyName = "OfferPad",
                            FirstName = "Chase",
                            LastName = "Timms",
                            ParentId = 1
                        });
                });

            modelBuilder.Entity("Paint.Domain.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Logo")
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ClientType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "REO"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comercial"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Residential"
                        });
                });

            modelBuilder.Entity("Paint.Domain.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<decimal>("RenovationBudget")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("SquareFootage")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Paint.Domain.PaintItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FiveGallonPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("GallonPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("HiCoverage")
                        .HasColumnType("int");

                    b.Property<int>("LowCoverage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Paints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FiveGallonPrice = 44.98m,
                            GallonPrice = 11.98m,
                            Grade = 1,
                            HiCoverage = 400,
                            LowCoverage = 300,
                            Name = "SPEED-WALL Flat",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            FiveGallonPrice = 70.98m,
                            GallonPrice = 19.98m,
                            Grade = 2,
                            HiCoverage = 400,
                            LowCoverage = 350,
                            Name = "PPG ULTRA-HIDE Zero Flat",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            FiveGallonPrice = 0m,
                            GallonPrice = 21.98m,
                            Grade = 1,
                            HiCoverage = 400,
                            LowCoverage = 300,
                            Name = "GLIDDEN ESSENTIALS SG",
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            FiveGallonPrice = 89.98m,
                            GallonPrice = 19.98m,
                            Grade = 2,
                            HiCoverage = 400,
                            LowCoverage = 350,
                            Name = "PPG Ultra-Hide Zero SG",
                            Type = 2
                        },
                        new
                        {
                            Id = 5,
                            FiveGallonPrice = 102m,
                            GallonPrice = 22.98m,
                            Grade = 3,
                            HiCoverage = 400,
                            LowCoverage = 400,
                            Name = "Glidden Premium SG",
                            Type = 2
                        },
                        new
                        {
                            Id = 6,
                            FiveGallonPrice = 121m,
                            GallonPrice = 25.98m,
                            Grade = 4,
                            HiCoverage = 400,
                            LowCoverage = 300,
                            Name = "PPG DIAMOND Eggshell",
                            Type = 2
                        },
                        new
                        {
                            Id = 7,
                            FiveGallonPrice = 168m,
                            GallonPrice = 36.98m,
                            Grade = 4,
                            HiCoverage = 400,
                            LowCoverage = 400,
                            Name = "PPG TIMELESS Eggshell",
                            Type = 2
                        },
                        new
                        {
                            Id = 8,
                            FiveGallonPrice = 76.98m,
                            GallonPrice = 14.98m,
                            Grade = 1,
                            HiCoverage = 400,
                            LowCoverage = 400,
                            Name = "GLIDDEN ESSENTIALS Eggshell",
                            Type = 3
                        },
                        new
                        {
                            Id = 9,
                            FiveGallonPrice = 79.98m,
                            GallonPrice = 17.98m,
                            Grade = 2,
                            HiCoverage = 400,
                            LowCoverage = 350,
                            Name = "PPG Ultra-Hide Zero Eggshell",
                            Type = 3
                        },
                        new
                        {
                            Id = 10,
                            FiveGallonPrice = 97.98m,
                            GallonPrice = 20.98m,
                            Grade = 3,
                            HiCoverage = 400,
                            LowCoverage = 400,
                            Name = "Glidden Premium Eggshell",
                            Type = 3
                        },
                        new
                        {
                            Id = 11,
                            FiveGallonPrice = 112m,
                            GallonPrice = 25.98m,
                            Grade = 4,
                            HiCoverage = 400,
                            LowCoverage = 350,
                            Name = "PPG DIAMOND Eggshell",
                            Type = 3
                        },
                        new
                        {
                            Id = 12,
                            FiveGallonPrice = 159m,
                            GallonPrice = 34.98m,
                            Grade = 4,
                            HiCoverage = 400,
                            LowCoverage = 400,
                            Name = "PPG TIMELESS Eggshell",
                            Type = 3
                        });
                });

            modelBuilder.Entity("Paint.Domain.PaintList", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("CeilingId")
                        .HasColumnType("int");

                    b.Property<int>("TaxRate")
                        .HasColumnType("int");

                    b.Property<int>("TrimId")
                        .HasColumnType("int");

                    b.Property<int>("WallId")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.ToTable("PaintList");
                });

            modelBuilder.Entity("Paint.Domain.PriceListLineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("LaborHours")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("LaborRate")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("LaborSubtotal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("LaborTotal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("MaterialSupplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaterialTotalCost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("MaterialUnitCost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ModelNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProfitMargin")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("ProfitTotal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("UOM")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("PriceList");
                });

            modelBuilder.Entity("Paint.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseBoardHeight")
                        .HasColumnType("int");

                    b.Property<int>("ChairRailHeight")
                        .HasColumnType("int");

                    b.Property<int>("CrownMoldingHeight")
                        .HasColumnType("int");

                    b.Property<int>("DoorsSF")
                        .HasColumnType("int");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("WindowSF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Paint.Domain.BidArea", b =>
                {
                    b.HasOne("Paint.Domain.BidSheet", null)
                        .WithMany("Areas")
                        .HasForeignKey("BidSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paint.Domain.BidItem", b =>
                {
                    b.HasOne("Paint.Domain.BidArea", null)
                        .WithMany("Items")
                        .HasForeignKey("BidAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paint.Domain.BidSheet", b =>
                {
                    b.HasOne("Paint.Domain.Job", "Job")
                        .WithOne("BidSheet")
                        .HasForeignKey("Paint.Domain.BidSheet", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paint.Domain.Category", b =>
                {
                    b.HasOne("Paint.Domain.Category", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Paint.Domain.Client", b =>
                {
                    b.HasOne("Paint.Domain.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paint.Domain.Client", "Parent")
                        .WithMany("Clients")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Paint.Domain.Address", "BillingAddress", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<double?>("Latitude")
                                .HasColumnType("float")
                                .HasMaxLength(13);

                            b1.Property<string>("Line1")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.Property<double?>("Longitude")
                                .HasColumnType("float");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(2)")
                                .HasMaxLength(2);

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsMany("Paint.Domain.PhoneNumber", "PhoneNumbers", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<bool>("Active")
                                .HasColumnType("bit");

                            b1.Property<string>("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PhoneNumberType")
                                .HasColumnType("int");

                            b1.Property<int>("PhoneNumberTypeId")
                                .HasColumnType("int");

                            b1.HasKey("ClientId", "Id");

                            b1.ToTable("PhoneNumber");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });
                });

            modelBuilder.Entity("Paint.Domain.Job", b =>
                {
                    b.HasOne("Paint.Domain.Client", "Client")
                        .WithMany("Jobs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Paint.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<int>("JobId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<double?>("Latitude")
                                .HasColumnType("float")
                                .HasMaxLength(13);

                            b1.Property<string>("Line1")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.Property<double?>("Longitude")
                                .HasColumnType("float");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(2)")
                                .HasMaxLength(2);

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(10)")
                                .HasMaxLength(10);

                            b1.HasKey("JobId");

                            b1.ToTable("Jobs");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });
                });

            modelBuilder.Entity("Paint.Domain.PaintList", b =>
                {
                    b.HasOne("Paint.Domain.Job", "Job")
                        .WithOne("PaintList")
                        .HasForeignKey("Paint.Domain.PaintList", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paint.Domain.PriceListLineItem", b =>
                {
                    b.HasOne("Paint.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paint.Domain.Room", b =>
                {
                    b.HasOne("Paint.Domain.Job", null)
                        .WithMany("Rooms")
                        .HasForeignKey("JobId");
                });
#pragma warning restore 612, 618
        }
    }
}
