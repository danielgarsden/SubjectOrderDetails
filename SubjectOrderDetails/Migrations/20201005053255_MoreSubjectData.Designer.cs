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
    [DbContext(typeof(SubjectOrderContext))]
    [Migration("20201005053255_MoreSubjectData")]
    partial class MoreSubjectData
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
                        },
                        new
                        {
                            subjectId = 2,
                            dateOfBirth = new DateTimeOffset(new DateTime(2015, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            firstName = "Tamas",
                            lastName = "Garsden"
                        },
                        new
                        {
                            subjectId = 3,
                            dateOfBirth = new DateTimeOffset(new DateTime(2017, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            firstName = "Alma",
                            lastName = "Garsden"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}