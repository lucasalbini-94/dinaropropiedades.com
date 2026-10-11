using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Log
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public string Accion { get; set; }
        public string Entidad { get; set; }
        public int? IdRegistro { get; set; }
        public string Detalle { get; set; }
        public string DireccionIP { get; set; }
        public string UserAgent { get; set; }
    }
}
