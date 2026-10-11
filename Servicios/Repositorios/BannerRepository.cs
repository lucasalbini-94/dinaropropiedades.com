using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class BannerRepository : IBannerRepository
    {
        public List<Banner> ObtenerTodos()
        {
            List<Banner> lista = new List<Banner>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Titulo, Subtitulo, TextoBoton, UrlDestino, NuevaPagina, RutaImagen, Alt, Orden, FechaDesde, FechaHasta, Activo FROM Banner ORDER BY Orden ASC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(MapearBanner(datos));
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Banner> ObtenerVisibles()
        {
            List<Banner> lista = new List<Banner>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    SELECT Id, Titulo, Subtitulo, TextoBoton, UrlDestino, NuevaPagina, RutaImagen, Alt, Orden, FechaDesde, FechaHasta, Activo 
                    FROM Banner 
                    WHERE Activo = 1 
                      AND (FechaDesde IS NULL OR FechaDesde <= SYSDATETIME()) 
                      AND (FechaHasta IS NULL OR FechaHasta >= SYSDATETIME()) 
                    ORDER BY Orden ASC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(MapearBanner(datos));
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public Banner ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Titulo, Subtitulo, TextoBoton, UrlDestino, NuevaPagina, RutaImagen, Alt, Orden, FechaDesde, FechaHasta, Activo FROM Banner WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return MapearBanner(datos);
                }
                return null;
            }
            finally { datos.cerrarConexion(); }
        }

        public int Agregar(Banner entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    INSERT INTO Banner (Titulo, Subtitulo, TextoBoton, UrlDestino, NuevaPagina, RutaImagen, Alt, Orden, FechaDesde, FechaHasta, Activo)
                    VALUES (@Titulo, @Subtitulo, @TextoBoton, @UrlDestino, @NuevaPagina, @RutaImagen, @Alt, @Orden, @FechaDesde, @FechaHasta, @Activo);
                    SELECT SCOPE_IDENTITY();");

                SetearParametros(datos, entidad);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Modificar(Banner entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    UPDATE Banner SET 
                        Titulo = @Titulo, Subtitulo = @Subtitulo, TextoBoton = @TextoBoton, 
                        UrlDestino = @UrlDestino, NuevaPagina = @NuevaPagina, RutaImagen = @RutaImagen, 
                        Alt = @Alt, Orden = @Orden, FechaDesde = @FechaDesde, FechaHasta = @FechaHasta, Activo = @Activo 
                    WHERE Id = @Id");

                datos.setearParametro("@Id", entidad.Id);
                SetearParametros(datos, entidad);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Eliminar(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("DELETE FROM Banner WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }

        private Banner MapearBanner(AccesoDB datos)
        {
            return new Banner
            {
                Id = (int)datos.Lector["Id"],
                Titulo = datos.Lector["Titulo"] != DBNull.Value ? (string)datos.Lector["Titulo"] : null,
                Subtitulo = datos.Lector["Subtitulo"] != DBNull.Value ? (string)datos.Lector["Subtitulo"] : null,
                TextoBoton = datos.Lector["TextoBoton"] != DBNull.Value ? (string)datos.Lector["TextoBoton"] : null,
                UrlDestino = datos.Lector["UrlDestino"] != DBNull.Value ? (string)datos.Lector["UrlDestino"] : null,
                NuevaPagina = (bool)datos.Lector["NuevaPagina"],
                RutaImagen = (string)datos.Lector["RutaImagen"],
                Alt = datos.Lector["Alt"] != DBNull.Value ? (string)datos.Lector["Alt"] : null,
                Orden = (short)datos.Lector["Orden"],
                FechaDesde = datos.Lector["FechaDesde"] != DBNull.Value ? (DateTime?)datos.Lector["FechaDesde"] : null,
                FechaHasta = datos.Lector["FechaHasta"] != DBNull.Value ? (DateTime?)datos.Lector["FechaHasta"] : null,
                Activo = (bool)datos.Lector["Activo"]
            };
        }

        private void SetearParametros(AccesoDB datos, Banner entidad)
        {
            datos.setearParametro("@Titulo", (object)entidad.Titulo ?? DBNull.Value);
            datos.setearParametro("@Subtitulo", (object)entidad.Subtitulo ?? DBNull.Value);
            datos.setearParametro("@TextoBoton", (object)entidad.TextoBoton ?? DBNull.Value);
            datos.setearParametro("@UrlDestino", (object)entidad.UrlDestino ?? DBNull.Value);
            datos.setearParametro("@NuevaPagina", entidad.NuevaPagina);
            datos.setearParametro("@RutaImagen", entidad.RutaImagen);
            datos.setearParametro("@Alt", (object)entidad.Alt ?? DBNull.Value);
            datos.setearParametro("@Orden", entidad.Orden);
            datos.setearParametro("@FechaDesde", (object)entidad.FechaDesde ?? DBNull.Value);
            datos.setearParametro("@FechaHasta", (object)entidad.FechaHasta ?? DBNull.Value);
            datos.setearParametro("@Activo", entidad.Activo);
        }
    }
}
