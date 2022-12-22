using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal.Excecoes
{
    internal class ObjectNotFoundException:ApplicationException
    {
        public ObjectNotFoundException(string mensagem):base(mensagem)
        {

        }
    }
}
