using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObtenerPorEmail(string email);
        bool ActualizarUltimoLogin(int idUsuario);
        bool CambiarPassword(int idUsuario, string nuevoPasswordHash);
    }
}
