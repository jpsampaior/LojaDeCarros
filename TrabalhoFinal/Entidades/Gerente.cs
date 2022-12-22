using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Entidades
{
    internal class Gerente:Funcionario
    {
        public Gerente(string cpf, string nome, int telefone, float salario) : base(cpf, nome, telefone, salario)
        {
            Cargo = "Gerente";
        }

        public override void adicionarBonusVendas(float valor)
        {
            BonusVendas += (.05f * valor);
        }
    }
}
