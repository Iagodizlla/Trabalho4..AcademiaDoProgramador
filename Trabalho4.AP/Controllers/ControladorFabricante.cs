using Microsoft.AspNetCore.Mvc;
using System.Text;
using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Controllers;

[Route("fabricantes")]
public class ControladorFabricante : Controller
{
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