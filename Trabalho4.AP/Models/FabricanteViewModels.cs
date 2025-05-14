using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Models;

public abstract class FormularioFabricanteViewModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public FormularioFabricanteViewModel(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
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

    public EditarFabricanteViewModel()
    {
    }
    public EditarFabricanteViewModel(int id, string nome, string telefone, string email) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}

public class CadastrarFabricanteViewModel : FormularioFabricanteViewModel
{

    public CadastrarFabricanteViewModel()
    {
    }
    public CadastrarFabricanteViewModel(string nome, string telefone, string email) : this()
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
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
            DetalhesFabricanteViewModel detalhesVM = new DetalhesFabricanteViewModel(
                f.Id,
                f.Nome,
                f.Email,
                f.Telefone
            );
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