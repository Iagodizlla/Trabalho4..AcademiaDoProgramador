using Trabalho4.AP.Compartilhado;

namespace Trabalho4.AP.ModuloEquipamento;

public class RepositorioEquipamentoEmArquivo : RepositorioBaseEmArquivo<Equipamento>, IRepositorioEquipamento
{
    public RepositorioEquipamentoEmArquivo() : base("equipamentos.json")
    {
    }
}