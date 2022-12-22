using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Entidades
{
    internal class CarroVenda:Carro
    {
        public CarroVenda(string fabricante, string modelo, float valor, int id) : base(fabricante, modelo, valor, id)
        {
            Finalidade = "Venda";
        }

        public override string ToString()
        {
            return $"Id: {Id} \n" +
                $"Modelo: {Fabricante} {Modelo} \n" +
                $"Valor de Venda: R${Valor} \n";
        }
    }
}
