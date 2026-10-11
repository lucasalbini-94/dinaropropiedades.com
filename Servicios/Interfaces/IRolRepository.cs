using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface IRolRepository : IRepository<Rol>
    {
        List<Permiso> ObtenerPermisosPorRol(int idRol);
        bool GuardarPermisosRol(int idRol, List<int> idsPermisos);
    }

    public interface IPermisoRepository : IRepository<Permiso>
    {
        Permiso ObtenerPorCodigo(string codigo);
    }
}
