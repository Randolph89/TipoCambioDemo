using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Dto.TipoCambio
{
    public class TipoCambioDto
    {
        public int  ID { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public string Moneda { get; set; }
        public Decimal ValorTipoCambio { get; set; }
        public Decimal MontoTipoCambio { get; set; }
    }
}
