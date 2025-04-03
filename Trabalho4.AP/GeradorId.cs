using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho4.AP
{
    public static class GeradorId
    {
        private static int IdEquipamentos = 0;

        public static int GerarIdEquipamento()
        {
            return ++IdEquipamentos;
        }
    }
}