using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdPropiedad { get; set; }
        public string Ruta { get; set; }
        public string Alt { get; set; }
        public bool Principal { get; set; }
        public short Orden { get; set; }
        public bool Activo { get; set; }

        public Imagen()
        {
            Principal = false;
            Orden = 1;
            Activo = true;
        }
    }
}
