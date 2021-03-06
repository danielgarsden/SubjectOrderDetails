﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubjectOrderDetails.DbContexts;

namespace SubjectOrderDetails.Migrations
{
#pragma warning disable CS1591

    [DbContext(typeof(SubjectOrderContext))]
    [Migration("20201005051527_InititalMigration")]
    partial class InititalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SubjectOrderDetails.Entities.Subject", b =>
                {
                    b.Property<int>("subjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("dateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("subjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            subjectId = 1,
                            dateOfBirth = new DateTimeOffset(new DateTime(1976, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            firstName = "Daniel",
                            lastName = "Garsden"
                        });
                });
#pragma warning restore 612, 618
        }
    }

#pragma warning restore CS1591
}
