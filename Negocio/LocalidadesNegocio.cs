using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;

namespace Negocio
{
    public class LocalidadesNegocio
    {
        public List<Localidades> listar()
        {
            List<Localidades > lista= new List<Localidades>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, IdDpto From Localidades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Localidades aux = new Localidades();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Departamento = new Departamentos();
                    aux.Departamento.Id = (int)datos.Lector["IdDpto"];

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

        public void insertar(Localidades nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Insert Into Localidades Values (@Descripcion, @IdDpto)");
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdDpto", nuevo.Departamento.Id);
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

        public void modificar(Localidades modificado)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("Update Localidades Set Descripcion = @Descripcion, IdDpto = @IdDpto Where Id = @Id");
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@IdDpto", modificado.Departamento.Id);
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
                datos.setearConsulta("Delete Localidades Where Id = @Id");
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
