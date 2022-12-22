using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Servicos
{
    internal class TaxaVenda:ITaxa
    {
        public float Taxar(float quantia)
        {
            if (quantia < 100000)
            {
                return quantia * .15f;
            }
            else
            {
                return quantia * .10f;
            }
        }
    }
}
