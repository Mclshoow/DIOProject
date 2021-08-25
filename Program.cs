using System;

namespace DIO.Series
{
    class Program
    {
        static FilmeRepositorio repositorioF = new FilmeRepositorio();
        static SerieRepositorio repositorioS = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            //string opcaoF = OpcaoFilme();
            //string opcaoS = OpcaoSerie();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "6":
                        ListarSeries();
                        break;
                    case "7":
                        InserirSerie();
                        break;
                    case "8":
                        AtualizarSerie();
                        break;
                    case "9":
                        ExcluirSerie();
                        break;
                    case "10":
                        VisualizarSerie();
                        break;   
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            
            }

            Console.WriteLine("Obrigado por utilizar nossos servicos!");
            Console.ReadLine();


            /*while (opcaoF.ToUpper() != "V")
            {
                switch (opcaoF)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;    
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        return;
                }
            }
            

            while (opcaoS.ToUpper() != "V")
            {
                switch (opcaoS)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;    
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        return;
                }
            }*/

            

        }
        // Filmes --------------------------------------------------------------------------------------------------------------------------------------------------
        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes.");

            var listaF = repositorioF.Lista();

            if (listaF.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }
            
            foreach (var filme in listaF)
            {
                Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
            }
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme.");

            foreach (int f in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", f, Enum.GetName(typeof(Genero), f));
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGeneroF = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do filme: ");
            string entradaTituloF = Console.ReadLine();

            Console.Write("Digite o ano do filme: ");
            int entradaAnoF = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao do filme: ");
            string entradaDescricaoF = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioF.ProximoId(),
                                        genero: (Genero)entradaGeneroF,
                                        titulo: entradaTituloF,
                                        ano: entradaAnoF,
                                        descricao: entradaDescricaoF);
            repositorioF.Insere(novoFilme);
        }

        private static void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int f in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", f, Enum.GetName(typeof(Genero), f));
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGeneroF = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do filme: ");
            string entradaTituloF = Console.ReadLine();

            Console.Write("Digite o ano do filme: ");
            int entradaAnoF = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao do filme: ");
            string entradaDescricaoF = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                            genero: (Genero)entradaGeneroF,
                                            titulo: entradaTituloF,
                                            ano: entradaAnoF,
                                            descricao: entradaDescricaoF);
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioF.Exclui(indiceFilme);
        }
        
        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioF.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        // Series --------------------------------------------------------------------------------------------------------------------------------------------------
        private static void ListarSeries()
        {
            Console.WriteLine("Listar series.");

            var listaS = repositorioS.Lista();

            if (listaS.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }
            
            foreach (var serie in listaS)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie.");

            foreach (int s in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", s, Enum.GetName(typeof(Genero), s));
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGeneroS = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do serie: ");
            string entradaTituloS = Console.ReadLine();

            Console.Write("Digite o ano da serie: ");
            int entradaAnoS = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricaoS = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorioS.ProximoId(),
                                        genero: (Genero)entradaGeneroS,
                                        titulo: entradaTituloS,
                                        ano: entradaAnoS,
                                        descricao: entradaDescricaoS);
            repositorioS.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int s in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", s, Enum.GetName(typeof(Genero), s));
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGeneroS = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do serie: ");
            string entradaTituloS = Console.ReadLine();

            Console.Write("Digite o ano do serie: ");
            int entradaAnoS = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao do serie: ");
            string entradaDescricaoS = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGeneroS,
                                            titulo: entradaTituloS,
                                            ano: entradaAnoS,
                                            descricao: entradaDescricaoS);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioS.Exclui(indiceSerie);
        }
        
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioS.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        // Menu --------------------------------------------------------------------------------------------------------------------------------------------------
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Projeto DIO - Filmes e Series.");
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine(" Menu filmes ");
            
            Console.WriteLine("1- Listar filmes.");
            Console.WriteLine("2- Inserir filme.");
            Console.WriteLine("3- Atualizar filme.");
            Console.WriteLine("4- Excluir filme.");
            Console.WriteLine("5- Visualizar filme.");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" Menu Series ");

            Console.WriteLine("6- Listar series.");
            Console.WriteLine("7- Inserir serie.");
            Console.WriteLine("8- Atualizar serie.");
            Console.WriteLine("9- Excluir serie.");
            Console.WriteLine("10- Visualizar serie.");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("C- Limpar tela.");
            Console.WriteLine("X- Sair.");

            string opcaoUsuario = Console.ReadLine()//.ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        /*        private static string OpcaoFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Projeto DIO - Filmes.");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1- Listar filmes.");
            Console.WriteLine("2- Inserir um novo filme.");
            Console.WriteLine("3- Atualizar filme.");
            Console.WriteLine("4- Excluir filmee.");
            Console.WriteLine("5- Visualizar filme.");
            Console.WriteLine("C- Limpar Tela.");
            Console.WriteLine("V- Voltar ao menu principal.");
            Console.WriteLine();

            string opcaoF = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoF;

            
        }

        private static string OpcaoSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Projeto DIO - Series.");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1- Listar series.");
            Console.WriteLine("2- Inserir uma nova serie.");
            Console.WriteLine("3- Atualizar serie.");
            Console.WriteLine("4- Excluir serie.");
            Console.WriteLine("5- Visualizar serie.");
            Console.WriteLine("C- Limpar Tela.");
            Console.WriteLine("V- Voltar ao menu principal.");
            Console.WriteLine();

            string opcaoS = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoS;
        }
        */
        
    }
}
