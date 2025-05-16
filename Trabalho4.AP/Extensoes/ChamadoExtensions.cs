using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloChamado;

namespace Trabalho4.AP.Extensoes;

public static class ChamadoExtensions
{
    public static Chamado ParaEntidadeC(
        this FormularioChamadoViewModel formularioVM,
        List<Equipamento> equipamentos
    )
    {
        Equipamento equipamentoSelecionado = null;

        foreach (var e in equipamentos)
        {
            if (e.Id == formularioVM.EquipamentoId)
                equipamentoSelecionado = e;
        }

        return new Chamado(
            formularioVM.Titulo,
            formularioVM.Descricao,
            equipamentoSelecionado
        );
    }

    public static DetalhesChamadoViewModel ParaDetalhesVM(this Chamado chamado)
    {
        return new DetalhesChamadoViewModel(
            chamado.Id,
            chamado.Titulo,
            chamado.Descricao,
            chamado.DataAbertura,
            chamado.Equipamento.Nome
        );
    }
}