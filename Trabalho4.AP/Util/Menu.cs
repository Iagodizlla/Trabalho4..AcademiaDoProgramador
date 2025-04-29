using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloChamado;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Util;

public class Menu
{
    private char opcaoPrincipal;
    private IRepositorioFabricante repositorioFabricante;
    private IRepositorioEquipamento repositorioEquipamento;
    private IRepositorioChamado repositorioChamado;

    public Menu()
    {
        this.repositorioFabricante = new RepositorioFabricanteEmMemoria();
        this.repositorioEquipamento = new RepositorioEquipamentoEmMemoria();
        this.repositorioChamado = new RepositorioChamadoEmMemoria();
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Fabricantes");
        Console.WriteLine("2 - Controle de Equipamentos");
        Console.WriteLine("3 - Controle de Chamados");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoPrincipal = Console.ReadLine()!.ToUpper()[0];
    }

    public ITelaCrud ObterTela()
    {
        if (opcaoPrincipal == '1')
            return new TelaFabricante(repositorioFabricante);

        else if (opcaoPrincipal == '2')
            return new TelaEquipamento(repositorioEquipamento, repositorioFabricante);

        else if (opcaoPrincipal == '3')
            return new TelaChamado(repositorioChamado, repositorioEquipamento);

        return null!;
    }
}