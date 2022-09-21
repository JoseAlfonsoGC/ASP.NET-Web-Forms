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
    public partial class _02_00_insert_ps_metod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatosAlumno();
            }
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
                /*procedimiento almacenado ocupado en la consulta anterior
                create proc SPIalumnos
	                @nombre varchar(50),
	                @ap_paterno varchar(50),
	                @ap_materno varchar(50),
	                @email varchar(50)
                as
                begin
	                insert into alumno(nombre,ap_paterno,ap_materno,email)
					            values(@nombre,@ap_paterno,@ap_materno,@email);
                end
                 */
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
    }
}