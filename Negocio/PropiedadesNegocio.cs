using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;

namespace Negocio
{
    public class PropiedadesNegocio
    {
        public List<Propiedades> listar()
        {
            List<Propiedades> lista = new List<Propiedades>();
            AccesoDB datos = new AccesoDB();

            try
            {
                //Sentencia para listar los datos de las tablas Propiedades, Características y Ubicación

                datos.setearConsulta("Select P.Id, P.Codigo, P.Titulo, P.Bio, P.Descripcion, P.IdTipoContrato, TC.Descripcion " +
                    "TipoContrato , P.IdTipoPropiedad, TP.Descripcion TipoPropiedad, P.Destacado, P.Activo, P.Precio, " +
                    "P.Moneda, P.Video, C.Ambientes, C.Baños, C.Cocheras, C.Dormitorios, C.Plantas, C.MetrosTotales, " +
                    "C.MetrosCubiertos, U.IdDpto, Dpto.Descripcion DptoDesc, U.IdLocalidad, Loc.Descripcion " +
                    "LocalidadDesc, U.IdPueblo, Pue.Descripcion PuebloDesc, U.UrlMaps " +
                    "From Propiedades P Inner Join  Caracteristicas C On P.Id = C.IdPropiedad " +
                    "Inner Join Ubicacion U On P.Id = U.IdPropiedad " +
                    "Inner Join[Tipo.Contrato] TC On P.IdTipoContrato = TC.Id " +
                    "Inner Join[Tipo.Propiedad] TP On P.IdTipoPropiedad = TP.Id " +
                    "Inner Join Departamentos Dpto On U.IdDpto = Dpto.Id " +
                    "Inner Join Localidades Loc On U.IdLocalidad = Loc.Id " +
                    "Inner Join Pueblos Pue On U.IdPueblo = Pue.Id ");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Propiedades aux = new Propiedades();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Bio = (string)datos.Lector["Bio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.TipoContrato = new TipoContrato();
                    aux.TipoContrato.Id = (int)datos.Lector["IdTipoContrato"];
                    aux.TipoContrato.Descripcion = (string)datos.Lector["TipoContrato"];
                    aux.TipoPropiedad = new TipoPropiedad();
                    aux.TipoPropiedad.Id = (int)datos.Lector["IdTipoPropiedad"];
                    aux.TipoPropiedad.Descripcion = (string)datos.Lector["TipoPropiedad"];
                    if (!(datos.Lector["Moneda"] is DBNull))
                        aux.Moneda = (string)datos.Lector["Moneda"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["Video"] is DBNull))
                        aux.Video = (string)datos.Lector["Video"];
                    if (!(datos.Lector["Destacado"] is DBNull))
                        aux.Destacado = (bool)datos.Lector["Destacado"];
                    if (!(datos.Lector["Activo"] is DBNull))
                        aux.Activo = (bool)datos.Lector["Activo"];
                    if (!(datos.Lector["Ambientes"] is DBNull))
                        aux.Ambientes = (int)datos.Lector["Ambientes"];
                    if (!(datos.Lector["Baños"] is DBNull))
                        aux.Baños = (int)datos.Lector["Baños"];
                    if (!(datos.Lector["Cocheras"] is DBNull))
                        aux.Cocheras = (int)datos.Lector["Cocheras"];
                    if (!(datos.Lector["Dormitorios"] is DBNull))
                        aux.Dormitorios = (int)datos.Lector["Dormitorios"];
                    if (!(datos.Lector["Plantas"] is DBNull))
                        aux.Plantas = (int)datos.Lector["Plantas"];
                    if (!(datos.Lector["MetrosTotales"] is DBNull))
                        aux.MetrosTotales = (int)datos.Lector["MetrosTotales"];
                    if (!(datos.Lector["MetrosCubiertos"] is DBNull))
                        aux.MetrosCubiertos = (int)datos.Lector["MetrosCubiertos"];
                    aux.Departamento = new Departamentos();
                    aux.Departamento.Id = (int)datos.Lector["IdDpto"];
                    aux.Departamento.Descripcion = (string)datos.Lector["DptoDesc"];
                    aux.Localidad = new Localidades();
                    aux.Localidad.Id = (int)datos.Lector["IdLocalidad"];
                    aux.Localidad.Descripcion = (string)datos.Lector["LocalidadDesc"];
                    aux.Pueblo = new Pueblos();
                    aux.Pueblo.Id = (int)datos.Lector["IdPueblo"];
                    aux.Pueblo.Descripcion = (string)datos.Lector["PuebloDesc"];
                    if (!(datos.Lector["UrlMaps"] is DBNull))
                        aux.Ubicacion = (string)datos.Lector["UrlMaps"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int insertar(Propiedades nuevo)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                //Sentencia de insercion en tabla Propiedades

                datos.setearConsulta("Insert Into Propiedades (Codigo, Titulo, Bio, Descripcion, Destacado, Activo, IdTipoPropiedad, IdTipoContrato, Moneda, Precio, Video)" +
                    "Output Inserted.Id Values (@Codigo, @Titulo, @Bio, @Descripcion, @Destacado, @Activo, @IdTipoPropiedad, @IdTipoContrato, @Moneda, @Precio, @Video)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Titulo", nuevo.Titulo);
                datos.setearParametro("@Bio", nuevo.Bio);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Destacado", nuevo.Destacado);
                datos.setearParametro("@Activo", nuevo.Activo);
                datos.setearParametro("@IdTipoPropiedad", nuevo.TipoPropiedad.Id);
                datos.setearParametro("@IdTipoContrato", nuevo.TipoContrato.Id);
                datos.setearParametro("@Moneda", nuevo.Moneda);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@Video", nuevo.Video);

                //Se devuelve el Id de la fila insertada

                nuevo.Id = datos.ejecutarAccionScalar();
                datos.cerrarConexion();

                //Sentencia de insercion en tabla Ubicaciones

                datos.setearConsulta("Insert Into Ubicacion (IdPropiedad, IdDpto, IdLocalidad, IdPueblo, UrlMaps)" +
                    "Values (@IdPropiedad, @IdDpto, @IdLocalidad, @IdPueblo, @UrlMaps)");
                datos.setearParametro("@IdPropiedad", nuevo.Id);
                datos.setearParametro("@IdDpto", nuevo.Departamento.Id);
                datos.setearParametro("@IdLocalidad", nuevo.Localidad.Id);
                datos.setearParametro("@IdPueblo", nuevo.Pueblo.Id);
                if (!(string.IsNullOrEmpty(nuevo.Ubicacion)))
                    datos.setearParametro("@UrlMaps", nuevo.Ubicacion);
                else
                    datos.setearParametro("@UrlMaps", DBNull.Value);
                datos.ejecutarAccion();
                datos.cerrarConexion();


                ////Agregar IdUbicacion a la tabla Propiedades

                //datos.setearConsulta("Update Propiedades Set IdUbicacion = @IdUbi Where Id = @Id");
                //datos.setearParametro("@IdUbi", Id);
                //datos.setearParametro("@Id", nuevo.Id);
                //datos.ejecutarAccion();
                //datos.cerrarConexion();

                //Sentencia de insercion en tabla Caracteristicas

                datos.setearConsulta("Insert Into Caracteristicas Values (@IdProp, @Ambientes, @Dormitorios, @Baños, @Plantas, @Cocheras, @MetrosTotales, @MetrosCubiertos)");
                datos.setearParametro("@IdProp", nuevo.Id);
                datos.setearParametro("@Ambientes", nuevo.Ambientes);
                datos.setearParametro("@Dormitorios", nuevo.Dormitorios);
                datos.setearParametro("@Baños", nuevo.Baños);
                datos.setearParametro("@Plantas", nuevo.Plantas);
                datos.setearParametro("@Cocheras", nuevo.Cocheras);
                datos.setearParametro("@MetrosTotales", nuevo.MetrosTotales);
                datos.setearParametro("@MetrosCubiertos", nuevo.MetrosCubiertos);
                datos.ejecutarAccion();

                return nuevo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Propiedades aux)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Update Propiedades Set Codigo = @Codigo, Titulo = @Titulo, Bio = @Bio, Descripcion = @Descripcion, Destacado = @Destacado, Activo = @Activo, IdTipoPropiedad = @TipoPropiedad, " +
                    "IdTipoContrato = @TipoContrato, Precio = @Precio, Video = @Video, Moneda = @Moneda " +
                    "Where Id = @Id " +
                    "Update Caracteristicas Set Ambientes = @Ambientes, Dormitorios = @Dormitorios, Baños = @Baños, Plantas = @Plantas, Cocheras = @Cocheras, " +
                    "MetrosTotales = @MetrosTotales, MetrosCubiertos = @MetrosCubiertos " +
                    "Where IdPropiedad = @Id " +
                    "Update Ubicacion Set IdDpto = @IdDpto, IdLocalidad = @IdLocalidad, IdPueblo = @IdPueblo, UrlMaps = @UrlMaps " +
                    "Where IdPropiedad = @Id");

                datos.setearParametro("@Codigo", aux.Codigo);
                datos.setearParametro("@Titulo", aux.Titulo);
                datos.setearParametro("@Bio", aux.Bio);
                datos.setearParametro("@Descripcion", aux.Descripcion);
                datos.setearParametro("@Destacado", aux.Destacado);
                datos.setearParametro("@Activo", aux.Activo);
                datos.setearParametro("@TipoPropiedad", aux.TipoPropiedad.Id);
                datos.setearParametro("@TipoContrato", aux.TipoContrato.Id);
                datos.setearParametro("@Moneda", aux.Moneda);
                datos.setearParametro("@Precio", aux.Precio);
                if (!(string.IsNullOrEmpty(aux.Video)))
                    datos.setearParametro("@Video", aux.Video);
                else
                    datos.setearParametro("@Video", DBNull.Value);
                datos.setearParametro("@Id", aux.Id);
                datos.setearParametro("@Ambientes", aux.Ambientes);
                datos.setearParametro("@Dormitorios", aux.Dormitorios);
                datos.setearParametro("@Baños", aux.Baños);
                datos.setearParametro("@Plantas", aux.Plantas);
                datos.setearParametro("@Cocheras", aux.Cocheras);
                datos.setearParametro("@MetrosTotales", aux.MetrosTotales);
                datos.setearParametro("@MetrosCubiertos", aux.MetrosCubiertos);
                //datos.setearParametro("@IdProp", aux.Id);
                datos.setearParametro("@IdDpto", aux.Departamento.Id);
                datos.setearParametro("@IdLocalidad", aux.Localidad.Id);
                datos.setearParametro("@IdPueblo", aux.Pueblo.Id);
                if (!(string.IsNullOrEmpty(aux.Ubicacion)))
                    datos.setearParametro("@UrlMaps", aux.Ubicacion);
                else
                    datos.setearParametro("@UrlMaps", DBNull.Value);
                //datos.setearParametro("@IdPropiedad", aux.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Delete Propiedades Where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
