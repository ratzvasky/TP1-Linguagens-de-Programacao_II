/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/7/2016 5:48:34 PM
	- Versão: 1.0
	- Descrição: Classe que reune toda a informação sobre turma, e os elementos que as compoe para poder ser tratada/guardada. (Esta definido como o unico curso de ESI)




*/

using System;
using BusinessObject_BO;
using System.IO;

namespace DataLayer_DL
{
    /// <summary>
    /// Enumerado de regimeEstudos
    /// </summary>
    public enum RegimeEstudos { laboral, PosLaboral};

    /// <summary>
    /// Classe ConjuntoTurma
    /// </summary>
    [Serializable]
    public static class Curso
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        static string nomeCurso;
        static Turma[] conjuntoTurma;
        static int contadorTurmasInseridas;
        static Aula[] conjuntoAulas;
        static int contadorAulasInseridas;

        #endregion

        #region VariaveisGlobais

        const int MAXIMOTURMAS = 5;
        const int MAXIMOAULAS = 520;

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Constructor de ConjuntoTurmas
        /// </summary>
       static Curso()
        {
            nomeCurso = "ESI";
            conjuntoTurma = new Turma[MAXIMOTURMAS];
            contadorTurmasInseridas = 0;
            conjuntoAulas = new Aula[MAXIMOAULAS];
            contadorAulasInseridas = 0;
        }

        #endregion


        #region Propriedades

        /// <summary>
        /// Propriedade de nomeCurso
        /// </summary>
        public static string NomeCurso
        {
            get { return nomeCurso; }
            set { nomeCurso = value; }
        }


        /// <summary>
        /// Propriedade contadorTurmasInseridas
        /// </summary>
        public static int ContadorTurmasInseridas
        {
            get { return contadorTurmasInseridas; }
        }


        /// <summary>
        /// Propriedade contadorAulasInseridas
        /// </summary>
        public static int ContadorAulasInseridas
        {
            get { return contadorAulasInseridas; }
        }

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos

        /// <summary>
        /// Este método insere um aluno na turma desejada
        /// ( Se não conseguir são geradas exception com a mesagem de erro do porque)
        /// </summary>
        /// <param name="AlunoAInserir"> Aluno que desejamos inserir</param>
        /// <param name="identificacaoTurma"> Indentificação da turma pretendida </param>
        /// <returns> Bool dependendo do sucesso da operação </returns>
        public static bool InsereAluno(int numeroAluno, string identificacaoTurma)
        {
            #region Variaveis

            int indiceTurma;

            #endregion

            // Verifica se a turma existe
            if (VerificaSeTurmaExiste(identificacaoTurma, out indiceTurma))
            {
                // Verifica se na turma em questão ja existe o aluno
                if (conjuntoTurma[indiceTurma].ExisteAluno(numeroAluno))
                {
                    throw new Exception(" Aluno já existe! ");
                }

                // Se não existir, insere-o
                else
                {
                    conjuntoTurma[indiceTurma].InsereAluno(numeroAluno);
                    return (true);
                }
            }

            // Se a turma não existir
            else
            {
                throw new Exception("A turma não existe! ");
            }
        }



        /// <summary>
        /// Este método verifica se existe alguma turma com uma identificacaoTurma igual e devolve o indice desta
        /// </summary>
        /// <param name="identificacaoTurma"> Identificação da turma </param>
        /// <param name="indiceTurma"> Indice onde a turma se encontra (-99 é porque não existe) </param>
        /// <returns> Bool dependendo de a turma existir </returns>
        static bool VerificaSeTurmaExiste(string identificacaoTurma, out int indiceTurma)
        {
            // Percorre o conjuntoTurma
            for (int i = 0; i <= contadorTurmasInseridas; i++)
            {
                // Se a turma existir
                if (conjuntoTurma[i].IdentificacaoTurma == identificacaoTurma)
                {
                    indiceTurma = i;

                    return (true);
                }
            }

            // Se não existir
            indiceTurma = -99;
            return (false);
        }



        /// <summary>
        /// Este método verifica se existe alguma turma com uma identificacaoTurma igual
        /// </summary>
        /// <param name="identificacaoTurma"> Identificação da turma </param>
        /// <returns> bool Dependendo de a turma existir  </returns>
        /// ///
        public static bool VerificaSeTurmaExiste(string identificacaoTurma)
        {
            if (contadorTurmasInseridas == 0)
            {
                return (false);
            }

            // Percorre o conjuntoTurma
            for (int i = 0; i < contadorTurmasInseridas; i++)
            {
                if (conjuntoTurma[i] == null)
                {
                    return (false);
                }

                // Se a turma existir
                if (conjuntoTurma[i].IdentificacaoTurma == identificacaoTurma)
                {
                    return (true);
                }
            }

            // Se não existir
            return (false);
        }


        /// <summary>
        /// Método que insere uma turma no conjuntoTurmas
        /// </summary>
        /// <param name="turmaAInserir"> turma que desejamos inserir </param>
        /// <returns> bool a indicar o sucesso da operação </returns>
        public static bool InsereTurma(Turma turmaAInserir)
        {
            #region Variaveis

            #endregion

            // Se já tiver 5 turmas
            if (contadorTurmasInseridas == MAXIMOTURMAS)
            {
                throw new Exception(" - Atingiu o maximo de turmas para este curso! ");
            }

            // Verifica se a turma existe
            if (!VerificaSeTurmaExiste(turmaAInserir.IdentificacaoTurma))
            {
                conjuntoTurma[contadorTurmasInseridas] = turmaAInserir;
                contadorTurmasInseridas++;
                return (true);
            }

            // se já existir
            else
            {
                throw new Exception(" - A Turma já existe !");
            }


        }


        /// <summary>
        /// Método que devolve um int[] com os numerosAlunos de uma determinada turma
        /// </summary>
        /// <param name="identificacaoTurma"> nome da turma </param>
        /// <returns> int[] com os numeros dos alunos </returns>
        public static int[] DevolveAlunosTurma(string identificacaoTurma)
        {
            #region Variaveis

            int indiceTurma;

            #endregion

            // Se a turma existir, obtem logo o indice desta
            if (VerificaSeTurmaExiste(identificacaoTurma, out indiceTurma))
            {
                return (conjuntoTurma[indiceTurma].ConjuntoAlunosIdentificacao);
            }

            else
            {
                throw new Exception(" - Não foi possivel obter o indice da turma");
            }
        }



        /// <summary>
        /// Método que guarda a informação em ficheiro do curso
        /// </summary>
        static public void GuardaCurso()
        {

            #region Variáveis

            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            #endregion

            // Definir caminho absoluto onde o ficheiro de texto será criado e escrito
            caminhoFicheiro = Environment.CurrentDirectory + "//curso.dat";


            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados os dados das sessões
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(caminhoFicheiro);


            // Inicializar classe responsável por serializar dados das sessões em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Serializar objecto que contém os dados das sessões em binário
            serializador.Serialize(stream, nomeCurso);
            serializador.Serialize(stream, conjuntoTurma);
            serializador.Serialize(stream, contadorTurmasInseridas);
            serializador.Serialize(stream, conjuntoAulas);
            serializador.Serialize(stream, contadorAulasInseridas);      

            // Fechar stream de escrita de modo a libertar os recursos do sistema
            stream.Close();

        }



        /// <summary>
        /// Método que carrega a informação de ficheiro do curso
        /// </summary>
        static public void CarregaCurso()
        {

            #region Variáveis

            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            #endregion


            // Definir caminho absoluto de onde o ficheiro de texto será carregado
            caminhoFicheiro = Environment.CurrentDirectory + "//pessoas.dat";


            // Se o ficheiro alvo não existir, ignorar o resto das iterações do presente método
            if (File.Exists(caminhoFicheiro) == false) return;


            // Inicializar stream de leitura através da abertura do ficheiro onde os dados das sessões estão guardados  
            stream = File.Open(caminhoFicheiro, FileMode.Open);


            // Inicializar classe responsável por serializar dados das sessões em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Carregar binário "desserializado" para o objecto que contém os dados das sessões
            nomeCurso = (string)serializador.Deserialize(stream);
            conjuntoTurma = (Turma[])serializador.Deserialize(stream);
            contadorTurmasInseridas = ((int)serializador.Deserialize(stream));
            conjuntoAulas = ((Aula[])serializador.Deserialize(stream));
            contadorAulasInseridas = ((int)serializador.Deserialize(stream));



            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();


        }

        #endregion


        #endregion


    }
}
