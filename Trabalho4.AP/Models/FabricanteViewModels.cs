using Trabalho4.AP.Extensoes;
using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Models;

public abstract class FormularioFabricanteViewModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

}

public class CadastrarFabricanteViewModel : FormularioFabricanteViewModel
{
    public CadastrarFabricanteViewModel() { }

    public CadastrarFabricanteViewModel(string nome, string email, string telefone) : this()
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}

public class EditarFabricanteViewModel : FormularioFabricanteViewModel
{
    public int Id { get; set; }

    public EditarFabricanteViewModel() { }

    public EditarFabricanteViewModel(int id, string nome, string email, string telefone) : this()
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}

public class ExcluirFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFabricanteViewModel() { }

    public ExcluirFabricanteViewModel(int id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFabricantesViewModel
{
    public List<DetalhesFabricanteViewModel> Registros { get; } = new List<DetalhesFabricanteViewModel>();

    public VisualizarFabricantesViewModel(List<Fabricante> fabricantes)
    {
        foreach (Fabricante f in fabricantes)
        {
            DetalhesFabricanteViewModel detalhesVM = f.ParaDetalhesVMF();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public DetalhesFabricanteViewModel(int id, string nome, string email, string telefone)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Email: {Email}, Telefone: {Telefone}";
    }
}