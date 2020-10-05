﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubjectOrderDetails.DbContexts;

namespace SubjectOrderDetails.Migrations
{
    [DbContext(typeof(SubjectOrderContext))]
    partial class SubjectOrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("titleId")
                        .HasColumnType("int");

                    b.HasKey("subjectId");

                    b.HasIndex("titleId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            subjectId = 1,
                            dateOfBirth = new DateTimeOffset(new DateTime(1976, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            firstName = "Daniel",
                            lastName = "Garsden",
                            titleId = 1
                        },
                        new
                        {
                            subjectId = 2,
                            dateOfBirth = new DateTimeOffset(new DateTime(2015, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            firstName = "Tamas",
                            lastName = "Garsden",
                            titleId = 3
                        },
                        new
                        {
                            subjectId = 3,
                            dateOfBirth = new DateTimeOffset(new DateTime(2017, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            firstName = "Alma",
                            lastName = "Garsden",
                            titleId = 4
                        });
                });

            modelBuilder.Entity("SubjectOrderDetails.Entities.Title", b =>
                {
                    b.Property<int>("titleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("titleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("titleId");

                    b.ToTable("Titles");

                    b.HasData(
                        new
                        {
                            titleId = 1,
                            titleName = "Mr"
                        },
                        new
                        {
                            titleId = 2,
                            titleName = "Mrs"
                        },
                        new
                        {
                            titleId = 3,
                            titleName = "Master"
                        },
                        new
                        {
                            titleId = 4,
                            titleName = "Miss"
                        });
                });

            modelBuilder.Entity("SubjectOrderDetails.Entities.Subject", b =>
                {
                    b.HasOne("SubjectOrderDetails.Entities.Title", "Title")
                        .WithMany()
                        .HasForeignKey("titleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
