using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using Trabalho4.AP.Util;

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
                    case '1': telaFabricante.CadastrarRegistro(); break;

                    case '2': telaFabricante.EditarRegistro(); break;

                    case '3': telaFabricante.ExcluirRegistro(); break;

                    case '4': telaFabricante.VisualizarRegistros(true); break;

                    default: break;
                }
            }

            else if (opcaoPrincipal == '2')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaEquipamento.CadastrarRegistro(); break;

                    case '2': telaEquipamento.EditarRegistro(); break;

                    case '3': telaEquipamento.ExcluirRegistro(); break;

                    case '4': telaEquipamento.VisualizarRegistros(true); break;

                    default: break;
                }
            }

            else if (opcaoPrincipal == '3')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaChamado.CadastrarRegistro(); break;

                    case '2': telaChamado.EditarRegistro(); break;

                    case '3': telaChamado.ExcluirRegistro(); break;

                    case '4': telaChamado.VisualizarRegistros(true); break;

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