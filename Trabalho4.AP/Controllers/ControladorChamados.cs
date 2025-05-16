using Microsoft.AspNetCore.Mvc;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Extensoes;
using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloChamado;

namespace Trabalho4.AP.Controllers;

[Route("chamados")]
public class ControladorChamados : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioChamado repositorioChamado;
    private IRepositorioEquipamento repositorioEquipamento;


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
        var equipamentos = repositorioEquipamento.SelecionarRegistros();

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
}