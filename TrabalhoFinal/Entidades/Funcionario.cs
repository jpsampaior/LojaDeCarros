using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Entidades
{
    abstract class Funcionario:Pessoa
    {
        public float Salario { get; set; }
        public float BonusVendas { get; set; }
        public string Cargo { get; set; }

        public Funcionario(string cpf, string nome, int telefone, float salario) : base(cpf, nome, telefone)
        {
            Salario = salario;
            BonusVendas = 0;
        }

        public abstract void adicionarBonusVendas(float valor);

        public float calcularSalario()
        {
            return Salario + BonusVendas;
        }

        public override string ToString()
        {
            return $"CPF: {Cpf} \n" +
                $"Nome: {Nome} \n" +
                $"Telefone: {Telefone} \n" +
                $"Salario Padrao: {Salario} \n" +
                $"Bonus Total Recebido por Vendas: {BonusVendas} \n" +
                $"Cargo: {Cargo} \n";
        }
    }
}
