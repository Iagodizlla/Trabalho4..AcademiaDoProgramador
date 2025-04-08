using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using Trabalho4.AP.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();
        TelaFabricante telaFabricante = new TelaFabricante();
        RepositorioEquipamento repositorioEquipamento = telaEquipamento.repositorioEquipamento;
        TelaChamado telaChamado = new TelaChamado(repositorioEquipamento);
        Menu telaPrincipal = new Menu();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.ApresentarMenuPrincipal();
            if (opcaoPrincipal == '1')
            {
                char opcaoEscolhida = telaPrincipal.ApresentarMenuEquipamento();
                switch (opcaoEscolhida)
                {
                    case '1': telaEquipamento.CadastrarEquipamento(); break;
                    case '2': telaEquipamento.EditarEquipamento(); break;
                    case '3': telaEquipamento.ExcluirEquipamento(); break;
                    case '4': telaEquipamento.VisualizarEquipamentos(true); break;
                    default: break;
                }
            }
            else if (opcaoPrincipal == '2')
            {
                char opcaoEscolhida = telaPrincipal.ApresentarMenuChamado();
                switch (opcaoEscolhida)
                {
                    case '1': telaChamado.CadastrarChamado(); break;
                    case '2': telaChamado.EditarChamado(); break;
                    case '3': telaChamado.ExcluirChamado(); break;
                    case '4': telaChamado.VisualizarChamados(true); break;
                    default: break;
                }
            }
            else if(opcaoPrincipal == '3')
            {
                char opcaoEscolhida = telaPrincipal.ApresentarMenuFabricante();
                switch (opcaoEscolhida)
                {
                    case '1': telaFabricante.CadastrarFabricante(); break;
                    case '2': telaFabricante.EditarFabricante(); break;
                    //case '3': telaFabricante.ExcluirFabricante(); break;
                    case '4': telaFabricante.VisualizarFabricantes(true); break;
                    default: break;
                }
            }
            else if(opcaoPrincipal == 'S')
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente.");
                Console.ReadLine();
            }
        }
    }
}