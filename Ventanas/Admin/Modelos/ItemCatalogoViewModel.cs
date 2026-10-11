using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ventanas.Admin.Modelos
{
    public class ItemCatalogoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        // Campos extras opcionales:
        public string Color { get; set; }
        public string Icono { get; set; }
        public string ExtraClave { get; set; }
        public string Extravalor { get; set; }
        public string Sigla { get; set; }

    }
}