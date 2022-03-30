using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class VagasController : ControllerBase
    {
        private IVagasRepository _vagasRepository { get; set; }

        public VagasController()
        {
            _vagasRepository = new VagasRepository();
        }

        /// <summary>
        /// Método responsavel por listar todas as vagas de um bicicletario responsavel
        /// </summary>
        /// <param name="id">id do bicicletario especifico</param>
        /// <returns>Uma lista com as vagas do bicicletario</returns>
        [HttpGet("{id}")]
        public IActionResult ListarTodas(int id)
        {
            try
            {
                return Ok(_vagasRepository.ListarTodas(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
