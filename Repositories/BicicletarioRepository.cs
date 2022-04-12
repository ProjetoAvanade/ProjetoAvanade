using Senai_ProjetoAvanade_webAPI.Contexts;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class BicicletarioRepository : IBicicletarioRepository
    {

        private readonly AvanadeContext ctx;

        public BicicletarioRepository(AvanadeContext appContext)
        {
            ctx = appContext;
        }

        public Bicicletario Buscar(int id)
        {
            return ctx.Bicicletarios.FirstOrDefault(c => c.IdBicicletario == id);
        }

        public void Cadastrar(bicicletarioViewModel bicicletarionovo)
        {
            Bicicletario bicicletariocadastro = new Bicicletario();

            bicicletariocadastro.Nome = bicicletarionovo.Nome;
            bicicletariocadastro.Rua = bicicletarionovo.Rua;
            bicicletariocadastro.Numero = bicicletarionovo.Numero;
            bicicletariocadastro.Bairro = bicicletarionovo.Bairro;
            bicicletariocadastro.Cidade = bicicletarionovo.Cidade;
            bicicletariocadastro.Longitude = bicicletarionovo.Longitude;
            bicicletariocadastro.Latitude = bicicletarionovo.Latitude;
            bicicletariocadastro.Cep = bicicletarionovo.Cep;
            bicicletariocadastro.HorarioAberto = bicicletarionovo.HorarioAberto;
            bicicletariocadastro.HorarioFechado = bicicletarionovo.HorarioFechado;

            ctx.Bicicletarios.Add(bicicletariocadastro);

            ctx.SaveChanges();
        }

        public List<Bicicletario> Listar()
        {
            return ctx.Bicicletarios.ToList();
        }
    }
}
