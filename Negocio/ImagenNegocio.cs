using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;
using Servicios.Interfaces;
using Servicios.Repositorios;

namespace Negocio
{
    public class ImagenNegocio
    {
        private readonly IImagenRepository _repo;

        public ImagenNegocio()
        {
            _repo = new ImagenRepository();
        }

        public ImagenNegocio(IImagenRepository repo)
        {
            _repo = repo;
        }

        public List<Imagen> ListarPorPropiedad(int idPropiedad)
        {
            if (idPropiedad <= 0)
            {
                throw new ArgumentException("ID de propiedad inválido");
            }

            return _repo.ObtenerPorPropiedad(idPropiedad);
        }

        public bool Guardar(Imagen imagen)
        {
            if (imagen == null)
            {
                throw new ArgumentNullException(nameof(imagen));
            }
            if (string.IsNullOrEmpty(imagen.Ruta))
            {
                throw new Exception("La ruta de la imagenn es obligatoria");
            }
            if (imagen.IdPropiedad <= 0)
            {
                throw new Exception("La imagen debe estar asociada a una propiedad válida");
            }

            if (imagen.Id > 0)
                return _repo.Modificar(imagen);
            else
                return _repo.Agregar(imagen) > 0;
        }

        public bool EstablecerPrincipal(int idImagen, int idPropiedad)
        {
            if (idImagen <= 0 || idPropiedad <= 0)
            {
                throw new ArgumentException("Parámtros inválidos");
            }
            return _repo.MarcarComoPrincipal(idImagen, idPropiedad);
        }

        public bool Eliminar(int idImagen)
        {
            if (idImagen <= 0)
            {
                throw new Exception("ID no válido");
            }

            return _repo.Eliminar(idImagen);
                
        }
    }
}
