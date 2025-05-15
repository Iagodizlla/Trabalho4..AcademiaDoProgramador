using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;

namespace Trabalho4.AP.Extensoes;

public static class EquipamentoExtensions
{
    public static DetalhesEquipamentoViewModel ParaViewModel(this Equipamento equipamento)
    {
        return new DetalhesEquipamentoViewModel(
            equipamento.Id,
            equipamento.Nome,
            equipamento.Fabricante.Nome,
            equipamento.PrecoAquisicao,
            equipamento.DataFabricacao
        );
    }
}
