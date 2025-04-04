using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    public class Chamado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public Equipamento Equipamento { get; set; }

        public Chamado(string titulo, string descricao, DateTime dataAbertura/*, Equipamento equipamento*/)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataAbertura = dataAbertura;
            //Equipamento = equipamento;
        }
    }
}