using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.Compartilhado;

namespace Trabalho4.AP.ModuloChamado;

public class Chamado : EntidadeBase<Chamado>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public Equipamento Equipamento { get; set; }
    public DateTime DataAbertura { get; private set; }
    public int TempoDecorrido
    {
        get
        {
            TimeSpan diferencaTempo = DateTime.Now.Subtract(DataAbertura);

            return diferencaTempo.Days;
        }
    }
    public Chamado()
    {
    }

    public Chamado(string titulo, string descricao, Equipamento equipamento) : this()
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        DataAbertura = DateTime.Now;
    }

    public override void AtualizarRegistro(Chamado chamadoAtualizado)
    {
        Titulo = chamadoAtualizado.Titulo;
        Descricao = chamadoAtualizado.Descricao;
        Equipamento = chamadoAtualizado.Equipamento;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Titulo))
            erros += "O campo 'Título' é obrigatório.\n";

        if (Titulo.Length < 3)
            erros += "O campo 'Título' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo 'Descrição' é obrigatório.\n";

        if (Equipamento == null)
            erros += "O campo 'Equipamento' é obrigatório.\n";

        return erros;
    }
}