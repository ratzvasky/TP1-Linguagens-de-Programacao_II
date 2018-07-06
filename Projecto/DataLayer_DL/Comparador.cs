/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/19/2016 10:44:27 PM
	- Versão: 1.0
	- Descrição: Classe que implementa a interface IComparer para o auxilio de ordenação de ArrayList's
	
*/

using System;
using System.Collections;
using BusinessObject_BO;

namespace DataLayer_DL
{
    /// <summary>
    /// Enumerador para indicar se a ordenação é ascente ou descendente 
    /// </summary>
    public enum DireccaoOrdenacao
    {
        Ascendente,
        Descendente
    }


    /// <summary>
    /// Classe Comparador
    /// </summary>
    class Comparador : IComparer
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        DireccaoOrdenacao direccao;

        #endregion

        #region VariaveisGlobais

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Consctructor Default de comparador
        /// ( Assume que a direcção é ascendente )
        /// </summary>
        public Comparador()
        {
            this.direccao = DireccaoOrdenacao.Ascendente;
        }


        /// <summary>
        /// Consctrutor que recebe por parametro a direcção que é pretendido ordenar
        /// </summary>
        /// <param name="direccao">  Ascente ou Descendente </param>
        public Comparador(DireccaoOrdenacao direccao)
        {
            this.direccao = direccao;
        }

        #endregion


        #region Propriedades

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos

        /// <summary>
        /// Compare do IComparer compara dois objetos
        /// Comparadores disponiveis: Aula
        /// </summary>
        /// <param name="x"> Aula1 </param>
        /// <param name="y"> Aula2 </param>
        /// <returns> -1/0/1 se for menor/igual/maior (-1) tambem se não encontrar o tipo </returns>
        public int Compare(object x, object y)
        {
            #region Variaveis

            Aula aula1, aula2;
            Aluno aluno1, aluno2;

            #endregion


            #region CompararAulas
            // Se o objecto1 for uma aula
            if (x is Aula && y is Aula)
            {
                // Converte os objectos para Aula
                aula1 = x as Aula;
                aula2 = y as Aula;


                // Se a direcção escolhida por Ascedente
                if (direccao == DireccaoOrdenacao.Ascendente)
                    return (aula1.Data > aula2.Data ? 1 : (aula1.Data == aula2.Data ? 0 : -1));

                // Se a direcção for descendente
                else
                    return (aula1.Data > aula2.Data ? -1 : (aula1.Data == aula2.Data ? 0 : 1));
            }

            #endregion


            #region CompararPessoa

            // Se o objecto1 for uma Pessoa
            if ((x is Aluno && y is Aluno) || (x is Docente && y is Docente))
            {
                // Converte os objectos para Aluno
                aluno1 = x as Aluno;
                aluno2 = y as Aluno;


                // Se a direcção escolhida por Ascedente
                if (direccao == DireccaoOrdenacao.Ascendente)
                    return (aluno1.NumeroIdentificacao > aluno2.NumeroIdentificacao ? 1 : (aluno1.NumeroIdentificacao == aluno2.NumeroIdentificacao ? 0 : -1));

                // Se a direcção for descendente
                else
                    return (aluno1.NumeroIdentificacao > aluno2.NumeroIdentificacao ? -1 : (aluno1.NumeroIdentificacao == aluno2.NumeroIdentificacao ? 0 : 1));
            }

            #endregion

            return (-1);

        }

        #endregion


        #endregion


    }
}
