using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Senai_ProjetoAvanade_webAPI.DataTransferObject;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private readonly IUsuarioRepository _context;

        public LocalizacaoController(IUsuarioRepository context)
        {
            _context = context;
        }

        public static double Radians(double x)
        {
            return x * Math.PI / 180;
        }

        public static double GreatCircleDistance(double lon1, double lat1, double lon2, double lat2)
        {
            double R = 6371e3;

            double sLat1 = Math.Sin(Radians(lat1));
            double sLat2 = Math.Sin(Radians(lat2));
            double cLat1 = Math.Sin(Radians(lat1));
            double cLat2 = Math.Sin(Radians(lat2));
            double cLon = Math.Sin(Radians(lon1) - Radians(lon2));

            double cosD = sLat1 * sLat2 * cLat1 * cLat2 * cLon;

            double d = Math.Acos(cosD);

            double dist = R * d;

            return dist;
        }

        /// <summary>
        /// Metodo responsavel pela listagem de pontos mais proximos da localizacao atual do usuario
        /// </summary>
        /// <param name="request">Argumentos para a requisicao</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Uma lista de pontos do mais proximo pro mais longe</returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Listar_Pontos_Proximos([FromQuery]LocalRequestDTO request, CancellationToken cancellationToken)
        {
            var locais = _context.ListarPontosProxixmos(request.Latitude, request.Longitude, request.metros);

            if (locais == null)
            {
                return NotFound(new { MensagemErro = "Lista de pontos não encontrada"});
            }

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var currentLocation = geometryFactory.CreatePoint(new Coordinate(request.Latitude, request.Longitude));

            var locaisOrdenadosDistancia = locais.ToList().Select(local => new LocalResponseDTO()
            {
                IdBicicletario = local.IdBicicletario,
                Nome = local.Nome,
                Bairro = local.Bairro,
                Cidade = local.Cidade,
                Rua = local.Rua,
                Numero = local.Numero,
                Latitude = Convert.ToDouble(local.Latitude),
                Longitude = Convert.ToDouble(local.Longitude),
                Distancia = GreatCircleDistance(Convert.ToDouble(local.Latitude), Convert.ToDouble(local.Longitude), request.Latitude, request.Longitude),
            });

            return Ok(locaisOrdenadosDistancia);
        }
    }
}
