/*

	- Nome: Rúben Guimarães    
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/18/2016 10:27:50 PM
	- Versão: 1.0
	- Descrição: Classe usada para gerir tabelas de hash
	
*/

using System;
using System.Collections;
using BusinessObject_BO;


namespace DataLayer_DL
{
    /// <summary>
    /// Classe TabelasDeHash
    /// </summary>
    [Serializable]
    public class TabelaDeHash
    {

        // Declaração do Estado da classe
        #region Estado


        #region Atributos

        static Hashtable tabelaHash;

        #endregion

        #region VariaveisGlobais

        #endregion


        #endregion


        // Declaração dos métodos da classe
        #region Metodos


        #region Constructores

        /// <summary>
        /// Cria uma hashTable com o tamanho default
        /// </summary>
        public TabelaDeHash()
        {
            tabelaHash = new Hashtable();
        }


        /// <summary>
        /// Constructor de tabela de hash que recebe a capacidade maxima da tabela
        /// </summary>
        /// <param name="tamanhoMaxTabela"></param>
        public TabelaDeHash(int tamanhoMaxTabela)
        {
            tabelaHash = new Hashtable(tamanhoMaxTabela);
        }

        #endregion


        #region Propriedades

        #endregion


        #region Operadores

        #endregion


        #region OutrosMetodos

        /// <summary>
        /// Função de Hashing que converte um nome numa chave para a tabela de HASH
        /// ( Tem uma falha caso se tente adicionar, dois m nomes diferentes mas que as letras coicidem ex: ESI e EIS)
        /// </summary>
        /// <param name="nomeID"> Nome Identificador </param>
        /// <param name="tamanhoMaxTabela"> Tamanho Maximo da tabela </param>
        /// <returns> Chave de Hash (int) </returns>
        public int FuncaoHash(string nomeID, int tamanhoMaxTabela)
        {
            #region Variaveis

            char[] aux = nomeID.ToCharArray();
            int chave = 0;

            #endregion

            // Por cada char no nomeCurso adiciona o numero ASCII a chave
            foreach (char caracter in aux)
            {
                chave += (int)caracter;
            }

            // Faz a devisão da chave pelo MAXHASHTABLE e devolve
            return (chave % tamanhoMaxTabela);
        }



        /// <summary>
        /// Método para inserir um objeto numa tabela de hash, usando como chave um nomeIdentificador (Ex. nomeCurso)
        /// </summary>
        /// <param name="objectoAInserir"> Objecto que desejamos inserir </param>
        /// <param name="nomeID"> nome identificador da chave </param>
        /// <param name="tamanhoMaxTabela"> tamanho maximo da tabela </param>
        /// <returns> bool dependedo do sucesso da operação </returns>
        public bool InsereAula(object objectoAInserir, string nomeID, int tamanhoMaxTabela)
        {
            #region Variaveis

            int chave;
            string nomeIDAux;

            #endregion

            // Converte para minusculas
            nomeIDAux = nomeID.ToLower();

            // Descobre a hashkey para o nomeIdentificador
            chave = FuncaoHash(nomeIDAux, tamanhoMaxTabela);


            // Se a tabela de hash não tiver já aquela chave
            if (!tabelaHash.ContainsKey(chave))
                // Cria o array list para aquela chave
                tabelaHash.Add(chave, new ArrayList());


            // Insere a aula no indice da chave
            ((ArrayList)(tabelaHash[chave])).Add(objectoAInserir);


            // Verifica se inseriu com sucesso
            if (((ArrayList)(tabelaHash[chave])).Contains(objectoAInserir))
                return (true);


            // Se não false
            else
                return (false);

        }


        /// <summary>
        /// Devolve a lista que um identificador(chave) possa ter
        /// </summary>
        /// <param name="nomeID"> nome identificador </param>
        /// <param name="tamanhoMaxTabela"> tamanho maximo da tabela </param>
        /// <param name="listaPretendida"> lista que pretendemos obter </param>
        /// <returns> bool indicado se operação teve sucesso (se a chave existe ou não) </returns>
        public bool DevolveListaIdentificador(string nomeID, int tamanhoMaxTabela, out ArrayList listaPretendida)
        {
            #region Variaveis

            int chave;

            #endregion

            // Descobre a hashkey para o nomeIdentificador
            chave = FuncaoHash(nomeID.ToLower(), tamanhoMaxTabela);

            // Se a chave existir
            if (tabelaHash.ContainsKey(chave))
            {
                listaPretendida = (ArrayList)tabelaHash[chave];
                return (true);
            }

            else
                listaPretendida = null;
                return (false);
        }

        #endregion


        #endregion



    }
}
