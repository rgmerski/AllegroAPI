using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AllegroAPI.Models;


namespace AllegroAPI.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<BillingEntry> BillingEntries { get; set; }
        public DbSet<OfferCost> OfferCosts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
