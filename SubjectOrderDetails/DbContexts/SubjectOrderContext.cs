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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    subjectId = 1,
                    firstName = "Daniel",
                    lastName = "Garsden",
                    dateOfBirth = new DateTime(1976, 8, 19)
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
