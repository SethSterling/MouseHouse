using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MouseHouse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MouseHouse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // DbSet for products
        public DbSet<Product> Products { get; set; }
    }
}
