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
    }
}