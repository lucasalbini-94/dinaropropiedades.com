using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;

namespace Negocio
{
    public class PueblosNegocio
    {
        public List<Pueblos> listar()
        {
            List<Pueblos> lista = new List<Pueblos>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, IdLocalidad From Pueblos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pueblos aux = new Pueblos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Localidad = new Localidades();
                    aux.Localidad.Id = (int)datos.Lector["IdLocalidad"];

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

        public void insertar(Pueblos nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Insert Into Pueblos Values (@Descripcion, @IdLocalidad)");
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Localidad", nuevo.Localidad.Id);
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

        public void modificar(Pueblos modificado)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Update Pueblos Set Descripcio = @Descripcion, IdLocalidad = @IdLocalidad Where Id = @Id");
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@IdLocalidad", modificado.Localidad.Id);
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
                datos.setearConsulta("Delete Pueblos Where Id = @Id");
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
