using Microsoft.AspNetCore.Mvc;
using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Controllers;

[Route("fabricantes")]
public class ControladorFabricante : Controller
{
    [HttpGet("editar/{id:int}")]
    public Task FormularioEditarFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(id);

        string conteudo = System.IO.File.ReadAllText("Html/EditarFabricante.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#nome#", fabricante.Nome);
        sb.Replace("#email#", fabricante.Email);
        sb.Replace("#telefone#", fabricante.Telefone);

        string conteudoString = sb.ToString();

        return HttpContext.Response.WriteAsync(conteudoString);
    }

    [HttpPost("editar/{id:int}")]
    public Task EditarFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        string nome = context.Request.Form["nome"].ToString();
        string email = context.Request.Form["email"].ToString();
        string telefone = context.Request.Form["telefone"].ToString();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.EditarRegistro(id, fabricante);

        string conteudo = System.IO.File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", fabricante.Nome + " editado com sucesso!");

        string conteudoFinal = sb.ToString();

        return HttpContext.Response.WriteAsync(conteudoFinal);
    }

    [HttpGet("exluir")]
    public Task FormularioExcluirFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(id);

        repositorioFabricante.ExcluirRegistro(id);

        string conteudo = System.IO.File.ReadAllText("Html/ExcluirFabricante.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#fabricante#", fabricante.Nome);

        sb.Replace("#mensagem#", "Fabricante excluído com sucesso!");

        string conteudoFinal = sb.ToString();

        return HttpContext.Response.WriteAsync(conteudoFinal);
    }

    [HttpPost("excluir")]
    public Task ExcluirFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        string conteudo = System.IO.File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", "registro excluido com sucesso!");

        string conteudoFinal = sb.ToString();

        return HttpContext.Response.WriteAsync(conteudoFinal);
    }

    [HttpGet("cadastrar")]
    public Task FormularioCadastrarFabricante(HttpContext context)
    {
        string conteudo = System.IO.File.ReadAllText("Html/CadastrarFabricante.html");

        return HttpContext.Response.WriteAsync(conteudo);
    }

    [HttpPost("cadastrar")]
    public Task CadastrarFabricante(HttpContext context)
    {
        string nome = context.Request.Form["nome"].ToString();
        string email = context.Request.Form["email"].ToString();
        string telefone = context.Request.Form["telefone"].ToString();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.CadastrarRegistro(fabricante);

        string conteudo = System.IO.File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", fabricante.Nome + " cadastrado com sucesso!");

        string conteudoFinal = sb.ToString();

        return HttpContext.Response.WriteAsync(conteudoFinal);
    }

    [HttpGet("visualizar")]
    public IActionResult VisualizarFabricantes()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string conteudo = System.IO.File.ReadAllText("Html/VisualizarFabricantes.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        foreach (var f in repositorioFabricante.SelecionarRegistros())
        {
            string itemlista = $"<li>{f.ToString()} |  <a href=\"/fabricantes/editar/{f.Id}\">Editar<a/> / <a href=\"/fabricantes/excluir/{f.Id}\">Excluir<a/> </li> #fabricante#";
            stringBuilder.Replace("#fabricante#", itemlista);
        }

        stringBuilder.Replace("#fabricante#", "");
        conteudo = stringBuilder.ToString();

        return Content(conteudo, "text/html");
    }
}