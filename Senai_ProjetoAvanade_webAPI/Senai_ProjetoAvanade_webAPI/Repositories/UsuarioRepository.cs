using Senai_ProjetoAvanade_webAPI.Contexts;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AvanadeContext ctx;

        public UsuarioRepository(AvanadeContext appContext)
        {
            ctx = appContext;
        }

        public Usuario BuscarId(int id)
        {
           // Usuario usuariobuscado = 

            return ctx.Usuarios.Select(U => new Usuario()
            {
                NomeUsuario = U.NomeUsuario,
                IdTipoUsuario = U.IdTipoUsuario,
                DataNascimento = U.DataNascimento,
                Email = U.Email,
                Pontos = U.Pontos,
                Saldo = U.Saldo,
                IdUsuario = U.IdUsuario
            })
                .FirstOrDefault(c => c.IdUsuario == id); 
             
        }

        public void Cadastrar(Usuario usuarionovo)
        {
            ctx.Usuarios.Add(usuarionovo);

            ctx.SaveChanges();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha.Length < 32)
                {
                    usuario.Senha = Crypto.Gerar_Hash(usuario.Senha);
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

                bool comparado = Crypto.Comparar(senha, usuario.Senha);

                if (comparado == true)
                {
                    return usuario;
                }
            }

            return null;
        }
    }
}
