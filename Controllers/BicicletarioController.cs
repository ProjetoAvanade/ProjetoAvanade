using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;

namespace Senai_ProjetoAvanade_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BicicletarioController : ControllerBase
    {
        private readonly IBicicletarioRepository _bicicletarioRepository; //E declarado um IBicicletarioRepository

        public BicicletarioController(IBicicletarioRepository bicicletario) 
            //O controller vai ser instanciado com uma Interface juntando os dados de uma Interface com a outra atribuindo os valores
        {
            _bicicletarioRepository = bicicletario;
        }

        /// <summary>
        /// Metodo responsave pelo cadastro de novos bicicletarios
        /// </summary>
        /// <param name="bicicletarionovo">Novo bicicletario a ser cadastrado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(bicicletarioViewModel bicicletarionovo)
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

        /// <summary>
        /// Metodo responsavel pela listagem de todos os bicicletarios
        /// </summary>
        /// <returns>Uma lista de Bicicletarios</returns>
        [Authorize(Roles = "2")]
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

        /// <summary>
        /// Metodo responsavel por buscar um bicicletario por id
        /// </summary>
        /// <param name="id">Id do bicicletario buscado</param>
        /// <returns>Um bicicletario com um id igual ao enviado</returns>
        [Authorize(Roles = "2")]
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
