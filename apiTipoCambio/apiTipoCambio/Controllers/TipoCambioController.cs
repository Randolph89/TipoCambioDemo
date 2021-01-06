using apiTipoCambio.Context;
using apiTipoCambio.Dto.TipoCambio;
using apiTipoCambio.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TipoCambioController: ControllerBase
    {
        private TipoCambioDbContext _context;

        public TipoCambioController(TipoCambioDbContext context)
        {
            _context = context;
        }

        [HttpPost("Actualizar")]
        public async Task<ActionResult> Actualizar([FromBody] TipoCambioDto model)
        {
            var tipoCambio = new TipoCambio();
            tipoCambio.ID = model.ID;
            tipoCambio.Moneda = model.Moneda;
            tipoCambio.ValorTipoCambio = model.ValorTipoCambio;

            _context.TipoCambio.Update(tipoCambio);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("ObtenerTipoCambio/{pMonto}/{pCodMonedaOrigen}/{pCodMonedaDestino}")]
        public async Task<ActionResult> ObtenerTipoCambio(decimal pMonto, int pCodMonedaOrigen, int pCodMonedaDestino)
        {
            var tipoCambio = new TipoCambio();

            if (pMonto > 0)
            {
                var vMonedaOrigen = _context.TipoCambio.First(x => x.ID == pCodMonedaOrigen);
                var vMonedaDestino = _context.TipoCambio.First(x => x.ID == pCodMonedaDestino);


                var vMontoTipoCambio = (pMonto * vMonedaDestino.ValorTipoCambio) / vMonedaOrigen.ValorTipoCambio;

                
                tipoCambio.MonedaOrigen = vMonedaOrigen.Moneda;
                tipoCambio.MonedaDestino = vMonedaDestino.Moneda;
                tipoCambio.ValorTipoCambio = vMonedaDestino.ValorTipoCambio;
                tipoCambio.MontoTipoCambio = vMontoTipoCambio;
                tipoCambio.Monto = pMonto;
            }
            
            return Ok(tipoCambio);
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> Listar()
        {
            var tipoCambios = _context.TipoCambio.ToList();
            return Ok(tipoCambios);
        }
    }
}
