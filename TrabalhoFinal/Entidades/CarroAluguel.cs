using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Entidades
{
    internal class CarroAluguel:Carro
    {
        public CarroAluguel(string fabricante, string modelo, float valor, int id) : base(fabricante, modelo, valor, id)
        {
            Finalidade = "Aluguel";
        }

        public override string ToString()
        {
            return $"Id: {Id} \n" + 
                $"Modelo: {Fabricante} {Modelo} \n" +
                $"Valor da Diaria: R${Valor} \n";
        }
    }
}
