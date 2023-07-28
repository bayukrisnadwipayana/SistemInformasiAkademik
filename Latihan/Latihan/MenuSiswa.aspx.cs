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
using Latihan;
using System.Data.SqlClient;
using System.Net;
using System.ComponentModel;
using System.Collections.Generic;

namespace Latihan
{
    public partial class MenuSiswa : System.Web.UI.Page
    {
        Controller controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                datapendaftaran.DataSource = controller.DisplayDataTable("SELECT siswa.nis, siswa.namasiswa, siswa.alamat, siswa.jeniskelamin, siswa.asalsekolah, kota.namakota, panitia.nama_panitia FROM siswa INNER JOIN kota ON siswa.kode_kota = kota.kode_kota INNER JOIN panitia ON siswa.id_panitia = panitia.id_panitia");
                datapendaftaran.DataBind();
            }
        }

        protected void GetValueByNis(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string nis = (item.FindControl("nissiswa") as Label).Text;
            Response.Redirect("EditDataSiswa.aspx?nis=" + nis);
        }

        protected void DeleteValueByNis(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string nis = (item.FindControl("nissiswa") as Label).Text;
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM siswa WHERE nis=@nis";
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = nis;
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    Response.Write("<script>alert('data sukses dihapus')</script>");
                    datapendaftaran.DataSource = controller.DisplayDataTable("SELECT siswa.nis, siswa.namasiswa, siswa.alamat, siswa.jeniskelamin, siswa.asalsekolah, kota.namakota, panitia.nama_panitia FROM siswa INNER JOIN kota ON siswa.kode_kota = kota.kode_kota INNER JOIN panitia ON siswa.id_panitia = panitia.id_panitia");
                    datapendaftaran.DataBind();
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

        protected void SearchDataSiswa(object sender, EventArgs e)
        {
            string textsearch = text_search.Text;
            string query = "SELECT siswa.nis, siswa.namasiswa, siswa.alamat, siswa.jeniskelamin, siswa.asalsekolah, kota.namakota, panitia.nama_panitia FROM siswa INNER JOIN kota ON siswa.kode_kota = kota.kode_kota INNER JOIN panitia ON siswa.id_panitia = panitia.id_panitia WHERE nis LIKE '%" + textsearch.Trim() + "%' OR namasiswa LIKE '%" + textsearch.Trim() + "%'";
            datapendaftaran.DataSource = controller.DisplayDataTable(query);
            datapendaftaran.DataBind();
        }

        protected void RedirectToAkademik(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string nis = (item.FindControl("nissiswa") as Label).Text;
            Response.Redirect("Akademik.aspx?nis=" + nis);
        }
    }
}
