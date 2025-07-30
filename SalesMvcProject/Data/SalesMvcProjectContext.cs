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

        public DbSet<SalesMvcProject.Models.Department> Department { get; set; } = default!;
    }
}
