using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_00_Estado_inicial_de_la_Aplicación
{
    public partial class _22_MultiView_and_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                MultiView1.ActiveViewIndex = 0;
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnSiguiente01_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtA.Text);
            int b = Convert.ToInt32(txtB.Text);
            int r = 0;

            if (rbSuma.Checked)
            {
                r = a + b;
            }
            if (rbResta.Checked)
            {
                r = a - b;
            }
            if (rbMulti.Checked)
            {
                r = a * b;
            }
            if (rbDiv.Checked)
            {
                r = a / b;
            }
            txtResultado.Text = r.ToString();
            MultiView1.ActiveViewIndex = 2;
        }

        
    }
}