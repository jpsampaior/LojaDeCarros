using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Excecoes;

namespace TrabalhoFinal.Entidades
{
    abstract class Pessoa
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }

        public Pessoa(string cpf, string nome, int telefone)
        {
            if (cpf.Length < 11) throw new ParametroInvalidoException("Cpf inválido, por favor tente novamente"); 
            Cpf = cpf;
            Nome = nome;
            Telefone = telefone;
        }
    }
}
