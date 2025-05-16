using Trabalho4.AP.Extensoes;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Models;

public abstract class FormularioEquipamentoViewModel
{
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public List<SelecionarFabricanteViewModel> FabricantesDisponiveis { get; set; } = new List<SelecionarFabricanteViewModel>();
    public int FabricanteId { get; set; }
}
public class SelecionarFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFabricanteViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
public class CadastrarEquipamentoViewModel : FormularioEquipamentoViewModel
{
    public CadastrarEquipamentoViewModel() { }

    public CadastrarEquipamentoViewModel(List<Fabricante> fabricantes)
    {
        foreach (var fabricante in fabricantes)
        {
            var selecionarFabricanteVM =
                new SelecionarFabricanteViewModel(fabricante.Id, fabricante.Nome);

            FabricantesDisponiveis.Add(selecionarFabricanteVM);
        }
    }
}
public class VisualizarEquipamentosViewModel
{
    public List<DetalhesEquipamentoViewModel> Registros { get; } = new List<DetalhesEquipamentoViewModel>();

    public VisualizarEquipamentosViewModel(List<Equipamento> equipamentos)
    {
        foreach (var e in equipamentos)
        {
            var detalhesVM = e.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}
public class DetalhesEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public string NomeFabricante { get; set; }

    public DetalhesEquipamentoViewModel(
        int id,
        string nome,
        decimal precoAquisicao,
        DateTime dataFabricacao,
        string nomeFabricante
    )
    {
        Id = id;
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        NomeFabricante = nomeFabricante;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Nome: {Nome} - Fabricante: {NomeFabricante} - Preço de Aquisição: {PrecoAquisicao:C2} - Data de Fabricação: {DataFabricacao:d}";
    }
}
public class EditarEquipamentoViewModel : FormularioFabricanteViewModel
{
    public int Id { get; set; }

    public EditarEquipamentoViewModel() { }
    public EditarEquipamentoViewModel(int id, string nome, decimal precoAquisicao, DateTime dataFabricacao, int fabricanteId) : this()
    {
        Id = id;
    }
}