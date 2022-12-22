using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Entidades
{
    internal class Vendedor:Funcionario
    {
        public Vendedor(string cpf, string nome, int telefone, float salario) : base(cpf, nome, telefone, salario)
        {
            Cargo = "Vendedor";
        }

        public override void adicionarBonusVendas(float valor)
        {
            BonusVendas += (.10f * valor);
        }
    }
}
