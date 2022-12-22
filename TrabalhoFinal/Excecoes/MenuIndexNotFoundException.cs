using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Excecoes
{
    internal class MenuIndexNotFoundException : ApplicationException
    {
        public MenuIndexNotFoundException(string mensagem):base(mensagem) 
        {
        }
    }
}
