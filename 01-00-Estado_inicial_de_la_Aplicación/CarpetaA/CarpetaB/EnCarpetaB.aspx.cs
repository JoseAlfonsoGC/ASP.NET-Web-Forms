using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_00_Estado_inicial_de_la_Aplicación.CarpetaA.CarpetaB
{
    public partial class EnCarpetaB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // El path actual
            Response.Write(Server.MapPath(".") + "<BR>");
            //El path del padre
            Response.Write(Server.MapPath("..") + "<BR>");
            // El path a root o directorio raiz
            Response.Write(Server.MapPath("~") + "<BR>");
            if (!IsPostBack)
            {
                DataSet Ds = new DataSet();
                Ds.ReadXml(Server.MapPath("~/DropDownList-03_Frutas.xml"));

                ddlFrutas.DataSource = Ds;

                ddlFrutas.DataValueField = "FrutaID";
                ddlFrutas.DataTextField = "FrutaNombre";

                ddlFrutas.DataBind();
            }
        }
    }
}