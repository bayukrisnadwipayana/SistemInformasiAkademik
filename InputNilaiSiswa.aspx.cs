using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Latihan;

namespace SistemAkademik
{
    public partial class InputNilaiSiswa1 : System.Web.UI.Page
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();
        Controller controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["nis"] != null)
                {
                    textnis.Text = Request.QueryString["nis"].ToString();
                    DisplayMataPelajaranGuru();
                }
                else
                {
                    Response.Redirect("DataSiswa.aspx");
                }
                DisplayNilaiRaportSiswa();
            }
        }

        protected void DisplayMataPelajaranGuru()
        {
            string query = "SELECT pelajaran.nama_mapel, pelajaran.id_mapel FROM pelajaran INNER JOIN guru ON pelajaran.id_mapel=guru.id_mapel WHERE guru.nip=@nipguru";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@nipguru", Encoding.UTF8.GetString(Convert.FromBase64String(Session["guru"].ToString())));
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    textpelajaran.Text = datareader.GetString(0).ToString();
                    hiddenidpelajaran.Value = datareader.GetString(1).ToString();
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
        protected void EventSimpanNilaiSiswa(object sender, EventArgs e)
        {
            if (controller.SaveDataRaport(dropdownkelas.SelectedValue.ToString(), dropdownsemester.SelectedValue.ToString(), textnis.Text, hiddenidpelajaran.Value, texttugas.Text, textkuis.Text, textujian.Text) > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Sukses Disimpan','success')", true);
                DisplayNilaiRaportSiswa();
            }
        }

        protected void DisplayNilaiRaportSiswa()
        {
            string query = "SELECT raport.kelas, raport.semester,raport.nis,raport.tugas,raport.kuis,raport.ujian,pelajaran.nama_mapel,(raport.tugas+raport.kuis+raport.ujian)/3 AS rata_rata FROM raport INNER JOIN guru ON raport.id_mapel = guru.id_mapel INNER JOIN pelajaran ON guru.id_mapel = pelajaran.id_mapel WHERE guru.id_mapel = (SELECT id_mapel FROM guru WHERE nip = @nip) AND raport.nis = @nis";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@nip", Encoding.UTF8.GetString(Convert.FromBase64String(Session["guru"].ToString())));
                command.Parameters.AddWithValue("@nis", Request.QueryString["nis"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "raport");
                tabelnilaisiswa.DataSource = ds.Tables["raport"];
                tabelnilaisiswa.DataBind();
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

        protected void EventDeleteNilaiSiswa(object sender,EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string query = "DELETE FROM raport WHERE kelas=@hapuskelas AND semester=@hapussemester AND id_mapel=(SELECT id_mapel FROM pelajaran WHERE nama_mapel=@hapusmapel) AND nis=@hapusnis";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@hapuskelas", row.Cells[0].Text);
                command.Parameters.AddWithValue("@hapussemester", row.Cells[1].Text);
                command.Parameters.AddWithValue("@hapusmapel", row.Cells[2].Text);
                command.Parameters.AddWithValue("@hapusnis", Request.QueryString["nis"].ToString());
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Siswa Sukses Dihapus','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Gagal','Data Siswa Sukses Dihapus','error')", true);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                DisplayNilaiRaportSiswa();
            }
        }
    }
}