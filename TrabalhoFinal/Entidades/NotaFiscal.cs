using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Entidades
{
    internal class NotaFiscal
    {
        public float ValorTotal { get; set; }
        public Cliente Cliente { get; set; }

        public NotaFiscal(float valorTotal, Cliente cliente)
        {
            ValorTotal = valorTotal;
            Cliente = cliente;
        }

        public override string ToString()
        {
            return Cliente.ToString() + $"\nValor da Compra: {ValorTotal}";
        }
    }
}
