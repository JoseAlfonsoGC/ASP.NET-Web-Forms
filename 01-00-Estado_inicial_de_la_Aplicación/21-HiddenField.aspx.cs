using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_00_Estado_inicial_de_la_Aplicación
{
    public partial class _21_HiddenField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            //colocamos el valor que nos interesa
            hfValor.Value = txtDato.Text;

            // limpimos la etiqueta y el textBox
            lblMostrar.Text = "";
            txtDato.Text = "";
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            //leemos el valor
            lblMostrar.Text = hfValor.Value;
        }
    }
}