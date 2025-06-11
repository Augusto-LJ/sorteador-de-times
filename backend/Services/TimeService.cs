using SorteadorDeTimes.Models;

namespace SorteadorDeTimes.Services
{
    public class TimeService
    {
        Time timeA = new();
        Time timeB = new();
        List<Jogador> jogadoresSobrando = [];

        public TimeService() { }

        public bool DadosRequestSaoInvalidos(SortearTimeRequest request)
        {
            return request.TamanhoDeCadaTime < 6 || request.ListaJogadores.Count < 12;
        }

        public List<Time> SortearTime(SortearTimeRequest request)
        {
            var jogadoresPorFuncao = SepararJogadoresPorFuncao(request.ListaJogadores);

            DefinirGoleiros(jogadoresPorFuncao.Goleiros, request.VaiRevezarNoGol);

            // Apenas separa um para cada, a princípio só para igualar a quantidade
            ColocarPorFuncaoUmJogadorParaCadaTime(jogadoresPorFuncao.Zagueiros);
            ColocarPorFuncaoUmJogadorParaCadaTime(jogadoresPorFuncao.Laterais);
            ColocarPorFuncaoUmJogadorParaCadaTime(jogadoresPorFuncao.Meias);
            ColocarPorFuncaoUmJogadorParaCadaTime(jogadoresPorFuncao.Atacantes);
            
            // Aqui vai a lógica que vai balancear os times de acordo com quantos jogadores cada time tem e com a habilidade total de cada time


            List<Time> timesSorteados = [timeA, timeB];

            return timesSorteados;
        }

        private JogadoresPorFuncao SepararJogadoresPorFuncao(List<Jogador> listaJogadores)
        {
            var jogadoresPorFuncao = new JogadoresPorFuncao()
            {
                Goleiros = [.. listaJogadores.Where(x => x.Funcao == Enum.Enum_Funcoes.Goleiro)],
                Zagueiros = [.. listaJogadores.Where(x => x.Funcao == Enum.Enum_Funcoes.Zagueiro)],
                Laterais = [.. listaJogadores.Where(x => x.Funcao == Enum.Enum_Funcoes.Lateral)],
                Meias = [.. listaJogadores.Where(x => x.Funcao == Enum.Enum_Funcoes.Meio)],
                Atacantes = [.. listaJogadores.Where(x => x.Funcao == Enum.Enum_Funcoes.Atacante)]
            };

            return jogadoresPorFuncao;
        }

        private void DefinirGoleiros(List<Jogador>? goleiros, bool vaiRevesarNoGol)
        {
            if (vaiRevesarNoGol || goleiros is null || goleiros.Count == 0)
                return;

            timeA.AdicionarJogador(goleiros[0]);

            if (goleiros.Count > 1)
                timeB.AdicionarJogador(goleiros[1]);
        }

        private void ColocarPorFuncaoUmJogadorParaCadaTime(List<Jogador>? jogadoresPosicaoEspecifica)
        {
            if (jogadoresPosicaoEspecifica is null || jogadoresPosicaoEspecifica.Count == 0)
                return;

            var jogadoresOrdenadosPorHabilidade = jogadoresPosicaoEspecifica.OrderByDescending(x => x.NivelHabilidade).ToList();
            var deveAdicionarJogadorNoTimeA = timeA.Jogadores.Count <= timeB.Jogadores.Count;

            if (deveAdicionarJogadorNoTimeA)
            {
                timeA.AdicionarJogador(jogadoresPosicaoEspecifica[0]);
                jogadoresPosicaoEspecifica.RemoveAt(0);

                if (jogadoresPosicaoEspecifica.Count > 0)
                {
                    timeB.AdicionarJogador(jogadoresPosicaoEspecifica[0]);
                    jogadoresPosicaoEspecifica.RemoveAt(0);
                }
            }
            else
            {
                timeB.AdicionarJogador(jogadoresPosicaoEspecifica[0]);
                jogadoresPosicaoEspecifica.RemoveAt(0);
                if (jogadoresPosicaoEspecifica.Count > 0)
                {
                    timeA.AdicionarJogador(jogadoresPosicaoEspecifica[0]);
                    jogadoresPosicaoEspecifica.RemoveAt(0);
                }
            }
        }
    }
}
