using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class TipoPropiedadRepository : ITipoPropiedadRepository
    {
        public List<TipoPropiedad> ObtenerTodos()
        {
            List<TipoPropiedad> lista = new List<TipoPropiedad>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo, Sigla FROM TipoPropiedad ORDER BY Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new TipoPropiedad
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Activo = (bool)datos.Lector["Activo"],
                        Sigla = (string)datos.Lector["Sigla"]
                    });
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public TipoPropiedad ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo, Sigla FROM TipoPropiedad WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new TipoPropiedad
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Activo = (bool)datos.Lector["Activo"],
                        Sigla = (string)datos.Lector["Sigla"]
                    };
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int Agregar(TipoPropiedad entidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("INSERT INTO TipoPropiedad (Descripcion, Activo, Sigla) VALUES (@Descripcion, @Activo, @Sigla); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Activo", entidad.Activo);
                datos.setearParametro("@Sigla", entidad.Sigla);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Modificar(TipoPropiedad entidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE TipoPropiedad SET Descripcion = @Descripcion, Activo = @Activo, Sigla = @Sigla WHERE Id = @Id");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Activo", entidad.Activo);
                datos.setearParametro("@Sigla", entidad.Sigla);
                datos.setearParametro("@Id", entidad.Id);
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
                datos.setearConsulta("DELETE FROM TipoPropiedad WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
