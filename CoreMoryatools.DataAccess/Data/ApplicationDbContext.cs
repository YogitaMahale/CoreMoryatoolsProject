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
        public DbSet<Category> Category { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<productimages> productimages { get; set; }
        
    }
}
