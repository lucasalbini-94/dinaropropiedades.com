using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class CaracteristicaRepository : ICaracteristicaRepository
    {
        public List<Caracteristica> ObtenerTodos()
        {
            List<Caracteristica> lista = new List<Caracteristica>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Icono, Activo FROM Caracteristica ORDER BY Descripcion");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new Caracteristica
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Icono = datos.Lector["Icono"] != DBNull.Value ? (string)datos.Lector["Icono"] : null,
                        Activo = (bool)datos.Lector["Activo"]
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public Caracteristica ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Icono, Activo FROM Caracteristica WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return new Caracteristica
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Icono = datos.Lector["Icono"] != DBNull.Value ? (string)datos.Lector["Icono"] : null,
                        Activo = (bool)datos.Lector["Activo"]
                    };
                }
                return null;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Caracteristica> ObtenerPorPropiedad(int idPropiedad)
        {
            List<Caracteristica> lista = new List<Caracteristica>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    SELECT C.Id, C.Descripcion, C.Icono, C.Activo 
                    FROM Caracteristica C
                    INNER JOIN PropiedadCaracteristica PC ON C.Id = PC.IdCaracteristica
                    WHERE PC.IdPropiedad = @IdPropiedad AND C.Activo = 1
                    ORDER BY C.Descripcion");
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new Caracteristica
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Icono = datos.Lector["Icono"] != DBNull.Value ? (string)datos.Lector["Icono"] : null,
                        Activo = (bool)datos.Lector["Activo"]
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool GuardarCaracteristicasPropiedad(int idPropiedad, List<int> idsCaracteristicas)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                // Limpiamos las características asignadas anteriormente
                datos.setearConsulta("DELETE FROM PropiedadCaracteristica WHERE IdPropiedad = @IdPropiedad");
                datos.setearParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarAccion();

                // Insertamos las seleccionadas
                if (idsCaracteristicas != null && idsCaracteristicas.Count > 0)
                {
                    foreach (int idCarac in idsCaracteristicas)
                    {
                        AccesoDB datosInsert = new AccesoDB();
                        try
                        {
                            datosInsert.setearConsulta("INSERT INTO PropiedadCaracteristica (IdPropiedad, IdCaracteristica) VALUES (@IdPropiedad, @IdCaracteristica)");
                            datosInsert.setearParametro("@IdPropiedad", idPropiedad);
                            datosInsert.setearParametro("@IdCaracteristica", idCarac);
                            datosInsert.ejecutarAccion();
                        }
                        finally
                        {
                            datosInsert.cerrarConexion();
                        }
                    }
                }
                return true;
            }
            finally { datos.cerrarConexion(); }
        }

        public int Agregar(Caracteristica entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO Caracteristica (Descripcion, Icono, Activo) VALUES (@Descripcion, @Icono, @Activo); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Icono", (object)entidad.Icono ?? DBNull.Value);
                datos.setearParametro("@Activo", entidad.Activo);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Modificar(Caracteristica entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("UPDATE Caracteristica SET Descripcion = @Descripcion, Icono = @Icono, Activo = @Activo WHERE Id = @Id");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Icono", (object)entidad.Icono ?? DBNull.Value);
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
                datos.setearConsulta("DELETE FROM Caracteristica WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
