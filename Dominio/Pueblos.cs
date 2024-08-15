using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pueblos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Localidades Localidad { get; set; }
    }
}
