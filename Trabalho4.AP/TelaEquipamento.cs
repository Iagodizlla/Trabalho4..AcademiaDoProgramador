using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    public class TelaEquipamento
    {
        public RepositorioEquipamento repositorio = new RepositorioEquipamento();

        public char ApresentarMenu()
        {
            Menu.ExibirCabecalho();

            Console.WriteLine("1 - Cadastrar Equipamento");
            Console.WriteLine("2 - Editar Equipamento");
            Console.WriteLine("3 - Excluir Equipamento");
            Console.WriteLine("4 - Visualizar Equipamentos");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void CadastrarEquipamento()
        {
            Menu.ExibirCabecalho();

            Console.WriteLine("Cadastrando Equipamento...");

            Console.WriteLine();

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o preço de aquisição do equipamento: R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (formato: dd/MM/aaaa): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento equipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

            repositorio.CadastrarEquipamento(equipamento);

            Notificador.ExibirMensagem("O equipamento foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void EditarEquipamento()
        {
            Menu.ExibirCabecalho();

            Console.WriteLine("Editando Equipamento...");

            Console.WriteLine();

            VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento que deseja editar: ");
            int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.ExisteEquipamento(idEquipamentoEscolhido))
            {
                Notificador.ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o preço de aquisição do equipamento: R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (formato: dd-MM-aaaa): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

            bool conseguiuEditar = repositorio.EditarEquipamento(idEquipamentoEscolhido, novoEquipamento);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição de equipamento...", ConsoleColor.Red);
                return;
            }

            Notificador.ExibirMensagem("O equipamento foi editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirEquipamento()
        {
            Menu.ExibirCabecalho();

            Console.WriteLine("Excluindo Equipamento...");

            Console.WriteLine();

            VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento que deseja excluir: ");
            int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.ExisteEquipamento(idEquipamentoEscolhido))
            {
                Notificador.ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorio.ExcluirEquipamento(idEquipamentoEscolhido);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão do equipamento...", ConsoleColor.Red);
                return;
            }

            Notificador.ExibirMensagem("O equipamento foi excluído com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarEquipamentos(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Menu.ExibirCabecalho();

                Console.WriteLine("Visualizando Equipamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -10} | {5, -10}",
                "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
            );

            Equipamento[] equipamentosCadastrados = repositorio.SelecionarEquipamentos();

            for (int i = 0; i < equipamentosCadastrados.Length; i++)
            {
                Equipamento e = equipamentosCadastrados[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -10} | {5, -10}",
                    e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
                );
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }
    }
}
