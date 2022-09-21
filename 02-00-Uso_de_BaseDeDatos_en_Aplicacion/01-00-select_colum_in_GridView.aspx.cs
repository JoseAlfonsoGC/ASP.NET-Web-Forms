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
    public partial class _01_00_select_colum_in_GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                /* procedimiento almacenado ocupado en la consulta anterior
                 create procedure SPSalumnos
                as 
                begin
	            select  id 'Clave alumno'
			            ,nombre 'Nombre'
			            ,ap_paterno 'Apellido paterno'
			            ,ap_materno 'Apellido materno'
			            ,email 'Correo'
		                from alumno
                end

                exec[SPSalumnos]
                 */

            }
        }
    }
}