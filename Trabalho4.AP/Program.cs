namespace Trabalho4.AP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquipamento = new TelaEquipamento();

            bool opcaoSairEscolhida = false;

            while (!opcaoSairEscolhida)
            {
                char opcaoPrincipalEscolhida = Menu.ApresentarMenuPrincipal();
                char operacaoEscolhida;

                switch (opcaoPrincipalEscolhida)
                {
                    case '1':
                        operacaoEscolhida = telaEquipamento.ApresentarMenu();

                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaEquipamento.CadastrarEquipamento();

                        else if (operacaoEscolhida == '2')
                            telaEquipamento.EditarEquipamento();

                        else if (operacaoEscolhida == '3')
                            telaEquipamento.ExcluirEquipamento();

                        else if (operacaoEscolhida == '4')
                            telaEquipamento.VisualizarEquipamentos(true);

                        break;

                    default: opcaoSairEscolhida = true; break;
                }
            }

            Console.ReadLine();
        }
    }
}