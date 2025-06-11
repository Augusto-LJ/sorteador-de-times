namespace SorteadorDeTimes.Models
{
    public class SortearTimeRequest
    {
        /// <summary>
        /// Quantidade de jogadores que cada time deve ter. Deve ser maior ou igual a 6.
        /// </summary>
        /// <example>5</example>
        public int TamanhoDeCadaTime { get; set; }

        /// <summary>
        /// Lista de jogadores que devem ser distribuídos nos times. Deve ser maior ou igual a 12.
        /// </summary>
        public List<Jogador> ListaJogadores { get; set; }

        /// <summary>
        /// Define se os jogadores da linha vão revezar no gol. Deve ser false se o goleiro for fixo.
        /// </summary>
        /// <example>true</example>
        public bool VaiRevezarNoGol { get; set; }
    }
}
