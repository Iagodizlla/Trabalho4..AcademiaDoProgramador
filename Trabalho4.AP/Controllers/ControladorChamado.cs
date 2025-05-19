using Microsoft.AspNetCore.Mvc;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Extensoes;
using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloChamado;

namespace Trabalho4.AP.Controllers;

[Route("chamados")]
public class ControladorChamado : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioChamado repositorioChamado;
    private IRepositorioEquipamento repositorioEquipamento;

    public ControladorChamado()
    {
        contextoDados = new ContextoDados(true);
        repositorioChamado = new RepositorioChamadoEmArquivo(contextoDados);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var chamados = repositorioChamado.SelecionarRegistros();

        var visualizarVM = new VisualizarChamadosViewModel(chamados);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

        var cadastrarVM = new CadastrarChamadoViewModel(equipamentos);

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarChamadoViewModel cadastrarVM)
    {
        var equipamentos = repositorioEquipamento.SelecionarRegistros();

        Chamado chamado = cadastrarVM.ParaEntidadeC(equipamentos);

        repositorioChamado.CadastrarRegistro(chamado);

        var notificacaoVM = new NotificacaoViewModel(
            "Chamado Cadastrado!",
            $"O registro \"{chamado.Titulo}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id}")]
    public IActionResult Editar([FromRoute] int id)
    {
        Chamado chamado = repositorioChamado.SelecionarRegistroPorId(id);

        if (chamado == null)
            return NotFound();

        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

        var editarVM = new EditarChamadoViewModel(chamado, equipamentos);

        return View(editarVM);
    }

    [HttpPost("editar/{id}")]
    public IActionResult Editar([FromRoute] int id, EditarChamadoViewModel editarVM)
    {
        Chamado chamado = repositorioChamado.SelecionarRegistroPorId(id);

        if (chamado == null)
            return NotFound();

        var equipamentos = repositorioEquipamento.SelecionarRegistros();

        chamado = editarVM.ParaEntidadeC(equipamentos);

        repositorioChamado.EditarRegistro(id, chamado);

        var notificacaoVM = new NotificacaoViewModel(
            "Chamado Editado!",
            $"O registro \"{chamado.Titulo}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        Chamado chamado = repositorioChamado.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirChamadoViewModel(id, chamado.Titulo);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        Chamado chamado = repositorioChamado.SelecionarRegistroPorId(id);

        repositorioChamado.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            "Chamado Excluído!",
            $"O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }
}