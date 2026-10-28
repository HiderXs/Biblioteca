using ConsoleApp1.Models;
using ConsoleApp1.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Services
{
    internal class LivroService
    {
        LivroRepository livroRepository = new LivroRepository();

        public void AddLivro(Livro livro)
        {

            if (string.IsNullOrWhiteSpace(livro.Titulo))
            {
                Console.WriteLine("O título é obrigatório.");
                return;
            }

            livroRepository.AdicionarLivro(livro);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        public List<Livro> GetAllLivros()
        {
            return livroRepository.GetAllLivros();
        }
    }
}
