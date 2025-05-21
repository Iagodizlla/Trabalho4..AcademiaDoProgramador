using Trabalho4.AP.Extensoes;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Models;

public abstract class FormularioEquipamentoViewModel
{
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public int FabricanteId { get; set; }

    public List<SelecionarFabricanteViewModel> FabricantesDisponiveis { get; set; }

    protected FormularioEquipamentoViewModel()
    {
        FabricantesDisponiveis = new List<SelecionarFabricanteViewModel>();
    }
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
    public CadastrarEquipamentoViewModel()
    {

    }

    public CadastrarEquipamentoViewModel(List<Fabricante> fabricantes)
    {
        foreach (var fabricante in fabricantes)
        {
            var selecionarVM = new SelecionarFabricanteViewModel(fabricante.Id, fabricante.Nome);

            FabricantesDisponiveis.Add(selecionarVM);
        }
    }
}

public class EditarEquipamentoViewModel : FormularioEquipamentoViewModel
{
    public int Id { get; set; }

    public EditarEquipamentoViewModel() { }

    public EditarEquipamentoViewModel(
        int id,
        string nome,
        decimal precoAquisicao,
        DateTime dataFabricacao,
        int fabricanteId,
        List<Fabricante> fabricantes
    )
    {
        Id = id;
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        FabricanteId = fabricanteId;

        foreach (var fabricante in fabricantes)
        {
            var selecionarVM = new SelecionarFabricanteViewModel(fabricante.Id, fabricante.Nome);

            FabricantesDisponiveis.Add(selecionarVM);
        }
    }
}

public class ExcluirEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirEquipamentoViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarEquipamentosViewModel
{
    public List<DetalhesEquipamentoViewModel> Registros { get; set; }

    public VisualizarEquipamentosViewModel(List<Equipamento> equipamentos)
    {
        Registros = new List<DetalhesEquipamentoViewModel>();

        foreach (Equipamento e in equipamentos)
        {
            DetalhesEquipamentoViewModel detalhesVM = e.ParaDetalhesVME();

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