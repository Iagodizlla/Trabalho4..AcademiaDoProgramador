using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    public static class Menu
    {
        public static void ExibirCabecalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|   Gestão de Equipamentos e Chamados  |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }
        public static char ApresentarMenuPrincipal()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Gerência de Equipamentos");
            Console.WriteLine("2 - Gerência de Chamados");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()!.ToUpper()[0];

            return opcaoEscolhida;
        }

        public static void ExibirCabecalhoEquipamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }
        public static void ExibirCabecalhoChamado()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|          Gestão de Chamados          |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }
    }
}