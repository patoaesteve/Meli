using Pato.Services;
using Pato.WebApi.Models;
using System.Web.Http;

namespace Pato.WebApi.Controllers
{
    public class ClimaController : ApiController
    {
        [Route("api/clima/{dia:int}")]
        [HttpGet]
        public ClimaResponse Clima(int dia)
        {
            var sistema = BigBang.CrearSistema();

            return new ClimaResponse
            {
                Dia = dia,
                Clima = sistema.GetClima(dia).Clima
            };
        }
    }
}
