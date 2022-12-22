using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;

namespace TrabalhoFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cpfs = { "05949451352", "12345678902", "05949451353", "12345678904", "05949451354", "12345678906" };
            string[] nomes = { "Felipe Costa", "Pedro Mendes", "Gustavo Peixoto", "Ana Fernandes", "Roberta Bezerra", "Laura Tavares" };
            int[] telefones = { 098765433, 098765434, 098765435, 098765436, 098765437, 098765438 };
            float[] salarios = { 4100f, 4825f, 2500f, 3592f };
            string[] fabricantes = { "Honda", "Renault", "Jeep", "Fiat" };
            string[] modelos = { "City", "Kwid", "Compass", "Mobi" };
            float[] valores = { 114900f, 63900f, 312.52f, 96.34f };
            int[] id = { 1, 2, 3, 4 };

            List<Funcionario> funcionarios = new List<Funcionario>();
            List<Cliente> clientes = new List<Cliente>();
            List<Carro> carros = new List<Carro>();

            for (int i = 0; i < 2; i++)
            {
                funcionarios.Add(new Gerente(cpfs[i], nomes[i], telefones[i], salarios[i]));
            }

            for (int i = 2; i < 4; i++)
            {
                funcionarios.Add(new Vendedor(cpfs[i], nomes[i], telefones[i], salarios[i]));
            }

            for (int i = 4; i < 6; i++)
            {
                clientes.Add(new Cliente(cpfs[i], nomes[i], telefones[i]));
            }

            for (int i = 0; i < 2; i++)
            {
                carros.Add(new CarroVenda(fabricantes[i], modelos[i], valores[i], id[i]));
            }

            for (int i = 2; i < 4; i++)
            {
                carros.Add(new CarroAluguel(fabricantes[i], modelos[i], valores[i], id[i]));
            }

            Menu menu = new Menu(new Locadora(funcionarios, carros, clientes));

            menu.MenuInicial();  
        }
    }
}
