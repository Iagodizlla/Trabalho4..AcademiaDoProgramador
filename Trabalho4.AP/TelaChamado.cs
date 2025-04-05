using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    internal class TelaChamado
    {
        public RepositorioEquipamento repositorio = new RepositorioEquipamento();
        public RegistroChamado registro = new RegistroChamado();
        public void ChamadosIniciais()
        {
            registro.CadastrarChamado(new Chamado("Uva", "Comer uvas", new DateTime(2022, 02, 22)));
            registro.CadastrarChamado(new Chamado("Uva2", "Comer uvas2", new DateTime(2022, 04, 12)));
            registro.CadastrarChamado(new Chamado("Uva3", "Comer uvas3", new DateTime(2023, 01, 01)));
        }
        public char ApresentarMenuChamado()
        {
            Menu.ExibirCabecalhoEquipamento();

            Console.WriteLine("1 - Cadastrar Chamado");
            Console.WriteLine("2 - Editar Chamado");
            Console.WriteLine("3 - Excluir Chamado");
            Console.WriteLine("4 - Visualizar Chamados");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!.ToUpper());

            return operacaoEscolhida;
        }
        public void CadastrarChamado()
        {
            Menu.ExibirCabecalhoChamado();

            Console.WriteLine("Cadastrando Chamado...");

            Console.WriteLine();

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine()!;

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine()!;

            //Console.Write("Digite o ID do equipamento do chamado: ");
            //int idEquipamento = Convert.ToInt32(Console.ReadLine());

            //if (!repositorio.ExisteEquipamento(idEquipamento))
            //{
            //    Notificador.ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
            //    return;
            //}

            Console.Write("Digite a data de abertura do chamado (formato: dd/MM/aaaa): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Chamado chamado = new Chamado(titulo, descricao, dataFabricacao/*, repositorio.equipamentos[idEquipamento]*/);

            registro.CadastrarChamado(chamado);

            Notificador.ExibirMensagem("O equipamento foi cadastrado com sucesso!", ConsoleColor.Green);
        }
        public void VisualizarChamados(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Menu.ExibirCabecalhoChamado();

                Console.WriteLine("Visualizando Chamados...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -7} | {1, -18} | {2, -20} | {3, -8}",
                "Id", "Titulo", "Descricao", "Data de Abertura"
            );

            Chamado[] chamadoCadastrados = registro.SelecionarChamado();

            for (int i = 0; i < chamadoCadastrados.Length; i++)
            {
                Chamado e = chamadoCadastrados[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -7} | {1, -18} | {2, -20} | {3, -8}",
                    e.Id, e.Titulo, e.Descricao, e.DataAbertura.ToShortDateString()
                );
            }

            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }
    }
}