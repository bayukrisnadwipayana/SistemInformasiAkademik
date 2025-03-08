using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace SistemAkademik
{
    public partial class JadwalGuru : System.Web.UI.Page
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["guru"] != null)
                {
                    DisplayMataPelajaranGuru();
                    DisplayJadwalMengajarGuru();
                }
                else
                {
                    Response.Redirect("LoginGuru.aspx");
                }               
            }
        }

        protected void DisplayMataPelajaranGuru()
        {
            string query = "SELECT pelajaran.nama_mapel,pelajaran.id_mapel FROM pelajaran INNER JOIN guru ON pelajaran.id_mapel=guru.id_mapel WHERE nip=@nipguru";
            string nipguru = Encoding.UTF8.GetString(Convert.FromBase64String(Session["guru"].ToString()));
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@nipguru", nipguru);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    namamapel.Text = datareader.GetString(0).ToString();
                    idmapel.Value = datareader.GetString(1).ToString();
                }
                datareader.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
            }
        }

        protected void EventTambahJadwalGuru(object sender,EventArgs e)
        {
            
            string query = "INSERT INTO jadwalkelas VALUES(@id_mapel,@nip,@kelas,@hari)";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@id_mapel", idmapel.Value);
                command.Parameters.AddWithValue("@nip", ((HyperLink)this.Master.FindControl("labelguru")).Text);
                command.Parameters.AddWithValue("@kelas", inputkelas.Text);
                command.Parameters.AddWithValue("@hari", inputhari.Text);
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Sukses Disimpan','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Gagal','Data Gagal Disimpan','error')", true);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                DisplayJadwalMengajarGuru();
            }
        }

        protected void DisplayJadwalMengajarGuru()
        {
            string query = "SELECT pelajaran.nama_mapel, jadwalkelas.kelas, jadwalkelas.hari FROM jadwalkelas INNER JOIN pelajaran ON pelajaran.id_mapel=jadwalkelas.id_mapel WHERE jadwalkelas.nip=@nipguru1";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@nipguru1", Encoding.UTF8.GetString(Convert.FromBase64String(Session["guru"].ToString())));
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "jadwalkelas");
                tabeljadwalmengajar.DataSource = ds.Tables["jadwalkelas"];
                tabeljadwalmengajar.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
            }
        }
    }
}