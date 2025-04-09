using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioFabricante)
    {
        this.repositorioFabricante = repositorioFabricante;
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Controle de Fabricantes");
        Console.WriteLine("--------------------------------------------");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Fabricante");
        Console.WriteLine("2 - Edição de Fabricante");
        Console.WriteLine("3 - Exclusão de Fabricante");
        Console.WriteLine("4 - Visualização de Fabricante");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Digite um opção válida: ");
        char opcaoEscolhida = Console.ReadLine()!.ToUpper()[0];

        return opcaoEscolhida;
    }

    public void CadastrarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Fabricante novoFabricante = ObterDadosFabricante();

        string erros = novoFabricante.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            CadastrarFabricante();

            return;
        }

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }

    public void EditarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Fabricante...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Fabricante fabricanteEditado = ObterDadosFabricante();

        string erros = fabricanteEditado.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            EditarFabricante();

            return;
        }
        bool conseguiuEditar = repositorioFabricante.EditarFabricante(idFabricante, fabricanteEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
    }

    public void ExcluirFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Fabricante...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idFabricante);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão do registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
    }

    public void VisualizarFabricantes(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

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

            if (f == null) continue;

            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
                f.Id, f.Nome, f.Email, f.Telefone, f.ObterQuantidadeEquipamentos()
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    public Fabricante ObterDadosFabricante()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o endereço de email do fabricante: ");
        string email = Console.ReadLine()!;

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine()!;

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        return fabricante;
    }
}