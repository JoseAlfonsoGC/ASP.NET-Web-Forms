using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace _01_00_Estado_inicial_de_la_Aplicación
{
    public class Global : HttpApplication
    {
        // CODIGO QUE COMPLEMENTA EL EJEMPLO 03-sesion_de_usuario {**********
        // Este handler se ejecuta cuando se crea una instancia de la apliccaion
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Creamos variables de estado para la aplicacion
            // Puede ser leida por todas las sesiones
            Application["Aplicaciones"] = 0;//conteo de cuantas aplicaciones se an instanciado
            Application["SesionesUsuario"] = 0;//conteo de cuantas sesiones de usuario

            // Incrementamos
            Application["Aplicaciones"] = (int)Application["Aplicaciones"] + 1;
        }
        // Este handler se ejecuta cuando se crea una sesion
        void Session_Start(object sender, EventArgs e)
        {
            Application["SesionesUsuario"] = (int)Application["SesionesUsuario"] + 1;
        }
        // Este handler se ejecuta cuando finaliza una sesion
        void Session_End(object sender, EventArgs e)
        {
            Application["SesionesUsuario"] = (int)Application["SesionesUsuario"] - 1;
        }
        // fin del complemento 03-sesion_de_usuari************}

    }
}