using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_00_Estado_inicial_de_la_Aplicación
{
    public partial class _06_Variables_se_sesion_pasar_Info : System.Web.UI.Page
    {
        private int conteo = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtConteo.Text = "0";
            }
            if (Session["click"] != null)
            {
                txtConteo.Text = ((int)Session["click"]).ToString();
            }
        }

        protected void btnIncrementa_Click(object sender, EventArgs e)
        {
            //si ya se ha usado la variable click
            if (Session["click"] != null)
            {
                //leemos el valor, hacemos typecast, lo incrementamos y lo colocamos en la 
                //variable para poder trabajar con ese dato en nuestro codigo
                conteo = (int)Session["click"] + 1;
            }
            //Actualiza el textBox
            txtConteo.Text = conteo.ToString();

            //Asignamos el valñor en la variable click
            Session["click"] = conteo;
        }
    }
}