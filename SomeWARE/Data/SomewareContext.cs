using Microsoft.EntityFrameworkCore;
using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Data
{
    public class SomewareContext : DbContext
    {
        public SomewareContext(DbContextOptions<SomewareContext> options)
            :base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
    }
}