/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/5/2016 11:21:24 AM
	- Versão: 1.0
	- Descrição: Classe que define o objecto Aluno
	
*/

using System;

namespace BusinessObject_BO
{

    /// <summary>
    /// Classe Aluno
    /// </summary>
    [Serializable]
    public class Aluno : Pessoa
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        bool propinasRegularizadas;

        #endregion

        #region VariaveisGlobais

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Constructor Default de Aluno
        /// (Assume que o Aluno tem as proprinasRegularizadas)
        /// </summary>
        public Aluno()
        {
            this.propinasRegularizadas = true;
        }


        /// <summary>
        /// Constructor de Aluno
        /// </summary>
        /// <param name="nomeAluno"> Nome do aluno </param>
        /// <param name="identificacaoAluno"> Numero de Aluno </param>
        /// <param name="regimeEstudos"> Regime de estudos (Laboral ou pos-Laboral) </param>
        public Aluno(string nomeAluno, int identificacaoAluno, bool propinasRegularizadas) : base(nomeAluno, identificacaoAluno)
        {
            this.propinasRegularizadas = propinasRegularizadas;
        }


        #endregion


        #region Propriedades

        /// <summary>
        /// Propridade de propinasRegularizadas
        /// </summary>
        public bool PropinasRegularizadas
        {
            get { return propinasRegularizadas; }
            set { propinasRegularizadas = value; }
        }

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos

        #endregion


        #endregion


    }
}
