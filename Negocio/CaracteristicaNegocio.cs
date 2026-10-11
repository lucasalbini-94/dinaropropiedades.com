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
    public class CaracteristicaNegocio
    {
        private readonly CaracteristicaRepository _repo;

        public CaracteristicaNegocio()
        {
            _repo = new CaracteristicaRepository();
        }

        public List<Caracteristica> ListarTodas()
        {
            return _repo.ObtenerTodos();
        }

        public List<Caracteristica> ListarPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0) throw new ArgumentException("ID de propiedad no válido.");
            return _repo.ObtenerPorPropiedad(idPropiedad);
        }

        public Caracteristica ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        public bool GuardarCaracteristicasPropiedad(int idPropiedad, List<int> idsCaracteristicas)
        {
            if (idPropiedad <= 0) throw new ArgumentException("ID de propiedad no válido.");
            return _repo.GuardarCaracteristicasPropiedad(idPropiedad, idsCaracteristicas);
        }

        public bool Guardar(Caracteristica caracteristica)
        {
            if (string.IsNullOrWhiteSpace(caracteristica.Descripcion))
                throw new Exception("La descripción de la característica es obligatoria.");

            if (caracteristica.Id > 0)
                return _repo.Modificar(caracteristica);
            else
                return _repo.Agregar(caracteristica) > 0;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            return _repo.Eliminar(id);
        }
    }
}
