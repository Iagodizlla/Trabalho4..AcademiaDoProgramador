namespace Trabalho4.AP.Models;

public class NotificacaoViewModel
{
    public string TituloPagina { get; set; }
    public string Mensagem { get; set; }

    public NotificacaoViewModel(string tituloPagina, string mensagem)
    {
        TituloPagina = tituloPagina;
        Mensagem = mensagem;
    }
}