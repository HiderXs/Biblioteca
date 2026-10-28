using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    internal class Livro
    {
        public int Id_Livro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public DateTime AnoPublicacao { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public Livro(int id, string titulo, string autor, string genero, DateTime anoPublicacao, int quantidadeDisponivel)
        {
            Id_Livro = id;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            AnoPublicacao = anoPublicacao;
            QuantidadeDisponivel = quantidadeDisponivel;
        }
    }
}
