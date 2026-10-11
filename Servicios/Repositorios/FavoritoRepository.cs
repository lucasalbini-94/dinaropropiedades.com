using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class FavoritoRepository : IFavoritoRepository
    {
        public List<Propiedad> ObtenerFavoritosPorUsuario(int idUsuario)
        {
            List<Propiedad> lista = new List<Propiedad>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    SELECT P.Id, P.Codigo, P.Titulo, P.PrecioActual, P.Moneda, P.Activo,
                           TP.Descripcion AS TipoPropiedadDesc,
                           TC.Descripcion AS TipoContratoDesc,
                           EP.Descripcion AS EstadoPropiedadDesc,
                           B.Descripcion AS BarrioDesc
                    FROM Favorito F
                    INNER JOIN Propiedad P ON F.IdPropiedad = P.Id
                    INNER JOIN TipoPropiedad TP ON P.IdTipoPropiedad = TP.Id
                    INNER JOIN TipoContrato TC ON P.IdTipoContrato = TC.Id
                    INNER JOIN EstadoPropiedad EP ON P.IdEstadoPropiedad = EP.Id
                    INNER JOIN Barrio B ON P.IdBarrio = B.Id
                    WHERE F.IdUsuario = @IdUsuario AND P.Activo = 1");

                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Propiedad
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = (string)datos.Lector["Codigo"],
                        Titulo = (string)datos.Lector["Titulo"],
                        PrecioActual = (decimal)datos.Lector["PrecioActual"],
                        Moneda = (string)datos.Lector["Moneda"],
                        Activo = (bool)datos.Lector["Activo"],
                        TipoPropiedad = new TipoPropiedad { Descripcion = (string)datos.Lector["TipoPropiedadDesc"] },
                        TipoContrato = new TipoContrato { Descripcion = (string)datos.Lector["TipoContratoDesc"] },
                        EstadoPropiedad = new EstadoPropiedad { Descripcion = (string)datos.Lector["EstadoPropiedadDesc"] },
                        Barrio = new Barrio { Descripcion = (string)datos.Lector["BarrioDesc"] }
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Agregar(int idUsuario, int idPropiedad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO Favorito (IdUsuario, IdPropiedad, Fecha) VALUES (@IdUsuario, @IdPropiedad, SYSDATETIME())");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Eliminar(int idUsuario, int idPropiedad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("DELETE FROM Favorito WHERE IdUsuario = @IdUsuario AND IdPropiedad = @IdPropiedad");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool EsFavorito(int idUsuario, int idPropiedad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT COUNT(1) FROM Favorito WHERE IdUsuario = @IdUsuario AND IdPropiedad = @IdPropiedad");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@IdPropiedad", idPropiedad);
                int cantidad = Convert.ToInt32(datos.ejecutarAccionScalar());
                return cantidad > 0;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
