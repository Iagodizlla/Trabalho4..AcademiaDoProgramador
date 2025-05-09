using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloChamado;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;
using Trabalho4.AP.Util;

namespace Trabalho4.AP;

class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        app.MapGet("/", PaginaInicial);

        app.MapGet("/fabricantes/visualizar", VisualizarFabricantes);

        app.Run();
    }
    static Task VisualizarFabricantes(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.CadastrarRegistro(new Fabricante("dell", "teste@dell.com", "(11) 1111-1111"));
        repositorioFabricante.CadastrarRegistro(new Fabricante("aple", "teste2@apple.com", "(21) 1111-1111"));

        string conteudo = File.ReadAllText("Html/VisualizarFabricantes.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        foreach (var f in repositorioFabricante.SelecionarRegistros())
        {
            string itemlista = $"<li>{f.ToString()}</li> #fabricante#";
            stringBuilder.Replace("#fabricante#", itemlista);
        }

        stringBuilder.Replace("#fabricante#", "");
        conteudo = stringBuilder.ToString();

        return context.Response.WriteAsync(conteudo);
    }
    static Task PaginaInicial(HttpContext context)
    {
        string conteudo = File.ReadAllText("Html/PaginaInicial.html");
        return context.Response.WriteAsync(conteudo);
    }
}