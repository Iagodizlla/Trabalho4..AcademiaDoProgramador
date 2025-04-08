using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RegistroFabricante registroFabricante;
    public RepositorioEquipamento repositorioEquipamento;

    public TelaEquipamento(RegistroFabricante registroFabricante)
    {
        this.registroFabricante = registroFabricante;
        repositorioEquipamento = new RepositorioEquipamento();
    }

    public void CadastrarEquipamento()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Cadastrando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine()!;

        VisualizarFabricantes();

        Console.Write("Digite o ID do fabricante equipamento: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricanteSelecionado = registroFabricante.SelecionarFabricantePorId(idFabricante);

        Console.Write("Digite o preço de aquisição R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento novoEquipamento = new Equipamento(nome, fabricanteSelecionado, precoAquisicao, dataFabricacao);

        repositorioEquipamento.CadastrarEquipamento(novoEquipamento);
    }
    public void VisualizarFabricantes()
    {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Visualizando Fabricante...");
            Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -35} | {3, -20}",
            "Id", "Nome", "E-mail", "Telefone"
        );

        Fabricante[] fabricantesCadastrados = registroFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante e = fabricantesCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -35} | {3, -20}",
                e.Id, e.Nome, e.Email, e.Telefone
            );
        }
        Console.ReadLine();
    }
    public void EditarEquipamento()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Editando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine()!;

        VisualizarFabricantes();

        Console.Write("Digite o ID do fabricante equipamento: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricanteSelecionado = registroFabricante.SelecionarFabricantePorId(idFabricante);

        Console.Write("Digite o preço de aquisição R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento novoEquipamento = new Equipamento(nome, fabricanteSelecionado, precoAquisicao, dataFabricacao);

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, novoEquipamento);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O equipamento foi editado com sucesso!");
        Console.ReadLine();
    }

    public void ExcluirEquipamento()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Excluindo Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O equipamento foi excluído com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarEquipamentos(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Visualizando Equipamentos...");
            Console.WriteLine("--------------------------------------------");
        }

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
}