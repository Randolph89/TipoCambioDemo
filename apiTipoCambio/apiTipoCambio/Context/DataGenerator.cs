using apiTipoCambio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Context
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TipoCambioDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TipoCambioDbContext>>()))
            {
                // Look for any board games already in database.
                if (context.TipoCambio.Any())
                {
                    return;   // Database has been seeded
                }

                context.TipoCambio.AddRange(
                    new TipoCambio
                    {
                        Moneda = "USD",
                        ValorTipoCambio= Convert.ToDecimal(1)
                    },
                    new TipoCambio
                    {
                        Moneda = "SOL PERUANO",
                        ValorTipoCambio = Convert.ToDecimal(3.63)
                    },
                    new TipoCambio
                    {
                        Moneda = "PESO MEXICANO",
                        ValorTipoCambio = Convert.ToDecimal(19.75)
                    },
                    new TipoCambio
                    {
                        Moneda = "PESO ARGENTINO",
                        ValorTipoCambio = Convert.ToDecimal(84.90)
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
