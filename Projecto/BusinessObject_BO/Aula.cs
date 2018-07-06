/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/17/2016 8:25:15 PM
	- Versão: 1.0
	- Descrição: Classe de "molde" para o objecto aula
	
*/

using System;

namespace BusinessObject_BO
{
    /// <summary>
    /// Enumerado de unidadeCurricular
    /// </summary>
    public enum UnidadeCurricular { naoDefinido, LP, FF, MN, Estatistica, AED };


    /// <summary>
    /// Classe Aula
    /// </summary>
    [Serializable]
    public class Aula
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        DateTime data;
        int numeroDocente;
        int sala;
        string identificacaoTurma;
        UnidadeCurricular unidadeCurricular;

        #endregion

        #region VariaveisGlobais

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Consctructor Default de Aula
        /// </summary>
        public Aula()
        {
            this.data = new DateTime();
            this.numeroDocente = -99999;
            this.sala = -99;
            this.identificacaoTurma = default(string);
            this.unidadeCurricular = default(UnidadeCurricular);
        }


        /// <summary>
        /// Consctructor de Aula que recebe os varios parametros de aula
        /// </summary>
        /// <param name="data"> Data e hora da aula </param>
        /// <param name="docente"> Docente que vai lecionar a aula </param>
        /// <param name="sala"> Numero da sala </param>
        /// <param name="identificacaoTurma"> Identificação da turma </param>
        public Aula(DateTime data, int numeroDocente, int sala, string identificacaoTurma, UnidadeCurricular unidadeCurricular)
        {
            this.data = data;
            this.numeroDocente = numeroDocente;
            this.sala = sala;
            this.identificacaoTurma = identificacaoTurma;
            this.unidadeCurricular = unidadeCurricular;
        }

        #endregion


        #region Propriedades

        /// <summary>
        /// Propriedade de data
        /// </summary>
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }


        /// <summary>
        /// Propriedade de numeroDocente
        /// </summary>
        public int NumeroDocente
        {
            get { return numeroDocente; }
            set { numeroDocente = value; }
        }


        /// <summary>
        /// Propriedade de sala
        /// </summary>
        public int Sala
        {
            get { return sala; }
            set { sala = value; }
        }


        /// <summary>
        /// Propriedade de identificaçãoTurma
        /// </summary>
        public string IdentificacaoTurma
        {
            get { return identificacaoTurma; }
            set { identificacaoTurma = value; }
        }


        /// <summary>
        /// Propriedade de unidadeCurricular
        /// </summary>
        public UnidadeCurricular UnidadeCurricular
        {
            get { return unidadeCurricular; }
            set { unidadeCurricular = value; }
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Método que faz overide ao Equals
        /// (Compara a data e o identificacaoTurma)
        /// </summary>
        /// <param name="obj"> Objecto a ser comparado </param>
        /// <returns> True/False dependo se é igual </returns>
        public override bool Equals(object obj)
        {
            #region Variaveis

            Aula aux = (Aula)obj;

            #endregion

            return (this.data == aux.data && this.identificacaoTurma == aux.identificacaoTurma);
        }


        
        /// <summary>
        /// Método que define o == para o objecto Aula
        /// </summary>
        /// <param name="aula1"> Primeira Aula a comparar </param>
        /// <param name="aula2"> Segunda Aula a comparar </param>
        /// <returns> True/False dependo se é igual </returns>
        public static bool operator ==(Aula aula1, Aula aula2)
        {
            return (aula1.Equals(aula2));
        }

        
        /// <summary>
        /// Método que define o != para o objecto Aula
        /// </summary>
        /// <param name="aula1"> Primeira aula a comparar </param>
        /// <param name="aula2"> Segunda aula a comparar </param>
        /// <returns> True/False dependo se é diferente </returns>
        public static bool operator !=(Aula aula1, Aula aula2)
        {
            return (!aula1.Equals(aula2));
        }
        
    

        #endregion

    
        #region OutrosMetodos

        #endregion


        #endregion


    }
}
