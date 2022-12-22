﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;

namespace TrabalhoFinal.Servicos
{
    internal interface IServico
    {
        float processarValor();
        void gerarNotaFiscal();
        void adicionarBonusFuncionario();
        
    }
}
