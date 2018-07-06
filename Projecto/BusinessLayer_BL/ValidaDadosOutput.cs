/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/23/2016 6:10:44 PM
	- Versão: 1.0
	- Descrição: Classe que gere a saida de dados da aplicação
	
*/

using System;
using BusinessObject_BO;
using DataLayer_DL;
using System.Collections;

namespace BusinessLayer_BL
{
    /// <summary>
    /// Classe ValidaDadosOutput
    /// </summary>
    public static class ValidaDadosOutput
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
        /// Método que controla a pesquisa de um aluno
        /// </summary>
        /// <param name="identificacaoAluno"> numero de aluno </param>
        /// <returns> o Aluno desejado </returns>
        public static Aluno PesquisaAluno(int identificacaoAluno)
        {
            #region Variaveis
            Aluno alunoAux;

            #endregion

            // Verifica se o aluno existe
            if (!Pessoas.ExisteAluno(identificacaoAluno))
            {
                throw new Exception(" - Não foi encontrado um aluno com esse numero!");
            }

            else
            {
                if (Pessoas.DevolveAluno(identificacaoAluno, out alunoAux))
                {
                    return alunoAux;
                }

                throw new Exception(" - Não foi possivel devolver o aluno !");
            }

        }



        /// <summary>
        /// Método que verifica se um determinado aluno existe no Pessoas 
        /// </summary>
        /// <param name="numeroAluno"> numero do aluno que desejamos verificar </param>
        /// <returns> bool a indicar se existe </returns>
        public static bool VerificaSeAlunoExiste(int numeroAluno)
        {
            // Verifica se o aluno existe
            if (!Pessoas.ExisteAluno(numeroAluno))
            {
                return (false);
            }

            // Se existir ...
            else
            {
                return (true);
            }
        }



        /// <summary>
        /// Método que verifica se um determinado Docente existe no Pessoas
        /// </summary>
        /// <param name="numeroDocente"> numero do docente </param>
        /// <returns> bool a indicar se existe ou não </returns>
        public static bool VerificaSeDocenteExiste(int numeroDocente)
        {
            // Verifica se o Docente existe
            if (!Pessoas.ExisteDocente(numeroDocente))
            {
                return (false);
            }

            // Se existir ...
            else
            {
                return (true);
            }
        }



        /// <summary>
        /// Método que verifica se uma determinada Turma existe
        /// </summary>
        /// <param name="nomeTurma"> nome da turma </param>
        /// <returns> bool a indicar se a turma existe ou não </returns>
        public static bool VerificaSeTurmaExiste(string nomeTurma)
        {
            // Verifica se o Turma existe
            if (!Curso.VerificaSeTurmaExiste(nomeTurma))
            {
                return (false);
            }

            // Se existir ...
            else
            {
                return (true);
            }
        }



        /// <summary>
        /// Método que controla a pesquisa de um aluno 
        /// </summary>
        /// <param name="identificacaoDocente"> numero de identificação de um docente </param>
        /// <returns> Devolve o docente desejado </returns>
        public static Docente PesquisaDocente(int identificacaoDocente)
        {
            #region Variaveis
            Docente docenteAux;

            #endregion

            // Verifica se o docente existe
            if (!Pessoas.ExisteDocente(identificacaoDocente))
            {
                throw new Exception(" - Não foi encontrado um Docente com esse numero!");
            }

            else
            {
                if (Pessoas.DevolveDocente(identificacaoDocente, out docenteAux))
                {
                    return docenteAux;
                }

                throw new Exception(" - Não foi possivel devolver o Docente !");
            }

        }



        /// <summary>
        /// Método que devolve o conjunto de alunos de uma turma dando o nome do curso e nome da turma 
        /// </summary>
        /// <param name="nomeTurma"> nome da turma </param>
        /// <param name="nomeCurso"> nome do curso </param>
        /// <returns> int[] com os numeros dos alunos </returns>
        public static int[] DevolveConjuntoAlunos(string nomeTurma, string nomeCurso)
        {
            #region Variaveis

            int[] conjuntoNumerosAlunos;

            #endregion

            // Se o nome do curso estiver correcto
            if (nomeCurso == Curso.NomeCurso)
            {
                // Verifica se a turma existe
                if (Curso.VerificaSeTurmaExiste(nomeTurma))
                {
                    // Se existir devolve o conjunto
                    conjuntoNumerosAlunos = Curso.DevolveAlunosTurma(nomeTurma);
                    return (conjuntoNumerosAlunos);
                }


                // Se não atira erro
                else
                {
                    throw new Exception(" - A turma não existe !");
                }
            }


            // Se não atira erro
            else
            {
                throw new Exception(" - O curso não existe !!");
            }

        }



        /// <summary>
        /// Método que permite obter um conjunto de aulas ordenadas de um determinado curso
        /// </summary>
        /// <param name="nomeCurso"> nome do curso </param>
        /// <returns> Aula[] com as aulas do curso ordenadas </returns>
        public static Aula[] DevolveConjuntoAulas(string nomeCurso)
        {
            #region Variaveis

            ArrayList listaAux;
            Aula[] conjuntoAulas;

            #endregion

            // Tenta Receber a lista ordenada
            try
            {               
                listaAux = Aulas.DevolveAulasCursoOrdenados(nomeCurso);
            }


            // Lança o erro
            catch (Exception erro)
            {

                throw erro;
            }
         

            // Converte a lista num array
            conjuntoAulas = listaAux.ToArray(typeof(Aula)) as Aula[];

            // Devolve as aulas
            return (conjuntoAulas);
        }



        /// <summary>
        /// Método que guarda a informação de Pessoas, Curso e Aulas em ficheiro Binario
        /// </summary>
        public static void GuardaInformacao()
        {
            // Tenta guardar Pessoas
            try
            {
                Pessoas.GuardaPessoas();
            }

            // Se não conseguir lança erro
            catch (Exception)
            {

                throw new Exception(" - Não foi possivel guardar pessoas !");
            }

            /*
            // Tenta guarda aulas
            try
            {
                Aulas.GuardaAulas();
            }

            // Se não conseguir lança erro
            catch (Exception)
            {

                throw new Exception(" - Não foi possivel guardar aulas !");
            }
            

            // Tenta guarda Curso
            try
            {
                Curso.GuardaCurso();
            }

            // Se não conseguir lança erro
            catch (Exception)
            {

                throw new Exception(" - Não foi possivel guardar curso !");
            }
            */

        }


        #endregion




        #endregion


    }
}
