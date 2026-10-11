using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HistorialPrecio
    {
        public int Id { get; set; }
        public int IdPropiedad { get; set; }
        public string Moneda { get; set; }
        public decimal PrecioAnterior { get; set; }
        public DateTime FechaCambio { get; set; }
        public string Observacion { get; set; }
    }
}
