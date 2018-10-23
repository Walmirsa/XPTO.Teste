
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XPTO.Entidades
{
    [Serializable]
    public class Enumeradores
    {
        public enum RelatorioTipo
        {
            Nulo=0,
            Vendas = 1,
            Clientes =2
        }
    }
}