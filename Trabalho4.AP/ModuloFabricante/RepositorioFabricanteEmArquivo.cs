using System.Text.Json;
using Trabalho4.AP.Compartilhado;

namespace Trabalho4.AP.ModuloFabricante;

public class RepositorioFabricanteEmArquivo : RepositorioBaseEmArquivo<Fabricante>, IRepositorioFabricante
{
    public RepositorioFabricanteEmArquivo() : base("fabricantes.json")
    {
    }
}