using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class BarrioRepository : IBarrioRepository
    {
        public List<Barrio> ObtenerTodos()
        {
            List<Barrio> lista = new List<Barrio>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo, Sigla FROM Barrio ORDER BY Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new Barrio
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

        public Barrio ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo, Sigla FROM Barrio WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return new Barrio
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

        public int Agregar(Barrio entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO Barrio (Descripcion, Activo, Sigla) VALUES (@Descripcion, @Activo, @Sigla); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Activo", entidad.Activo);
                datos.setearParametro("@Activo", entidad.Sigla);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Modificar(Barrio entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("UPDATE Barrio SET Descripcion = @Descripcion, Activo = @Activo, Sigla = @Sigla WHERE Id = @Id");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Activo", entidad.Activo);
                datos.setearParametro("@Id", entidad.Id);
                datos.setearParametro("@Sigla", entidad.Sigla);
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
                datos.setearConsulta("DELETE FROM Barrio WHERE Id = @Id");
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
