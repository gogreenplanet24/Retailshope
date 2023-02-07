using Microsoft.EntityFrameworkCore;
using Retailshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retailshop
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
        public DbSet<Product> Products
        {
            get;
            set;
        }
        public DbSet<Order> Orders
        {
            get;
            set;
        }
    }
}
