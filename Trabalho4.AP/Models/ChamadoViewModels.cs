using Trabalho4.AP.Extensoes;
using Trabalho4.AP.ModuloChamado;
using Trabalho4.AP.ModuloEquipamento;

namespace Trabalho4.AP.Models;

public abstract class FormularioChamadoViewModel
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataAbertura { get; set; }
    public int EquipamentoId { get; set; }

    public List<SelecionarEquipamentoViewModel> EquipamentosDisponiveis { get; set; }

    protected FormularioChamadoViewModel()
    {
        EquipamentosDisponiveis = new List<SelecionarEquipamentoViewModel>();
    }
}

public class SelecionarEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarEquipamentoViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
public class VisualizarChamadosViewModel
{
    public List<DetalhesChamadoViewModel> Registros { get; set; }

    public VisualizarChamadosViewModel(List<Chamado> chamados)
    {
        Registros = new List<DetalhesChamadoViewModel>();

        foreach (Chamado c in chamados)
        {
            DetalhesChamadoViewModel detalhesVM = c.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}
public class DetalhesChamadoViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataAbertura { get; private set; }
    public string NomeEquipamento { get; set; }

    public DetalhesChamadoViewModel(
        int id,
        string titulo,
        string descricao,
        DateTime dataAbertura,
        string nomeEquipamento
    )
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        DataAbertura = dataAbertura;
        NomeEquipamento = nomeEquipamento;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Titulo: {Titulo} - Equipamento: {NomeEquipamento} - Descricao: {Descricao} - Data de Abertura: {DataAbertura:d}";
    }
}
public class CadastrarChamadoViewModel : FormularioChamadoViewModel
{
    public CadastrarChamadoViewModel() { }

    public CadastrarChamadoViewModel(List<Equipamento> equipamentos)
    {
        foreach (var equipamento in equipamentos)
        {
            var selecionarVM = new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome);

            EquipamentosDisponiveis.Add(selecionarVM);
        }
    }
}
public class EditarChamadoViewModel : FormularioChamadoViewModel
{
    public int Id { get; set; }

    public EditarChamadoViewModel() { }

    public EditarChamadoViewModel(Chamado chamado, List<Equipamento> equipamentos)
    {
        Id = chamado.Id;
        Titulo = chamado.Titulo;
        Descricao = chamado.Descricao;
        DataAbertura = chamado.DataAbertura;

        foreach (var equipamento in equipamentos)
        {
            var selecionarVM = new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome);

            EquipamentosDisponiveis.Add(selecionarVM);
        }
    }
}
public class ExcluirChamadoViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }

    public ExcluirChamadoViewModel(int id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}