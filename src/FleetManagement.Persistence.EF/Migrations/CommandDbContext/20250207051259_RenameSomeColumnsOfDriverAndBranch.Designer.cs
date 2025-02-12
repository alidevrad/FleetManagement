﻿// <auto-generated />
using System;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetManagement.Persistence.EF.Migrations.CommandDbContext
{
    [DbContext(typeof(FleetManagementDbContext))]
    [Migration("20250207051259_RenameSomeColumnsOfDriverAndBranch")]
    partial class RenameSomeColumnsOfDriverAndBranch
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Fleet")
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FleetManagement.Domain.Models.Customers.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<double>("Longitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StoreOwnerName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers", "Fleet");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Drivers.Driver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LicenseExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LicenseIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicenseType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NativeLanguage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Drivers", "Fleet");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Vehicles.Vehicle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("AverageFuelConsumption")
                        .HasColumnType("float");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlateNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("LoadCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<byte>("VehicleType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", "Fleet");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Warehouses.Warehouse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<double>("Longitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses", "Fleet");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Customers.Customer", b =>
                {
                    b.OwnsMany("FleetManagement.Domain.Models.Customers.Branch", "Branches", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("AgentFullName")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<DateTime>("CreationDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<long>("CustomerId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime?>("DeleteDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsActive")
                                .HasColumnType("bit");

                            b1.Property<bool?>("IsDeleted")
                                .HasColumnType("bit");

                            b1.Property<DateTime?>("LastUpdateDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<double>("Latitude")
                                .HasPrecision(9, 6)
                                .HasColumnType("float(9)");

                            b1.Property<double>("Longitude")
                                .HasPrecision(9, 6)
                                .HasColumnType("float(9)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("rowversion");

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Branches", "Fleet");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.OwnsOne("FleetManagement.Domain.Common.BuildingBlocks.PhoneNumber", "AgentPhoneNumber", b2 =>
                                {
                                    b2.Property<long>("BranchId")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("CountryCode")
                                        .IsRequired()
                                        .HasMaxLength(10)
                                        .HasColumnType("nvarchar(10)")
                                        .HasColumnName("AgentPhoneNumberCountryCode");

                                    b2.Property<string>("Number")
                                        .IsRequired()
                                        .HasMaxLength(20)
                                        .HasColumnType("nvarchar(20)")
                                        .HasColumnName("AgentPhoneNumber");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)")
                                        .HasColumnName("AgentPhoneNumberTitle");

                                    b2.HasKey("BranchId");

                                    b2.ToTable("Branches", "Fleet");

                                    b2.WithOwner()
                                        .HasForeignKey("BranchId");
                                });

                            b1.OwnsMany("FleetManagement.Domain.Common.BuildingBlocks.PhoneNumber", "PhoneNumbers", b2 =>
                                {
                                    b2.Property<long>("BranchId")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("Number")
                                        .HasMaxLength(20)
                                        .HasColumnType("nvarchar(20)");

                                    b2.Property<string>("CountryCode")
                                        .IsRequired()
                                        .HasMaxLength(10)
                                        .HasColumnType("nvarchar(10)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("BranchId", "Number");

                                    b2.ToTable("BranchPhoneNumbers", "Fleet");

                                    b2.WithOwner()
                                        .HasForeignKey("BranchId");
                                });

                            b1.Navigation("AgentPhoneNumber");

                            b1.Navigation("PhoneNumbers");
                        });

                    b.OwnsMany("FleetManagement.Domain.Common.BuildingBlocks.PhoneNumber", "PhoneNumbers", b1 =>
                        {
                            b1.Property<long>("CustomerId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Number")
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("CustomerId", "Number");

                            b1.ToTable("CustomerPhoneNumbers", "Fleet");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Branches");

                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Drivers.Driver", b =>
                {
                    b.OwnsOne("FleetManagement.Domain.Common.BuildingBlocks.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<long>("DriverId")
                                .HasColumnType("bigint");

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("DriverPhoneNumberCountryCode");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("DriverPhoneNumber");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("DriverPhoneNumberTitle");

                            b1.HasKey("DriverId");

                            b1.ToTable("Drivers", "Fleet");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.OwnsMany("FleetManagement.Domain.Models.Drivers.EmergencyContact", "EmergencyContacts", b1 =>
                        {
                            b1.Property<long>("DriverId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("Relationship")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("DriverId", "Id");

                            b1.ToTable("EmergencyContacts", "Fleet");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.OwnsMany("FleetManagement.Domain.Models.Drivers.TrainingQualification", "TrainingQualifications", b1 =>
                        {
                            b1.Property<long>("DriverId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime?>("ExpirationDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("ObtainedDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("QualificationName")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.HasKey("DriverId", "Id");

                            b1.ToTable("TrainingQualifications", "Fleet");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });

                    b.Navigation("EmergencyContacts");

                    b.Navigation("PhoneNumber");

                    b.Navigation("TrainingQualifications");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Vehicles.Vehicle", b =>
                {
                    b.OwnsMany("FleetManagement.Domain.Models.Vehicles.VehicleMaintenance", "VehicleMaintenances", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<DateTime>("CreationDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("DeleteDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<bool?>("IsDeleted")
                                .HasColumnType("bit");

                            b1.Property<DateTime?>("LastUpdateDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Reason")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<DateTime>("RepairDate")
                                .HasColumnType("datetime2");

                            b1.Property<byte[]>("RowVersion")
                                .IsConcurrencyToken()
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("rowversion");

                            b1.Property<long>("VehicleId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("VehicleId");

                            b1.ToTable("VehicleMaintenances", "Fleet");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");
                        });

                    b.Navigation("VehicleMaintenances");
                });
#pragma warning restore 612, 618
        }
    }
}
