﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volvo.Registrations.Trucks.EfCore.SqlServer;

#nullable disable

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Migrations
{
    [DbContext(typeof(TrucksDbContext))]
    partial class TrucksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Volvo.Registrations.Trucks.BusinessModels.Commons.Events.DomainEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_time");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid?>("PreviousEventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerializedContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("serialized_content");

                    b.HasKey("Id");

                    b.ToTable("DomainEvent", (string)null);
                });

            modelBuilder.Entity("Volvo.Registrations.Trucks.BusinessModels.Trucks.Models.TruckModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_time");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_modification_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TruckModel", (string)null);
                });

            modelBuilder.Entity("Volvo.Registrations.Trucks.BusinessModels.Trucks.Truck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_time");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("deletion_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_modification_time");

                    b.Property<int>("ManufacturingYear")
                        .HasColumnType("int")
                        .HasColumnName("manufacturing_year");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("model_id");

                    b.HasKey("Id");

                    b.HasIndex("ModelId")
                        .IsUnique();

                    b.ToTable("Truck", (string)null);
                });

            modelBuilder.Entity("Volvo.Registrations.Trucks.BusinessModels.Trucks.Truck", b =>
                {
                    b.HasOne("Volvo.Registrations.Trucks.BusinessModels.Trucks.Models.TruckModel", "TruckModel")
                        .WithOne()
                        .HasForeignKey("Volvo.Registrations.Trucks.BusinessModels.Trucks.Truck", "ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TruckModel");
                });
#pragma warning restore 612, 618
        }
    }
}