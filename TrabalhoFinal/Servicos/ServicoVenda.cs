using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;

namespace TrabalhoFinal.Servicos
{
    internal class ServicoVenda:Servico
    {
        public ServicoVenda(Funcionario vendedor, Funcionario gerente, Cliente cliente, Carro carro) : base(vendedor, gerente, cliente, carro)
        {
            Taxa = new TaxaVenda();
        }

        public override float processarValor()
        {
            return Carro.Valor + (float)Taxa.Taxar(Carro.Valor) - Cliente.calcularDesconto(Carro.Valor);
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
