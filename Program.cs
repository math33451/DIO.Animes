using System;

namespace DIO.Animes
{
    class Program
    {
        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() !="X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarAnimes();
                        break;
                    case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();


                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirAnime()
        {
            Console.Write("Digite o id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());
            Console.Write("Tem certeza? (1)Sim (2)Não");
            bool confirmacao = true;
            Console.ReadLine();
            if (confirmacao == true){
               repositorio.Exclui(indiceAnime); 
            }
            else{
                Console.WriteLine("Obrigado por utilizar nossos serviços.");
            }

        }

        private static void VisualizarAnime()
        {
            Console.Write("Digite o id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            var anime = repositorio.RetornaPorId(indiceAnime);

            Console.WriteLine(anime);
        }


        private static void AtualizarAnime()
        {
            Console.Write("Digite o Id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do anime:");
            string entradaDescricao = Console.ReadLine();

            Anime atualizaAnime = new Anime(id: indiceAnime,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceAnime, atualizaAnime);
        }

        private static void ListarAnimes()
        {
            Console.WriteLine("Listar animes");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum anime cadastrado.");
                return;
            }
            foreach (var anime in lista)
            {
                var excluido = anime.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", anime.retornaId(), anime.retornaTitulo(), (excluido ? "*Excluido*" : " "));
            }
        }

        private static void InserirAnime()
        {
            Console.WriteLine("Inserir novo anime");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do anime:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do anime:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do anime:");
            string entradaDescricao = Console.ReadLine();

            Anime novoAnime = new Anime(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoAnime);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seja bem-vinde ao DIO Animes!");
            Console.WriteLine("Informe a Opção desejada:");

            Console.WriteLine("1- Listar animes");
            Console.WriteLine("2- Inserir novo anime");
            Console.WriteLine("3- Atualizar anime");
            Console.WriteLine("4- Excluir anime");
            Console.WriteLine("5- Visualizar anime");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
