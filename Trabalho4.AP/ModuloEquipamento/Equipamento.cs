using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System.Net.Mail;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento
{
    public int Id;
    public string Nome;
    public Fabricante Fabricante;
    public decimal PrecoAquisicao;
    public DateTime DataFabricacao;

    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao, Fabricante fabricante)
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }

    public string ObterNumeroSerie()
    {
        string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

        return $"{tresPrimeirosCaracteres}-{Id}";
    }
    public string Validar()
    {
        string erros = "";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if(PrecoAquisicao < 0)
            erros += "O campo 'Preço de Aquisição' não pode ser negativo.\n";

        return erros;
    }
}