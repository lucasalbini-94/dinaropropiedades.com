using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
        public bool Activo { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public DateTime FechaAlta { get; set; }

        public List<Propiedad> Favoritos { get; set; }

        public Usuario()
        {
            Favoritos = new List<Propiedad>();
            Activo = true;
        }
    }
}
