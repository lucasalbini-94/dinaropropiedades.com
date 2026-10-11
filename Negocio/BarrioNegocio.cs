using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;
using Servicios.Interfaces;
using Servicios.Repositorios;

namespace Negocio
{
    public class BarrioNegocio
    {
        private readonly IBarrioRepository _repo;

        public BarrioNegocio()
        {
            _repo = new BarrioRepository();
        }

        public BarrioNegocio(IBarrioRepository repo)
        {
            _repo = repo;
        }
        public List<Barrio> ListarTodos()
        {
            return _repo.ObtenerTodos();
        }

        public Barrio ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        public bool Guardar(Barrio barrio)
        {
            if (string.IsNullOrWhiteSpace(barrio.Descripcion))
                throw new Exception("El nombre del barrio es obligatorio.");

            if (barrio.Id > 0)
                return _repo.Modificar(barrio);
            else
                return _repo.Agregar(barrio) > 0;
        }

        public bool Modificar(Barrio entidad)
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
