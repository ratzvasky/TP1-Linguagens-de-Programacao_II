/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/18/2016 6:48:02 PM
	- Versão: 1.0
	- Descrição: Classe que vai guardas todas as aulas de todos os cursos
	
*/

using System;
using System.Collections;
using BusinessObject_BO;
using System.IO;

namespace DataLayer_DL
{
    /// <summary>
    /// Classe Aulas
    /// </summary>
    [Serializable]
    public static class Aulas
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        static TabelaDeHash conjuntoAulas;

        #endregion

        #region VariaveisGlobais

        const int MAXHASHTABLE = 10; // Maximo 10 cursos

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Consctructor de Aulas (Cria uma HashTable com tamanho maximo de 10 cursos)
        /// </summary>
        static Aulas()
        {
            conjuntoAulas = new TabelaDeHash(MAXHASHTABLE);
        }


        #endregion


        #region Propriedades

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos


        /// <summary>
        /// Método usado para inserir uma aula na tabela de hash do conjunto de aulas
        /// </summary>
        /// <param name="aulaAInserir"> aula que desejamos inserir </param>
        /// <param name="nomeCurso"> nome do curso para ser usado como chave </param>
        /// <returns> Bool dependedo do sucesso da operação </returns>
        static public bool InsereAula(Aula aulaAInserir, string nomeCurso)
        {
            // Se conseguir Adicionar
            if (conjuntoAulas.InsereAula(aulaAInserir, nomeCurso, MAXHASHTABLE))
            {
                return true;
            }

            // Se não atira erro
            else
            {
                throw new Exception(" Não foi possivel adicionar aula a tabela de hash");
            }
        }



        /// <summary>
        /// Método que devolve uma lista de aulas de um curso dando o nome do curso prentedido
        /// </summary>
        /// <param name="nomeCurso"> Nome do curso pretendido </param>
        /// <returns> ArrayList com as aulas </returns>
        static public ArrayList DevolveAulasCurso(string nomeCurso)
        {
            #region Variaveis

            ArrayList aux;

            #endregion

            // Se conseguir obter a lista com o nomeCurso
            if (conjuntoAulas.DevolveListaIdentificador(nomeCurso, MAXHASHTABLE, out aux))
            {
                return aux;
            }

            else
            {
                throw new Exception(" O curso não existe");
            }
        }



        /// <summary>
        /// Método que devolve uma lista de aulas de um curso dando o nome do curso prentedido
        /// </summary>
        /// <param name="nomeCurso"> Nome do curso pretendido </param>
        /// <returns> ArrayList com as aulas ordenadas </returns>
        static public ArrayList DevolveAulasCursoOrdenados(string nomeCurso)
        {
            #region Variaveis

            ArrayList aux;

            #endregion

            // Se conseguir obter a lista com o nomeCurso
            if (conjuntoAulas.DevolveListaIdentificador(nomeCurso, MAXHASHTABLE, out aux))
            {
                aux.Sort(new Comparador());

                return aux;
            }

            else
            {
                throw new Exception("\n - O curso não existe, ou as aulas não podem ser ordenadas");
            }
        }


        /// <summary>
        /// Método que guarda em ficheiro as aulas
        /// </summary>
        static public void GuardaAulas()
        {

            #region Variáveis

            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            #endregion

            // Definir caminho absoluto onde o ficheiro de texto será criado e escrito
            caminhoFicheiro = Environment.CurrentDirectory + "//aulas.dat";


            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados os dados das sessões
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(caminhoFicheiro);


            // Inicializar classe responsável por serializar dados das sessões em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Serializar objecto que contém os dados das sessões em binário
            serializador.Serialize(stream, conjuntoAulas);



            // Fechar stream de escrita de modo a libertar os recursos do sistema
            stream.Close();

        }



        /// <summary>
        /// Método que carregaAulas de ficheiro
        /// </summary>
        static public void CarregaAulas()
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
            conjuntoAulas = (TabelaDeHash)serializador.Deserialize(stream);


            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();
        }

        #endregion


        #endregion


    }
}
