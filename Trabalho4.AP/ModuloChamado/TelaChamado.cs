using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Util;

namespace Trabalho4.AP.ModuloChamado;

public class TelaChamado : TelaBase<Chamado>, ITelaCrud
{
    public RepositorioChamado repositorioChamado;
    public RepositorioEquipamento repositorioEquipamento;

    public TelaChamado(RepositorioChamado repositorioChamado, RepositorioEquipamento repositorioEquipamento)
        : base("Chamado", repositorioChamado)
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamento;
    }

    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Visualizando Chamados...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
            "Id", "Data de Abertura", "Título", "Descrição", "Equipamento", "Tempo Decorrido"
        );

        Chamado[] registros = repositorioChamado.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Chamado c = registros[i];

            if (c == null)
                continue;

            string tempoDecorrido = $"{c.TempoDecorrido} dia(s)";

            Console.WriteLine(
                "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
                c.Id, c.DataAbertura.ToShortDateString(), c.Titulo, c.Descricao, c.Equipamento.Nome, tempoDecorrido
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    public override Chamado ObterDados()
    {
        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine()!.Trim();

        Console.Write("Digite o descrição do chamado: ");
        string descricao = Console.ReadLine()!.Trim();

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine()!.Trim());

        Equipamento equipamentoSelecionado = (Equipamento)repositorioEquipamento.SelecionarRegistroPorId(idEquipamento);

        Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

        return novoChamado;
    }

    public void VisualizarEquipamentos()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Equipamentos...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
        );

        Equipamento[] registros = repositorioEquipamento.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Equipamento e = registros[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                e.Id, e.Nome, e.NumeroSerie, e.Fabricante, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
}