namespace Trabalho4.AP.Models;

public class NotificacaoViewModel
{
    public string Mensagem { get; set; }

    public NotificacaoViewModel(string mensagem)
    {
        Mensagem = mensagem;
    }
}