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

        public JogoDaVelha() //metodo construtor indicando que fim de jogo é falso e o arraw de posições
        {
            fimDeJogo = false;
            posicoes = new[] {'1','2','3','4','5','6','7','8','9'};
            vez = 'x';
        }

        //metodo para iniciar o jogo
        //jogos rodam em grande loop - diversas rodadas acontecendo em sequencia

        public void Iniciar(char[] posicoes)
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
            vez = vez == 'x' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            throw new NotImplementedException();
        }

        private void LerEscolhaDoUsuario()
        {
            throw new NotImplementedException();
        }

        private void RenderizarTabela()
        {
            throw new NotImplementedException();
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  ";
        }
    }
}
