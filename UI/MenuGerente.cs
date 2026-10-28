using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI
{
    internal class MenuGerente
    {
        public int opcaoSelecionada { get; set; }
        

        public void ExibirMenu()
        {
            Console.Clear();
            LivroService livroService = new LivroService();
            Console.WriteLine("=== Menu Gerente ===");
            Console.WriteLine("1. Adicionar Livro");
            Console.WriteLine("2. Listar Livros");
            Console.WriteLine("3. Excluir Livro");
            Console.WriteLine("4. Atualizar Livro");
            Console.WriteLine("5. Listar Livros Disponíveis");
            Console.WriteLine("6. Listar Livros Indisponíveis");
            Console.WriteLine("7. Listar Usuários");
            Console.WriteLine("8. Sair");
            Console.Write("Escolha uma opção: ");
            opcaoSelecionada = Convert.ToInt32(Console.ReadLine());
            switch (opcaoSelecionada)
            {
                case 1:
                    Console.Clear();
                    while (true)
                    {
                        try
                        {
                            Console.Write("Digite o título: ");
                            string titulo = Console.ReadLine();

                            Console.Write("Digite o autor: ");
                            string autor = Console.ReadLine();

                            Console.Write("Digite o gênero: ");
                            string genero = Console.ReadLine();

                            Console.WriteLine("Digite o ano de publicação no formato YYYY-MM-DD: ");
                            DateTime anoPublicacao = Convert.ToDateTime(Console.ReadLine());

                            Console.Write("Digite a quantidade disponível: ");
                            int quantidade = Convert.ToInt32(Console.ReadLine());

                            Livro livro = new Livro(0, titulo, autor, genero, anoPublicacao, quantidade);
                            livroService.AddLivro(livro);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato de data inválido. Por favor, use o formato YYYY-MM-DD.");
                            Console.WriteLine("Digite s para tentar novamente ou qualquer outra tecla para sair: ");
                            string opc = Console.ReadLine();
                            if (opc.ToUpper() == "S")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                            Console.WriteLine("Deseja tentar novamente? (S/N)");
                            string opc = Console.ReadLine();
                            if (opc.ToUpper() == "S")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=== Livros Disponíveis ===");
                    List <Livro> livros = livroService.GetAllLivros();
                    foreach (Livro livro in livros)
                    {
                        Console.WriteLine($"- {livro.Titulo} por {livro.Autor}");
                    }
                    break;
                case 3:
                    // Chamar método para excluir livro
                    break;
                case 4:
                    // Chamar método para atualizar livro
                    break;
                case 5:
                    // Chamar método para listar livros disponíveis
                    break;
                case 6:
                    // Chamar método para listar livros indisponíveis
                    break;
                case 7:
                    // Chamar método para listar usuários
                    break;
                case 8:
                    Console.WriteLine("Saindo do menu gerente...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
