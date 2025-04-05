using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    internal class RegistroChamado
    {
        public Chamado[] chamados = new Chamado[100];
        private void RegistrarChamado(Chamado chamado)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null)
                    continue;

                else
                {
                    chamados[i] = chamado;
                    break;
                }
            }
        }
        public bool EditarChamado(int id, Chamado chamadoEditado)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null)
                    continue;

                else if (chamados[i].Id == id)
                {
                    chamados[i].Titulo = chamadoEditado.Titulo;
                    chamados[i].Descricao = chamadoEditado.Descricao;
                    chamados[i].DataAbertura = chamadoEditado.DataAbertura;
                    //chamados[i].Equipamento.Id = chamadoEditado.Equipamento.Id;

                    return true;
                }
            }
            return false;
        }
        public bool ExisteChamado(int id)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado e = chamados[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }
        public void CadastrarChamado(Chamado novoChamado)
        {
            novoChamado.Id = GeradorId.GerarIdChamado();
            RegistrarChamado(novoChamado);
        }
        public Chamado[] SelecionarChamado()
        {
            return chamados;
        }
    }
}
