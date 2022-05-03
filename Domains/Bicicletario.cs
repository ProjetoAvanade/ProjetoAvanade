using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using NetTopologySuite.Geometries;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Domains
{
    public partial class Bicicletario
    {
        public Bicicletario()
        {
            Vagas = new HashSet<Vaga>();
        }

        public int IdBicicletario { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Point Latlong { get; set; }
        public string Cep { get; set; }
        public TimeSpan? HorarioAberto { get; set; }
        public TimeSpan? HorarioFechado { get; set; }

        public virtual ICollection<Vaga> Vagas { get; set; }
    }
}
