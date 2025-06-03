namespace SorteadorDeTimes.Models
{
    public class Jogador
    {
        /// <summary>
        /// Nome do jogador, do mesmo jeito que foi cadastrado
        /// </summary>
        /// <example>Augusto Lima Jardim</example>
        public string Nome { get; set; }

        /// <summary>
        /// Nível de habilidade. Deve ser um número decimal de 1 a 10
        /// </summary>
        /// <example>8.5</example>
        public double NivelHabilidade { get; set; }

        /// <summary>
        /// Função que o jogador exerce. Deve ser uma das opções: goleiro, zagueiro, lateral, meio, atacante
        /// </summary>
        /// <example>Atacante</example>
        public string Funcao { get; set; }
    }
}
