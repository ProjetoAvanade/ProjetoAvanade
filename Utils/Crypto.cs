using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Utils
{
    public class Crypto
    {
        public static string Gerar_Hash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Comparar(string senhalogin, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senhalogin, hash);
        }
    }
}
