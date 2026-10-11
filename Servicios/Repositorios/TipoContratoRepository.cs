using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class TipoContratoRepository : ITipoContratoRepository
    {
        public List<TipoContrato> ObtenerTodos()
        {
            List<TipoContrato> lista = new List<TipoContrato>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo FROM TipoContrato ORDER BY Descripcion");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new TipoContrato
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Activo = (bool)datos.Lector["Activo"]
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public TipoContrato ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo FROM TipoContrato WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return new TipoContrato
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Activo = (bool)datos.Lector["Activo"]
                    };
                }
                return null;
            }
            finally { datos.cerrarConexion(); }
        }

        public int Agregar(TipoContrato entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO TipoContrato (Descripcion, Activo) VALUES (@Descripcion, @Activo); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Activo", entidad.Activo);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Modificar(TipoContrato entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("UPDATE TipoContrato SET Descripcion = @Descripcion, Activo = @Activo WHERE Id = @Id");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Activo", entidad.Activo);
                datos.setearParametro("@Id", entidad.Id);
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
                datos.setearConsulta("DELETE FROM TipoContrato WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
