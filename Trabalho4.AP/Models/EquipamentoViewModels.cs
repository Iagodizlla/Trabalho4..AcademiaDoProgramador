using Trabalho4.AP.Extensoes;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Models;

public class VisualizarEquipamentoViewModel
{
    public List<DetalhesEquipamentoViewModel> Registros;

    public VisualizarEquipamentoViewModel()
    {
    }
    public VisualizarEquipamentoViewModel(List<Equipamento> equipamentos): this()
    {
        Registros = new List<DetalhesEquipamentoViewModel>();

        foreach (Equipamento e in equipamentos)
        {
            DetalhesEquipamentoViewModel detalhesVM = e.ParaViewModel();
            Registros.Add(detalhesVM);
        }
    }
}
public class FormularioEquipamentoViewModel
{
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public string FabricanteNome { get; set; }
}
public class DetalhesEquipamentoViewModel : FormularioEquipamentoViewModel
{
    public int Id { get; set; }

    public DetalhesEquipamentoViewModel() { }

    public DetalhesEquipamentoViewModel(int id, string nome, string fabricanteNome, decimal precoAquisicao, DateTime dataFabricacao) : this()
    {
        Id = id;
    }
}
public class EditarEquipamentoViewModel : FormularioEquipamentoViewModel
{
    public int Id { get; set; }
    public EditarEquipamentoViewModel() { }
    public EditarEquipamentoViewModel(int id, string nome, string fabricanteNome, decimal precoAquisicao, DateTime dataFabricacao) : this()
    {
        Id = id;
    }
}
public class ExcluirEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirEquipamentoViewModel() { }
    public ExcluirEquipamentoViewModel(int id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}
public class CadastrarEquipamentoViewModel : FormularioEquipamentoViewModel
{
    public CadastrarEquipamentoViewModel() { }
    public CadastrarEquipamentoViewModel(string nome, decimal precoAquisicao, DateTime dataFabricacao, string fabricanteNome) : this()
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        FabricanteNome = fabricanteNome;
    }
}
