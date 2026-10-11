using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class LogRepository : ILogRepository
    {
        public List<Log> ObtenerUltimos(int top = 100)
        {
            List<Log> lista = new List<Log>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta($@"
                    SELECT TOP ({top}) Id, Fecha, IdUsuario, Accion, Entidad, IdRegistro, Detalle, DireccionIP, UserAgent
                    FROM Log
                    ORDER BY Fecha DESC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new Log
                    {
                        Id = (long)datos.Lector["Id"],
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        IdUsuario = (int)(datos.Lector["IdUsuario"] != DBNull.Value ? (int?)datos.Lector["IdUsuario"] : null),
                        Accion = (string)datos.Lector["Accion"],
                        Entidad = (string)datos.Lector["Entidad"],
                        IdRegistro = datos.Lector["IdRegistro"] != DBNull.Value ? (int?)datos.Lector["IdRegistro"] : null,
                        Detalle = datos.Lector["Detalle"] != DBNull.Value ? (string)datos.Lector["Detalle"] : null,
                        DireccionIP = datos.Lector["DireccionIP"] != DBNull.Value ? (string)datos.Lector["DireccionIP"] : null,
                        UserAgent = datos.Lector["UserAgent"] != DBNull.Value ? (string)datos.Lector["UserAgent"] : null
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public long Registrar(Log log)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta(@"
                    INSERT INTO Log (Fecha, IdUsuario, Accion, Entidad, IdRegistro, Detalle, DireccionIP, UserAgent)
                    VALUES (SYSDATETIME(), @IdUsuario, @Accion, @Entidad, @IdRegistro, @Detalle, @DireccionIP, @UserAgent);
                    SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@IdUsuario", (object)log.IdUsuario ?? DBNull.Value);
                datos.setearParametro("@Accion", log.Accion);
                datos.setearParametro("@Entidad", log.Entidad);
                datos.setearParametro("@IdRegistro", (object)log.IdRegistro ?? DBNull.Value);
                datos.setearParametro("@Detalle", (object)log.Detalle ?? DBNull.Value);
                datos.setearParametro("@DireccionIP", (object)log.DireccionIP ?? DBNull.Value);
                datos.setearParametro("@UserAgent", (object)log.UserAgent ?? DBNull.Value);

                return Convert.ToInt64(datos.ejecutarAccionScalar());
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
