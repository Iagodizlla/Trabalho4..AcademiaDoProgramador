using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;

    public TelaEquipamento(RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        this.repositorioFabricante = repositorioFabricante;
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Controle de Equipamentos");
        Console.WriteLine("--------------------------------------------");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Equipamento");
        Console.WriteLine("2 - Edição de Equipamento");
        Console.WriteLine("3 - Exclusão de Equipamento");
        Console.WriteLine("4 - Visualização de Equipamentos");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Digite um opção válida: ");
        char opcaoEscolhida = Console.ReadLine()!.ToUpper()[0];

        return opcaoEscolhida;
    }

    public void CadastrarEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Equipamento novoEquipamento = ObterDadosEquipamento();

        string erros = novoEquipamento.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            CadastrarEquipamento();

            return;
        }

        Fabricante fabricante = novoEquipamento.Fabricante;

        fabricante.AdicionarEquipamento(novoEquipamento);

        repositorioEquipamento.CadastrarEquipamento(novoEquipamento);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public void EditarEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Editando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoAntigo = repositorioEquipamento.SelecionarEquipamentoPorId(idSelecionado);
        Fabricante fabricanteAntigo = equipamentoAntigo.Fabricante;

        Console.WriteLine();

        Equipamento equipamentoEditado = ObterDadosEquipamento();

        string erros = equipamentoEditado.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            EditarEquipamento();

            return;
        }
        Fabricante fabricanteEditado = equipamentoEditado.Fabricante;

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, equipamentoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição de um registro...", ConsoleColor.Red);

            return;
        }

        if (fabricanteAntigo != fabricanteEditado)
        {
            fabricanteAntigo.RemoverEquipamento(equipamentoAntigo);

            fabricanteEditado.AdicionarEquipamento(equipamentoEditado);
        }

        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
    }

    public void ExcluirEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Excluindo Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idSelecionado);

        bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão de um registro...", ConsoleColor.Red);

            return;
        }

        Fabricante fabricanteSelecionado = equipamentoSelecionado.Fabricante;

        fabricanteSelecionado.RemoverEquipamento(equipamentoSelecionado);

        Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
    }

    public void VisualizarEquipamentos(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Visualizando Equipamentos...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
        );

        Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Equipamento e = equipamentosCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante.Nome, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    public void VisualizarFabricantes()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Fabricantes...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
            "Id", "Nome", "Email", "Telefone", "Qtd. Equipamentos"
        );

        Fabricante[] fabricantesCadastrados = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante f = fabricantesCadastrados[i];

            if (f == null)
                continue;

            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
                f.Id, f.Nome, f.Email, f.Telefone, f.ObterQuantidadeEquipamentos()
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    public Equipamento ObterDadosEquipamento()
    {
        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o preço de aquisição R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        VisualizarFabricantes();

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarFabricantePorId(idFabricante);

        Equipamento equipamento = new Equipamento(
            nome,
            precoAquisicao,
            dataFabricacao,
            fabricanteSelecionado
        );

        return equipamento;
    }

}