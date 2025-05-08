using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloChamado;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;
using Trabalho4.AP.Util;

namespace Trabalho4.AP;

class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        app.MapGet("/", OlaMundo);

        app.Run();
    }
    static Task OlaMundo(HttpContext context)
    {
        context.Response.ContentType = "text/plain; charset=utf-8";
        return context.Response.WriteAsync("Olá, Mundo!");
    }
}