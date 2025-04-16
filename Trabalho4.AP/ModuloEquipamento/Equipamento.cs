using Trabalho4.AP.ModuloFabricante;
using Trabalho4.AP.Compartilhado;

namespace Trabalho4.AP.ModuloEquipamento;

public class Equipamento : EntidadeBase
{
    public string Nome { get; set; }
    public Fabricante Fabricante { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public string NumeroSerie
    {
        get
        {
            string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

            return $"{tresPrimeirosCaracteres}-{Id}";
        }
    }

    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao, Fabricante fabricante)
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Equipamento equipamentoAtualizado = (Equipamento)registroAtualizado;

        Nome = equipamentoAtualizado.Nome;
        DataFabricacao = equipamentoAtualizado.DataFabricacao;
        PrecoAquisicao = equipamentoAtualizado.PrecoAquisicao;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (PrecoAquisicao <= 0)
            erros += "O campo 'Preço de Aquisição' deve ser maior que zero.\n";

        if (DataFabricacao > DateTime.Now)
            erros += "O campo 'Data de Fabricação' deve conter uma data passada.\n";

        return erros;
    }
}