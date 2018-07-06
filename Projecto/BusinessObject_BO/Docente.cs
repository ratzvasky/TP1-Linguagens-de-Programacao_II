/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/3/2016 3:14:18 PM
	- Versão: 1.0
	- Descrição: Classe Docente que deriva da classe Pessoa
	
*/

using System;

namespace BusinessObject_BO
{
    /// <summary>
    /// Enumerado de Unidade Curricular
    /// </summary>
    public enum GrauAcademico { Licenciado = 1, Mestre, Doutor}


    /// <summary>
    /// Classe Docente
    /// </summary>
    [Serializable]
    public class Docente : Pessoa
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        GrauAcademico grauAcademico;

        #endregion

        #region VariaveisGlobais

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Constructor Default de Docente
        /// (Atribui o GrauAcademico como Licenciado)
        /// </summary>
        public Docente()
        {
            this.grauAcademico = default(GrauAcademico);
        }


        /// <summary>
        /// Constructor de Docente
        /// </summary>
        /// <param name="nomeDocente"> Nome do docente </param>
        /// <param name="numeroIdentificacao"> numero de identificaçao </param>
        /// <param name="unidadeCurricular"> Unidade Curricular que o docente leciona </param>
        public Docente(string nomeDocente, int numeroIdentificacao, GrauAcademico grauAcademico) :base (nomeDocente, numeroIdentificacao)
        {
            this.grauAcademico = grauAcademico;
        }


        #endregion


        #region Propriedades

        /// <summary>
        /// Propriedade de GrauAcademico
        /// </summary>
        public GrauAcademico GrauAcademico
        {
            get { return grauAcademico; }
            set { grauAcademico = value; }
        }

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos

        #endregion


        #endregion


    }
}
