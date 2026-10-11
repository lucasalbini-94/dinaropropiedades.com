using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    SELECT U.Id, U.Nombre, U.Apellido, U.Email, U.PasswordHash, U.IdRol, U.Activo, U.UltimoLogin, U.FechaAlta,
                           R.Descripcion AS RolDesc
                    FROM Usuario U
                    INNER JOIN Rol R ON U.IdRol = R.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(MapearUsuario(datos));
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario ObtenerPorId(int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    SELECT U.Id, U.Nombre, U.Apellido, U.Email, U.PasswordHash, U.IdRol, U.Activo, U.UltimoLogin, U.FechaAlta,
                           R.Descripcion AS RolDesc
                    FROM Usuario U
                    INNER JOIN Rol R ON U.IdRol = R.Id
                    WHERE U.Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return MapearUsuario(datos);
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario ObtenerPorEmail(string email)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    SELECT U.Id, U.Nombre, U.Apellido, U.Email, U.PasswordHash, U.IdRol, U.Activo, U.UltimoLogin, U.FechaAlta,
                           R.Descripcion AS RolDesc
                    FROM Usuario U
                    INNER JOIN Rol R ON U.IdRol = R.Id
                    WHERE U.Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return MapearUsuario(datos);
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int Agregar(Usuario entidad)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta(@"
                    INSERT INTO Usuario (Nombre, Apellido, Email, PasswordHash, IdRol, Activo, FechaAlta)
                    VALUES (@Nombre, @Apellido, @Email, @PasswordHash, @IdRol, @Activo, SYSDATETIME());
                    SELECT SCOPE_IDENTITY();");

                SetearParametros(datos, entidad);

                return Convert.ToInt32(datos.ejecutarAccionScalar());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Modificar(Usuario entidad)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    UPDATE Usuario SET 
                        Nombre = @Nombre, 
                        Apellido = @Apellido, 
                        Email = @Email, 
                        IdRol = @IdRol, 
                        Activo = @Activo 
                    WHERE Id = @Id");

                datos.setearParametro("@Id", entidad.Id);
                datos.setearParametro("@Nombre", (object)entidad.Nombre ?? DBNull.Value);
                datos.setearParametro("@Apellido", (object)entidad.Apellido ?? DBNull.Value);
                datos.setearParametro("@Email", entidad.Email);
                datos.setearParametro("@IdRol", entidad.IdRol);
                datos.setearParametro("@Activo", entidad.Activo);
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
                datos.setearConsulta("DELETE FROM Usuario WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();

                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ActualizarUltimoLogin(int idUsuario)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Usuario SET UltimoLogin = SYSDATETIME() WHERE Id = @Id");
                datos.setearParametro("@Id", idUsuario);
                datos.ejecutarAccion();

                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool CambiarPassword(int idUsuario, string nuevoPasswordHash)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("UPDATE Usuario SET PasswordHash = @PasswordHash WHERE Id = @Id");
                datos.setearParametro("@PasswordHash", nuevoPasswordHash);
                datos.setearParametro("@Id", idUsuario);
                datos.ejecutarAccion();

                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private Usuario MapearUsuario(AccesoDB datos)
        {
            return new Usuario
            {
                Id = (int)datos.Lector["Id"],
                Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : null,
                Apellido = datos.Lector["Apellido"] != DBNull.Value ? (string)datos.Lector["Apellido"] : null,
                Email = (string)datos.Lector["Email"],
                PasswordHash = (string)datos.Lector["PasswordHash"],
                IdRol = (int)datos.Lector["IdRol"],
                Rol = new Rol { Id = (int)datos.Lector["IdRol"], Descripcion = (string)datos.Lector["RolDesc"] },
                Activo = (bool)datos.Lector["Activo"],
                UltimoLogin = datos.Lector["UltimoLogin"] != DBNull.Value ? (DateTime?)datos.Lector["UltimoLogin"] : null,
                FechaAlta = (DateTime)datos.Lector["FechaAlta"]
            };
        }

        private void SetearParametros(AccesoDB datos, Usuario entidad)
        {
            datos.setearParametro("@Nombre", (object)entidad.Nombre ?? DBNull.Value);
            datos.setearParametro("@Apellido", (object)entidad.Apellido ?? DBNull.Value);
            datos.setearParametro("@Email", entidad.Email);
            datos.setearParametro("@PasswordHash", entidad.PasswordHash);
            datos.setearParametro("@IdRol", entidad.IdRol);
            datos.setearParametro("@Activo", entidad.Activo);
        }
    }
}
