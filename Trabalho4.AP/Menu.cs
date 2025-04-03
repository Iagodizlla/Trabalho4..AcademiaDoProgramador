using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    public static class Menu
    {
        public static char ApresentarMenuPrincipal()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Gerência de Equipamentos");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()![0];

            return opcaoEscolhida;
        }

        public static void ExibirCabecalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }
    }
}