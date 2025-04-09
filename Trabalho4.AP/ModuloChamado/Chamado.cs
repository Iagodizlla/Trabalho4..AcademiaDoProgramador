using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System.Net.Mail;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado
{
    public int Id;
    public string Titulo;
    public string Descricao;
    public Equipamento Equipamento;
    public DateTime DataAbertura;

    public Chamado(string titulo, string descricao, Equipamento equipamento)
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        DataAbertura = DateTime.Now;
    }

    public int ObterTempoDecorrido()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(DataAbertura);

        return diferencaTempo.Days;
    }
    public string Validar()
    {
        string erros = "";

        if (Titulo.Length < 5)
            erros += "O campo 'Titulo' precisa conter ao menos 5 caracteres.\n";

        if(string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo 'Descrição' é obrigatório.\n";

        return erros;
    }
}