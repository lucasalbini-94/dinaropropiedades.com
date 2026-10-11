using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;
using Servicios.Repositorios;

namespace Negocio
{
    public class LogNegocio
    {
        private readonly ILogRepository _repo;

        public LogNegocio()
        {
            _repo = new LogRepository();
        }

        public LogNegocio(ILogRepository repo)
        {
            _repo = repo;
        }

        public List<Log> ListarUltimos(int cantidad = 100)
        {
            return _repo.ObtenerUltimos(cantidad);
        }

        public void RegistrarAccion(string accion, string entidad, int? idRegistro = null, int? idUsuario = null, string detalle = null, string ip = null, string userAgent = null)
        {
            if (string.IsNullOrWhiteSpace(accion) || string.IsNullOrWhiteSpace(entidad))
                return;

            Log entrada = new Log
            {
                Accion = accion,
                Entidad = entidad,
                IdRegistro = idRegistro,
                IdUsuario = (int)idUsuario,
                Detalle = detalle,
                DireccionIP = ip,
                UserAgent = userAgent
            };

            _repo.Registrar(entrada);
        }
    }
}
