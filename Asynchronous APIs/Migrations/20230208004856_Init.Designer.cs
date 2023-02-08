﻿// <auto-generated />
using Asynchronous_APIs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsynchronousAPIs.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230208004856_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Asynchronous_APIs.Models.ListingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EstimatedCompetionTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestBody")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestStatus")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ListingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
