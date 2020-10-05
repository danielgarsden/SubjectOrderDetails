﻿using Microsoft.EntityFrameworkCore;
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
    }
}
