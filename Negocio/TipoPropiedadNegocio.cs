using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;

namespace Negocio
{
    public class TipoPropiedadNegocio
    {
        public List<TipoPropiedad> listar()
        {
            List<TipoPropiedad> lista = new List<TipoPropiedad>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From [Tipo.Propiedad]");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoPropiedad aux = new TipoPropiedad();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public void insertar(TipoPropiedad nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Insert Into [Tipo.Propiedad] Values (@Descripcion)");
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
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

        public void modificar(TipoPropiedad modificado)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Update [Tipo.Propiedad] Set Descripcion = @Descripcion Where Id = @Id");
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@Id", modificado.Id);
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
                datos.setearConsulta("Delete [Tipo.Propiedad] Where Id = @Id");
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
