using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Net.Mail;
using System.Net;

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
            //si se descomenta la siguiente linea, se borra del todo el usuario y se tendria que comentar la linea de baneo 
            //EliminarAlumno(gvdAlumnos.DataKeys[e.RowIndex].Value.ToString());
            BajaAlumno(gvdAlumnos.DataKeys[e.RowIndex].Value.ToString());
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
        public DataTable dtAlumno()
        {
            //generar PDF de la tabla 
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSalumnos";
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();
            }
            return dt;
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
        public void BajaAlumno(string id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPBajaAlumno";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int64.Parse(id);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                /* modificar la tabla existente de alumno agregando la columna banActivo
                 * 
                 alter table alumno add banActivo bit

                 select * from alumno

                 * Actualizar la columna de banActivo
                 
                 update alumno set banActivo=1
                *porocedimiento almacenado que se uso
                 create proc SPBajaAlumno
                 @id int
                 as begin
	                update alumno set banActivo=0
	             where id=@id
                 end
                *sin dejar de lado que se tiene que modificar el procedimiento almacenado que llena la entidad donde visualizamos los registros 
                 proc despues de la modificacion
                ALTER procedure [dbo].[SPSalumnos]
                as 
                begin
	            select  id 'Clave alumno'
			            ,nombre 'Nombre'
			            ,ap_paterno 'Apellido paterno'
			            ,ap_materno 'Apellido materno'
			            ,email 'Correo'
		        from alumno
		            where banActivo = 1
                end
                 */
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
        public void BusquedaAlumno()
        {
            /*
            create procedure SPSalumnosPorNombre
            @nombre varchar(50)
            as 
            begin
	            select  id 'Clave alumno'
			            ,nombre 'Nombre'
			            ,ap_paterno 'Apellido paterno'
			            ,ap_materno 'Apellido materno'
			            ,email 'Correo'
		            from alumno
		            where banActivo=1
		            and nombre like '%'+@nombre+'%'
            end
             */
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSalumnosPorNombre";
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value=txtNombreBus.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                gvdAlumnos.DataSource = cmd.ExecuteReader();
                gvdAlumnos.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaAlumno();
        }

        protected void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter write = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = dtAlumno();
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);


                PdfPTable table = new PdfPTable(dt.Columns.Count);
                document.Add(new Paragraph(20, "Reporte de Alumnos 2022", fontTitle));
                document.Add(new Chunk("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    widths[i] = 4f;

                table.SetWidths(widths);
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell(new Phrase("columns"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font9));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), font9));
                        }
                    }
                }
                document.Add(table);
            }
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=AlumnosActuales2022" + ".pdf");
            HttpContext.Current.Response.Write(document);
            Response.Flush();
            Response.End();
        }

        protected void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dtAlumno();
            Stream s = DataTableToExcel(dt);
            if (s != null)
            {
                MemoryStream ms = s as MemoryStream;
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + HttpUtility.UrlEncode("alumnos2022") + ".xlsx"));
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Length", ms.ToArray().Length.ToString());
                Response.BinaryWrite(ms.ToArray());
                Response.Flush();
                ms.Close();
                ms.Dispose();
            }
        }
        public Stream DataTableToExcel(DataTable dt)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet("Alumno20");
            XSSFRow headerRow = headerRow = (XSSFRow)sheet.CreateRow(0);
            try
            {
                foreach(DataColumn column in dt.Columns)
                {
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                int rowIndex = 1;
                foreach(DataRow row in dt.Rows)
                {
                    XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                    foreach(DataColumn column in dt.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }
                    ++rowIndex;
                }
                for(int i = 0; i<=dt.Columns.Count; ++i)
                {
                    sheet.AutoSizeColumn(i);
                }
                workbook.Write(ms);
                ms.Flush();
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                ms.Close();
                sheet = null;
                headerRow = null;
                workbook = null;
            }
            return ms;
        }

        protected void btnCorreo_Click(object sender, EventArgs e)
        {

        }
    }
}