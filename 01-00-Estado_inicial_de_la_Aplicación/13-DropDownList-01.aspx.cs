using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_00_Estado_inicial_de_la_Aplicación
{
    public partial class _13_DropDownList_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem Fresa = new ListItem("Fresa", "4");
                ListItem Naranja = new ListItem("Naranja", "5");

                DropDownListFrutas.Items.Add(Fresa);
                DropDownListFrutas.Items.Add(Naranja);
            }

        }

        protected void btnPruebas_Click(object sender, EventArgs e)
        {
            lblIndice.Text = DropDownListFrutas.SelectedIndex.ToString();
            lblValor.Text = DropDownListFrutas.SelectedValue.ToString();
            //lblSeleccionado.Text = DropDownListFrutas.SelectedItem.ToString();
            //forma alternativa de acceder a item
            lblSeleccionado.Text = DropDownListFrutas.Items[DropDownListFrutas.SelectedIndex].ToString();
        }
    }
}