using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;
using Servicios.Repositorios;

namespace Negocio
{
    public class RolNegocio
    {
        private readonly IRolRepository _repo;

        public RolNegocio()
        {
            _repo = new RolRepository();
        }

        public RolNegocio(IRolRepository repo)
        {
            _repo = repo;
        }

        public List<Rol> ListarTodos()
        {
            return _repo.ObtenerTodos();
        }

        public List<Permiso> ListarPermisosPorRol(int idRol)
        {
            if (idRol <= 0) throw new ArgumentException("ID de rol no válido.");
            return _repo.ObtenerPermisosPorRol(idRol);
        }

        public bool GuardarPermisos(int idRol, List<int> idsPermisos)
        {
            if (idRol <= 0) throw new ArgumentException("ID de rol no válido.");
            return _repo.GuardarPermisosRol(idRol, idsPermisos);
        }

        public bool Guardar(Rol rol)
        {
            if (string.IsNullOrWhiteSpace(rol.Descripcion))
                throw new Exception("La descripción del rol es obligatoria.");

            if (rol.Id > 0)
                return _repo.Modificar(rol);
            else
                return _repo.Agregar(rol) > 0;
        }
    }
}
