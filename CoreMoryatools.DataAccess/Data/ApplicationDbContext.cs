using System;
using System.Collections.Generic;
using System.Text;
using CoreMoryatools.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreMoryatools.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Your code setting up foreign keys of whatever!
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<productimages> productimages { get; set; }
       public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<country> country { get; set; }
        public DbSet<state> state { get; set; }
        public DbSet<city> city { get; set; }

    }
}
