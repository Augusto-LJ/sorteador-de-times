using Microsoft.AspNetCore.Mvc;
using SorteadorDeTimes.Models;
using SorteadorDeTimes.Services;

namespace SorteadorDeTimes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        /// <summary>
        /// Sorteia e balanceia os times
        /// </summary>
        /// <returns>Lista de times já sorteados e balanceados</returns>
        [HttpPost("SortearTime")]
        [ProducesResponseType(typeof(IEnumerable<List<Jogador>>), StatusCodes.Status200OK)]
        public IActionResult SortearTime(List<Jogador> listaJogadores, int tamanhoDeCadaTime, bool vaiRevesarNoGol)
        {
            var timesSorteados = new TimeService().SortearTime(listaJogadores, tamanhoDeCadaTime, vaiRevesarNoGol);

            return Ok(timesSorteados);
        }
    }
}
