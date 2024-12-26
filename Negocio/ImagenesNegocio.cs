using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios;
using Dominio;

namespace Negocio
{
    public class ImagenesNegocio
    {
        public List<Imagenes> listar(int id = -1, bool pri = false)
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoDB datos = new AccesoDB();
            try
            {
                // Traer imágenes de una propiedad específica
                if (id != -1)
                    datos.setearConsulta("Select Id, Ruta, Principal, IdPropiedad, Alt From Imagenes Where IdPropiedad = " + id.ToString());
                // Traer solo imágenes principales
                else if (pri)
                    datos.setearConsulta("Select Id, Ruta, Principal, IdPropiedad, Alt From Imagenes Where Principal = 1");
                // Traer todas las imágenes
                else
                    datos.setearConsulta("Select Id, Ruta, Principal, IdPropiedad, Alt From Imagenes");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagenes aux = new Imagenes();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Ruta = (string)datos.Lector["Ruta"];
                    aux.Principal = (bool)datos.Lector["Principal"];
                    aux.IdPropiedad = (int)datos.Lector["IdPropiedad"];
                    aux.Alt = (string)datos.Lector["Alt"];

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

        public void insertar(Imagenes imagen)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Insert Into Imagenes Values (@Ruta, @IdPropiedad, @Principal, @Alt)");
                datos.setearParametro("@Ruta", imagen.Ruta);
                datos.setearParametro("@IdPropiedad", imagen.IdPropiedad);
                datos.setearParametro("@Principal", imagen.Principal);
                datos.setearParametro("@Alt", imagen.Alt);
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
                datos.setearConsulta("delete Imagenes Where Id = @Id");
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
