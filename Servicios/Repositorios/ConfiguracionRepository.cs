using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios.Interfaces;

namespace Servicios.Repositorios
{
    public class ConfiguracionRepository : IConfiguracionRepository
    {
        public Configuracion Obtener()
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT TOP 1 Id, NombreEmpresa, Telefono, WhatsApp, Email, Direccion, Latitud, Longitud, Facebook, Instagram, YouTube, LinkedIn, Logo, LogoOscuro, Favicon, GoogleMaps, GoogleAnalytics, MetaTitulo, MetaDescripcion FROM Configuracion");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Configuracion
                    {
                        Id = (int)datos.Lector["Id"],
                        NombreEmpresa = (string)datos.Lector["NombreEmpresa"],
                        Telefono = datos.Lector["Telefono"] != DBNull.Value ? (string)datos.Lector["Telefono"] : null,
                        WhatsApp = datos.Lector["WhatsApp"] != DBNull.Value ? (string)datos.Lector["WhatsApp"] : null,
                        Email = datos.Lector["Email"] != DBNull.Value ? (string)datos.Lector["Email"] : null,
                        Direccion = datos.Lector["Direccion"] != DBNull.Value ? (string)datos.Lector["Direccion"] : null,
                        Latitud = datos.Lector["Latitud"] != DBNull.Value ? (decimal?)datos.Lector["Latitud"] : null,
                        Longitud = datos.Lector["Longitud"] != DBNull.Value ? (decimal?)datos.Lector["Longitud"] : null,
                        Facebook = datos.Lector["Facebook"] != DBNull.Value ? (string)datos.Lector["Facebook"] : null,
                        Instagram = datos.Lector["Instagram"] != DBNull.Value ? (string)datos.Lector["Instagram"] : null,
                        YouTube = datos.Lector["YouTube"] != DBNull.Value ? (string)datos.Lector["YouTube"] : null,
                        LinkedIn = datos.Lector["LinkedIn"] != DBNull.Value ? (string)datos.Lector["LinkedIn"] : null,
                        Logo = datos.Lector["Logo"] != DBNull.Value ? (string)datos.Lector["Logo"] : null,
                        LogoOscuro = datos.Lector["LogoOscuro"] != DBNull.Value ? (string)datos.Lector["LogoOscuro"] : null,
                        Favicon = datos.Lector["Favicon"] != DBNull.Value ? (string)datos.Lector["Favicon"] : null,
                        GoogleMaps = datos.Lector["GoogleMaps"] != DBNull.Value ? (string)datos.Lector["GoogleMaps"] : null,
                        GoogleAnalytics = datos.Lector["GoogleAnalytics"] != DBNull.Value ? (string)datos.Lector["GoogleAnalytics"] : null,
                        MetaTitulo = datos.Lector["MetaTitulo"] != DBNull.Value ? (string)datos.Lector["MetaTitulo"] : null,
                        MetaDescripcion = datos.Lector["MetaDescripcion"] != DBNull.Value ? (string)datos.Lector["MetaDescripcion"] : null
                    };
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Guardar(Configuracion c)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                if (c.Id > 0)
                {
                    datos.setearConsulta(@"
                        UPDATE Configuracion SET 
                            NombreEmpresa=@NombreEmpresa, Telefono=@Telefono, WhatsApp=@WhatsApp, Email=@Email, 
                            Direccion=@Direccion, Latitud=@Latitud, Longitud=@Longitud, Facebook=@Facebook, 
                            Instagram=@Instagram, YouTube=@YouTube, LinkedIn=@LinkedIn, Logo=@Logo, 
                            LogoOscuro=@LogoOscuro, Favicon=@Favicon, GoogleMaps=@GoogleMaps, 
                            GoogleAnalytics=@GoogleAnalytics, MetaTitulo=@MetaTitulo, MetaDescripcion=@MetaDescripcion
                        WHERE Id=@Id");
                    datos.setearParametro("@Id", c.Id);
                }
                else
                {
                    datos.setearConsulta(@"
                        INSERT INTO Configuracion (NombreEmpresa, Telefono, WhatsApp, Email, Direccion, Latitud, Longitud, Facebook, Instagram, YouTube, LinkedIn, Logo, LogoOscuro, Favicon, GoogleMaps, GoogleAnalytics, MetaTitulo, MetaDescripcion)
                        VALUES (@NombreEmpresa, @Telefono, @WhatsApp, @Email, @Direccion, @Latitud, @Longitud, @Facebook, @Instagram, @YouTube, @LinkedIn, @Logo, @LogoOscuro, @Favicon, @GoogleMaps, @GoogleAnalytics, @MetaTitulo, @MetaDescripcion)");
                }

                datos.setearParametro("@NombreEmpresa", c.NombreEmpresa);
                datos.setearParametro("@Telefono", (object)c.Telefono ?? DBNull.Value);
                datos.setearParametro("@WhatsApp", (object)c.WhatsApp ?? DBNull.Value);
                datos.setearParametro("@Email", (object)c.Email ?? DBNull.Value);
                datos.setearParametro("@Direccion", (object)c.Direccion ?? DBNull.Value);
                datos.setearParametro("@Latitud", (object)c.Latitud ?? DBNull.Value);
                datos.setearParametro("@Longitud", (object)c.Longitud ?? DBNull.Value);
                datos.setearParametro("@Facebook", (object)c.Facebook ?? DBNull.Value);
                datos.setearParametro("@Instagram", (object)c.Instagram ?? DBNull.Value);
                datos.setearParametro("@YouTube", (object)c.YouTube ?? DBNull.Value);
                datos.setearParametro("@LinkedIn", (object)c.LinkedIn ?? DBNull.Value);
                datos.setearParametro("@Logo", (object)c.Logo ?? DBNull.Value);
                datos.setearParametro("@LogoOscuro", (object)c.LogoOscuro ?? DBNull.Value);
                datos.setearParametro("@Favicon", (object)c.Favicon ?? DBNull.Value);
                datos.setearParametro("@GoogleMaps", (object)c.GoogleMaps ?? DBNull.Value);
                datos.setearParametro("@GoogleAnalytics", (object)c.GoogleAnalytics ?? DBNull.Value);
                datos.setearParametro("@MetaTitulo", (object)c.MetaTitulo ?? DBNull.Value);
                datos.setearParametro("@MetaDescripcion", (object)c.MetaDescripcion ?? DBNull.Value);

                datos.ejecutarAccion();

                return true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
