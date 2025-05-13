using System.Text;
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

        builder.Services.AddControllers();

        WebApplication app = builder.Build();
        
        app.MapControllers();

        app.Run();
    }
}