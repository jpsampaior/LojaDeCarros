using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Excecoes
{
    internal class MenuCaracteristicaInvalidaException:ApplicationException
    {
        public MenuCaracteristicaInvalidaException(string mensagem):base(mensagem)
        {

        }
    }
}
