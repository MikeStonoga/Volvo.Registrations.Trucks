﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volvo.Registrations.Trucks.EfCore.SqlServer;

#nullable disable

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Migrations
{
    [DbContext(typeof(TrucksDbContext))]
    [Migration("20221221022349_Initial_Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}