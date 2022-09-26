using DTS_EntityFrameworks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTS_EntityFrameworks.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<DbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Region> Regions { get; set; }


    }
}
