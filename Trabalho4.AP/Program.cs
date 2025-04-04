namespace Trabalho4.AP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquipamento = new TelaEquipamento();
            TelaChamado telaChamado = new TelaChamado();
            bool opcaoSairEscolhida = false;

            telaEquipamento.EquipamentosIniciais();

            while (!opcaoSairEscolhida)
            {
                #region Menu Principal(Sair / Gerência de Equipamentos)
                char opcaoPrincipalEscolhida = Menu.ApresentarMenuPrincipal();
                char operacaoEscolhida;
                #endregion
                #region Selecionar opcaoes
                switch (opcaoPrincipalEscolhida)
                {
                    case '1':
                        #region menu secundário(Cadastrar Equipamento / Editar Equipamento / Excluir Equipamento / Visualizar Equipamentos)
                        operacaoEscolhida = telaEquipamento.ApresentarMenuEquipamento();
                        #endregion
                        #region Selecionar opcaoes
                        if (operacaoEscolhida == 'S')
                            break;

                        if (operacaoEscolhida == '1')
                            telaEquipamento.CadastrarEquipamento();

                        else if (operacaoEscolhida == '2')
                            telaEquipamento.EditarEquipamento();

                        else if (operacaoEscolhida == '3')
                            telaEquipamento.ExcluirEquipamento();

                        else if (operacaoEscolhida == '4')
                            telaEquipamento.VisualizarEquipamentos(true);
                        #endregion
                        break;
                    case '2':
                        #region menu secundário(Cadastrar Chamado / Editar Chamado / Excluir Chamado / Visualizar Chamados)
                        operacaoEscolhida = telaChamado.ApresentarMenuChamado();
                        #endregion
                        #region Selecionar opcaoes
                        if (operacaoEscolhida == 'S')
                            break;

                        if (operacaoEscolhida == '1')
                            telaChamado.CadastrarChamado();

                        //else if (operacaoEscolhida == '2')
                        //    telaEquipamento.EditarEquipamento();

                        //else if (operacaoEscolhida == '3')
                        //    telaEquipamento.ExcluirEquipamento();

                        //else if (operacaoEscolhida == '4')
                        //    telaEquipamento.VisualizarEquipamentos(true);
                        #endregion
                        break;
                    case 'S':
                        #region Sair
                        opcaoSairEscolhida = true;
                        break;
                        #endregion
                    default:
                        #region Opção inválida
                        Console.WriteLine("Opção inválida, tente novamente.");
                        Console.ReadLine();
                        break;
                        #endregion
                }
                #endregion
            }
        }
    }
}