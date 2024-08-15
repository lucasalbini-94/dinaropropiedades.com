using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;

namespace Negocio
{
    public class DptoNegocio
    {
        public List<Departamentos> listar()
        {
            List<Departamentos> lista = new List<Departamentos>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From Departamentos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Departamentos aux = new Departamentos();
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

        public void insertar(Departamentos nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Insert Into Departamentos Values (@Descripcion)");
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

        public void modificar(Departamentos modificado)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Update Departamentos Set Descripcion = @Descripcion Where Id = @Id");
                datos.setearParametro("@Id", modificado.Id);
                datos.setearParametro("@Descripcion", modificado.Descripcion);
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
                datos.setearConsulta("Delete Departamentos Where Id = @Id");
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
