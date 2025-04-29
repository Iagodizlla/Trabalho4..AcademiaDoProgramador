using Trabalho4.AP.Compartilhado;
namespace Trabalho4.AP.ModuloChamado;

public class RepositorioChamadoEmArquivo : RepositorioBaseEmArquivo<Chamado>, IRepositorioChamado
{
    public RepositorioChamadoEmArquivo() : base("chamados.json")
    {
    }
}