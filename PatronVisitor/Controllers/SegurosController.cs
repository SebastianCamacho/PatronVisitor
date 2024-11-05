using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatronVisitor.Models;
using PatronVisitor.Visitor;

namespace PatronVisitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private static readonly List<ISeguro> _seguros = new List<ISeguro>();

        // POST /seguros - Para crear un seguro
        [HttpPost]
        public IActionResult CrearSeguro([FromBody] SeguroDTO seguroDTO)
        {
            ISeguro seguro = seguroDTO.Tipo switch
            {
                "vida" => new SeguroVida(seguroDTO.Monto),
                "robo" => new SeguroRobo(seguroDTO.Monto),
                "jubilacion" => new PlanJubilacion(seguroDTO.Monto),
                _ => null
            };

            if (seguro == null)
                return BadRequest("Tipo de seguro no válido.");

            _seguros.Add(seguro);
            return Ok("Seguro creado exitosamente.");
        }

        // GET /reporte - Para generar el reporte SIRIA
        [HttpGet("reporte")]
        public IActionResult ObtenerReporte()
        {
            if (!_seguros.Any())
                return Ok("No hay seguros registrados.");

            var visitorReporteSir = new VisitorReporteSir();
            foreach (var seguro in _seguros)
            {
                seguro.Accept(visitorReporteSir);
            }

            var reporte = visitorReporteSir.GetReporte();
            return Ok(reporte);
        }
    }
    public class SeguroDTO
    {
        public string Tipo { get; set; }
        public double Monto { get; set; }
    }
}
