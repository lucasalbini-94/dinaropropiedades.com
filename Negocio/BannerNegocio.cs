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
    public class BannerNegocio
    {
        private readonly IBannerRepository _repo;

        public BannerNegocio()
        {
            _repo = new BannerRepository();
        }

        public BannerNegocio(IBannerRepository repo)
        {
            _repo = repo;
        }

        public List<Banner> ListarVisibles()
        {
            return _repo.ObtenerVisibles();
        }

        public List<Banner> ListarTodos()
        {
            return _repo.ObtenerTodos();
        }

        public bool Guardar(Banner banner)
        {
            if (banner == null) throw new ArgumentNullException(nameof(banner));
            if (string.IsNullOrWhiteSpace(banner.RutaImagen))
                throw new Exception("Debe cargar una imagen para el banner.");

            if (banner.Id > 0)
                return _repo.Modificar(banner);
            else
                return _repo.Agregar(banner) > 0;
        }

        public bool Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            return _repo.Eliminar(id);
        }
    }
}
