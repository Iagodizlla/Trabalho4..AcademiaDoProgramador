using Microsoft.AspNetCore.Mvc;

namespace Trabalho4.AP.Controllers;

[Route("/")]
public class ControladorInicial : Controller
{
    public IActionResult PaginaInicial()
    {
        string conteudo = System.IO.File.ReadAllText("Html/PaginaInicial.html");
        return Content(conteudo, "text/html");
    }
}