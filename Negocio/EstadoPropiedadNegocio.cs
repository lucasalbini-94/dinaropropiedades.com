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
    public class EstadoPropiedadNegocio
    {
        private readonly IEstadoPropiedadRepository _repo;

        public EstadoPropiedadNegocio()
        {
            _repo = new EstadoPropiedadRepository();
        }

        public EstadoPropiedadNegocio(IEstadoPropiedadRepository repo)
        {
            _repo = repo;
        }

        public List<EstadoPropiedad> ListarTodos()
        {
            return _repo.ObtenerTodos();
        }

        public EstadoPropiedad ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        public bool Guardar(EstadoPropiedad estado)
        {
            if (string.IsNullOrWhiteSpace(estado.Descripcion))
                throw new Exception("La descripción del estado de propiedad es obligatoria.");

            if (estado.Id > 0)
                return _repo.Modificar(estado);
            else
                return _repo.Agregar(estado) > 0;
        }

        public bool Modificar(EstadoPropiedad entidad)
        {
            return _repo.Modificar(entidad);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            return _repo.Eliminar(id);
        }
    }
}
