using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Controllers;

[Route("fabricantes")]
public class ControladorFabricante : Controller
{
    [HttpGet("editar/{id:int}")]
    public IActionResult FormularioEditarFabricante([FromRoute]int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(id);

        ViewBag.Fabricante = fabricante;

        return View("Editar");
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFabricante(
        [FromRoute] int id, 
        [FromForm] string nome, 
        [FromForm] string email, 
        [FromForm] string telefone)
    {
        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.EditarRegistro(id, fabricante);

        ViewBag.Mensagem = $"O \"{fabricante.Nome}\" editado com sucesso!";

        return View("Notificacao");
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult FormularioExcluirFabricante([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(id);

        ViewBag.Fabricante = fabricante;

        return View("Excluir");
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirFabricante([FromRoute]int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        ViewBag.Mensagem = $"O registro foi excluido com sucesso!";

        return View("Notificacao");
    }

    [HttpGet("cadastrar")]
    public IActionResult FormularioCadastrarFabricante()
    {
       return View("Cadastrar");
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarFabricante(
        [FromForm]string nome, 
        [FromForm]string email, 
        [FromForm]string telefone)
    {
        Fabricante fabricante = new Fabricante(nome, email, telefone);

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.CadastrarRegistro(fabricante);

        ViewBag.Mensagem = $"O \"{fabricante.Nome}\" cadastrado com sucesso!";

        return View("Notificacao");
    }

    [HttpGet("visualizar")]
    public IActionResult VisualizarFabricantes()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        ViewBag.Fabricantes = repositorioFabricante.SelecionarRegistros();
        
        return View("Visualizar");
    }
}