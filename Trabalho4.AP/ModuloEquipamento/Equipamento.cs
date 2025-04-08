namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento
{
    public int Id;
    public string Nome;
    public string Fabricante;
    public decimal PrecoAquisicao;
    public DateTime DataFabricacao;

    public Equipamento(string nome, string fabricante, decimal precoAquisicao, DateTime dataFabricacao)
    {
        Nome = nome;
        Fabricante = fabricante;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
    }

    public string ObterNumeroSerie()
    {
        string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

        return $"{tresPrimeirosCaracteres}-{Id}";
    }
}