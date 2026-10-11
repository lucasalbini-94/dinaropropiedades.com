using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface IPropiedadRepository : IRepository<Propiedad>
    {
        int ObtenerSiguienteId();
        Propiedad ObtenerPorCodigo(string codigo);
        List<Propiedad> BuscarConFiltros(int? idTipo, int? idContrato, int? idBarrio, decimal? precioMax);
        List<Propiedad> ObtenerDestacadas();
        List<Propiedad> ObtenerUltimasCargadas(int cantidad = 5);
        bool CambiarEstado(int idPropiedad, bool activo);
        bool MarcarComoDestacado(int idPropiedad, bool destacado);
    }
}
