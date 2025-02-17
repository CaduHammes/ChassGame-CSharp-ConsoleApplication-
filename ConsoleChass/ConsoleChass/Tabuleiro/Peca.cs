﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChass.Tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qntMovimentos { get; protected set; }

        public Tab tab { get; protected set; }

        public Peca(Cor cor, Tab tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qntMovimentos = 0;
        }

        public void IncrementarQntDeMovimentos()
        {
            qntMovimentos++;
        }

        public void DecrementarQntDeMovimentos()
        {
            qntMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();


    }
}
