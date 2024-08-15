using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Propiedades
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Bio { get; set; }
        public string Descripcion { get; set; }
        public Departamentos Departamento { get; set; }
        public Localidades Localidad { get; set; }
        public Pueblos Pueblo { get; set; }
        public bool Destacado { get; set; }
        public bool Activo { get; set; }
        public string ImagenPrincipal { get; set; }
        public string Video { get; set; }
        public int MetrosTotales { get; set; }
        public int MetrosCubiertos { get; set; }
        public int Ambientes { get; set; }
        public int Dormitorios { get; set; }
        public int Baños { get; set; }
        public int Plantas { get; set; }
        public int Cocheras { get; set; }
        public TipoPropiedad TipoPropiedad { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public string Moneda { get; set; }
        public decimal Precio { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Ubicacion { get; set; }
    }
}
