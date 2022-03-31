using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_ProjetoAvanade_webAPI.Domains;
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
    public class ReservaController : ControllerBase
    {
        private IReservaRepository _reservaRepository { get; set; }

        public ReservaController()
        {      
            _reservaRepository = new ReservaRepository();
        }

        /// <summary>
        /// Metodo reponsavel pelo cadastro de novas reservas
        /// </summary>
        /// <param name="NovaReserva">Uma nova reserva a ser cadastrada</param>
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
    }
}
