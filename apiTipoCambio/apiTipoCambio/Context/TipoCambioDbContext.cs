using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Context
{
    public class TipoCambioDbContext : DbContext
    {
        public TipoCambioDbContext(DbContextOptions<TipoCambioDbContext> options)
    : base(options)
        {
        }

        public DbSet<Models.TipoCambio> TipoCambio { get; set; }
    }
}
