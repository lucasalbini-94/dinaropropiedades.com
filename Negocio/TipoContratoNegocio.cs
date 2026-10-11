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
    public class  TipoContratoNegocio
    {
        private readonly ITipoContratoRepository _repo;

        public TipoContratoNegocio()
        {
            _repo = new TipoContratoRepository();
        }

        public TipoContratoNegocio(ITipoContratoRepository repo)
        {
            _repo = repo;
        }

        public List<TipoContrato> ListarTodos()
        {
            return _repo.ObtenerTodos();
        }

        public TipoContrato ObtenerPorId(int id)
        {
            return _repo.ObtenerPorId(id);
        }

        public bool Guardar(TipoContrato tipoContrato)
        {
            if (string.IsNullOrWhiteSpace(tipoContrato.Descripcion))
                throw new Exception("La descripción del tipo de contrato no puede estar vacía.");

            if (tipoContrato.Id > 0)
                return _repo.Modificar(tipoContrato);
            else
                return _repo.Agregar(tipoContrato) > 0;
        }

        public bool Modificar(TipoContrato entidad)
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
