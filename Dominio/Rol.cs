using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Rol
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public List<Permiso> Permisos { get; set; }

        public Rol()
        {
            Permisos = new List<Permiso>();
        }
    }
}
