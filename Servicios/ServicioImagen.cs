using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Servicios
{
    public class ServicioImagen
    {
        public static string GuardarImagenDesdeBase64(string base64Data, int idPropiedad, string nombreUnico, string rutaFisicaBase)
        {
            // Limpiar la cabecera 'data:image/jpeg;base64,' si viene presente
            string rawBase64 = base64Data;
            if (rawBase64.Contains(","))
            {
                rawBase64 = rawBase64.Substring(rawBase64.IndexOf(",") + 1);
            }

            byte[] imageBytes = Convert.FromBase64String(rawBase64);

            // Carpeta raíz: /Uploads/Propiedades/{idPropiedad}
            string carpetaPropiedad = Path.Combine(rutaFisicaBase, "Uploads", "Propiedades", "Propiedad_" + idPropiedad);
            string carpetaSmall = Path.Combine(carpetaPropiedad, "small");
            string carpetaMedium = Path.Combine(carpetaPropiedad, "medium");
            string carpetaLarge = Path.Combine(carpetaPropiedad, "Large");

            Directory.CreateDirectory(carpetaSmall);
            Directory.CreateDirectory(carpetaMedium);
            Directory.CreateDirectory(carpetaLarge);

            string nombreArchivo = nombreUnico + ".jpg";

            using (MemoryStream ms = new MemoryStream(imageBytes))
            using (Image imgOriginal = Image.FromStream(ms))
            {
                // Generar tamaños
                using (Bitmap bmpLarge = Redimensionar(imgOriginal, 1200, 800))
                    bmpLarge.Save(Path.Combine(carpetaLarge, nombreArchivo), ImageFormat.Jpeg);
                using (Bitmap bmpMedium = Redimensionar(imgOriginal, 600, 400))
                    bmpMedium.Save(Path.Combine(carpetaMedium, nombreArchivo), ImageFormat.Jpeg);
                using (Bitmap bmpSmall = Redimensionar(imgOriginal, 150, 150))
                    bmpSmall.Save(Path.Combine(carpetaSmall, nombreArchivo), ImageFormat.Jpeg);
            }

            return "Uploads/Propiedades/Propiedad_" + idPropiedad + "/" + nombreArchivo;
        }

        private static Bitmap Redimensionar(Image imagen, int anchoMax, int altoMax)
        {
            float ratioAncho = (float)anchoMax / imagen.Width;
            float ratioAlto = (float)altoMax / imagen.Height;
            float ratio = Math.Min(ratioAncho, ratioAlto);

            int nuevoAncho = (int)(imagen.Width * ratio);
            int nuevoAlto = (int)(imagen.Height * ratio);

            Bitmap nuevoLienzo = new Bitmap(nuevoAncho, nuevoAlto);
            using (Graphics g = Graphics.FromImage(nuevoLienzo))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawImage(imagen, 0, 0, nuevoAncho, nuevoAlto);
            }

            return nuevoLienzo;
        }
    }
}
