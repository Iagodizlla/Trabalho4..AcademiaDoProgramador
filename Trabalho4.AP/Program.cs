using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RepositorioFabricante repositorioFabricante = new RepositorioFabricante();
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
        RepositorioChamado repositorioChamado = new RepositorioChamado();

        TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante);
        TelaEquipamento telaEquipamento = new TelaEquipamento(repositorioEquipamento, repositorioFabricante);
        TelaChamado telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);

        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.ApresentarMenuPrincipal();

            if (opcaoPrincipal == '1')
            {
                char opcaoEscolhida = telaFabricante.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaFabricante.CadastrarFabricante(); break;

                    case '2': telaFabricante.EditarFabricante(); break;

                    case '3': telaFabricante.ExcluirFabricante(); break;

                    case '4': telaFabricante.VisualizarFabricantes(true); break;

                    default: break;
                }
            }

            else if (opcaoPrincipal == '2')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaEquipamento.CadastrarEquipamento(); break;

                    case '2': telaEquipamento.EditarEquipamento(); break;

                    case '3': telaEquipamento.ExcluirEquipamento(); break;

                    case '4': telaEquipamento.VisualizarEquipamentos(true); break;

                    default: break;
                }
            }

            else if (opcaoPrincipal == '3')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaChamado.CadastrarChamado(); break;

                    case '2': telaChamado.EditarChamado(); break;

                    case '3': telaChamado.ExcluirChamado(); break;

                    case '4': telaChamado.VisualizarChamados(true); break;

                    default: break;
                }
            }
            else
            {
                break;
            }
        }
    }
}