using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class PropiedadRepository : IPropiedadRepository
    {
        #region Consultas Base (CRUD)

        public List<Propiedad> ObtenerTodos()
        {
            List<Propiedad> lista = new List<Propiedad>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    SELECT
                        P.Id,
                        P.Codigo,
                        P.Titulo,
                        P.Bio,
                        P.Direccion,
                        P.IdTipoPropiedad,
                        P.IdTipoContrato,
                        P.IdEstadoPropiedad,
                        P.IdBarrio,
                        P.PrecioActual,
                        P.Moneda,
                        P.Activo,
                        P.Destacado,
                        P.MostrarDireccion,
                        P.Latitud,
                        P.Longitud,
                        P.Ambientes,
                        P.Dormitorios,
                        P.Baños,
                        P.Cocheras,
                        P.Plantas,
                        P.MetrosTotales,
                        P.MetrosCubiertos,
                        P.Video,
                        P.FechaAlta,
                        P.FechaPublicacion,
                        P.FechaModificacion,
                        P.FechaVenta,
                        TP.Descripcion AS TipoPropiedadDesc,
                        TC.Descripcion AS TipoContratoDesc,
                        EP.Descripcion AS EstadoPropiedadDesc,
                        B.Descripcion AS BarrioDesc
                    FROM Propiedad P
                    INNER JOIN TipoPropiedad TP ON P.IdTipoPropiedad = TP.Id
                    INNER JOIN TipoContrato TC ON P.IdTipoContrato = TC.Id
                    INNER JOIN EstadoPropiedad EP ON P.IdEstadoPropiedad = EP.Id
                    INNER JOIN Barrio B ON P.IdBarrio = B.Id");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(MapearPropiedad(datos));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el listado de propiedades", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Propiedad ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    SELECT P.Id, P.Codigo, P.Titulo, P.Bio, P.Descripcion, P.IdTipoPropiedad, P.IdTipoContrato, 
                           P.IdEstadoPropiedad, P.IdBarrio, P.Direccion, P.MostrarDireccion, 
                           P.Latitud, P.Longitud, P.Ambientes, P.Dormitorios, P.Baños, 
                           P.Cocheras, P.Plantas, P.MetrosTotales, P.MetrosCubiertos, 
                           P.Moneda, P.PrecioActual, P.Video, P.Destacado, P.Activo, 
                           P.FechaAlta, P.FechaPublicacion, P.FechaModificacion, P.FechaVenta,
                           TP.Descripcion AS TipoPropiedadDesc,
                           TC.Descripcion AS TipoContratoDesc,
                           EP.Descripcion AS EstadoPropiedadDesc,
                           B.Descripcion AS BarrioDesc
                    FROM Propiedad P
                    INNER JOIN TipoPropiedad TP ON P.IdTipoPropiedad = TP.Id
                    INNER JOIN TipoContrato TC ON P.IdTipoContrato = TC.Id
                    INNER JOIN EstadoPropiedad EP ON P.IdEstadoPropiedad = EP.Id
                    INNER JOIN Barrio B ON P.IdBarrio = B.Id
                    WHERE P.Id = @Id");

                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return MapearPropiedad(datos, incluirDescripcionLarga: true);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la propiedad con ID {id}", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int Agregar(Propiedad entidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    INSERT INTO Propiedad 
                    (Codigo, Titulo, Bio, Descripcion, IdTipoPropiedad, IdTipoContrato, IdEstadoPropiedad, IdBarrio, 
                     Direccion, MostrarDireccion, Latitud, Longitud, Ambientes, Dormitorios, Baños, Cocheras, Plantas, 
                     MetrosTotales, MetrosCubiertos, Moneda, PrecioActual, Video, Destacado, Activo, FechaAlta)
                    VALUES 
                    (@Codigo, @Titulo, @Bio, @Descripcion, @IdTipoPropiedad, @IdTipoContrato, @IdEstadoPropiedad, @IdBarrio, 
                     @Direccion, @MostrarDireccion, @Latitud, @Longitud, @Ambientes, @Dormitorios, @Baños, @Cocheras, @Plantas, 
                     @MetrosTotales, @MetrosCubiertos, @Moneda, @PrecioActual, @Video, @Destacado, @Activo, @FechaAlta);
                    SELECT SCOPE_IDENTITY();");

                SetearParametrosPropiedad(datos, entidad);

                // Ejecuta scalar para devolver el ID generado por el IDENTITY
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la nueva propiedad", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Modificar(Propiedad entidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    UPDATE Propiedad SET 
                        Codigo = @Codigo,
                        Titulo = @Titulo,
                        Bio = @Bio,
                        Descripcion = @Descripcion,
                        IdTipoPropiedad = @IdTipoPropiedad,
                        IdTipoContrato = @IdTipoContrato,
                        IdEstadoPropiedad = @IdEstadoPropiedad,
                        IdBarrio = @IdBarrio,
                        Direccion = @Direccion,
                        MostrarDireccion = @MostrarDireccion,
                        Latitud = @Latitud,
                        Longitud = @Longitud,
                        Ambientes = @Ambientes,
                        Dormitorios = @Dormitorios,
                        Baños = @Baños,
                        Cocheras = @Cocheras,
                        Plantas = @Plantas,
                        MetrosTotales = @MetrosTotales,
                        MetrosCubiertos = @MetrosCubiertos,
                        Moneda = @Moneda,
                        PrecioActual = @PrecioActual,
                        Video = @Video,
                        Destacado = @Destacado,
                        Activo = @Activo,
                        FechaModificacion = SYSDATETIME()
                    WHERE Id = @Id");

                datos.setearParametro("@Id", entidad.Id);
                SetearParametrosPropiedad(datos, entidad);

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar la propiedad con ID {entidad.Id}", ex);
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
                datos.setearConsulta("DELETE FROM Propiedades WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al elmiminar la propiedad con ID {id}", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        #endregion

        #region Métodos Específicos de IPropiedadRepository

        public Propiedad ObtenerPorCodigo(string codigo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    SELECT P.Id, P.Codigo, P.Titulo, P.Bio, P.Descripcion, P.IdTipoPropiedad, P.IdTipoContrato, 
                           P.IdEstadoPropiedad, P.IdBarrio, P.Direccion, P.MostrarDireccion, 
                           P.Latitud, P.Longitud, P.Ambientes, P.Dormitorios, P.Baños, 
                           P.Cocheras, P.Plantas, P.MetrosTotales, P.MetrosCubiertos, 
                           P.Moneda, P.PrecioActual, P.Video, P.Destacado, P.Activo, 
                           P.FechaAlta, P.FechaPublicacion, P.FechaModificacion, P.FechaVenta,
                           TP.Descripcion AS TipoPropiedadDesc,
                           TC.Descripcion AS TipoContratoDesc,
                           EP.Descripcion AS EstadoPropiedadDesc,
                           B.Descripcion AS BarrioDesc
                    FROM Propiedad P
                    INNER JOIN TipoPropiedad TP ON P.IdTipoPropiedad = TP.Id
                    INNER JOIN TipoContrato TC ON P.IdTipoContrato = TC.Id
                    INNER JOIN EstadoPropiedad EP ON P.IdEstadoPropiedad = EP.Id
                    INNER JOIN Barrio B ON P.IdBarrio = B.Id
                    WHERE P.Codigo = @Codigo");

                datos.setearParametro("@Codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return MapearPropiedad(datos, incluirDescripcionLarga: true);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar la propiedad con código {codigo}", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int ObtenerSiguienteId()
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT ISNULL(MAX(ID), 0) + 1 AS SiguienteId FROM Propiedad");
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Propiedad> BuscarConFiltros(int? idTipo, int? idContrato, int? idBarrio, decimal? precioMax)
        {
            List<Propiedad> lista = new List<Propiedad>();
            AccesoDB datos = new AccesoDB();

            try
            {
                string query = @"
                    SELECT P.Id, P.Codigo, P.Titulo, P.Bio, P.IdTipoPropiedad, P.IdTipoContrato, 
                           P.IdEstadoPropiedad, P.IdBarrio, P.Direccion, P.MostrarDireccion, 
                           P.Latitud, P.Longitud, P.Ambientes, P.Dormitorios, P.Baños, 
                           P.Cocheras, P.Plantas, P.MetrosTotales, P.MetrosCubiertos, 
                           P.Moneda, P.PrecioActual, P.Video, P.Destacado, P.Activo, 
                           P.FechaAlta, P.FechaPublicacion, P.FechaModificacion, P.FechaVenta,
                           TP.Descripcion AS TipoPropiedadDesc,
                           TC.Descripcion AS TipoContratoDesc,
                           EP.Descripcion AS EstadoPropiedadDesc,
                           B.Descripcion AS BarrioDesc
                    FROM Propiedad P
                    INNER JOIN TipoPropiedad TP ON P.IdTipoPropiedad = TP.Id
                    INNER JOIN TipoContrato TC ON P.IdTipoContrato = TC.Id
                    INNER JOIN EstadoPropiedad EP ON P.IdEstadoPropiedad = EP.Id
                    INNER JOIN Barrio B ON P.IdBarrio = B.Id
                    WHERE P.Activo = 1";

                if (idTipo.HasValue && idTipo > 0)
                    query += " AND P.IdTipoPropiedad = @IdTipo";

                if (idContrato.HasValue && idContrato.Value > 0)
                    query += " AND P.IdTipoContrato = @IdContrato";

                if (idBarrio.HasValue && idBarrio.Value > 0)
                    query += " AND P.IdBarrio = @IdBarrio";

                if (precioMax.HasValue && precioMax.Value > 0)
                    query += " AND P.PrecioActual <= @PrecioMax";

                datos.setearConsulta(query);

                if (idTipo.HasValue && idTipo.Value > 0) datos.setearParametro("@IdTipo", idTipo.Value);
                if (idContrato.HasValue && idContrato.Value > 0) datos.setearParametro("@IdContrato", idContrato.Value);
                if (idBarrio.HasValue && idBarrio.Value > 0) datos.setearParametro("@IdBarrio", idBarrio.Value);
                if (precioMax.HasValue && precioMax.Value > 0) datos.setearParametro("@PrecioMax", precioMax.Value);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(MapearPropiedad(datos));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la búsqueda filtrada de propiedades", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Propiedad> ObtenerDestacadas()
        {
            List<Propiedad> lista = new List<Propiedad>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    SELECT P.Id, P.Codigo, P.Titulo, P.Bio, P.IdTipoPropiedad, P.IdTipoContrato, 
                           P.IdEstadoPropiedad, P.IdBarrio, P.Direccion, P.MostrarDireccion, 
                           P.Latitud, P.Longitud, P.Ambientes, P.Dormitorios, P.Baños, 
                           P.Cocheras, P.Plantas, P.MetrosTotales, P.MetrosCubiertos, 
                           P.Moneda, P.PrecioActual, P.Video, P.Destacado, P.Activo, 
                           P.FechaAlta, P.FechaPublicacion, P.FechaModificacion, P.FechaVenta,
                           TP.Descripcion AS TipoPropiedadDesc,
                           TC.Descripcion AS TipoContratoDesc,
                           EP.Descripcion AS EstadoPropiedadDesc,
                           B.Descripcion AS BarrioDesc
                    FROM Propiedad P
                    INNER JOIN TipoPropiedad TP ON P.IdTipoPropiedad = TP.Id
                    INNER JOIN TipoContrato TC ON P.IdTipoContrato = TC.Id
                    INNER JOIN EstadoPropiedad EP ON P.IdEstadoPropiedad = EP.Id
                    INNER JOIN Barrio B ON P.IdBarrio = B.Id
                    WHERE P.Destacado = 1 AND P.Activo = 1
                    ORDER BY P.FechaPublicacion DESC");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(MapearPropiedad(datos));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las propiedades destacadas", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Propiedad> ObtenerUltimasCargadas(int cantidad = 5)
        {
            List<Propiedad> lista = new List<Propiedad>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"SELECT TOP (@Cantidad)
                                p.Id, p.Codigo, p.Titulo, p.Precio, p.Moneda, p.Direccion,
                                p.FechaPublicacion, p.Activo, p.Destacado,
                                tp.Nombre AS TipoPropiedadNombre,
                                tc.Nombre AS TipoContratoNombre,
                                b.Nombre AS BarrioNombre
                               FROM Propiedad p
                               INNER JOIN TipoPropiedad tp ON p.IdTipoPropiedad = tp.Id
                               INNER JOIN TipoContrato tc ON p.IdTipoContrato = tc.Id
                               INNER JOIN Barrio b ON p.IdBarrio = b.Id
                               ORDER BY p.Id DESC");

                datos.setearParametro("@Cantidad", cantidad);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MapearPropiedad(datos);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar las últimas propiedades cargadas", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool CambiarEstado(int idPropiedad, bool activo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Propiedad SET Activo = @Activo, FechaModificacion = SYSDATETIME() WHERE Id = @Id");
                datos.setearParametro("@Activo", activo);
                datos.setearParametro("@Id", idPropiedad);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar estado activo de la propiedad {idPropiedad}", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool MarcarComoDestacado(int idPropiedad, bool destacado)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Propiedad SET Destacado = @Destacado, FechaModificacion = SYSDATETIME() WHERE Id = @Id");
                datos.setearParametro("@Destacado", destacado);
                datos.setearParametro("@Id", idPropiedad);
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el estado destacado de la propiedaad {idPropiedad}", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        #endregion

        #region Helpers Internos de Mapeo

        private Propiedad MapearPropiedad(AccesoDB datos, bool incluirDescripcionLarga = false)
        {
            Propiedad aux = new Propiedad();

            aux.Id = (int)datos.Lector["Id"];
            aux.Codigo = (string)datos.Lector["Codigo"];
            aux.Titulo = (string)datos.Lector["Titulo"];
            aux.Bio = datos.Lector["Bio"] != DBNull.Value ? (string)datos.Lector["Bio"] : null;

            if (incluirDescripcionLarga)
            {
                aux.Descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : null;
            }

            aux.IdTipoPropiedad = (int)datos.Lector["IdTipoPropiedad"];
            aux.IdTipoContrato = (int)datos.Lector["IdTipoContrato"];
            aux.IdEstadoPropiedad = (int)datos.Lector["IdEstadoPropiedad"];
            aux.IdBarrio = (int)datos.Lector["IdBarrio"];

            // Mapeo de objetos de navegación
            aux.TipoPropiedad = new TipoPropiedad { Id = aux.IdTipoPropiedad, Descripcion = (string)datos.Lector["TipoPropiedadDesc"] };
            aux.TipoContrato = new TipoContrato { Id = aux.IdTipoContrato, Descripcion = (string)datos.Lector["TipoContratoDesc"] };
            aux.EstadoPropiedad = new EstadoPropiedad { Id = aux.IdEstadoPropiedad, Descripcion = (string)datos.Lector["EstadoPropiedadDesc"] };
            aux.Barrio = new Barrio { Id = aux.IdBarrio, Descripcion = (string)datos.Lector["BarrioDesc"] };

            // Ubicación
            aux.Direccion = datos.Lector["Direccion"] != DBNull.Value ? (string)datos.Lector["Direccion"] : null;
            aux.MostrarDireccion = (bool)datos.Lector["MostrarDireccion"];
            aux.Latitud = datos.Lector["Latitud"] != DBNull.Value ? (decimal?)datos.Lector["Latitud"] : null;
            aux.Longitud = datos.Lector["Longitud"] != DBNull.Value ? (decimal?)datos.Lector["Longitud"] : null;

            // Atributos numéricos (Nullables)
            aux.Ambientes = datos.Lector["Ambientes"] != DBNull.Value ? (short?)datos.Lector["Ambientes"] : null;
            aux.Dormitorios = datos.Lector["Dormitorios"] != DBNull.Value ? (short?)datos.Lector["Dormitorios"] : null;
            aux.Banios = datos.Lector["Baños"] != DBNull.Value ? (short?)datos.Lector["Baños"] : null;
            aux.Cocheras = datos.Lector["Cocheras"] != DBNull.Value ? (short?)datos.Lector["Cocheras"] : null;
            aux.Plantas = datos.Lector["Plantas"] != DBNull.Value ? (short?)datos.Lector["Plantas"] : null;
            aux.MetrosTotales = datos.Lector["MetrosTotales"] != DBNull.Value ? (short?)datos.Lector["MetrosTotales"] : null;
            aux.MetrosCubiertos = datos.Lector["MetrosCubiertos"] != DBNull.Value ? (short?)datos.Lector["MetrosCubiertos"] : null;

            // Precio y Estado
            aux.Moneda = (string)datos.Lector["Moneda"];
            aux.PrecioActual = (decimal)datos.Lector["PrecioActual"];
            aux.Video = datos.Lector["Video"] != DBNull.Value ? (string)datos.Lector["Video"] : null;
            aux.Destacado = (bool)datos.Lector["Destacado"];
            aux.Activo = (bool)datos.Lector["Activo"];

            // Fechas
            aux.FechaAlta = (DateTime)datos.Lector["FechaAlta"];
            aux.FechaPublicacion = datos.Lector["FechaPublicacion"] != DBNull.Value ? (DateTime?)datos.Lector["FechaPublicacion"] : null;
            aux.FechaModificacion = datos.Lector["FechaModificacion"] != DBNull.Value ? (DateTime?)datos.Lector["FechaModificacion"] : null;
            aux.FechaVenta = datos.Lector["FechaVenta"] != DBNull.Value ? (DateTime?)datos.Lector["FechaVenta"] : null;

            return aux;
        }

        private void SetearParametrosPropiedad(AccesoDB datos, Propiedad entidad)
        {
            datos.setearParametro("@Codigo", entidad.Codigo);
            datos.setearParametro("@Titulo", entidad.Titulo);
            datos.setearParametro("@Bio", (object)entidad.Bio ?? DBNull.Value);
            datos.setearParametro("@Descripcion", (object)entidad.Descripcion ?? DBNull.Value);
            datos.setearParametro("@IdTipoPropiedad", entidad.IdTipoPropiedad);
            datos.setearParametro("@IdTipoContrato", entidad.IdTipoContrato);
            datos.setearParametro("@IdEstadoPropiedad", entidad.IdEstadoPropiedad);
            datos.setearParametro("@IdBarrio", entidad.IdBarrio);
            datos.setearParametro("@Direccion", (object)entidad.Direccion ?? DBNull.Value);
            datos.setearParametro("@MostrarDireccion", entidad.MostrarDireccion);
            datos.setearParametro("@Latitud", (object)entidad.Latitud ?? DBNull.Value);
            datos.setearParametro("@Longitud", (object)entidad.Longitud ?? DBNull.Value);
            datos.setearParametro("@Ambientes", (object)entidad.Ambientes ?? DBNull.Value);
            datos.setearParametro("@Dormitorios", (object)entidad.Dormitorios ?? DBNull.Value);
            datos.setearParametro("@Baños", (object)entidad.Banios ?? DBNull.Value);
            datos.setearParametro("@Cocheras", (object)entidad.Cocheras ?? DBNull.Value);
            datos.setearParametro("@Plantas", (object)entidad.Plantas ?? DBNull.Value);
            datos.setearParametro("@MetrosTotales", (object)entidad.MetrosTotales ?? DBNull.Value);
            datos.setearParametro("@MetrosCubiertos", (object)entidad.MetrosCubiertos ?? DBNull.Value);
            datos.setearParametro("@Moneda", entidad.Moneda);
            datos.setearParametro("@PrecioActual", entidad.PrecioActual);
            datos.setearParametro("@Video", (object)entidad.Video ?? DBNull.Value);
            datos.setearParametro("@Destacado", entidad.Destacado);
            datos.setearParametro("@Activo", entidad.Activo);
            datos.setearParametro("FechaAlta", entidad.FechaAlta);
        }

        #endregion
    }
}