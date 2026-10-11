using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class ImagenRepository : IImagenRepository
    {
        public List<Imagen> ObtenerTodos()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT Id, IdPropiedad, Ruta, Alt, Principal, Orden, Activo FROM Imagen WHERE Activo = 1 ORDER BY Orden ASC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(MapearImagen(datos));
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Imagen ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT Id, IdPropiedad, Ruta, Alt, Principal, Orden, Activo FROM Imagen WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return MapearImagen(datos);
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Imagen> ObtenerPorPropiedad(int idPropiedad)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT Id, IdPropiedad, Ruta, Alt, Principal, Orden, Activo FROM Imagen WHERE IdPropiedad = @IdPropiedad AND Activo = 1 ORDER BY Principal DESC, Orden ASC");
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(MapearImagen(datos));
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int Agregar(Imagen entidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    INSERT INTO Imagen (IdPropiedad, Ruta, Alt, Principal, Orden, Activo) 
                    VALUES (@IdPropiedad, @Ruta, @Alt, @Principal, @Orden, @Activo); 
                    SELECT SCOPE_IDENTITY();");

                SetearParametros(datos, entidad);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Modificar(Imagen entidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    UPDATE Imagen SET 
                        IdPropiedad = @IdPropiedad, 
                        Ruta = @Ruta, 
                        Alt = @Alt, 
                        Principal = @Principal, 
                        Orden = @Orden, 
                        Activo = @Activo 
                    WHERE Id = @Id");

                datos.setearParametro("@Id", entidad.Id);
                SetearParametros(datos, entidad);
                datos.ejecutarAccion();
                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Eliminar(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("DELETE FROM Imagen WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool MarcarComoPrincipal(int idImagen, int idPropiedad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    UPDATE Imagen SET Principal = 0 WHERE IdPropiedad = @IdPropiedad;
                    UPDATE Imagen SET Principal = 1 WHERE Id = @IdImagen AND IdPropiedad = @IdPropiedad;");
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.setearParametro("@IdImagen", idImagen);
                datos.ejecutarAccion();
                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Reordenar(int idImagen, short nuevoOrden)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Imagen SET Orden = @Orden WHERE Id = @Id");
                datos.setearParametro("@Orden", nuevoOrden);
                datos.setearParametro("@Id", idImagen);
                datos.ejecutarAccion();
                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool EliminarPorPropiedad(int idPropiedad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("DELETE FROM Imagen WHERE IdPropiedad = @IdPropiedad");
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarAccion();
                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private Imagen MapearImagen(AccesoDB datos)
        {
            return new Imagen
            {
                Id = (int)datos.Lector["Id"],
                IdPropiedad = (int)datos.Lector["IdPropiedad"],
                Ruta = (string)datos.Lector["Ruta"],
                Alt = datos.Lector["Alt"] != DBNull.Value ? (string)datos.Lector["Alt"] : null,
                Principal = (bool)datos.Lector["Principal"],
                Orden = (short)datos.Lector["Orden"],
                Activo = (bool)datos.Lector["Activo"]
            };
        }

        private void SetearParametros(AccesoDB datos, Imagen entidad)
        {
            datos.setearParametro("@IdPropiedad", entidad.IdPropiedad);
            datos.setearParametro("@Ruta", entidad.Ruta);
            datos.setearParametro("@Alt", (object)entidad.Alt ?? DBNull.Value);
            datos.setearParametro("@Principal", entidad.Principal);
            datos.setearParametro("@Orden", entidad.Orden);
            datos.setearParametro("@Activo", entidad.Activo);
        }
    }
}
