using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.ViewModels
{
    public class reservaViewModel
    {
        public DateTime? FechaTrava { get; set; }
        public decimal? Preco { get; set; }
        public bool? StatusPagamento { get; set; }
    }
}
