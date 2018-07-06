
/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/5/2016 11:12:56 AM
	- Versão: 1.0
	- Descrição: Classe turma, que contem um conjunto de numeros de alunos
	
*/

using System;
using BusinessObject_BO;

    
namespace DataLayer_DL
{
    /// <summary>
    /// Classe Turma
    /// </summary>
    [Serializable]
    public class Turma
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        string identificacaoTurma;
        int[] conjuntoAlunosIdentificacao;
        int contadorAlunos;

        #endregion

        #region VariaveisGlobais

        const int TAMANHOMAXIMOALUNOS = 30;

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Constructor Default de turma
        /// </summary>
        public Turma()
        {
            this.identificacaoTurma = null;
            this.conjuntoAlunosIdentificacao = new int[TAMANHOMAXIMOALUNOS];
            this.contadorAlunos = 0;
        }


        /// <summary>
        /// Constructor de turma que recebe a sua identificação
        /// (Assume como tamanho do conjunto de alunos valores pre-definidos (30))
        /// </summary>
        /// <param name="identificacaoTurma"> identificação da turma </param>
        public Turma(string identificacaoTurma)
        {
            this.identificacaoTurma = identificacaoTurma;
            this.conjuntoAlunosIdentificacao = new int[TAMANHOMAXIMOALUNOS];
            this.contadorAlunos = 0;
        }



        /// <summary>
        /// Constructor de turma que recebe a sua identificação e o tamanho do conjunto de Alunos
        /// </summary>
        /// <param name="quantidadeAlunos"> Tamanho maximo da turma  </param>
        /// <param name="identificacaoTurma"> identificação da turma </param>
        public Turma(string identificacaoTurma, int quantidadeAlunos)
        {
            this.identificacaoTurma = identificacaoTurma;
            this.conjuntoAlunosIdentificacao = new int[quantidadeAlunos];
            this.contadorAlunos = 0;
        }

        #endregion


        #region Propriedades

        /// <summary>
        /// Propriedade de identificacaoTurma
        /// </summary>
        public string IdentificacaoTurma
        {
            get { return identificacaoTurma; }
            set { identificacaoTurma = value; }
        }


        /// <summary>
        /// Propriedade de conjuntoAlunos
        /// </summary>
        public int[] ConjuntoAlunosIdentificacao
        {
            get { return conjuntoAlunosIdentificacao; }
            set { conjuntoAlunosIdentificacao = value; }
        }


        /// <summary>
        /// Propriedade de contadorAlunos
        /// </summary>
        public int ContadorAlunos
        {
            get { return contadorAlunos; }
        }

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos

        /// <summary>
        /// Método que insere um aluno no conjuntoAlunos
        /// </summary>
        /// <param name="alunoAInserir"> Aluno que desejamos inserir </param>
        /// <returns> Bool Depedendo se inseriu com sucesso </returns>
        public bool InsereAluno(int numeroAlunoAInserir)
        {
            // Verifica se ainda não atingiu o numero max
            if (contadorAlunos <= TAMANHOMAXIMOALUNOS)
            {
                // Verifica se o aluno já existe
                if (ExisteAluno(numeroAlunoAInserir))
                {
                    throw new Exception(" Aluno já existe! ");
                }

                // Se não existir, insere-o
                else
                {
                    // Insere
                    conjuntoAlunosIdentificacao[contadorAlunos] = numeroAlunoAInserir;
                    contadorAlunos++;
                    return (true);
                }            
            }

            return (false);
        }


        /// <summary>
        /// Este método verifica se existe um determinado Aluno no conjuntoAlunos
        /// </summary>
        /// <param name="alunoAVerificar"> Aluno que desejamos verificar se existe </param>
        /// <returns> True/False dependedo se existe </returns>
        public bool ExisteAluno(int numeroAlunoAVerificar)
        {
            // Se não existirem alunos no contador
            if (ContadorAlunos == 0)
            {
                return (false); 
            }

            else
            {
                // Percorre o conjunto de alunos 
                for (int i = 0; i <= contadorAlunos; i++)
                {
                    if (conjuntoAlunosIdentificacao[i] == numeroAlunoAVerificar)
                    {
                        return (true);
                    }
                }
            }

            // Se não existir
            return (false);
        }


        /// <summary>
        /// Método que insere(ou substitui) um conjunto de alunos na turma
        /// </summary>
        /// <param name="conjuntoNumeroAlunos"> int[] com as identificações dos alunos </param>
        /// <returns> bool a indicar o sucesso da operação </returns>
        public bool InsereConjuntoAlunos(int[] conjuntoNumeroAlunos)
        {
            ConjuntoAlunosIdentificacao = conjuntoNumeroAlunos;
            contadorAlunos = conjuntoNumeroAlunos.Length;

            return (true);
        }


        #endregion


        #endregion


    }
}
