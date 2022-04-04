using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Repositories;
using Senai_ProjetoAvanade_webAPI.ViewModels;
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

        private readonly IVagasRepository _vagasRepository;

        public VagasController(IVagasRepository vagas)
        {
            _vagasRepository = vagas;
        }

        /// <summary>
        /// Método responsavel por listar todas as vagas de um bicicletario responsavel
        /// </summary>
        /// <param name="id">id do bicicletario especifico</param>
        /// <returns>Uma lista com as vagas do bicicletario</returns>
        [Authorize(Roles = "2")]
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

        /// <summary>
        /// Metodo responsavel pela atualizacao do status de uma vaga
        /// </summary>
        /// <param name="id">Id da vaga a ser buscada</param>
        /// <param name="status_novo">Novo valor para o status dessa vaga</param>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult AtualizarStatusVaga(int id, vagasViewModel status_novo)
        {
            try
            {
                _vagasRepository.Atualizar(id, status_novo);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
