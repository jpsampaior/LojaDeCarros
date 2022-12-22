using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;

namespace TrabalhoFinal.Servicos
{
    internal class Busca : IBusca
    {
        List<Carro> carros;

        public Busca(List<Carro> carros)
        {
            this.carros = carros;
        }

        public Carro BuscarPorId(int id)
        {
            return carros.Find(x => x.Id == id);
        }

        public List<Carro> BuscarCarroAluguel()
        {
            return carros.FindAll(x => x.Finalidade == "Aluguel");
        }

        public List<Carro> BuscarCarroVenda()
        {
            return carros.FindAll(x => x.Finalidade == "Venda");
        }
    }
}
