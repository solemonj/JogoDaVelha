using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class JogoDaVelha
    {

        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int jogada = 0;

        public JogoDaVelha() //metodo construtor indicando que fim de jogo é falso e o arraw de posições
        {
            fimDeJogo = false;
            posicoes = new[] {'1','2','3','4','5','6','7','8','9'};
            vez = 'X';
        }

        //metodo para iniciar o jogo
        //jogos rodam em grande loop - diversas rodadas acontecendo em sequencia

        public void Iniciar()
        {
            while (!fimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarVez();
            }
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            if (jogada < 5)
                return;
            if (ExiteVitoriaHorizontal() || ExisteVitoriaVertcial() || ExiteVitoriaDiagonal())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!! Vítoria de {vez}");
            }
            if (jogada == 9)
            {
                fimDeJogo = true;
                Console.WriteLine("Fim de jogo!! EMPATE");
            }
        }

        private bool ExiteVitoriaHorizontal()
        {
            bool linha1 = posicoes[0] == posicoes[1] && posicoes[1] == posicoes[2];
            bool linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return linha1 || linha2 || linha3;
        }

        private bool ExisteVitoriaVertcial()
        {
            bool coluna1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool coluna2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool coluna3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return coluna1 || coluna2 || coluna3;
        }

        private bool ExiteVitoriaDiagonal()
        {
            bool diagonal1 = posicoes[0] == posicoes[4] && posicoes[4] == posicoes[8];
            bool diagonal2 = posicoes[2] == posicoes[4] && posicoes[4] == posicoes[6];

            return diagonal1 || diagonal2;  
        }



        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, escolha entre uma posição de 1 a 9 que esteja disponível na tabela");


            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida)) //vaida se a entrada é válida (número e se ainda nao está ocupada)
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            posicoes[indice] = vez;

            jogada++;
        }

        private bool ValidarEscolhaUsuario (int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            return (posicoes[indice] != 'O' && posicoes[indice] != 'X');
        } 

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}
