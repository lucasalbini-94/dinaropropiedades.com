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
    public class TipoPropiedadNegocio
    {

        private readonly ITipoPropiedadRepository _repo;

        public TipoPropiedadNegocio()
        {
            _repo = new TipoPropiedadRepository();
        }

        public TipoPropiedadNegocio(ITipoPropiedadRepository repo)
        {
            _repo = repo;
        }

        public List<TipoPropiedad> ListarTodas()
        {
            return _repo.ObtenerTodos();
        }

        public TipoPropiedad ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        public bool Guardar(TipoPropiedad tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
                throw new Exception("La descripción del tipo de propiedad no puede estar vacía.");

            if (tipo.Id > 0)
                return _repo.Modificar(tipo);
            else
                return _repo.Agregar(tipo) > 0;
        }

        public bool Modificar(TipoPropiedad tipo)
        {
            return _repo.Modificar(tipo);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            return _repo.Eliminar(id);
        }
    }
}
