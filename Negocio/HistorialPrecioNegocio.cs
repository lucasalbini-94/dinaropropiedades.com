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
    public class HistorialPrecioNegocio
    {
        private readonly IHistorialPrecioRepository _repo;

        public HistorialPrecioNegocio()
        {
            _repo = new HistorialPrecioRepository();
        }

        public HistorialPrecioNegocio(IHistorialPrecioRepository repo)
        {
            _repo = repo;
        }

        public List<HistorialPrecio> ListarPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0) throw new ArgumentException("ID de propiedad inválido.");
            return _repo.ObtenerPorPropiedad(idPropiedad);
        }

        public bool RegistrarCambioPrecio(int idPropiedad, string moneda, decimal precioAnterior, string observacion)
        {
            if (idPropiedad <= 0) throw new ArgumentException("ID de propiedad inválido.");
            if (precioAnterior <= 0) throw new ArgumentException("El precio anterior debe ser mayor a cero.");

            HistorialPrecio historial = new HistorialPrecio
            {
                IdPropiedad = idPropiedad,
                Moneda = moneda,
                PrecioAnterior = precioAnterior,
                Observacion = observacion
            };

            return _repo.Agregar(historial) > 0;
        }
    }
}
