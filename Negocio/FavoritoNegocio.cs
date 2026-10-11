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
    public class FavoritoNegocio
    {
        private readonly IFavoritoRepository _repo;

        public FavoritoNegocio()
        {
            _repo = new FavoritoRepository();
        }

        public FavoritoNegocio(IFavoritoRepository repo)
        {
            _repo = repo;
        }

        public List<Propiedad> ListarPorUsuario(int idUsuario)
        {
            if (idUsuario <= 0) throw new ArgumentException("Usuario no válido.");
            return _repo.ObtenerFavoritosPorUsuario(idUsuario);
        }

        public bool ToggleFavorito(int idUsuario, int idPropiedad)
        {
            if (idUsuario <= 0 || idPropiedad <= 0) throw new ArgumentException("Parámetros no válidos.");

            if (_repo.EsFavorito(idUsuario, idPropiedad))
            {
                return _repo.Eliminar(idUsuario, idPropiedad);
            }
            else
            {
                return _repo.Agregar(idUsuario, idPropiedad);
            }
        }
    }
}
