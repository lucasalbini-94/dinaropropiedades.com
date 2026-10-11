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
    public class UsuarioNegocio
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioNegocio()
        {
            _repo = new UsuarioRepository();
        }

        public UsuarioNegocio(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public Usuario Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Debe ingresar el email");
            }

            Usuario usuario = _repo.ObtenerPorEmail(email.Trim());

            if (usuario == null || !usuario.Activo)
            {
                throw new Exception("Las credenciales son incorrectas o la cuenta está inactiva");
            }

            bool esPasswordValido = usuario.PasswordHash == password;

            if (!esPasswordValido)
            {
                throw new Exception("La contraseña es incorrecta");
            }

            _repo.ActualizarUltimoLogin(usuario.Id);
            return usuario;
        }

        public List<Usuario> ListarTodos()
        {
            return _repo.ObtenerTodos();
        }

        public bool Guardar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("El email es obligatorio.");

            if (usuario.IdRol <= 0)
                throw new Exception("Debe asignar un rol válido al usuario.");

            if (usuario.Id > 0)
            {
                return _repo.Modificar(usuario);
            }
            else
            {
                var existente = _repo.ObtenerPorEmail(usuario.Email);
                if (existente != null)
                    throw new Exception("Ya existe un usuario registrado con ese email.");

                return _repo.Agregar(usuario) > 0;
            }
        }
    }
}
