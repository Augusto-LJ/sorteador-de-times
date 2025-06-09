namespace SorteadorDeTimes.Models
{
    public class Time
    {
        public List<Jogador> Jogadores { get; set; } = [];
        public double SomaNivelHabilidadeJogadores { get; set; } = 0;
        public double MediaNivelHabilidadeJogadores { get; set; } = 0;
        public void AdicionarJogador(Jogador jogador)
        {
            Jogadores.Add(jogador);
            SomaNivelHabilidadeJogadores += jogador.NivelHabilidade;
            MediaNivelHabilidadeJogadores = SomaNivelHabilidadeJogadores / Jogadores.Count;
        }
    };

}
