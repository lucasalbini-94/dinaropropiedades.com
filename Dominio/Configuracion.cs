using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Configuracion
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string Telefono { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string YouTube { get; set; }
        public string LinkedIn { get; set; }
        public string Logo { get; set; }
        public string LogoOscuro { get; set; }
        public string Favicon { get; set; }
        public string GoogleMaps { get; set; }
        public string GoogleAnalytics { get; set; }
        public string MetaTitulo { get; set; }
        public string MetaDescripcion { get; set; }
    }
}
