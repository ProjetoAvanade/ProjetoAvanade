using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Utils;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Senai_ProjetoAvanade_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _context;

        public UsuarioController(IUsuarioRepository context)
        {
            _context = context;
        }


        /// <summary>
        /// Metodo responsavel pelo cadastro de usuarios
        /// </summary>
        /// <param name="usuarionovo">Novo usuario a ser cadastrado</param>
        /// <param name="arquivo">Imagem de perfil da pessoa</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar([FromForm] usuarioViewModel usuarionovo, IFormFile arquivo)
        {
            try
            {
                string[] extensoesPermitidas = { "jpg", "png", "jpeg" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado");
                }

                if (uploadResultado == "Extensão não permitida")
                {
                    return BadRequest("Extensão de arquivo não permitida");
                }

                usuarionovo.Imagem = uploadResultado;

                _context.Cadastrar(usuarionovo);

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
        /// <returns>Usuario com o id igual ao enviado</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Buscar()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_context.BuscarId(id));

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        //[Authorize(Roles = "2")]
        [HttpPut]
        public IActionResult AtualizarSaldo(saldoViewModel teste)
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                Usuario usuarioteste = _context.AtualizarSaldo(teste, id);
                if (usuarioteste == null)
                {
                    return BadRequest(new {mensagem = "Quantidade de pontos insuficiente"  });
                }
                return Ok( new {Saldo_Atual =  usuarioteste.Saldo, Pontos = usuarioteste.Pontos});
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
