using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Propiedad
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Bio { get; set; }
        public string Descripcion { get; set; }

        // Claves Foráneas
        public int IdTipoPropiedad { get; set; }
        public int IdTipoContrato { get; set; }
        public int IdEstadoPropiedad { get; set; }
        public int IdBarrio { get; set; }

        // Objetos relacionados
        public TipoPropiedad TipoPropiedad { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public EstadoPropiedad EstadoPropiedad { get; set; }
        public Barrio Barrio { get; set; }

        // Ubicacion
        public string Direccion { get; set; }
        public bool MostrarDireccion { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }

        // Detalle y características numéricas
        public short? Ambientes { get; set; }
        public short? Dormitorios { get; set; }
        public short? Banios { get; set; }
        public short? Cocheras { get; set; }
        public short? Plantas { get; set; }
        public short? MetrosTotales { get; set; }
        public short? MetrosCubiertos { get; set; }

        // Precio y Estado
        public string Moneda { get; set; }
        public decimal PrecioActual { get; set; }
        public string Video { get; set; }
        public bool Destacado { get; set; }
        public bool Activo { get; set; }

        // Auditoría de fechas
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaVenta { get; set; }

        // Listas asociadas
        public List<Imagen> Imagenes { get; set; }
        public List<Caracteristica> Caracteristicas { get; set; }
        public List<HistorialPrecio> HistorialPrecios { get; set; }

        // Imagenes principales
        public string RutaImagenPrincipal { get; set; }

        // Constructor para iniciar listas y evitar NullReferenceException
        public Propiedad()
        {
            Imagenes = new List<Imagen>();
            Caracteristicas = new List<Caracteristica>();
            HistorialPrecios = new List<HistorialPrecio>();
            MostrarDireccion = false;
            Destacado = false;
            Activo = true;
        }
    }
}
