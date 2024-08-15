using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagenes
    {
        public int Id { get; set; }
        public string Ruta { get; set; }
        public int IdPropiedad { get; set; }
        public bool Principal { get; set; }
    }
}
