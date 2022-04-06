using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Repositories;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository context)
        {
            _usuarioRepository = context;
        }

        /// <summary>
        /// Metodo responsavel por fazer login no sistema
        /// </summary>
        /// <param name="login">Objeto do tipo Login com Email e Senha</param>
        /// <returns>Usuario com esse email e senha</returns>
        [HttpPost]
        public IActionResult Login(loginViewModel login)
        {
            try
            {
                Usuario UsuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (UsuarioBuscado != null)
                {
                    var MinhasClains = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString()),
                        new Claim ("role", UsuarioBuscado.IdTipoUsuario.ToString())
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projetoavanade-chave-autenticacao"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var meuToken = new JwtSecurityToken(
                        issuer: "ProjetoAvanade_webAPI",
                        audience: "ProjetoAvanade_webAPI",
                        claims: MinhasClains,
                        expires: DateTime.Now.AddHours(3),
                        signingCredentials: creds
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
                }

                return BadRequest("Email ou Senha Invalidos!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
