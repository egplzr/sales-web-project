using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvcProject.Models;

namespace SalesMvcProject.Data
{
    public class SalesMvcProjectContext : DbContext
    {
        public SalesMvcProjectContext (DbContextOptions<SalesMvcProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
