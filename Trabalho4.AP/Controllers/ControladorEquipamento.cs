using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Extensoes;
using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Controllers;

[Route("equipamentos")]
public class ControladorEquipamento : Controller
{
    [HttpGet("excluir/{id:int}")]
    public IActionResult ExibirFormularioExclusaoEquipamento([FromRoute] int id)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);

        var equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirEquipamentoViewModel(
            equipamentoSelecionado.Id,
            equipamentoSelecionado.Nome
        );

        return View("Excluir", excluirVM);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirEquipamento([FromRoute] int id)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);

        repositorioEquipamento.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            "Equipamento Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult ExibirFormularioEdicaoEquipamento([FromRoute] int id)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

        var editarVM = new EditarEquipamentoViewModel(
            id,
            equipamentoSelecionado.Nome,
            equipamentoSelecionado.PrecoAquisicao,
            equipamentoSelecionado.DataFabricacao,
            equipamentoSelecionado.Fabricante.Id,
            fabricantes
        );

        return View("Editar", editarVM);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarEquipamento([FromRoute] int id, EditarEquipamentoViewModel editarVM)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var equipamentoOriginal = repositorioEquipamento.SelecionarRegistroPorId(id);

        var equipamentoEditado = editarVM.ParaEntidade(fabricantes);

        if (equipamentoEditado.Fabricante != equipamentoOriginal.Fabricante)
        {
            equipamentoOriginal.Fabricante.RemoverEquipamento(equipamentoOriginal);
            equipamentoOriginal.Fabricante = equipamentoEditado.Fabricante;
        }

        repositorioEquipamento.EditarRegistro(id, equipamentoEditado);

        var notificacaoVM = new NotificacaoViewModel(
            "Equipamento Editado!",
            $"O registro \"{equipamentoEditado.Nome}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult ExibirFormularioCadastroEquipamento()
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var cadastrarVM = new CadastrarEquipamentoViewModel(fabricantes);

        return View("Cadastrar", cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarEquipamento(CadastrarEquipamentoViewModel cadastrarVM)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var novoEquipamento = cadastrarVM.ParaEntidade(fabricantes);

        repositorioEquipamento.CadastrarRegistro(novoEquipamento);

        var notificacaoVM = $"Equipamento Cadastrado! O registro \"{novoEquipamento.Nome}\" foi cadastrado com sucesso!";

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult VisualizarEquipamentos()
    {
        var contextoDados = new ContextoDados(true);
        var repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);

        var equipamentos = repositorioEquipamento.SelecionarRegistros();

        var visualizarVM = new VisualizarEquipamentosViewModel(equipamentos);

        return View("Visualizar", visualizarVM);
    }
}