using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    internal class Devolucao
    {
        public int Id_Devolucao { get; set; }
        public int Id_Emprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int multa { get; set; }
    }
}
