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
    public partial class _03_00_Delete_users : System.Web.UI.Page
    {
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

        public void EliminarAlumno(string id)
        {
            /*procedimiento almacenado ocupado para eliminar registros
             create proc SPDalumnos
	                @id int
             as begin
	                delete from alumno where id=@id
             end
             */
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
    }
}