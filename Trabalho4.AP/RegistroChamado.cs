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
