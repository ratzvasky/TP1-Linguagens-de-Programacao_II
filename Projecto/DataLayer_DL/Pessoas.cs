/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/17/2016 12:00:18 PM
	- Versão: 1.0
	- Descrição: Classe que perserva um conjunto de Alunos[] e de Docentes[]
	
*/

using System;
using BusinessObject_BO;
using System.IO;

namespace DataLayer_DL
{
    /// <summary>
    /// Classe Pessoas
    /// </summary>
    [Serializable]
    public static class Pessoas
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        static Docente[] conjuntoDocentes;
        static int contadorDocentes;
        static Aluno[] conjuntoAlunos;
        static int contadorAlunos;

        #endregion

        #region VariaveisGlobais

        const int MAXALUNOS = 1000;
        const int MAXDOCENTES = 50;


        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Consctructor de Pessoas
        /// </summary>
        static Pessoas()
        {
            conjuntoAlunos = new Aluno[MAXALUNOS];
            conjuntoDocentes = new Docente[MAXDOCENTES];
            contadorAlunos = 0;
            contadorDocentes = 0;
        }


        #endregion


        #region Propriedades

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos


        /// <summary>
        /// Método que insere um aluno ao conjunto, gerado uma exception se o aluno já existir
        /// </summary>
        /// <param name="alunoAInserir"> Aluno que desejamos inserir </param>
        /// <returns> bool a indicar o sucesso da operação </returns>
        public static bool InsereAluno(Aluno alunoAInserir)
        {
            // Verifica se ainda não atingiu o numero max
            if (contadorAlunos < MAXALUNOS)
            {
                // Verifica se o aluno já existe
                if (ExisteAluno(alunoAInserir))
                {
                    throw new Exception(" Aluno já existe! ");
                }

                // Se não existir, insere-o
                else
                {
                    // Insere
                    conjuntoAlunos[contadorAlunos] = alunoAInserir;
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
        static public bool ExisteAluno(Aluno alunoAVerificar)
        {
            // Se não existirem alunos no contador
            if (contadorAlunos == 0)
            {
                return (false);
            }

            else
            {
                // Percorre o conjunto de alunos 
                for (int i = 0; i < contadorAlunos; i++)
                {
                    if (conjuntoAlunos[i] == alunoAVerificar)
                    {
                        return (true);
                    }
                }
            }

            // Se não existir
            return (false);
        }



        /// <summary>
        /// Este método verifica se existe um determinado Aluno no conjuntoAlunos dando apenas a identificação deste
        /// </summary>
        /// <param name="identificacaoAluno"> int com a identificação do aluno </param>
        /// <returns> bool a indicar se o aluno existe ou não </returns>
        static public bool ExisteAluno(int identificacaoAluno)
        {
            // Se não existirem alunos no contador
            if (contadorAlunos == 0)
            {
                return (false);
            }

            else
            {
                // Percorre o conjunto de alunos 
                for (int i = 0; i < contadorAlunos; i++)
                {
                    if (conjuntoAlunos[i].NumeroIdentificacao == identificacaoAluno)
                    {
                        return (true);
                    }
                }
            }

            // Se não existir
            return (false);
        }



        /// <summary>
        /// Este método devolve um aluno dando o numero de identificação
        /// </summary>
        /// <param name="identificacaoAluno"> numero de identificação do aluno </param>
        /// <param name="alunoDesejado"> aluno encontrado </param>
        /// <returns> bool a indicar o sucesso </returns>
        static public bool DevolveAluno (int identificacaoAluno, out Aluno alunoDesejado)
        {
            // Percorre o conjunto de alunos inseridos
            for (int i = 0; i < contadorAlunos; i++)
            {
                // Se encontrar o aluno devolve
                if (conjuntoAlunos[i].NumeroIdentificacao == identificacaoAluno)
                {
                    alunoDesejado = conjuntoAlunos[i];
                    return (true);
                }
            }

            alunoDesejado = default(Aluno);

            return (false);
        }



        /// <summary>
        /// Método que insere um docente no conjuntoDocentes, gera uma exception se o docente já existir
        /// </summary>
        /// <param name="docenteAInserir"> Docente a inserir </param>
        /// <returns> bool dependendo do sucesso da operação </returns>
        public static bool InsereDocente(Docente docenteAInserir)
        {
            // Verifica se ainda não atingiu o numero max
            if (contadorDocentes < MAXDOCENTES)
            {
                // Verifica se o aluno já existe
                if (ExisteDocente(docenteAInserir))
                {
                    throw new Exception(" Docente já existe! ");
                }


                // Se não existir, insere-o
                else
                {
                    // Insere
                    conjuntoDocentes[contadorDocentes] = docenteAInserir;
                    contadorDocentes++;
                    return (true);

                }
            }

            return (false);

        }



        /// <summary>
        /// Método que verifica se um docente existe
        /// </summary>
        /// <param name="DocenteAVerificar"> docente a verificar</param>
        /// <returns> bool dependendo do sucesso da operação </returns>
        static public bool ExisteDocente(Docente DocenteAVerificar)
        {
            // Se não existirem docentes no contador
            if (contadorDocentes == 0)
            {
                return (false);
            }

            else
            {
                // Percorre o conjunto de docentes
                for (int i = 0; i < contadorDocentes; i++)
                {
                    if (conjuntoDocentes[i] == DocenteAVerificar)
                    {
                        return (true);
                    }
                }
            }

            // Se não existir
            return (false);
        }



        /// <summary>
        /// Este método verifica se um docente existe dando apenas a identificação deste
        /// </summary>
        /// <param name="identificacaoDocente"> numero de identificação do docente </param>
        /// <returns> bool a indicar se existe ou não </returns>
        static public bool ExisteDocente(int identificacaoDocente)
        {
            // Se não existirem docentes no contador
            if (contadorDocentes == 0)
            {
                return (false);
            }

            else
            {
                // Percorre o conjunto de docentes 
                for (int i = 0; i < contadorDocentes; i++)
                {
                    if (conjuntoDocentes[i].NumeroIdentificacao == identificacaoDocente)
                    {
                        return (true);
                    }
                }
            }

            // Se não existir
            return (false);
        }



        /// <summary>
        /// Método que devolve um docente dando o numero de identificação 
        /// </summary>
        /// <param name="identificacaoDocente"> numero de identificação do docete </param>
        /// <param name="docenteDesejado"> docente desejado encontrar </param>
        /// <returns> bool a indicar o sucesso da operação </returns>
        static public bool DevolveDocente(int identificacaoDocente, out Docente docenteDesejado)
        {
            // Percorre o conjunto de alunos inseridos
            for (int i = 0; i < contadorDocentes; i++)
            {
                // Se encontrar o aluno devolve
                if (conjuntoDocentes[i].NumeroIdentificacao == identificacaoDocente)
                {
                    docenteDesejado = conjuntoDocentes[i];
                    return (true);
                }
            }

            docenteDesejado = default(Docente);

            return (false);
        }



        /// <summary>
        /// Método que perserva a informação em ficheiro
        /// </summary>
        static public void GuardaPessoas()
        {

            #region Variáveis

            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            #endregion
           
            // Definir caminho absoluto onde o ficheiro de texto será criado e escrito
            caminhoFicheiro = Environment.CurrentDirectory + "//pessoas.dat";


            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados os dados das sessões
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(caminhoFicheiro);


            // Inicializar classe responsável por serializar dados das sessões em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Serializar objecto que contém os dados das sessões em binário
            serializador.Serialize(stream, conjuntoAlunos);
            serializador.Serialize(stream, conjuntoDocentes);
            serializador.Serialize(stream, contadorAlunos);
            serializador.Serialize(stream, contadorDocentes);


            // Fechar stream de escrita de modo a libertar os recursos do sistema
            stream.Close();
       
        }



        /// <summary>
        /// Método que Carrega as pessoas do ficheiro
        /// </summary>
        static public void CarregaPessoas()
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
            conjuntoAlunos = (Aluno[])serializador.Deserialize(stream);
            conjuntoDocentes = (Docente[])serializador.Deserialize(stream);
            contadorDocentes = ((int)serializador.Deserialize(stream));
            contadorAlunos = ((int)serializador.Deserialize(stream));



            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();


        }

        #endregion


        #endregion


    }
}
