using Trabalho4.AP.Compartilhado;
using Trabalho4.AP.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP.ModuloFabricante
{
    public class RegistroFabricante
    {
        public Fabricante[] fabricantes = new Fabricante[100];
        public int contadorFabricantes = 0;
        public void CadastrarFabricante(Fabricante novoFabricante)
        {
            novoFabricante.Id = GeradorIds.GerarIdFabricante();

            fabricantes[contadorFabricantes++] = novoFabricante;
        }
        public Fabricante[] SelecionarFabricantes()
        {
            return fabricantes;
        }
        public bool EditarFabricante(int idFabricante, Fabricante fabricanteEditado)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null) continue;

                else if (fabricantes[i].Id == idFabricante)
                {
                    fabricantes[i].Nome = fabricanteEditado.Nome;
                    fabricantes[i].Email = fabricanteEditado.Email;
                    fabricantes[i].Telefone = fabricanteEditado.Telefone;

                    return true;
                }
            }

            return false;
        }
        public bool ExcluirFabricante(int idEquipamento)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null) continue;

                else if (fabricantes[i].Id == idEquipamento)
                {
                    fabricantes[i] = null!;

                    return true;
                }
            }

            return false;
        }
        public Fabricante SelecionarFabricantePorId(int idFabricante)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante e = fabricantes[i];

                if (e == null)
                    continue;

                else if (e.Id == idFabricante)
                    return e;
            }

            return null!;
        }
    }
}