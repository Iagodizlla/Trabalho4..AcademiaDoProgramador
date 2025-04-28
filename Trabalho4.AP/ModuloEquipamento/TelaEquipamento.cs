using Trabalho4.AP.ModuloFabricante;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Util;

namespace Trabalho4.AP.ModuloEquipamento;

public class TelaEquipamento : TelaBase<Equipamento>, ITelaCrud
{
    public IRepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;

    public TelaEquipamento(IRepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
        : base("Equipamento", repositorioEquipamento)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        this.repositorioFabricante = repositorioFabricante;
    }

    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Equipamento novoEquipamento = (Equipamento)ObterDados();

        string erros = novoEquipamento.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            CadastrarRegistro();

            return;
        }

        Fabricante fabricante = novoEquipamento.Fabricante;

        fabricante.AdicionarEquipamento(novoEquipamento);

        repositorioEquipamento.CadastrarRegistro(novoEquipamento);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Editando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoAntigo = (Equipamento)repositorioEquipamento.SelecionarRegistroPorId(idSelecionado);
        Fabricante fabricanteAntigo = equipamentoAntigo.Fabricante;

        Console.WriteLine();

        Equipamento equipamentoEditado = (Equipamento)ObterDados();

        Fabricante fabricanteEditado = equipamentoEditado.Fabricante;

        if (fabricanteAntigo != fabricanteEditado)
        {
            fabricanteAntigo.RemoverEquipamento(equipamentoAntigo);

            fabricanteEditado.AdicionarEquipamento(equipamentoEditado);
        }

        bool conseguiuEditar = repositorioEquipamento.EditarRegistro(idSelecionado, equipamentoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição de um registro...", ConsoleColor.Red);

            return;
        }


        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
    }

    public override void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Excluindo Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = (Equipamento)repositorioEquipamento.SelecionarRegistroPorId(idSelecionado);

        bool conseguiuExcluir = repositorioEquipamento.ExcluirRegistro(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão de um registro...", ConsoleColor.Red);

            return;
        }

        Fabricante fabricanteSelecionado = equipamentoSelecionado.Fabricante;

        fabricanteSelecionado.RemoverEquipamento(equipamentoSelecionado);

        Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
    }

    public override void VisualizarRegistros(bool exibirTitulo)
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

        Equipamento[] registros = repositorioEquipamento.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Equipamento e = registros[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                e.Id, e.Nome, e.NumeroSerie, e.Fabricante.Nome, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    public override Equipamento ObterDados()
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

        Fabricante fabricanteSelecionado = (Fabricante)repositorioFabricante.SelecionarRegistroPorId(idFabricante);

        Equipamento equipamento = new Equipamento(
            nome,
            precoAquisicao,
            dataFabricacao,
            fabricanteSelecionado
        );

        Fabricante fabricante = equipamento.Fabricante;

        fabricante.AdicionarEquipamento(equipamento);

        return equipamento;
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

        Fabricante[] registros = repositorioFabricante.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Fabricante f = registros[i];

            if (f == null)
                continue;

            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
                f.Id, f.Nome, f.Email, f.Telefone, f.QuantidadeEquipamentos
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }

}