using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    internal class Emprestimo
    {
        public int Id_Emprestimo { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
