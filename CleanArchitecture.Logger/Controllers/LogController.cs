using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Logger.Controllers
{
    [Route("Logs")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }
        // POST api/<LogController>
        [HttpPost]
        [Route("ObtenerError")]
        public void Post([FromBody] ErrorDto error)
        {
            _logger.LogError(error.Mensaje);
        }

    }
}
