using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class LoginRepository : IUsuarioRepository
    {
        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuario.FirstOrDefault(u => u.email == email);

            if (usuario != null)
            {
                if (usuario.senha.Length < 32)
                {
                    usuario.senha = Crypto.Gerar_Hash(usuario.senha);
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

                bool comparado = Crypto.Comparar(senha, usuario.senha);

                if (comparado == true)
                {
                    return usuario;
                }
            }

            return null;
        }
    }
}
