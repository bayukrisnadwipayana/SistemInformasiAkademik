using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using Latihan;

namespace Latihan
{
    public partial class Akademik : System.Web.UI.Page
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();
        Controller controller = new Controller();

        protected void SimpanRaportSiswa(object sender, EventArgs e)
        {
            if (controller.SaveDataRaport(dropdownkelas.SelectedValue, dropdownsemester.SelectedValue, textnis.Text, dropdownlistpelajaran.SelectedValue, texttugas.Text, textkuis.Text, textujian.Text) > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal.fire('Sukses','Data Sukses Disimpan','success')", true);
            }
        }

        protected void DisplayRaportKelas1Semester1(string semester,string nis)
        {
            string query = "SELECT  raport.kelas, raport.semester, raport.nis, siswa.namasiswa, pelajaran.nama_mapel, raport.tugas, raport.kuis, raport.ujian, (raport.tugas + raport.kuis + raport.ujian)/ 3 AS rata_rata FROM raport INNER JOIN siswa ON raport.nis = siswa.nis INNER JOIN pelajaran ON raport.id_mapel=pelajaran.id_mapel WHERE (siswa.nis = @nis11) AND (raport.semester = @semester11)";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis11", SqlDbType.VarChar).Value = nis;
                command.Parameters.Add("@semester11", SqlDbType.VarChar).Value = semester;
                datareader = command.ExecuteReader();
                tabelkelas1semester1.DataSource = datareader;
                tabelkelas1semester1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
            }
        }

        protected void DisplayRaportKelas1Semester2(string semester, string nis)
        {
            string query = "SELECT  raport.kelas, raport.semester, raport.nis, siswa.namasiswa, pelajaran.nama_mapel, raport.tugas, raport.kuis, raport.ujian, (raport.tugas + raport.kuis + raport.ujian)/ 3 AS rata_rata FROM raport INNER JOIN siswa ON raport.nis = siswa.nis INNER JOIN pelajaran ON raport.id_mapel=pelajaran.id_mapel WHERE (siswa.nis = @nis12) AND (raport.semester = @semester12)";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText=query;
                command.Parameters.Add("@nis12", SqlDbType.VarChar).Value = nis;
                command.Parameters.Add("@semester12", SqlDbType.VarChar).Value = semester;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "raport");
                tabelkelas1semester2.DataSource = ds;
                tabelkelas1semester2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
            }
        }

        protected void RenderDropDownPelajaran()
        {
            dropdownlistpelajaran.DataSource = controller.DisplayDataTable("SELECT * FROM pelajaran");
            dropdownlistpelajaran.DataValueField = "id_mapel";
            dropdownlistpelajaran.DataTextField = "nama_mapel";
            dropdownlistpelajaran.DataBind();
        }

        protected void EventModalHapusRaportKelas1Semester1(object sender, EventArgs e)
        {
            
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            SqlDataReader datareader;
            string query = "SELECT raport.id_mapel FROM raport INNER JOIN pelajaran ON raport.id_mapel=pelajaran.id_mapel WHERE pelajaran.nama_mapel=@namamapel";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@namamapel", SqlDbType.VarChar).Value = (item.FindControl("labelpelajaran") as Label).Text;
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    texthapuskelas1.Text = (item.FindControl("labelkelas") as Label).Text;
                    texthapussemester1.Text = (item.FindControl("labelsemester") as Label).Text;
                    texthapusnis.Text = (item.FindControl("labelnis") as Label).Text;
                    texthapuspelajaran1.Text = datareader["id_mapel"].ToString();
                }
                datareader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
            }
            this.modalpopup.Show();
        }

        protected void EventHapusRaportKelas1Semester1(object sender, EventArgs e)
        {
            if (controller.EventHapusRaportKelas1Semester1(texthapuskelas1.Text, texthapussemester1.Text, texthapusnis.Text, texthapuspelajaran1.Text) > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Hapus','Data Sukses Dihapus','success')", true);
                DisplayRaportKelas1Semester1("1", Request.QueryString["nis"]);
            }
        }

        protected void EventHapusRaportKelas1Semester2(object sender, GridViewDeleteEventArgs e)
        {
            string query = "DELETE FROM raport INNER JOIN pelajaran ON raport.id_mapel=pelajaran.id_mapel WHERE nis=@nis AND kelas=@kelas AND semester=@semester";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = tabelkelas1semester2.DataKeys[e.RowIndex].Values["nis"].ToString();
                command.Parameters.Add("@kelas", SqlDbType.VarChar).Value = tabelkelas1semester2.DataKeys[e.RowIndex].Values["kelas"].ToString();
                command.Parameters.Add("@semester", SqlDbType.VarChar).Value = tabelkelas1semester2.DataKeys[e.RowIndex].Values["semester"].ToString();
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Sukses Dihapus','success')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderDropDownPelajaran();
                DisplayRaportKelas1Semester1("1", Request.QueryString["nis"]);
                DisplayRaportKelas1Semester2("2", Request.QueryString["nis"]);
                if (Request.Url.AbsoluteUri.Contains('?'))
                {
                    textnis.Text = Request.Url.AbsoluteUri.Split('=')[1];
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}
