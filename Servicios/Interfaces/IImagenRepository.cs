using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios.Interfaces
{
    public interface IImagenRepository : IRepository<Imagen>
    {
        List<Imagen> ObtenerPorPropiedad(int idPropiedad);
        bool MarcarComoPrincipal(int idImagen, int idPropiedad);
        bool Reordenar(int idImagen, short nuevoOrden);
        bool EliminarPorPropiedad(int idPropiedad);
    }
}
