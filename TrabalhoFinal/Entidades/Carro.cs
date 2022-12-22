using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Excecoes;

namespace TrabalhoFinal.Entidades
{
    abstract class Carro
    {
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public float Valor { get; set; }
        public string Finalidade { get; set; }
        public int Id { get; set; }

        string[] fabricantesValidos = { "Honda", "Toyota", "Jeep", "BMW", "Renault", "Ford", "Fiat", "Volkswagen", "Hyundai", "Volvo", "Nissan", "Land Rover", "Jaguar" };
        int verif = 0;

        public Carro(string fabricante, string modelo, float valor, int id)
        {
            for(int i = 0; i < fabricantesValidos.Length; i++)
            {
                if (fabricante == fabricantesValidos[i]) verif = 1;
            }

            if (verif == 1) Fabricante = fabricante;
            else throw new ParametroInvalidoException("Fabricante fornecido não aceito");

            Modelo = modelo;

            if(valor <= 0) throw new ParametroInvalidoException("Valor digitado não se aplica");
            else Valor = valor;

            if (id <= 0) throw new ParametroInvalidoException("Id digitado não se aplica");
            else Id = id;
        }


    }
}
