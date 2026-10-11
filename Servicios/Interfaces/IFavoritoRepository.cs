using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface IFavoritoRepository
    {
        List<Propiedad> ObtenerFavoritosPorUsuario(int idUsuario);
        bool Agregar(int idUsuario, int idPropiedad);
        bool Eliminar(int idUsuario, int idPropiedad);
        bool EsFavorito(int idUsuario, int idPropiedad);
    }
}
