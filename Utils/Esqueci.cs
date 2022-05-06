using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Utils
{
    public class Esqueci
    {
        public void Codigodevalidacao()
        {
            Random codigo = new Random();

            Random[] teste = new Random[6];

            for (int i = 0; i < 6; i++)
            {
                codigo.Next(1,9);

                Console.WriteLine(codigo);

                teste[i] = codigo;
            }

            Console.WriteLine(teste);
        }
    }
}
