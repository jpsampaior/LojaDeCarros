
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;

namespace TrabalhoFinal.Servicos
{
    internal class ServicoAluguel:Servico
    {
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }

        public ServicoAluguel(DateTime dataDevolucao, Funcionario vendedor, Funcionario gerente, Cliente cliente, Carro carro) : base(vendedor, gerente, cliente, carro)
        {
            DataRetirada = DateTime.Now;
            DataDevolucao = dataDevolucao;
            Taxa = new TaxaAluguel();
        }

        public override float processarValor()
        {
            TimeSpan duracao = DataDevolucao.Subtract(DataRetirada);
            float valor = (float)Math.Ceiling(duracao.TotalDays) * Carro.Valor;

            return valor + (float)Taxa.Taxar(valor) - Cliente.calcularDesconto(valor);
        }

        public override void adicionarBonusFuncionario()
        {
            Gerente.adicionarBonusVendas(processarValor());
            Vendedor.adicionarBonusVendas(processarValor());
        }

        public override void gerarNotaFiscal()
        {
            Cliente.TotalCompras += 1;
            adicionarBonusFuncionario();
            NotaFiscal = new NotaFiscal(processarValor(), Cliente);
            Console.WriteLine(NotaFiscal);
        }
    }
}
