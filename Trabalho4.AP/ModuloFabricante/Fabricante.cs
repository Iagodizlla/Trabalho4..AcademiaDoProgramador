using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System.Net.Mail;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante
{
    public int Id;
    public string Nome;
    public string Email;
    public string Telefone;
    public Equipamento[] Equipamentos;

    public Fabricante(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Equipamentos = new Equipamento[100];
    }

    public string Validar()
    {
        string erros = "";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Email))
            erros += "O campo 'Email' é obrigatório.\n";

        else if (!MailAddress.TryCreate(Email, out _))
            erros += "O campo 'Email' deve estar em um formato válido.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        else if (Telefone.Length < 12)
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

    public int ObterQuantidadeEquipamentos()
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