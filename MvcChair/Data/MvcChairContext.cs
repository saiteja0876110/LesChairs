using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcChair.Models;

namespace MvcChair.Data
{
    public class MvcChairContext : DbContext
    {
        public MvcChairContext (DbContextOptions<MvcChairContext> options)
            : base(options)
        {
        }

        public DbSet<MvcChair.Models.Chair> Chair { get; set; } = default!;
    }
}
