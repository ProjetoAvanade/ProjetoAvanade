using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Repositories;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reserva)
        {
            _reservaRepository = reserva;
        }

        /// <summary>
        /// Metodo reponsavel pelo cadastro de novas reservas
        /// </summary>
        /// <param name="NovaReserva">Uma nova reserva a ser cadastrada</param>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Reserva NovaReserva)
        {
            try
            {
                _reservaRepository.Cadastrar(NovaReserva);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Metodo responsavel por atualizar uma reserva ja existente
        /// </summary>
        /// <param name="id">Id da reserva a ser atualizada</param>
        /// <param name="ReservaAtualizada">Novas informações</param>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, reservaViewModel ReservaAtualizada)
        {
            try
            {
                _reservaRepository.Atualizar(id, ReservaAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Metodo responsavel por listar as reservas do usuario logado
        /// </summary>
        /// <returns>Uma lista de reservas</returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Listar_Minhas()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_reservaRepository.Listar_Minhas(id));
            }
            catch (Exception ex)
            {

                return BadRequest(new { 
                mensage = "Usuario precisa estar logado para ver as suas reservas", ex
                });
            }
        }
    }
}
