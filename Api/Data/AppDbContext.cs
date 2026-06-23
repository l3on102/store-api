using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}