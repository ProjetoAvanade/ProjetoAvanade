using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.ViewModels
{
    public class vagasViewModel
    {
        [Required(ErrorMessage = "É necessario o preenchimento do status da vaga")]
        public bool StatusVagas { get; set; }
    }
}
