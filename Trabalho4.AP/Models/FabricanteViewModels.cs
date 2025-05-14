using Trabalho4.AP.Extensoes;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Models;

public abstract class FormularioFabricanteViewModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}

public class ExcluirFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFabricanteViewModel()
    {
    }
    public ExcluirFabricanteViewModel(int id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class EditarFabricanteViewModel : FormularioFabricanteViewModel
{
    public int Id { get; set; }

    public EditarFabricanteViewModel() { }
    public EditarFabricanteViewModel(int id, string nome, string telefone, string email) : this()
    {
        Id = id;
    }
}

public class CadastrarFabricanteViewModel : FormularioFabricanteViewModel
{
    public CadastrarFabricanteViewModel() { }
    public CadastrarFabricanteViewModel(string nome, string telefone, string email) : this()
    {
    }
}

public class VisualizarFabricantesViewModel
{
    public List<DetalhesFabricanteViewModel> Registros { get; set; } = new List<DetalhesFabricanteViewModel>();

    public VisualizarFabricantesViewModel()
    {
    }
    public VisualizarFabricantesViewModel(List<Fabricante> fabricantes) : this()
    {
        foreach (Fabricante f in fabricantes)
        {
            DetalhesFabricanteViewModel detalhesVM = f.ParaViewModel();
            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public DetalhesFabricanteViewModel()
    {
    }
    public DetalhesFabricanteViewModel(int id, string nome, string email, string telefone) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, Email: {Email}";
    }
}