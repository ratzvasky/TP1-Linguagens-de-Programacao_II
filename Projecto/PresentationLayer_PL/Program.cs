/*

	- Nome: Rúben Guimarães
	- Numero Aluno: 11156
	- Email: a11156@alunos.ipca.pt
	- Curso: Engenharia de Sistemas Informaticos
	- Data: 5/3/2016 2:56:15 PM
	- Versão: 2.0
	- Descrição: Este projecto é um software que permite ajudar a gestão de uma escola. Neste Momento só permite a inserção de um curso "ESI",
     mas permite adicionar Alunos e Docentes a uma "base de dados" que perserva toda a informação. E adicionar varias turmas e aulas ao curso ESI.
                 

    - TODO: 
            - Corrigir erros de guardar informação em ficheiro.
            - Adicionar nova opção de pesquisa, que forçe o cruzamento de classes.


      

*/

using System;
using BusinessLayer_BL;
using BusinessObject_BO;

namespace PresentationLayer_PL
{
    /// <summary>
    /// Classe Principal (Program)
    /// </summary>
    public class Program
    {

        #region Estado

        #endregion

        #region Métodos

        /// <summary>
        /// Método Principal (Main)
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            #region Variaveis

            int opcaoEscolhida;
            Aluno alunoAux;
            Docente docenteAux;
            int pesquisaAux, pesquisaAux2;
            string nomeTurmaAux, nomeCursoAux;
            const int MAXTURMA = 30;
            int numeroAlunoAux;
            int[] numerosAlunos = new int[MAXTURMA];
            int[] conjuntoAlunos;
            Aula aulaAux;
            Aula[] conjuntoAulas;

            #endregion

            // Ciclo para correr o Menu
            do
            {
                Console.Clear();
                opcaoEscolhida = Menu();

                switch (opcaoEscolhida)
                {

                    // Inserir um aluno
                    case 1:

                        #region RecebeAluno

                        alunoAux = RecebeAluno();

                        // Tenta inserir o aluno
                        try
                        {
                            ValidaDadosInput.InsereAluno(alunoAux);
                            Console.WriteLine("\n - Aluno Inserido com exito!");
                            Console.ReadKey();
                        }

                        // Se não conseguir apresenta o erro
                        catch (Exception erro)
                        {

                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                        }

                        #endregion

                        break;


                    // Inserir um docente
                    case 2:

                        #region InsereDocente

                        docenteAux = RecebeDocente();

                        // Tenta inserir o docente
                        try
                        {
                            ValidaDadosInput.InsereDocente(docenteAux);
                            Console.WriteLine("\n - Docente Inserido com exito!");
                            Console.ReadKey();
                        }

                        // Se não conseguir apresenta o erro
                        catch (Exception erro)
                        {
                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                        }

                        #endregion

                        break;


                    // Consulta de informação
                    case 3:

                        #region ConsultaInformacao

                        Console.Write("\n - Deseja consultar um aluno (1) ou professor (2) ? ");
                        pesquisaAux2 = int.Parse(Console.ReadLine());

                        // Se desejar pesquisar um aluno
                        if (pesquisaAux2 == 1)
                        {
                            Console.Write("\n - Insira o numero do aluno que deseja pesquisar: ");
                            pesquisaAux = int.Parse(Console.ReadLine());


                            // Tentar consultar e apresentar a informação
                            try
                            {
                                alunoAux = ValidaDadosOutput.PesquisaAluno(pesquisaAux);

                                Console.Clear();
                                Console.WriteLine(" Informação do aluno nº{0}", pesquisaAux);
                                Console.WriteLine(@"
Nome: {0}
Propinas pagas ? {1} ", alunoAux.NomePessoa, alunoAux.PropinasRegularizadas);

                                Console.ReadKey();
                            }

                            // Se não lança erros
                            catch (Exception erro)
                            {

                                Console.WriteLine(erro.Message);
                                Console.ReadKey();
                            }

                        }


                        // Se desejar pesquisar um docente 
                        if (pesquisaAux2 == 2)
                        {
                            Console.Write("\n - Insira o numero do docente que deseja pesquisar: ");
                            pesquisaAux = int.Parse(Console.ReadLine());


                            // Tenta consultar
                            try
                            {
                                docenteAux = ValidaDadosOutput.PesquisaDocente(pesquisaAux);

                                Console.Clear();
                                Console.WriteLine(" Informação do Docente nº{0}", pesquisaAux);
                                Console.WriteLine(@"
Nome: {0}
Grau Academico: {1} ", docenteAux.NomePessoa, docenteAux.GrauAcademico);

                                Console.ReadKey();
                            }

                            // Se não lança erro
                            catch (Exception erro)
                            {

                                Console.WriteLine(erro.Message);
                                Console.ReadKey();
                            }
                        }


                        // Se não inserir uma opção correcta
                        else
                        {
                            Console.WriteLine(" - Opção de pesquisa não valida !");
                        }

                        #endregion

                        break;

                    // Criar uma turma
                    case 4:

                        #region CriaTurma

                        // Requista informação
                        Console.Write("\n - Insira o nome da turma: ");
                        nomeTurmaAux = Console.ReadLine();

                        Console.Write("\n - Insira o nome do curso que deseja inserir a turma: ");
                        nomeCursoAux = Console.ReadLine().ToUpper();

                        Console.Write("\n - Insira o numero de aluno para adicionar a turma (0 para terminar): ");
                        numeroAlunoAux = int.Parse(Console.ReadLine());

                        for (int i = 0; i < MAXTURMA; i++)
                        {
                            // Se for inserido o 0 sai
                            if (numeroAlunoAux == 0)
                            {
                                break;
                            }


                            // Verifica se o aluno existe na base de dados
                            if (ValidaDadosOutput.VerificaSeAlunoExiste(numeroAlunoAux))
                            {
                                numerosAlunos[i] = numeroAlunoAux;
                            }


                            // Se não insere o numero
                            else
                            {
                                Console.WriteLine(" - O aluno inserido não existe !");
                                Console.ReadKey();
                            }

                            // Requisita o proximo numero
                            Console.Write("\n - Insira o numero de aluno para adicionar a turma (0 para terminar): ");
                            numeroAlunoAux = int.Parse(Console.ReadLine());
                        }

                        // Tenta adicionar a turma 
                        try
                        {
                            ValidaDadosInput.CriaTurma(nomeTurmaAux, nomeCursoAux, numerosAlunos);
                        }

                        // Se não conseguir apresenta o motivo
                        catch (Exception erro)
                        {
                            Console.WriteLine(erro.Message);
                            Console.WriteLine("\n\n" + erro);
                            Console.ReadKey();
                        }

                        #endregion

                        break;


                    // Lista uma turma
                    case 5:

                        #region ListaTurma

                        // Requisita informação ao utilizador
                        Console.Write("\n - Insira o nome da turma que deseja listar os alunos: ");
                        nomeTurmaAux = Console.ReadLine();

                        Console.Write("\n - Insira o nome do curso: ");
                        nomeCursoAux = Console.ReadLine().ToUpper();


                        // Tenta requistar a informação
                        try
                        {
                            conjuntoAlunos = ValidaDadosOutput.DevolveConjuntoAlunos(nomeTurmaAux, nomeCursoAux);
                        }


                        // Se acorrer um erro
                        catch (Exception erro)
                        {

                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                            break;
                        }


                        // Apresenta os numeros
                        Console.Clear();
                        Console.WriteLine(" - Alunos da turma {0}", nomeTurmaAux);

                        foreach (int numero in conjuntoAlunos)
                        {
                            // Se o numero for 0
                            if (numero == 0)
                            {
                                break;
                            }

                            Console.WriteLine(" - " + numero);

                        }

                        Console.ReadKey();

                        #endregion

                        break;


                    // Cria uma nova aula
                    case 6:

                        #region CriarAula

                        // Tenta receber uma aula
                        try
                        {
                            aulaAux = RecebeAula();
                        }


                        // Se não conseguir, apresenta erro e sai do case
                        catch (Exception erro)
                        {

                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                            break;
                        }

                        // Recebe o nome do curso que desejamos inserir a aula
                        Console.Write("\n - Insira o Curso que deseja inserir a aula: ");
                        nomeCursoAux = Console.ReadLine().ToUpper();

                        // Tenta adicionar a aula
                        try
                        {
                            if (ValidaDadosInput.InsereAula(aulaAux, nomeCursoAux))
                            {
                                Console.WriteLine("\n - Aula Inserida com sucesso!");
                            }

                        }


                        // Se não apresenta erro
                        catch (Exception erro)
                        {
                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                        }


                        #endregion

                        break;


                    // Apresenta a lista de aulas de um curso ordenada
                    case 7:

                        #region ListaAula

                        // Requista informação
                        Console.Write("\n - Insira o nome do curso que deseja consultar as aulas: ");
                        nomeCursoAux = Console.ReadLine().ToUpper();

                        // Tenta requisitar a informaçao
                        try
                        {
                            conjuntoAulas = ValidaDadosOutput.DevolveConjuntoAulas(nomeCursoAux);
                        }

                        // se não conseguir lança o erro
                        catch (Exception erro)
                        {

                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                            break;
                        }

                        // Percorre a informação
                        foreach (Aula aula in conjuntoAulas)
                        {
                            // Apresenta a informação
                            Console.WriteLine("\n\n\t\t ** Aula ** ");
                            Console.Write("\n - Data: {0}", aula.Data);
                            Console.Write("\n Numero Docente Responsavel: {0}", aula.NumeroDocente);
                            Console.Write("\n Sala: {0}", aula.Sala);
                            Console.Write("\n Turma: {0}", aula.IdentificacaoTurma);
                            Console.Write("\n Unidade Curricular: {0}", aula.UnidadeCurricular);
                            Console.WriteLine("\n\n\t\t ** ** ");
                        }

                        Console.ReadKey();

                        #endregion

                        break;


                    // Guarda a informação em ficheiro
                    case 8:

                        #region GuardaInformacao

                        // Tenta guardar a informação 
                        try
                        {
                            ValidaDadosOutput.GuardaInformacao();
                        }


                        catch (Exception erro)
                        {

                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                            break;
                        }

                        finally
                        {
                            Console.WriteLine(" - Informação guardada com sucesso !");
                            Console.ReadKey();
                        }

                        
                        #endregion

                        break;


                    // Carrega as informaçoes
                    case 9:

                        #region CarregaInformacao

                        // Tenta carregar a informação 
                        try
                        {
                            ValidaDadosInput.CarregaInformacao();
                        }


                        catch (Exception erro)
                        {

                            Console.WriteLine(erro.Message);
                            Console.ReadKey();
                            break;
                        }

                        finally
                        {
                            Console.WriteLine(" - Informação Carregada com sucesso!");
                            Console.ReadKey();
                        }

                            

                        #endregion

                        break;


                    // SAIR
                    case 0:

                        Environment.Exit(0);

                        break;



                    // Caso Default
                    default:

                        Console.WriteLine(" Opção não é valida tente novamente !");
                        Console.ReadKey();

                        break;

                }

            } while (opcaoEscolhida != 0);
        }

        #region OutrosMetodos

        /// <summary>
        /// Método que apresenta o Menu e recolhe a opçãoEscolhida
        /// </summary>
        /// <returns></returns>
        static int Menu()
        {

            #region Variaveis

            int opcaoEscolhida;
            bool numeroValido = false;

            #endregion

            // Enquanto não for inserido um numero valido repete o ciclo
            do
            {
                Console.Clear();
                Console.WriteLine("\t   **** GESTOR DE UMA ESCOLA **** ");
                Console.WriteLine("\t     by Rúben Guimarães nº11156 \n");
                Console.Write(@"
    Escolha a opção pretendida:

        1 - Inserir Aluno.
        2 - Inserir Docente.
        3 - Consultar Informação.
        4 - Cria Turma.
        5 - Lista Turma.
        6 - Cria Aula.
        7 - Lista Aulas.
        8 - Guarda Informação.
        9 - Carrega Informação.
        0 - Sai.

    Opção: ");


                // Tentar converter para um inteiro a interação do utilizador
                numeroValido = int.TryParse(Console.ReadLine(), out opcaoEscolhida);


                // Adverte o utilizador que inseriu uma opção invalida
                if (numeroValido == false)
                {
                    Console.WriteLine(" A opção pretendida não é valida tente novamente !");
                    Console.ReadKey();
                }

            } while (!numeroValido);


            // Devolve a opçãoEscolhida
            return (opcaoEscolhida);
        }


        /// <summary>
        /// Método que recebe um aluno do utilizador
        /// </summary>
        /// <returns></returns>
        static Aluno RecebeAluno()
        {
            #region Variaveis

            string nomeAluno;
            int identificacaoAluno;
            bool propinasRegularizadas = false;
            string propinasRegularizadasAux;
            Aluno aluno;

            #endregion

            // Requista informação do utilizador
            Console.Write("\n - Insira o nome do aluno:  ");
            nomeAluno = Console.ReadLine();

            Console.Write("\n - Insira o numero do aluno: ");
            identificacaoAluno = int.Parse(Console.ReadLine());

            Console.Write("\n - O aluno tem as propinhas regularizadas (SIM/NAO)? ");
            propinasRegularizadasAux = Console.ReadLine().ToLower();

            // Regulariza as propinas do aluno
            if (propinasRegularizadasAux == "sim")
            {
                propinasRegularizadas = true;
            }


            // Devolve o aluno
            return (aluno = new Aluno(nomeAluno, identificacaoAluno, propinasRegularizadas));

        }


        /// <summary>
        /// Método que recebe um docente do utilizador
        /// </summary>
        /// <returns></returns>
        static Docente RecebeDocente()
        {
            #region Variaveis

            string nomeDocente;
            int identificacaoDocente;
            GrauAcademico grauAcademico;
            int grauAcademicoAux;
            Docente docente;

            #endregion

            // Requista informação do utilizador
            Console.Write("\n - Insira o nome do Docente:  ");
            nomeDocente = Console.ReadLine();

            Console.Write("\n - Insira o numero do Docente: ");
            identificacaoDocente = int.Parse(Console.ReadLine());

            Console.Write("\n - Qual o grau academico ?  ");
            Console.Write("\n ( 1 - Licenciado, 2 - Mestre, 3 - Doutor ): ");
            grauAcademicoAux = int.Parse(Console.ReadLine());


            // Atribui o grauAcademico correcto
            switch (grauAcademicoAux)
            {
                case 1:
                    grauAcademico = GrauAcademico.Licenciado;
                    break;

                case 2:
                    grauAcademico = GrauAcademico.Mestre;
                    break;

                case 3:
                    grauAcademico = GrauAcademico.Doutor;
                    break;

                default:
                    Console.WriteLine("\n - Algo correu mal com o grau academico do docente !");
                    Console.WriteLine(" - Foi assumido que o docente é licenciado !");
                    grauAcademico = GrauAcademico.Licenciado;
                    break;
            }


            // Devolve o docente
            return (docente = new Docente(nomeDocente, identificacaoDocente, grauAcademico));
        }


        /// <summary>
        /// Método que recebe uma aula do utilizador
        /// </summary>
        /// <returns></returns>
        static Aula RecebeAula()
        {
            #region Variaveis

            DateTime dataAux;
            int numeroDocenteAux, numeroSala, unidadeCurricularAux;
            string nomeTurmaAux;
            UnidadeCurricular unidadeCurricular;
            Aula aula;

            #endregion

            // Requista informação ao utilizador
            Console.Write("\n - Insira uma data para a aula no formato (AAAA-MM-DD HH:MI): ");
            dataAux = DateTime.Parse(Console.ReadLine());

            Console.Write("\n - Insira o numero do docente responsavel pela aula: ");
            numeroDocenteAux = int.Parse(Console.ReadLine());


            // Se o docente não existir, sai
            if (!ValidaDadosOutput.VerificaSeDocenteExiste(numeroDocenteAux))
            {
                throw new Exception("\n - O docente não existe ! Crie primeiro o Docente!");
            }


            Console.Write("\n - Insira o numero da sala para a aula: ");
            numeroSala = int.Parse(Console.ReadLine());

            Console.Write("\n - Insira o nome da turma: ");
            nomeTurmaAux = Console.ReadLine();


            // Se a turma não existir, sai
            if (!ValidaDadosOutput.VerificaSeTurmaExiste(nomeTurmaAux))
            {
                throw new Exception("\n - A turma não existe ! Crie primeiro a Turma!");
            }



            Console.Write("\n - Qual a unidade curricular ?  ");
            Console.Write("\n ( 1 - LP, 2 - FF, 3 - MN, 4 - Estatistica, 5 - AED ): ");
            unidadeCurricularAux = int.Parse(Console.ReadLine());



            // Atribui a unidadeCurricular correcta
            switch (unidadeCurricularAux)
            {
                case 1:
                    unidadeCurricular = UnidadeCurricular.LP;
                    break;

                case 2:
                    unidadeCurricular = UnidadeCurricular.FF;
                    break;

                case 3:
                    unidadeCurricular = UnidadeCurricular.MN;
                    break;

                case 4:
                    unidadeCurricular = UnidadeCurricular.Estatistica;
                    break;

                case 5:
                    unidadeCurricular = UnidadeCurricular.AED;
                    break;

                default:
                    Console.WriteLine("\n - Algo correu mal com a unidade curricular da aula !");
                    Console.WriteLine(" - Foi assumido que a unidade curricular não esta definida !");
                    unidadeCurricular = UnidadeCurricular.naoDefinido;
                    break;
            }

            // Devolve Aula
            return (aula = new Aula(dataAux, numeroDocenteAux, numeroSala, nomeTurmaAux, unidadeCurricular));
        }

        #endregion

        #endregion
    }
}
