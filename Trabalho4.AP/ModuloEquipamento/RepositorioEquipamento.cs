using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class RepositorioEquipamento
{
    public Equipamento[] equipamentos = new Equipamento[100];
    public int contadorEquipamentos = 0;

    public void CadastrarEquipamento(Equipamento novoEquipamento)
    {
        novoEquipamento.Id = GeradorIds.GerarIdEquipamento();

        equipamentos[contadorEquipamentos++] = novoEquipamento;
    }

    public bool EditarEquipamento(int idEquipamento, Equipamento equipamentoEditado)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null) continue;

            else if (equipamentos[i].Id == idEquipamento)
            {
                equipamentos[i].Nome = equipamentoEditado.Nome;
                equipamentos[i].Fabricante = equipamentoEditado.Fabricante;
                equipamentos[i].PrecoAquisicao = equipamentoEditado.PrecoAquisicao;
                equipamentos[i].DataFabricacao = equipamentoEditado.DataFabricacao;

                return true;
            }
        }

        return false;
    }

    public bool ExcluirEquipamento(int idEquipamento)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null) continue;

            else if (equipamentos[i].Id == idEquipamento)
            {
                equipamentos[i] = null!;

                return true;
            }
        }

        return false;
    }

    public Equipamento[] SelecionarEquipamentos()
    {
        return equipamentos;
    }

    public Equipamento SelecionarEquipamentoPorId(int idEquipamento)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            else if (e.Id == idEquipamento)
                return e;
        }

        return null!;
    }
}