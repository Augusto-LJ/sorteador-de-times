using Microsoft.AspNetCore.Mvc;
using SorteadorDeTimes.Models;

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
        public IActionResult SortearTime(List<Jogador> listaJogadores)
        {
            return Ok(listaJogadores);
        }
    }
}
