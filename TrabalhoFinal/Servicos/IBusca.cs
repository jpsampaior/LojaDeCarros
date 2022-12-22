using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;

namespace TrabalhoFinal.Servicos
{
    internal interface IBusca
    {
        Carro BuscarPorId(int id);
        List<Carro> BuscarCarroAluguel();
        List<Carro> BuscarCarroVenda();
    }
}
