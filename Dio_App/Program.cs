
using System;
using Dio_App.Classes;

namespace Dio_App
{
    class Program{

        static PessoaRepositorio repositorio = new PessoaRepositorio();
        static SerieRepositorio catalogo = new SerieRepositorio();

        static void Main()
        {
            MenuPrincipal();
        }

        private static void Login()
        {
            string login, senha, chave;
            string TipoLogin = "Commum";
            var lista = repositorio.Lista();
            bool Encontrado = false;
        
            System.Console.WriteLine("---LOGIN---");
            System.Console.WriteLine("Digite seu login:");
            login = Console.ReadLine();
            System.Console.WriteLine("Digite sua senha:");
            senha = Console.ReadLine();
        
            for(int i = 0; i < lista.Count; i++)
            {
                if(String.Equals(login, lista[i].retornarLogin()))
                {
                    Encontrado = true;

                    if(String.Equals(senha, lista[i].retornarSenha()))
                    {

                        if( String.Equals(TipoLogin, lista[i].retornarAcesso()))
                        {   
                            if(lista[i].RetornarIsValid())
                            {
                                System.Console.WriteLine("Usuario " + login + " logado com suceso!!");
                                MenuUsuario();
                            }
                            else
                            {
                                System.Console.WriteLine("Acesso bloqueado, Entre em contato com o suporte!");
                                i = lista.Count;
                            }
                            
                        }
                        else
                        {
                            if(lista[i].RetornarIsValid())
                            {
                                System.Console.WriteLine("Entre com a chave de acesso: ");
                                chave = Console.ReadLine();

                                if(String.Equals(chave, lista[i].retornarChave())){
                                    System.Console.WriteLine("Desenvolvedor " + login + " logado com suceso!!");
                                    MenuDesenvolvedor();
                                }
                                else{
                                    System.Console.WriteLine("Chave de acesso inválida, tente novamente!");
                                }
                            }
                            else{
                                System.Console.WriteLine("Acesso bloqueado, Entre em contato com o suporte!");
                                i = lista.Count;
                            }
                                                
                        }         
                        
                    }
                    else{
                        System.Console.WriteLine("Senha inválida, Tente Novamente!");
                    }
                }

                 
            }

            if(!Encontrado)
            {
                System.Console.WriteLine("Usuario não cadastrado no sistema!");
                System.Console.WriteLine("Cadastre-se para aproveitar os nossos serviços!");
                System.Console.WriteLine("Atenciosamente, suporte PABLOFLIX.");
            }

        }
        
        private static void MenuUsuario()
		{
            string opcaoUsuario;

            do{
                Console.WriteLine();
			    Console.WriteLine("---PABLOFLIX---");
			    Console.WriteLine("1- Ver catalogo");
                Console.WriteLine("2- Assistir série");
			    Console.WriteLine("X- Sair");
                Console.WriteLine("Informe a opção desejada:");
                opcaoUsuario = Console.ReadLine(); 

                switch(opcaoUsuario)
				{
					case "1":
                       ListarCatalogo();						
						break;
                        case "2":
                       Assistir();				
						break;
                    case "X":
                        break;
					default:
						System.Console.WriteLine("Entre com uma opcao válida");
                    break;
				}


            }while (opcaoUsuario.ToUpper() != "X");
			
            System.Console.WriteLine("Logout");
		}
        private static void Assistir()
		{
            int indiceSerie;

			Console.Write("Digite o id da série que deseja assistir: ");
			indiceSerie = int.Parse(Console.ReadLine());

			var serie = catalogo.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void ListarCatalogo()
		{
			Console.WriteLine("---CATÁLOGO---");

			var lista = catalogo.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Catálogo vazio.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
                if(!excluido){
                    System.Console.WriteLine("================================================================");
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
				
			}
		}


        private static void MenuCadastro()
		{
            int idade, EntradaAcesso;
            string senha, login, nome;

            Console.WriteLine("---CADASTRO---");
            foreach (int i in Enum.GetValues(typeof(TipoAcesso)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoAcesso), i));
			}

			Console.Write("Digite sua opcao de cadastro acima: ");
			EntradaAcesso = int.Parse(Console.ReadLine());

            Console.Write("Digite o seu nome: ");
			nome = Console.ReadLine();

            Console.Write("Digite sua idade: ");
			idade = int.Parse(Console.ReadLine());

            Console.Write("Digite seu login: ");
			login = Console.ReadLine();

            Console.Write("Digite sua senha: ");
			senha = Console.ReadLine();

			 
            Pessoa novaPessoa = new Pessoa(id: repositorio.ProximoId(),
									acesso: (TipoAcesso)EntradaAcesso,
                                    nome: nome,
									idade: idade,
									Login: login,
									Senha: senha);   

            repositorio.InserirPessoa(novaPessoa);

            System.Console.WriteLine(login + "cadastrado com sucesso!!!");
            Console.WriteLine(); 
        
		
		}

        private static void MenuPrincipal()
		{
            string opcaoUsuario;

            do{
                Console.WriteLine();
			    Console.WriteLine("---BEM VINDO A PABLOFLIX---");
			    Console.WriteLine("1- Login");
			    Console.WriteLine("2- Cadastrar-se");
			    Console.WriteLine("X- Sair");
                Console.WriteLine("Informe a opção desejada:");
			    Console.WriteLine();
                opcaoUsuario = Console.ReadLine(); 

                switch(opcaoUsuario)
				{
					case "1":
                        Login();						
						break;
					case "2":
						MenuCadastro();
						break;
                    case "X":
                        break;
					default:
						System.Console.WriteLine("Entre com uma opcao válida");
                    break;
				}


            }while (opcaoUsuario.ToUpper() != "X");
			
            System.Console.WriteLine("Obrigado por usar nossos serviços! Até a próxima :)");

		}
        private static void MenuDesenvolvedor()
		{
            string opcaoUsuario;

            do
            {
                Console.WriteLine();
			    Console.WriteLine("---MENU DESENVOLVEDOR---");
			    Console.WriteLine("1- Listar séries");
			    Console.WriteLine("2- Inserir nova série");
			    Console.WriteLine("3- Atualizar série");
			    Console.WriteLine("4- Excluir série");
			    Console.WriteLine("5- Visualizar série");
                Console.WriteLine("6- Listar Usuários");
                Console.WriteLine("7- Bloquear usuário");
			    Console.WriteLine("C- Limpar Tela");
			    Console.WriteLine("X- Sair");
                Console.WriteLine("Informe a opção desejada:");
			    opcaoUsuario = Console.ReadLine().ToUpper();

                switch(opcaoUsuario){
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
                    case "6":
                        ListarUsuarios();
                        break;
                    case "7":
                        BloquearUsuario();
                        break;
                    case "C":
						Console.Clear();
						break;
                    case "X":
                        break;
					default:
						System.Console.WriteLine("Entre com uma opcao válida");
                    break;
                }

            }while(opcaoUsuario.ToUpper() != "X");

            System.Console.WriteLine("Logout");
			
		}

        private static void ListarSeries()
		{
			Console.WriteLine("---LISTAR SÉRIES---");

			var lista = catalogo.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("---ADICIONAR NOVA SÉRIE---");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: catalogo.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			catalogo.Insere(novaSerie);
		}

        private static void AtualizarSerie()
		{
            System.Console.WriteLine("---ATUALIZAR SÉRIE---");
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			catalogo.Atualiza(indiceSerie, atualizaSerie);
		}


        private static void ExcluirSerie()
		{
            System.Console.WriteLine("---EXCLUIR SÉRIE DO CATÁLOGO---");
			Console.Write("Digite o id da série: ");

			int indiceSerie = int.Parse(Console.ReadLine());

			catalogo.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{   
            System.Console.WriteLine("---VISUALIZAR SÉRIE---");
			Console.Write("Digite o id da série: ");

			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = catalogo.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

         
        private static void ListarUsuarios()
		{
			Console.WriteLine("---LISTA DE USUÁRIOS---");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma usuário cadastrado.");
				return;
			}

			foreach (var pessoa in lista)
			{
                var aux = pessoa.RetornarIsValid();
                
                System.Console.WriteLine("================================================================");
				Console.WriteLine("#ID {0}: - {1} {2}", pessoa.retornarId(), pessoa.retornarLogin(), (aux ? "*ACESSO BLOQUEADO*" : "ATIVO"));
			}
		}
        
        private static void BloquearUsuario()
		{
            System.Console.WriteLine("---BLOQUEAR USUÁRIO---");
			Console.Write("Digite o id do usuário que deseja bloquear: ");

			int indiceUsuario = int.Parse(Console.ReadLine());

            var bloqueado = repositorio.retornaPorId(indiceUsuario);

            System.Console.WriteLine(bloqueado);
            System.Console.WriteLine("Esse usuário que deseja bloquear?");
            System.Console.WriteLine("1 - Sim" + "\n" + "2 - Não");
            int confirma = int.Parse(Console.ReadLine());

            if(confirma == 1)
            {
            
                repositorio.BloquearAcesso(indiceUsuario);
                System.Console.WriteLine("(0) bloqueado com sucesso", bloqueado.retornarLogin());

            }
            else{
                System.Console.WriteLine("Bloqueio cancelado.");
            }
			
		}
        
    }
}
