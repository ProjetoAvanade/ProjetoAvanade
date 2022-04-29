using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.DataTransferObject
{
    public class LocalResponseDTO
    {
        public int IdBicicletario { get; set; }

        public string Nome { get; set; }

        public string Rua { get; set; }

        public int? Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Distancia { get; set; }
    }
}
