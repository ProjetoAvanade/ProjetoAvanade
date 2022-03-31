using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_ProjetoAvanade_webAPI.Contexts;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _context;

        public UsuarioController(UsuarioRepository context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo para novos usuarios poderem se cadastrar
        /// </summary>
        /// <param name="usuarionovo">Objeto do tipo usuario que vai ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuarionovo)
        {

            try
            {
                _context.Usuarios.Cadastrar(usuarionovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Metodo para buscar informações de um usuario especifico
        /// </summary>
        /// <param name="id">Id que sera usado para comparacao</param>
        /// <returns>Usuario com o id igual ao enviado</returns>
        
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            try
            {

                return Ok(_context.Usuarios.BuscarId(id));

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
    }
}
