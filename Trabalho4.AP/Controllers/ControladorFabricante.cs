using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Extensoes;
using Trabalho4.AP.Models;
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

        EditarFabricanteViewModel editarVM = new EditarFabricanteViewModel(
            fabricante.Id,
            fabricante.Nome,
            fabricante.Telefone,
            fabricante.Email
            );

        return View("Editar", editarVM);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFabricante([FromRoute] int id, EditarFabricanteViewModel editarVm)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = new Fabricante(editarVm.Nome, editarVm.Email, editarVm.Telefone);

        repositorioFabricante.EditarRegistro(id, fabricante);

        ViewBag.Mensagem = $"O \"{editarVm.Nome}\" editado com sucesso!";

        return View("Notificacao");
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult FormularioExcluirFabricante([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = repositorioFabricante.SelecionarRegistroPorId(id);

        ExcluirFabricanteViewModel excluirVM = new ExcluirFabricanteViewModel(
            fabricante.Id,
            fabricante.Nome
            );

        return View("Excluir", excluirVM);
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
        CadastrarFabricanteViewModel cadastrarVM = new CadastrarFabricanteViewModel();

        return View("Cadastrar", cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarFabricante(CadastrarFabricanteViewModel cadastrarVM)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricante = cadastrarVM.ParaEntidade();

        repositorioFabricante.CadastrarRegistro(fabricante);

        ViewBag.Mensagem = $"O \"{cadastrarVM.Nome}\" cadastrado com sucesso!";

        return View("Notificacao");
    }

    [HttpGet("visualizar")]
    public IActionResult VisualizarFabricantes()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

        VisualizarFabricantesViewModel fabricantesVM = new VisualizarFabricantesViewModel(fabricantes);

        return View("Visualizar", fabricantesVM);
    }
}