using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Servicos
{
    internal class TaxaAluguel:ITaxa
    {
        public float Taxar(float quantia)
        {
            if (quantia < 150)
            {
                return quantia * .12f;
            }
            else
            {
                return quantia * .10f;
            }
        }
    }
}
