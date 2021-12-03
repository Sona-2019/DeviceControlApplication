﻿// <auto-generated />
using System;
using DeviceManagement.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeviceManagement.Migrations
{
    [DbContext(typeof(DeviceContext))]
    [Migration("20211203031421_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeviceManagement.Database.Modal.Device", b =>
                {
                    b.Property<int>("deviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("deviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deviceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deviceTemperature")
                        .HasColumnType("int");

                    b.Property<byte[]>("deviceThumbnail")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("deviceUsage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("deviceId");

                    b.ToTable("Device");
                });
#pragma warning restore 612, 618
        }
    }
}
