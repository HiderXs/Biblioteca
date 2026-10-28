using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI
{
    internal class MenuPrincipal
    {
        public int opcaoSelecionada { get; set; }
        MenuGerente menuGerente = new MenuGerente();
        MenuUsuario menuUsuario = new MenuUsuario();
        public void ExibirMenu()
        {
            Console.WriteLine("=== Menu Principal ===");
            Console.WriteLine("1. Usuario");
            Console.WriteLine("2. Gerente");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            opcaoSelecionada = Convert.ToInt32(Console.ReadLine());
            switch (opcaoSelecionada)
            {
                case 1:
                    menuUsuario.ExibirMenu();
                    break;
                case 2:
                    menuGerente.ExibirMenu();
                    break;
                case 3:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
