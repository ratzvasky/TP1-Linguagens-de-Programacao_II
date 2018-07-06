/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/3/2016 2:59:23 PM
	- Versão: 1.0
	- Descrição: Classe que gere a entrada de dados da aplicação
	
*/

using System;
using BusinessObject_BO;
using DataLayer_DL;

namespace BusinessLayer_BL
{
    /// <summary>
    /// Classe ValidaDadosInput
    /// </summary>
    public static class ValidaDadosInput
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        #endregion

        #region VariaveisGlobais

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        #endregion


        #region Propriedades

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos

        /// <summary>
        /// Método que insere um aluno no conjuntoAlunos do Pessoas
        /// </summary>
        /// <param name="aluno"> aluno que sejamos inserir </param>
        /// <returns> bool depedendo do sucesso</returns>
        public static bool InsereAluno(Aluno aluno)
        {
            // Regra de negocio
            if (aluno.NumeroIdentificacao > 999 && aluno.NumeroIdentificacao < 100000)
            {
                // Tenta inserir o aluno
                try
                {
                    Pessoas.InsereAluno(aluno);
                    return (true);
                }

                // Envia a exception
                catch (Exception erro)
                {
                    throw erro;
                }
            }

            // Se não respeitar a regra de negocio
            else
            {
                throw new Exception(" - O numero de identificação não é valido !");
            }
        }


        /// <summary>
        /// Método que insere um docente no conjuntoDocentes da classe Pessoas 
        /// </summary>
        /// <param name="docenteAInserir"> Docente que desejamos inserir </param>
        /// <returns> bool dependedo do sucesso </returns>
        public static bool InsereDocente(Docente docenteAInserir)
        {
            // Regra de negocio
            if (docenteAInserir.NumeroIdentificacao > 999 && docenteAInserir.NumeroIdentificacao < 100000)
            {
                // Tenta inserir o aluno
                try
                {
                    Pessoas.InsereDocente(docenteAInserir);
                    return (true);
                }

                // Envia a exception
                catch (Exception erro)
                {
                    throw erro;
                }
            }

            // Se não respeitar a regra de negocio
            else
            {
                throw new Exception(" - O numero de identificação não é valido !");
            }
        }


        /// <summary>
        /// Método que insere uma turma a um determinado curso
        /// </summary>
        /// <param name="nomeTurma"> nome da turma que desejamos inserir </param>
        /// <param name="nomeCurso"> nome do curso que queremos adicionar a turma </param>
        /// <param name="conjuntoNumerosAlunos"> conjunto dos numeros dos alunos da turma </param>
        /// <returns> bool a indicar se inseriou a turma com sucesso </returns>
        public static bool CriaTurma(string nomeTurma, string nomeCurso, int[] conjuntoNumerosAlunos)
        {
            #region Variaveis

            Turma turmaAux;

            #endregion

            // Verifica se o nomeTurma respeita as regras
            if (nomeTurma != null && nomeCurso == Curso.NomeCurso )
            {
                // Cria a turma
                turmaAux = new Turma(nomeTurma);

                // Adiciona os conjuntoNumerosAlunos a turma
                turmaAux.InsereConjuntoAlunos(conjuntoNumerosAlunos);


                // Tenta adicionar a turma ao curso
                try
                {
                    Curso.InsereTurma(turmaAux);
                }

                // Se não lança o erro
                catch (Exception erro)
                {

                    throw erro;
                }


                return (true);
            }

            else
            {
                throw new Exception(" - A nome da turma não é valido ou o Curso não existe! ");
            }
        }



        /// <summary>
        /// Método que insere uma Aula no Aulas
        /// </summary>
        /// <param name="aulaAInserir"> objecto aula a inserir </param>
        /// <param name="nomeCurso"> nome do curso da aula </param>
        /// <returns> bool a indicar se houve sucesso</returns>
        public static bool InsereAula(Aula aulaAInserir, string nomeCurso)
        {
            // Verifica se respeita a regra de negocio
            if (aulaAInserir.Sala < 0 || aulaAInserir.Sala > 50)
            {
                throw new Exception(" - A sala não é valida !");
            }


            // Tenta adicionar a aula a Aulas
            try
            {
                Aulas.InsereAula(aulaAInserir, nomeCurso);
                return (true);
            }


            // Se não conseguir lança erro
            catch (Exception erro)
            {
                throw erro;
            }
        }



        /// <summary>
        /// Método que carrega a informação das classes Pessoas, Curso e Aulas de ficheiro
        /// </summary>
        public static void CarregaInformacao()
        {
            // Tenta carregar pessoas 
            try
            {
                Pessoas.CarregaPessoas();
            }


            catch (Exception)
            {

                throw new Exception(" - Não foi possivel carregar pessoas !");
            }

            /*
            // Tenta carregar Aulas 
            try
            {
                Aulas.CarregaAulas();
            }


            catch (Exception)
            {

                throw new Exception(" - Não foi possivel carregar Aulas !");
            }
            

            // Tenta carregar Curso 
            try
            {
                Curso.CarregaCurso();
            }


            catch (Exception)
            {

                throw new Exception(" - Não foi possivel carregar Curso !");
            }
            */
        }

        #endregion


        #endregion


    }
}
