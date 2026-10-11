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
    public class PropiedadNegocio
    {
        private readonly IPropiedadRepository _propiedadRepo;

        // Constructor por defecto: Asigna la implementación ADO.NET
        public PropiedadNegocio()
        {
            _propiedadRepo = new PropiedadRepository();
        }

        // Constructor sobrecargado: Permite inyectar repositorios alternativos o Mocking para pruebas
        public PropiedadNegocio(IPropiedadRepository propiedadRepo)
        {
            _propiedadRepo = propiedadRepo;
        }

        #region Métodos de Lectura

        public List<Propiedad> ListarTodas()
        {
            return _propiedadRepo.ObtenerTodos();
        }

        public Propiedad ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la propiedad no es válido");

            return _propiedadRepo.ObtenerPorId(id);
        }

        public int ObtenerSiguienteId()
        {
            return _propiedadRepo.ObtenerSiguienteId();
        }

        public Propiedad ObtenerPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentException("Debe proporcionar un código de propiedad");

            return _propiedadRepo.ObtenerPorCodigo(codigo);
        }

        public List<Propiedad> BuscarConFiltros(int? idTipo, int? idContrato, int? idBarrio, decimal? precioMax)
        {
            return _propiedadRepo.BuscarConFiltros(idTipo, idContrato, idBarrio, precioMax);
        }

        public List<Propiedad> ListarDestacadas()
        {
            return _propiedadRepo.ObtenerDestacadas();
        }

        public List<Propiedad> ObtenerUltimasCargadas(int cantidad = 5)
        {
            return _propiedadRepo.ObtenerUltimasCargadas(cantidad);
        }

        #endregion

        #region Lógica de Guardado (Altas y Modificaciones)

        public int Guardar(Propiedad propiedad)
        {
            // Validar Reglas de Negocio
            ValidarPropiedad(propiedad);

            // Normalizar datos
            propiedad.Codigo = propiedad.Codigo.Trim().ToUpper();
            propiedad.Titulo = propiedad.Titulo.Trim();

            // Verificar que no exista otra propiedad con el mismo código
            var existeCodigo = _propiedadRepo.ObtenerPorCodigo(propiedad.Codigo);
            if (existeCodigo != null)
            {
                throw new InvalidOperationException($"Ya existe una propiedad registrada con el código {propiedad.Codigo}");
            }

            return _propiedadRepo.Agregar(propiedad);
        }

        public bool Modificar(Propiedad propiedad)
        {
            // Validar Reglas de Negocio
            ValidarPropiedad(propiedad);

            // Normalizar datos
            propiedad.Codigo = propiedad.Codigo.Trim().ToUpper();
            propiedad.Titulo = propiedad.Titulo.Trim();

            return _propiedadRepo.Modificar(propiedad);
        }

        #endregion

        #region Operaciones de Estado y Eliminacion

        public bool CambiarEstado(int idPropiedad, bool activo)
        {
            if (idPropiedad <= 0)
            {
                throw new ArgumentException("El ID de la propiedad no es válido");
            }

            return _propiedadRepo.CambiarEstado(idPropiedad, activo);
        }

        public bool MarcarComoDestacado(int idPropiedad, bool destacado)
        {
            if (idPropiedad <= 0)
            {
                throw new ArgumentException("El ID de la propiedad no es válido");
            }

            return _propiedadRepo.MarcarComoDestacado(idPropiedad, destacado);
        }

        public bool Eliminar(int idPropiedad)
        {
            if (idPropiedad <= 0)
            {
                throw new ArgumentException("El ID de la propiedad no es válido");
            }

            return _propiedadRepo.Eliminar(idPropiedad);
        }

        #endregion

        #region Métodos Privados de Validación

        private void ValidarPropiedad(Propiedad propiedad)
        {
            if (propiedad == null)
            {
                throw new ArgumentException(nameof(propiedad), "Los datos de la propiedad no pueden ser nulos");
            }

            if (string.IsNullOrEmpty(propiedad.Codigo))
            {
                throw new Exception("El código de la propiedad es obligatorio");
            }

            if (string.IsNullOrEmpty(propiedad.Titulo))
            {
                throw new Exception("El título de la propiedad es obligatorio");
            }

            if (propiedad.IdTipoPropiedad <= 0)
            {
                throw new Exception("Debe seleccionar un tipo de propedad válido");
            }

            if (propiedad.IdTipoContrato <= 0)
            {
                throw new Exception("Debe seleccionar un tipo de contrato válido");
            }

            if (propiedad.IdBarrio <= 0)
            {
                throw new Exception("Debe seleccionar un barrio válido");
            }

            if (propiedad.PrecioActual <= 0)
            {
                throw new Exception("El precio de la propiedad debe ser mayor a cero");
            }

            if (string.IsNullOrEmpty(propiedad.Moneda))
            {
                throw new Exception("Debe especificar la moneda de la operación (ej. USD, ARS)");
            }
        }

        #endregion
    }
}
