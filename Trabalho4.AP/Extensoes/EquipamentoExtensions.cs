using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Extensoes;

public static class EquipamentoExtensions
{
    public static Equipamento ParaEntidade(
        this FormularioEquipamentoViewModel formularioVM,
        List<Fabricante> fabricantes
    )
    {
        Fabricante fabricanteSelecionado = null;

        foreach (var f in fabricantes)
        {
            if (f.Id == formularioVM.FabricanteId)
                fabricanteSelecionado = f;
        }

        return new Equipamento(
            formularioVM.Nome,
            formularioVM.PrecoAquisicao,
            formularioVM.DataFabricacao,
            fabricanteSelecionado
        );
    }

    public static DetalhesEquipamentoViewModel ParaDetalhesVM(this Equipamento equipamento)
    {
        return new DetalhesEquipamentoViewModel(
            equipamento.Id,
            equipamento.Nome,
            equipamento.PrecoAquisicao,
            equipamento.DataFabricacao,
            equipamento.Fabricante.Nome
        );
    }
}