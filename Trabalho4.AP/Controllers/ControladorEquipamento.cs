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