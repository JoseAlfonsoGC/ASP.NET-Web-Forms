using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_00_Estado_inicial_de_la_Aplicación
{
    public partial class _14_DropDownList_02_inf_xml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("DropDownList-03_Frutas.xml"));

                ddlLFrutas.DataSource = ds;
                ddlLFrutas.DataValueField = "FrutaID";
                ddlLFrutas.DataTextField = "FrutaNombre";

                ddlLFrutas.DataBind();
            }
        }
    }
}