using Microsoft.EntityFrameworkCore;
using SubjectOrderDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.DbContexts
{
    public class SubjectOrderContext : DbContext
    {
        public SubjectOrderContext(DbContextOptions<SubjectOrderContext> options) : base(options)
        {

        }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    subjectId = 1,
                    firstName = "Daniel",
                    lastName = "Garsden",
                    dateOfBirth = new DateTime(1976, 8, 19),
                    titleId = 1
                },
                new Subject()
                {
                    subjectId = 2,
                    firstName = "Tamas",
                    lastName = "Garsden",
                    dateOfBirth = new DateTime(2015, 11, 29),
                    titleId = 3
                },
                new Subject()
                {
                    subjectId = 3,
                    firstName = "Alma",
                    lastName = "Garsden",
                    dateOfBirth = new DateTime(2017, 11, 16),
                    titleId = 4
                }
                );

            modelBuilder.Entity<Title>().HasData(
                new Title()
                {
                    titleId = 1,
                    titleName = "Mr"
                },
                new Title()
                {
                    titleId = 2,
                    titleName = "Mrs"
                },
                new Title()
                {
                    titleId = 3,
                    titleName = "Master"
                },
                new Title()
                {
                    titleId = 4,
                    titleName = "Miss"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
