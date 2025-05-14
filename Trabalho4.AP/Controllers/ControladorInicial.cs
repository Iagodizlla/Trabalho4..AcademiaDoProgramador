using Microsoft.AspNetCore.Mvc;

namespace Trabalho4.AP.Controllers;

[Route("/")]
public class ControladorInicial : Controller
{
    public IActionResult PaginaInicial()
    {
        return View("PaginaInicial");
    }
}