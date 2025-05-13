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

        app.MapGet("/fabricantes/cadastrar", FormularioCadastrarFabricante);
        app.MapPost("/fabricantes/cadastrar", CadastrarFabricante);

        app.MapGet("/fabricantes/editar/{id:int}", FormularioEditarFabricante);
        app.MapPost("/fabricantes/editar/{id:int}", EditarFabricante);

        app.MapGet("/fabricantes/excluir/{id:int}", FormularioExcluirFabricante);
        app.MapPost("/fabricantes/ecluir/{id:int}", ExcluirFabricante);

        app.MapGet("/fabricantes/visualizar", VisualizarFabricantes);

        app.Run();
    }
    static Task ExcluirFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        string conteudo = File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", "registro excluido com sucesso!");

        string conteudoFinal = sb.ToString();

        return context.Response.WriteAsync(conteudoFinal);
    }
    static Task FormularioExcluirFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(id);

        repositorioFabricante.ExcluirRegistro(id);

        string conteudo = File.ReadAllText("Html/ExcluirFabricante.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#fabricante#", fabricante.Nome);

        sb.Replace("#mensagem#", "Fabricante excluído com sucesso!");

        string conteudoFinal = sb.ToString();

        return context.Response.WriteAsync(conteudoFinal);
    }
    static Task CadastrarFabricante(HttpContext context)
    {
        string nome = context.Request.Form["nome"].ToString();
        string email = context.Request.Form["email"].ToString();
        string telefone = context.Request.Form["telefone"].ToString();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.CadastrarRegistro(fabricante);

        string conteudo = File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", fabricante.Nome + " cadastrado com sucesso!");

        string conteudoFinal = sb.ToString();

        return context.Response.WriteAsync(conteudoFinal);
    }
    static Task FormularioEditarFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(id);

        string conteudo = File.ReadAllText("Html/FormularioEditarFabricante.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#nome#", fabricante.Nome);
        sb.Replace("#email#", fabricante.Email);
        sb.Replace("#telefone#", fabricante.Telefone);

        string conteudoString = sb.ToString();

        return context.Response.WriteAsync(conteudoString);
    }
    static Task FormularioCadastrarFabricante(HttpContext context)
    {
        string conteudo = File.ReadAllText("Html/FormularioCadastrarFabricante.html");


        return context.Response.WriteAsync(conteudo);
    }
    static Task VisualizarFabricantes(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string conteudo = File.ReadAllText("Html/VisualizarFabricantes.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        foreach (var f in repositorioFabricante.SelecionarRegistros())
        {
            string itemlista = $"<li>{f.ToString()} |  <a href=\"/fabricantes/editar/{f.Id}\">Editar<a/> / <a href=\"/fabricantes/excluir/{f.Id}>Excluir<a/> </li> #fabricante#";
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
    static Task EditarFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        string nome = context.Request.Form["nome"].ToString();
        string email = context.Request.Form["email"].ToString();
        string telefone = context.Request.Form["telefone"].ToString();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.EditarRegistro(id, fabricante);

        string conteudo = File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", fabricante.Nome + " editado com sucesso!");

        string conteudoFinal = sb.ToString();

        return context.Response.WriteAsync(conteudoFinal);
    }
}