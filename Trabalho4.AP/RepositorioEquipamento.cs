using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    public class RepositorioEquipamento
    {
        public Equipamento[] equipamentos = new Equipamento[100];

        public void CadastrarEquipamento(Equipamento novoEquipamento)
        {
            novoEquipamento.Id = GeradorId.GerarIdEquipamento();

            RegistrarItem(novoEquipamento);
        }

        public bool EditarEquipamento(int id, Equipamento equipamentoEditado)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null)
                    continue;

                else if (equipamentos[i].Id == id)
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

        public bool ExcluirEquipamento(int id)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null)
                    continue;

                else if (equipamentos[i].Id == id)
                {
                    equipamentos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public Equipamento[] SelecionarEquipamentos()
        {
            return equipamentos;
        }

        public Equipamento SelecionarEquipamentoPorId(int id)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return e;
            }

            return null;
        }

        public bool ExisteEquipamento(int id)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }

        private void RegistrarItem(Equipamento equipamento)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] != null)
                    continue;

                else
                {
                    equipamentos[i] = equipamento;
                    break;
                }
            }
        }
    }
}
