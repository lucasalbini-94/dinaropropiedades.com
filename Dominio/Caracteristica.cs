using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Caracteristica
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public bool Activo { get; set; }
    }
}
