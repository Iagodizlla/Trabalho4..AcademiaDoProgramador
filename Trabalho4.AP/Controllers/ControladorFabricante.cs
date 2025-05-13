using Microsoft.AspNetCore.Mvc;
using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Controllers;

[Route("fabricantes")]
public class ControladorFabricante : Controller
{
    [HttpGet("editar/{id:int}")]
    public IActionResult FormularioEditarFabricante([FromForm]int id)
    {
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

        return Content(conteudoString, "text/html");
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFabricante([FromForm]int id, [FromForm]string nome, [FromForm]string email, [FromForm]string telefone)
    {
        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.EditarRegistro(id, fabricante);

        string conteudo = System.IO.File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", fabricante.Nome + " editado com sucesso!");

        string conteudoFinal = sb.ToString();

        return Content(conteudoFinal, "text/html");
    }

    [HttpGet("exluir")]
    public IActionResult FormularioExcluirFabricante([FromForm] int id)
    {
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

        return Content(conteudoFinal, "text/html");
    }

    [HttpPost("excluir")]
    public IActionResult ExcluirFabricante([FromForm]int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        string conteudo = System.IO.File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", "registro excluido com sucesso!");

        string conteudoFinal = sb.ToString();

        return Content(conteudoFinal, "text/html");
    }

    [HttpGet("cadastrar")]
    public IActionResult FormularioCadastrarFabricante()
    {
        string conteudo = System.IO.File.ReadAllText("Html/CadastrarFabricante.html");

        return Content(conteudo, "text/html");
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarFabricante([FromForm]string nome, [FromForm]string email, [FromForm]string telefone)
    {
        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.CadastrarRegistro(fabricante);

        string conteudo = System.IO.File.ReadAllText("Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);
        sb.Replace("#mensagem#", fabricante.Nome + " cadastrado com sucesso!");

        string conteudoFinal = sb.ToString();

        return Content(conteudoFinal, "text/html");
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