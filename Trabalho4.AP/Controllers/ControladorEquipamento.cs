using Microsoft.AspNetCore.Mvc;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Extensoes;
using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Controllers;

[Route("equipamentos")]
public class ControladorEquipamento : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioEquipamento repositorioEquipamento;
    private IRepositorioFabricante repositorioFabricante;

    public ControladorEquipamento()
    {
        contextoDados = new ContextoDados(true);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
        repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var cadastrarVM = new CadastrarEquipamentoViewModel(fabricantes);

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarEquipamentoViewModel cadastrarVM)
    {
        var fabricantes = repositorioFabricante.SelecionarRegistros();

        Equipamento equipamento = cadastrarVM.ParaEntidade(fabricantes);

        repositorioEquipamento.CadastrarRegistro(equipamento);

        var notificacaoVM = new NotificacaoViewModel(
            "Equipamento Cadastrado!",
            $"O registro \"{equipamento.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var editarVM = new EditarEquipamentoViewModel(
            id,
            equipamentoSelecionado.Nome,
            equipamentoSelecionado.PrecoAquisicao,
            equipamentoSelecionado.DataFabricacao,
            equipamentoSelecionado.Fabricante.Id,
            fabricantes

        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarEquipamentoViewModel editarVM)
    {
        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var equipamentoEditado = editarVM.ParaEntidade(fabricantes);

        var equipamentoOriginal = repositorioEquipamento.SelecionarRegistroPorId(id);

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

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirEquipamentoViewModel(id, equipamentoSelecionado.Nome);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        repositorioEquipamento.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            "Equipamento Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var equipamentos = repositorioEquipamento.SelecionarRegistros();

        var visualizarVM = new VisualizarEquipamentosViewModel(equipamentos);

        return View(visualizarVM);
    }
}