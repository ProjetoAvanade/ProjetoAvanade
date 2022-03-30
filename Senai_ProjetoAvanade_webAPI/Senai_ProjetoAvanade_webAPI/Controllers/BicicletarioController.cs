using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class BicicletarioController : ControllerBase
    {
        private IBicicletarioRepository _bicicletarioRepository { get; set; }

        public BicicletarioController()
        {
            _bicicletarioRepository = new BicicletarioRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Bicicletario bicicletarionovo)
        {
            try
            {
                _bicicletarioRepository.Cadastrar(bicicletarionovo);

                return StatusCode(201);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_bicicletarioRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                return Ok(_bicicletarioRepository.Buscar(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
