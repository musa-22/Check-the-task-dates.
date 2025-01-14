﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.DATA;

#nullable disable

namespace Reminder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250114105853_newDataSeed")]
    partial class newDataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Reminder.Model.Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("leftDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("startData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("totalDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("detailsDb");
                });
#pragma warning restore 612, 618
        }
    }
}