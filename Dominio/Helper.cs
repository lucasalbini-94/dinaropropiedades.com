using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Ventanas
{
    public static class Helper
    {
        public static Imagenes imagenPlaceholder()
        {
            Imagenes img = new Imagenes();
            img.Principal = true;
            img.Ruta = "./Images/ImgApp/placeholder.jpg";
            img.Alt = "Imagen de placeholder";
            return img;
        }

        public static void separarPropiedadesYTerrenos(ref List<Propiedades> lista)
        {
            foreach (Propiedades prop in lista)
            {
                if (prop.TipoPropiedad.Descripcion == "Terreno")
                {
                    prop.Terreno = true;
                }
                else
                {
                    prop.Terreno = false;
                }
            }
        }

        public static void separarPropiedadesYTerrenos(ref Propiedades prop)
        {
            if (prop.TipoPropiedad.Descripcion == "Terreno")
            {
                prop.Terreno = true;
            }
            else
            {
                prop.Terreno = false;
            }
        }
    }
}