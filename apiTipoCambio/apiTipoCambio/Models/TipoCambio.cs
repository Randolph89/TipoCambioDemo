using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Models
{
    public class TipoCambio
    {
        public int ID { get; set; }
        public string Moneda { get; set; }
        public Decimal Monto { get; set; }
        public Decimal ValorTipoCambio { get; set; }
        public Decimal MontoTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
    }
}
