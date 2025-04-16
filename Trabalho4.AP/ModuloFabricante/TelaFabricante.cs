using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Util;

namespace Trabalho4.AP.ModuloFabricante;

public class TelaFabricante : TelaBase
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioFabricante)
        : base("Fabricante", repositorioFabricante)
    {
        this.repositorioFabricante = repositorioFabricante;
    }

    public override void VisualizarRegistros(bool exibirTitulo)
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

        EntidadeBase[] registros = repositorioFabricante.SelecionarRegistros();
        Fabricante[] fabricantesCadastrados = new Fabricante[registros.Length];

        for (int i = 0; i < registros.Length; i++)
            fabricantesCadastrados[i] = (Fabricante)registros[i];

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante f = fabricantesCadastrados[i];

            if (f == null) continue;

            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
                f.Id, f.Nome, f.Email, f.Telefone, f.QuantidadeEquipamentos
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    public override EntidadeBase ObterDados()
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