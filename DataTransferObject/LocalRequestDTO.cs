using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.DataTransferObject
{
    public class LocalRequestDTO
    {
        [Required(ErrorMessage = "Informe a Latitude")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Informe a Longitude")]
        public double Longitude { get; set; }

        public int metros { get; set; } = 1000;
    }
}
