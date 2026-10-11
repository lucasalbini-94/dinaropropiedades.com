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
    class ConfiguracionNegocio
    {
        private readonly IConfiguracionRepository _repo;

        public ConfiguracionNegocio()
        {
            _repo = new ConfiguracionRepository();
        }

        public ConfiguracionNegocio(IConfiguracionRepository repo)
        {
            _repo = repo;
        }

        public Configuracion Obtener()
        {
            return _repo.Obtener();
        }

        public bool Guardar(Configuracion configuracion)
        {
            if (configuracion == null)
            {
                throw new ArgumentNullException(nameof(configuracion));
            }
            if (string.IsNullOrWhiteSpace(configuracion.NombreEmpresa))
            {
                throw new Exception("El nombre de la empresa es obligatorio");
            }

            return _repo.Guardar(configuracion);
        }
    }
}
