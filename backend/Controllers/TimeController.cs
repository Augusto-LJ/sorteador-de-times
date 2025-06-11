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
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult SortearTime(SortearTimeRequest request)
        {
            TimeService timeService = new();

            if (timeService.DadosRequestSaoInvalidos(request))
                return BadRequest("Dados da requisição inválidos");

            var timesSorteados = timeService.SortearTime(request);

            return Ok(timesSorteados);
        }
    }
}
