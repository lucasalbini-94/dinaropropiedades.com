using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class EstadoPropiedadRepository : IEstadoPropiedadRepository
    {
        public List<EstadoPropiedad> ObtenerTodos()
        {
            List<EstadoPropiedad> lista = new List<EstadoPropiedad>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Color, Activo FROM EstadoPropiedad ORDER BY Descripcion");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new EstadoPropiedad
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Color = datos.Lector["Color"] != DBNull.Value ? (string)datos.Lector["Color"] : null,
                        Activo = (bool)datos.Lector["Activo"]
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public EstadoPropiedad ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Color, Activo FROM EstadoPropiedad WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return new EstadoPropiedad
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Color = datos.Lector["Color"] != DBNull.Value ? (string)datos.Lector["Color"] : null,
                        Activo = (bool)datos.Lector["Activo"]
                    };
                }
                return null;
            }
            finally { datos.cerrarConexion(); }
        }

        public int Agregar(EstadoPropiedad entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO EstadoPropiedad (Descripcion, Color, Activo) VALUES (@Descripcion, @Color, @Activo); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Color", (object)entidad.Color ?? DBNull.Value);
                datos.setearParametro("@Activo", entidad.Activo);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Modificar(EstadoPropiedad entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("UPDATE EstadoPropiedad SET Descripcion = @Descripcion, Color = @Color, Activo = @Activo WHERE Id = @Id");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Color", (object)entidad.Color ?? DBNull.Value);
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
                datos.setearConsulta("DELETE FROM EstadoPropiedad WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
