using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public decimal PrecoAquisicao { get; set; }
        public DateTime DataFabricacao { get; set; }

        public Equipamento(string nome, string fabricante, decimal precoAquisicao, DateTime dataFabricacao)
        {
            Nome = nome;
            Fabricante = fabricante;
            PrecoAquisicao = precoAquisicao;
            DataFabricacao = dataFabricacao;
        }

        public string ObterNumeroSerie()
        {
            string dataFabricacaoCurta = DataFabricacao.ToString("yyyyMM");
            string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper() + Id;

            return string.Join('-', dataFabricacaoCurta, tresPrimeirosCaracteres);
        }
    }
}