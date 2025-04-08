using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioChamado repositorioChamado;

    public TelaChamado(RepositorioEquipamento repositorioEquipamento)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        repositorioChamado = new RepositorioChamado();
    }

    public void CadastrarChamado()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Chamado...");
        Console.WriteLine("--------------------------------------------");

        Chamado novoChamado = ObterDadosChamado();

        repositorioChamado.CadastrarChamado(novoChamado);

        Console.WriteLine();
        Console.WriteLine("O chamado foi cadastrado com sucesso!");
        Console.ReadLine();
    }

    public void EditarChamado()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Chamado...");
        Console.WriteLine("--------------------------------------------");

        VisualizarChamados(false);

        Console.Write("Digite o ID do chamado que deseja editar: ");
        int idChamado = Convert.ToInt32(Console.ReadLine());

        Chamado novoChamado = ObterDadosChamado();

        bool conseguiuEditar = repositorioChamado.EditarChamado(idChamado, novoChamado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O chamado foi editado com sucesso!");
        Console.ReadLine();
    }

    public void ExcluirChamado()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Chamado...");
        Console.WriteLine("--------------------------------------------");

        VisualizarChamados(false);

        Console.Write("Digite o ID do chamado que deseja excluir: ");
        int idChamado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioChamado.ExcluirChamado(idChamado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O chamado foi excluído com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarChamados(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ExibirCabecalho();

            Console.WriteLine("Visualizando Chamados...");
            Console.WriteLine("--------------------------------------------");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -16} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
            "Id", "Data de Abertura", "Título", "Descrição", "Equipamento", "Tempo Decorrido"
        );

        Chamado[] chamadosCadastrados = repositorioChamado.SelecionarChamados();

        for (int i = 0; i < chamadosCadastrados.Length; i++)
        {
            Chamado c = chamadosCadastrados[i];

            if (c == null)
                continue;

            string tempoDecorrido = $"{c.ObterTempoDecorrido()} dia(s)";

            Console.WriteLine(
                "{0, -6} | {1, -16} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
                c.Id, c.DataAbertura.ToShortDateString(), c.Titulo, c.Descricao, c.Equipamento.Nome, tempoDecorrido
            );
        }
        Console.ReadLine();
    }

    public void VisualizarEquipamentos()
    {
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
        Console.ReadLine();
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Controle de Chamados");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();
    }

    public Chamado ObterDadosChamado()
    {
        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine()!.Trim();

        Console.Write("Digite o descrição do chamado: ");
        string descricao = Console.ReadLine()!.Trim();

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine()!.Trim());

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);

        Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

        return novoChamado;
    }
}