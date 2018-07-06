/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/3/2016 2:59:05 PM
	- Versão: 1.0
	- Descrição: Esta classe absctracta sera o "molde" para as clases que derivam desta (Docente e Aluno)
	
*/

using System;

namespace BusinessObject_BO
{
    /// <summary>
    /// Classe Abstracta Pessoa
    /// </summary>
    [Serializable]
    public abstract class Pessoa
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        string nomePessoa;
        int numeroIdentificacao;

        #endregion

        #region VariaveisGlobais

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Consctructor Default de pessoa
        /// </summary>
        public Pessoa()
        {
            nomePessoa = "Não atribuido";
            numeroIdentificacao = -99999;
        }


        /// <summary>
        /// Consctructor de Pessoa que recebe os parametros do exterior
        /// </summary>
        /// <param name="nomePessoa"> Nome da pessoa </param>
        /// <param name="numeroIdentificacao"> Numero Identificação 'xxxxx' </param>
        public Pessoa(string nomePessoa, int numeroIdentificacao)
        {
            this.nomePessoa = nomePessoa;
            this.numeroIdentificacao = numeroIdentificacao;
        }


        #endregion


        #region Propriedades

        /// <summary>
        /// Propriedade De nomePessoa
        /// </summary>
        public string NomePessoa
        {
            get { return nomePessoa; }
            set { nomePessoa = value; }
        }


        /// <summary>
        /// Propriedade De numeroIdentificacao
        /// </summary>
        public int NumeroIdentificacao
        {
            get { return numeroIdentificacao; }
            set { numeroIdentificacao = value; }
        }


        #endregion


        #region Operadores

        /// <summary>
        /// Método que faz overide ao Equals
        /// (Compara o nomePessoa e o numeroIdentificação)
        /// </summary>
        /// <param name="obj"> Objecto a ser comparado </param>
        /// <returns> True/False dependo se é igual </returns>
        public override bool Equals(object obj)
        {
            #region Variaveis

            Pessoa aux = (Pessoa)obj;

            #endregion

            return (this.nomePessoa == aux.nomePessoa && this.numeroIdentificacao == aux.numeroIdentificacao);
        }


        /// <summary>
        /// Método que define o == para o objecto Pessoa
        /// </summary>
        /// <param name="pessoa1"> Primeira Pessoa a comparar </param>
        /// <param name="pessoa2"> Segunda Pessoa a comparar </param>
        /// <returns> True/False dependo se é igual </returns>
        public static bool operator ==(Pessoa pessoa1, Pessoa pessoa2)
        {
            return (pessoa1.Equals(pessoa2));
        }


        /// <summary>
        /// Método que define o != para o objecto Pessoa
        /// </summary>
        /// <param name="pessoa1"> Primeira Pessoa a comparar </param>
        /// <param name="pessoa2"> Segunda Pessoa a comparar </param>
        /// <returns> True/False dependo se é diferente </returns>
        public static bool operator !=(Pessoa pessoa1, Pessoa pessoa2)
        {
            return (!pessoa1.Equals(pessoa2));
        }

        #endregion


        #region OutrosMetodos

        #endregion


        #endregion


    }
}
