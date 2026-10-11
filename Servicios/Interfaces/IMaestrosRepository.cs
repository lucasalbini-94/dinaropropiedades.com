using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface ITipoPropiedadRepository : IRepository<TipoPropiedad> { }
    public interface ITipoContratoRepository : IRepository<TipoContrato> { }
    public interface IEstadoPropiedadRepository : IRepository<EstadoPropiedad> { }
    public interface IBarrioRepository : IRepository<Barrio> { }
    public interface ICaracteristicaRepository : IRepository<Caracteristica> { }
}
