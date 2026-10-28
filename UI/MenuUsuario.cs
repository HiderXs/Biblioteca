using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI
{
    internal class MenuUsuario
    {
        public int opcaoSelecionada { get; set; }

        public void ExibirMenu()
        {
            LivroService livroService = new LivroService();
            Console.WriteLine("=== Menu Usuario ===");
            Console.WriteLine("1. Listar Livros Disponíveis");
            Console.WriteLine("2. Listar Livros Indisponíveis");
            Console.WriteLine("3. Fazer Empréstimo");
            Console.WriteLine("4. Fazer devolução");
            Console.WriteLine("5. Pagar multa");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            opcaoSelecionada = Convert.ToInt32(Console.ReadLine());
            switch (opcaoSelecionada)
            {
                case 1:
                    // Chamar método para listar livros disponíveis
                    break;
                case 2:
                    // Chamar método para listar livros indisponíveis
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=== Livros Disponíveis ===");
                    List<Livro> livros = livroService.GetAllLivros();
                    foreach (Livro livro in livros)
                    {
                        Console.WriteLine($"- {livro.Id_Livro} - {livro.Titulo} por {livro.Autor}");
                    }
                    Console.WriteLine("Digite o ID do livro que deseja fazer emprestimo: ");
                    int idLivro = Convert.ToInt32(Console.ReadLine());
                    break;
                case 4:
                    // Chamar método para fazer devolução
                    break;
                case 5:
                    // Chamar método para pagar multa
                    break;
                case 6:
                    Console.WriteLine("Saindo do menu usuário...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
