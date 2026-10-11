using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface IConfiguracionRepository
    {
        Configuracion Obtener();
        bool Guardar(Configuracion configuracion);
    }
}
