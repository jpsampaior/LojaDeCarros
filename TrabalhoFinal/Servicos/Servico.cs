using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;

namespace TrabalhoFinal.Servicos
{
    abstract class Servico:IServico
    {
        public Funcionario Vendedor { get; set; }
        public Funcionario Gerente { get; set; }
        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
        public ITaxa Taxa { get; set; }
        public NotaFiscal NotaFiscal { get; set; }

        public Servico(Funcionario vendedor, Funcionario gerente, Cliente cliente, Carro carro)
        {
            this.Vendedor = vendedor;
            this.Gerente = gerente;
            this.Cliente = cliente;
            this.Carro = carro;
            this.Taxa = null;
            this.NotaFiscal = null;
        }

        public abstract float processarValor();
        public abstract void gerarNotaFiscal();
        public abstract void adicionarBonusFuncionario();
        
    }
}
