using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_00_Uso_de_BaseDeDatos_en_Aplicacion
{
    public partial class _04_00_update_user_dataBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatosAlumno();
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlDatoAlumno.Visible = false;
            pnlAltaAlumno.Visible = true;
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pnlAltaAlumno.Visible = false;
            pnlDatoAlumno.Visible = true;
            GuardaAlumno();
            CargaDatosAlumno();
        }

        protected void gvdAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvdAlumnos.Rows[e.RowIndex];
            EliminarAlumno(gvdAlumnos.DataKeys[e.RowIndex].Value.ToString());
            CargaDatosAlumno();
        }
        public void CargaDatosAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSalumnos";
                cmd.Connection = conn;
                conn.Open();
                gvdAlumnos.DataSource = cmd.ExecuteReader();
                gvdAlumnos.DataBind();
            }
        }

        public void GuardaAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIalumnos";
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text.Trim();
                cmd.Parameters.Add("@ap_paterno", SqlDbType.VarChar).Value = txtAp_Paterno.Text.Trim();
                cmd.Parameters.Add("@ap_materno", SqlDbType.VarChar).Value = txtAp_materno.Text.Trim();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarAlumno(string id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPDalumnos";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int64.Parse(id);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void lkbActualizar_Click(object sender, EventArgs e)
        {
            pnlAltaAlumno.Visible = true;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            gvdAlumnos.SelectedIndex = row.RowIndex;
            lblIdAlumno.Text = row.Cells[0].Text;
            txtNombre.Text = row.Cells[1].Text;
            txtAp_Paterno.Text = row.Cells[2].Text;
            txtAp_materno.Text = row.Cells[3].Text;
            txtEmail.Text=row.Cells[4].Text;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            pnlAltaAlumno.Visible = false;
            pnlDatoAlumno.Visible = true;
            actualizarAlumno();
            lblIdAlumno.Text = "";
            btnActualizar.Visible = false;
            btnGuardar.Visible = true;
            CargaDatosAlumno();
        }
        public void actualizarAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUlumnos";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = long.Parse(lblIdAlumno.Text);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value=txtNombre.Text.Trim();
                cmd.Parameters.Add("@ap_paterno", SqlDbType.VarChar).Value=txtAp_Paterno.Text.Trim();
                cmd.Parameters.Add("@ap_materno", SqlDbType.VarChar).Value=txtAp_materno.Text.Trim();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value=txtEmail.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}