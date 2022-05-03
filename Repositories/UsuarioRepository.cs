using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using Senai_ProjetoAvanade_webAPI.Context;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Utils;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AvanadeContext ctx;

        public UsuarioRepository(AvanadeContext appContext)
        {
            ctx = appContext;
        }

        public Usuario AtualizarSaldo(saldoViewModel teste, int id)
        {
            Usuario usuariologado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

            if (usuariologado.Pontos != 0)
            {
                var resto = (usuariologado.Pontos - (Convert.ToInt32(teste.Saldo) * 15));

                if (resto >= 0)
                {
                usuariologado.Pontos = (usuariologado.Pontos - (Convert.ToInt32(teste.Saldo) * 15));

                usuariologado.Saldo = (teste.Saldo + usuariologado.Saldo);

                ctx.Usuarios.Update(usuariologado);
                ctx.SaveChanges();

                return usuariologado;
                }

                else
                {
                    return null;
                }

            }

            return null;


            //return "Usuario não tem pontos suficientes";
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
                Imagem = U.Imagem,
                IdUsuario = U.IdUsuario,
            })
                .FirstOrDefault(c => c.IdUsuario == id); 
             
        }

        public void Cadastrar([FromForm] usuarioViewModel usuarionovo)
        {

            Usuario usuarioteste = new Usuario();

            usuarioteste.IdTipoUsuario = usuarionovo.IdTipoUsuario;
            usuarioteste.NomeUsuario = usuarionovo.NomeUsuario;
            usuarioteste.Email = usuarionovo.Email;
            usuarioteste.Senha = usuarionovo.Senha;
            usuarioteste.Cpf = usuarionovo.Cpf;
            usuarioteste.DataNascimento = usuarionovo.DataNascimento;
            usuarioteste.Imagem = usuarionovo.Imagem;
            
            ctx.Usuarios.Add(usuarioteste);

            ctx.SaveChanges();
        }

        public List<Bicicletario> ListarPontosProxixmos(double Latitude, double Longitude, int metros = 1000)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory();
            var myLocation = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(Latitude, Longitude));

            List<Bicicletario> locais = ctx.Bicicletarios.ToList();

            return locais.OrderBy(x => x.Latlong.Distance(myLocation)).Where(x => x.Latlong.IsWithinDistance(myLocation, metros)).ToList();

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
