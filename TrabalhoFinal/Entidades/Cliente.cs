using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Entidades
{
    internal class Cliente:Pessoa
    {
        public int TotalCompras { get; set; }

        public Cliente(string cpf, string nome, int telefone) : base(cpf, nome, telefone)
        {
            TotalCompras = 0;
        }

        public virtual float calcularDesconto(float valor)
        {

            if (TotalCompras % 3 == 0 || TotalCompras == 0) return valor * .1f;
            else return valor * 0f;
        }

        public override string ToString()
        {
            return $"CPF: {Cpf} \n" +
                $"Nome: {Nome} \n" +
                $"Telefone: {Telefone} \n" +
                $"Total de Compras Realizadas: {TotalCompras} \n";
        }
    }
}
