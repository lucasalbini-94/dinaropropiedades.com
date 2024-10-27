using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zen.Barcode;
using System.IO;
using System.Drawing;

namespace Ventanas
{
    public partial class QR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                string url = tbxUrl.Text;

                // Generar el código de barras en formato QR
                CodeQrBarcodeDraw qrCode = BarcodeDrawFactory.CodeQr;
                System.Drawing.Image img = qrCode.Draw(url, 50);

                // Convertir la imagen a un array de bytes
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();

                    // Convertir la imagen a base64 para mostrarla en la etiqueta <img>
                    string base64Image = Convert.ToBase64String(byteImage);
                    imgQR.ImageUrl = "data:image/png;base64," + base64Image;

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorAdmin.aspx");
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string url = tbxUrl.Text;
                string nuevoNombre = tbxRenombrar.Text;

                // Generar el código de barras en formato QR
                CodeQrBarcodeDraw qrCode = BarcodeDrawFactory.CodeQr;
                System.Drawing.Image img = qrCode.Draw(url, 50);

                // Definir la ruta donde se guardará la imagen
                string relativePath = "~/Images/ImgQR/" + nuevoNombre + ".png";
                string absolutePath = Server.MapPath(relativePath);

                // Guardar la imagen en el servidor
                img.Save(absolutePath, System.Drawing.Imaging.ImageFormat.Png);

                // Configurar la respuesta para descargar el archivo
                Response.Clear();
                Response.ContentType = "image/png";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + nuevoNombre + ".png");
                Response.WriteFile(absolutePath);
                Response.Flush();
                Response.SuppressContent = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("ErrorAdmin.aspx");
            }
        }
    }
}