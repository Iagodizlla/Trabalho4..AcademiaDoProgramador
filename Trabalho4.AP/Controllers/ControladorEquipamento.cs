using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.Extensoes;
using Trabalho4.AP.Models;
using Trabalho4.AP.ModuloEquipamento;

namespace Trabalho4.AP.Controllers;

[Route("equipamentos")]
public class ControladorEquipamento : Controller
{
    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        ContextoDados contexto = new ContextoDados(true);
        RepositorioEquipamentoEmArquivo repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

        VisualizarEquipamentoViewModel visualizarVM = new VisualizarEquipamentoViewModel(equipamentos);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        return View();
    }
}