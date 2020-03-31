using System;
using System.Threading.Tasks;
using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APICaja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        private readonly ILogger<CajaController> _logger = null;
        private readonly IBsTurno _bsTurno = null;
        public CajaController(ILogger<CajaController> logger, IBsTurno bsTurno)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bsTurno = bsTurno ?? throw new ArgumentNullException(nameof(bsTurno));
        }

        [HttpGet("getTest")]
        public ActionResult getTests()
        {
            ObjectResult result;
            int resultado;
            try
            {
                result = Ok("Hola - WEB API .NET CORE");
            }
            catch (Exception ex)
            {
                resultado = 0;
                result = StatusCode(StatusCodes.Status500InternalServerError, resultado);
                _logger.LogInformation($"Ha ocurrido un error: {ex.Message.ToString()}");
            }
            return result;
        }

        [HttpPost("agregarTurno")]
        public async Task<ActionResult> agregarTurno([FromBody]Turno turno)
        {
            ObjectResult result;
            int resultado;
            try
            {
                resultado = await _bsTurno.agregaTurnoJsonAsync(turno);
                result = Ok(resultado == 1 ? "Registro exitoso ": "Intente nuevamente");
            }
            catch (Exception ex)
            {
                resultado = 0;
                result = StatusCode(StatusCodes.Status500InternalServerError, resultado);
                _logger.LogInformation($"Ha ocurrido un error: {ex.Message.ToString()}");
            }            
            return result;
        }

        
    }
}
