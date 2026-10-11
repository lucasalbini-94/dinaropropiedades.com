using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Banner
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string TextoBoton { get; set; }
        public string UrlDestino { get; set; }
        public bool NuevaPagina { get; set; }
        public string RutaImagen { get; set; }
        public string Alt { get; set; }
        public short Orden { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public bool Activo { get; set; }
    }
}
