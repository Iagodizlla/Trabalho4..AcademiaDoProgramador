using Trabalho4.AP.ModuloEquipamento;
using System.Net.Mail;
using Trabalho4.AP.Compartilhado;

namespace Trabalho4.AP.ModuloFabricante;

public class Fabricante : EntidadeBase<Fabricante>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public Equipamento[] Equipamentos { get; private set; }
    public int QuantidadeEquipamentos
    {
        get
        {
            int contador = 0;

            for (int i = 0; i < Equipamentos.Length; i++)
            {
                if (Equipamentos[i] != null)
                    contador++;
            }

            return contador;
        }
    }

    public Fabricante(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Equipamentos = new Equipamento[100];
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Email))
            erros += "O campo 'Email' é obrigatório.\n";

        if (!MailAddress.TryCreate(Email, out _))
            erros += "O campo 'Email' deve estar em um formato válido.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        if (Telefone.Length < 12)
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.";

        return erros;
    }


    public void AdicionarEquipamento(Equipamento equipamento)
    {
        for (int i = 0; i < Equipamentos.Length; i++)
        {
            if (Equipamentos[i] == null)
            {
                Equipamentos[i] = equipamento;
                return;
            }
        }
    }

    public void RemoverEquipamento(Equipamento equipamento)
    {
        for (int i = 0; i < Equipamentos.Length; i++)
        {
            if (Equipamentos[i] == null)
                continue;

            else if (Equipamentos[i] == equipamento)
            {
                Equipamentos[i] = null!;

                return;
            }
        }
    }

    public override void AtualizarRegistro(Fabricante fabricanteEditado)
    {
        Nome = fabricanteEditado.Nome;
        Email = fabricanteEditado.Email;
        Telefone = fabricanteEditado.Telefone;
    }
}