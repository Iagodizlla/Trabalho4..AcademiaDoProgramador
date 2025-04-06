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

        public Chamado(string titulo, string descricao, DateTime dataAbertura)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataAbertura = dataAbertura;
        }
    }
}