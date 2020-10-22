using Microsoft.EntityFrameworkCore;
using SubjectOrderDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.DbContexts
{
    /// <summary>
    /// Class to interact with the SubjectOrderDetails Database
    /// </summary>
    public class SubjectOrderContext : DbContext
    {
        /// <summary>
        /// Constructor that calls the base constructor
        /// </summary>
        /// <param name="options"></param>
        public SubjectOrderContext(DbContextOptions<SubjectOrderContext> options) : base(options)
        {

        }

        /// <summary>
        /// A DBset of subjects
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// A DbSet of titles
        /// </summary>
        public DbSet<Title> Titles { get; set; }

        /// <summary>
        /// Create some dummy data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    SubjectId = 1,
                    FirstName = "Daniel",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(1976, 8, 19),
                    TitleId = 1
                },
                new Subject()
                {
                    SubjectId = 2,
                    FirstName = "Tamas",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(2015, 11, 29),
                    TitleId = 3
                },
                new Subject()
                {
                    SubjectId = 3,
                    FirstName = "Alma",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(2017, 11, 16),
                    TitleId = 4
                },
                new Subject()
                {
                    SubjectId = 4,
                    FirstName = "Phillip",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(1949, 10, 05),
                    TitleId = 4
                },
                 new Subject()
                 {
                     SubjectId = 5,
                     FirstName = "Jennifer",
                     LastName = "Garsden",
                     DateOfBirth = new DateTime(1986, 07, 17),
                     TitleId = 4
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
