using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Excecoes
{
    internal class ParametroInvalidoException:ApplicationException
    {
        public ParametroInvalidoException(string mensagem):base(mensagem)
        {

        }
    }
}
