using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Servicos;
using TrabalhoFinal.Excecoes;

namespace TrabalhoFinal.Entidades
{
    internal class Locadora
    {
        List<Funcionario> funcionarios;
        List<Carro> carros;
        Busca busca;
        List<Servico> servicos;
        List<Cliente> clientes;

        public Locadora(List<Funcionario> funcionarios, List<Carro> carros, List<Cliente> clientes)
        {
            this.funcionarios = funcionarios;
            this.carros = carros;
            this.busca = new Busca(carros);
            this.servicos = new List<Servico>();
            this.clientes = clientes;
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }

        public void ProcurarFuncionarioPorCago(string cargo)
        {
            funcionarios.FindAll(x => x.Cargo == cargo).ForEach(Console.WriteLine);
        }

        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public Funcionario ProcurarFuncionarioPorCPF(string cpf)
        {
            Funcionario retorno = funcionarios.Find(x => x.Cpf == cpf );

            if (retorno == null) throw new ObjectNotFoundException("O funcionário procurado não se encontra dentro do banco de dados, tente novamente");

            else
            {
                Console.WriteLine(retorno);
                return retorno;
            }
        }



        public void BuscarCarroAluguel()
        {
            Console.WriteLine("Carros disponíveis para alugar:");
            Console.WriteLine();
            busca.BuscarCarroAluguel().ForEach(Console.WriteLine);
        }

        public void BuscarCarroVenda()
        {
            Console.WriteLine("Carros disponíveis para compra:");
            Console.WriteLine();
            busca.BuscarCarroVenda().ForEach(Console.WriteLine);
        }

        public Carro BuscarCarroPorId(int id)
        {
            Carro retorno = carros.Find(x => x.Id == id);

            if (retorno == null) throw new ObjectNotFoundException("O carro procurado não se encontra dentro do banco de dados, tente novamente");

            else
            {
                Console.WriteLine(retorno);
                return retorno;
            }
        }

        public Cliente BuscarClientePorCPF(string cpf)
        {
            Cliente retorno = clientes.Find(x => x.Cpf == cpf);

            if (retorno == null) throw new ObjectNotFoundException("O cliente procurado não se encontra dentro do banco de dados, tente novamente");

            else
            {
                Console.WriteLine(retorno);
                return retorno;
            }
        }

        public void BuscarClientes()
        {
            clientes.FindAll(x=>x.Cpf != null).ForEach(Console.WriteLine);
        }

        public void AdicionarCarro(Carro carro)
        {
            carros.Add(carro);
            Console.WriteLine(carro);
        }

        public void OperacaoAluguel(ServicoAluguel servicoAluguel)
        {
            servicoAluguel.gerarNotaFiscal();
            servicos.Add(servicoAluguel);
        }

        public void OperacaoVenda(ServicoVenda servicoVenda)
        {
            servicoVenda.gerarNotaFiscal();
            servicos.Add(servicoVenda);
        }
    }
}
