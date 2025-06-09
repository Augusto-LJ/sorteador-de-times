using SorteadorDeTimes.Enum;

namespace SorteadorDeTimes.Models
{
    public class Jogador
    {
        /// <summary>
        /// Nome do jogador, do mesmo jeito que foi cadastrado
        /// </summary>
        /// <example>Jogador 01</example>
        public string Nome { get; set; }

        /// <summary>
        /// Nível de habilidade. Deve ser um número decimal de 1 a 10
        /// </summary>
        /// <example>8.5</example>
        public double NivelHabilidade { get; set; }

        /// <summary>
        /// Função que o jogador exerce. Deve ser uma das opções: Goleiro (1), Zagueiro (2), Lateral (3), Meio (4), Atacante (5)
        /// </summary>
        /// <example>Enum.Enum_Funcoes.Atacante</example>
        public Enum_Funcoes Funcao { get; set; }
    }
}
