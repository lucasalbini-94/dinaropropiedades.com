using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class RolRepository : IRolRepository
    {
        public List<Rol> ObtenerTodos()
        {
            List<Rol> lista = new List<Rol>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo FROM Rol ORDER BY Descripcion");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new Rol
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

        public Rol ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion, Activo FROM Rol WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return new Rol
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

        public List<Permiso> ObtenerPermisosPorRol(int idRol)
        {
            List<Permiso> lista = new List<Permiso>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    SELECT P.Id, P.Codigo, P.Descripcion 
                    FROM Permiso P
                    INNER JOIN RolPermiso RP ON P.Id = RP.IdPermiso
                    WHERE RP.IdRol = @IdRol
                    ORDER BY P.Descripcion");
                datos.setearParametro("@IdRol", idRol);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new Permiso
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = (string)datos.Lector["Codigo"],
                        Descripcion = (string)datos.Lector["Descripcion"]
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool GuardarPermisosRol(int idRol, List<int> idsPermisos)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("DELETE FROM RolPermiso WHERE IdRol = @IdRol");
                datos.setearParametro("@IdRol", idRol);
                datos.ejecutarAccion();

                if (idsPermisos != null && idsPermisos.Count > 0)
                {
                    foreach (int idPermiso in idsPermisos)
                    {
                        AccesoDB datosInsert = new AccesoDB();
                        try
                        {
                            datosInsert.setearConsulta("INSERT INTO RolPermiso (IdRol, IdPermiso) VALUES (@IdRol, @IdPermiso)");
                            datosInsert.setearParametro("@IdRol", idRol);
                            datosInsert.setearParametro("@IdPermiso", idPermiso);
                            datosInsert.ejecutarAccion();
                        }
                        finally { datosInsert.cerrarConexion(); }
                    }
                }
                return true;
            }
            finally { datos.cerrarConexion(); }
        }

        public int Agregar(Rol entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("INSERT INTO Rol (Descripcion, Activo) VALUES (@Descripcion, @Activo); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Descripcion", entidad.Descripcion);
                datos.setearParametro("@Activo", entidad.Activo);
                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Modificar(Rol entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("UPDATE Rol SET Descripcion = @Descripcion, Activo = @Activo WHERE Id = @Id");
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
                datos.setearConsulta("DELETE FROM Rol WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                return true;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
