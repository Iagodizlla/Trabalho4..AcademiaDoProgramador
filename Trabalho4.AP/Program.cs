using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloChamado;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;
using Trabalho4.AP.Util;

namespace Trabalho4.AP;

class Program
{
    static void Main(string[] args)
    {
        Menu telaPrincipal = new Menu();

        while (true)
        {
            telaPrincipal.ApresentarMenuPrincipal();

            TelaBase telaSelecionada = telaPrincipal.ObterTela();

            char opcaoEscolhida = telaSelecionada.ApresentarMenu();

            switch (opcaoEscolhida)
            {
                case '1': telaSelecionada.CadastrarRegistro(); break;

                case '2': telaSelecionada.EditarRegistro(); break;

                case '3': telaSelecionada.ExcluirRegistro(); break;

                case '4': telaSelecionada.VisualizarRegistros(true); break;

                default: break;
            }
        }
    }
}