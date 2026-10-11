using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class HistorialPrecioRepository : IHistorialPrecioRepository
    {
        public List<HistorialPrecio> ObtenerTodos()
        {
            List<HistorialPrecio> lista = new List<HistorialPrecio>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, IdPropiedad, Moneda, PrecioAnterior, FechaCambio, Observacion FROM HistorialPrecio ORDER BY FechaCambio DESC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(MapearHistorial(datos));
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public HistorialPrecio ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, IdPropiedad, Moneda, PrecioAnterior, FechaCambio, Observacion FROM HistorialPrecio WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return MapearHistorial(datos);
                }
                return null;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<HistorialPrecio> ObtenerPorPropiedad(int idPropiedad)
        {
            List<HistorialPrecio> lista = new List<HistorialPrecio>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, IdPropiedad, Moneda, PrecioAnterior, FechaCambio, Observacion FROM HistorialPrecio WHERE IdPropiedad = @IdPropiedad ORDER BY FechaCambio DESC");
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(MapearHistorial(datos));
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public int Agregar(HistorialPrecio entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    INSERT INTO HistorialPrecio (IdPropiedad, Moneda, PrecioAnterior, FechaCambio, Observacion)
                    VALUES (@IdPropiedad, @Moneda, @PrecioAnterior, SYSDATETIME(), @Observacion);
                    SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@IdPropiedad", entidad.IdPropiedad);
                datos.setearParametro("@Moneda", entidad.Moneda);
                datos.setearParametro("@PrecioAnterior", entidad.PrecioAnterior);
                datos.setearParametro("@Observacion", (object)entidad.Observacion ?? DBNull.Value);

                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Modificar(HistorialPrecio entidad)
        {
            throw new NotImplementedException("El historial de precios no se modifica, solo se registran altas.");
        }

        public bool Eliminar(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("DELETE FROM HistorialPrecio WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }

        private HistorialPrecio MapearHistorial(AccesoDB datos)
        {
            return new HistorialPrecio
            {
                Id = (int)datos.Lector["Id"],
                IdPropiedad = (int)datos.Lector["IdPropiedad"],
                Moneda = (string)datos.Lector["Moneda"],
                PrecioAnterior = (decimal)datos.Lector["PrecioAnterior"],
                FechaCambio = (DateTime)datos.Lector["FechaCambio"],
                Observacion = datos.Lector["Observacion"] != DBNull.Value ? (string)datos.Lector["Observacion"] : null
            };
        }
    }
}
