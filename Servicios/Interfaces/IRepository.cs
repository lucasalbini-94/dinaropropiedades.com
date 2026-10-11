using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
        int Agregar(T entidad);
        bool Modificar(T entidad);
        bool Eliminar(int id);
    }
}
