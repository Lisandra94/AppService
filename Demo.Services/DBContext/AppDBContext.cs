using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using App.Services.Models;

namespace App.Services.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
               : base(options)
        {
        }

        public DbSet<PersonModel> Person { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>().ToTable("Person");

        }
    }
}
