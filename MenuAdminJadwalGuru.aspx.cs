using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Latihan;

namespace SistemAkademik
{
    public partial class MenuAdminJadwalGuru : System.Web.UI.Page
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();

        protected void GenerateNamaGuru()
        {
            string query = "SELECT nip,namaguru FROM guru";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "guru");
                namaguru.DataSource = ds.Tables["guru"];
                namaguru.DataValueField = "nip";
                namaguru.DataTextField = "namaguru";
                namaguru.DataBind();
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

        protected void GenerateNamaPelajaran()
        {
            string query = "SELECT id_mapel,nama_mapel FROM pelajaran";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "pelajaran");
                namamapel.DataSource = ds.Tables["pelajaran"];
                namamapel.DataValueField = "id_mapel";
                namamapel.DataTextField = "nama_mapel";
                namamapel.DataBind();
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
        protected void FungsiEditNamaMapel()
        {
            Controller controler = new Controller();
            editnamamapel.DataSource = controler.DisplayDataTable("SELECT * FROM pelajaran");
            editnamamapel.DataValueField = "id_mapel";
            editnamamapel.DataTextField = "nama_mapel";
            editnamamapel.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateNamaGuru();
                GenerateNamaPelajaran();
                DisplayJadwalGuruGridview();
            }
        }

        protected void EventSimpanJadwalGuru(object sender, EventArgs e)
        {
            string query = "INSERT INTO jadwalkelas VALUES(@id_mapel,@nip,@kelas,@hari)";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@id_mapel", namamapel.SelectedValue.ToString());
                command.Parameters.AddWithValue("@nip", namaguru.SelectedValue.ToString());
                command.Parameters.AddWithValue("@kelas", kelas.SelectedValue.ToString());
                command.Parameters.AddWithValue("@hari", hari.SelectedValue.ToString());
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Jadwal Sukses Disimpan','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Gagal','Data Jadwal Gagal Disimpan','error')", true);
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
        protected void DisplayJadwalGuruGridview()
        {
            string query = "SELECT guru.namaguru, pelajaran.nama_mapel,jadwalkelas.kelas,jadwalkelas.hari FROM jadwalkelas INNER JOIN GURU ON guru.nip=jadwalkelas.nip INNER JOIN pelajaran ON pelajaran.id_mapel=jadwalkelas.id_mapel ORDER BY jadwalkelas.kelas ASC";
            try
            {
                koneksi.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "jadwalkelas");
                tabeljadwalguru.DataSource = ds.Tables["jadwalkelas"];
                tabeljadwalguru.DataBind();
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

        protected void EventEditListJadwalGuru(object sender, EventArgs e)
        {
            FungsiEditNamaMapel();
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            editnamamapel.Items.FindByText(row.Cells[1].Text).Selected = true;
            editkelas.Text = row.Cells[2].Text;          
            string query = "SELECT jadwalkelas.nip FROM jadwalkelas INNER JOIN guru ON jadwalkelas.nip=guru.nip WHERE guru.namaguru=@namaguru";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@namaguru", row.Cells[0].Text);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    editnipguru.Text = datareader["nip"].ToString();
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
            this.popupeditjadwalguru.Show();
        }

        protected void UpdateDataJadwalKelas(object sender, EventArgs e)
        {
            string query = "UPDATE jadwalkelas SET hari=@hari WHERE id_mapel=@id_mapel AND nip=@nip AND kelas=@kelas";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@kelas", editkelas.Text);
                command.Parameters.AddWithValue("@hari", editnamahari.SelectedValue.ToString());
                command.Parameters.AddWithValue("@id_mapel", editnamamapel.SelectedValue.ToString());
                command.Parameters.AddWithValue("@nip", editnipguru.Text);
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    Response.Write("<script>alert('Data Sukses Diupdate')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data Gagal Diupdate')</script>");
                }
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

        protected void EventDeleteListJadwalGuru(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string query = "DELETE FROM jadwalkelas WHERE nip=(SELECT DISTINCT guru.nip FROM guru INNER JOIN jadwalkelas ON guru.nip=jadwalkelas.nip WHERE guru.namaguru=@hapusnipguru) AND id_mapel=(SELECT DISTINCT jadwalkelas.id_mapel FROM jadwalkelas INNER JOIN pelajaran ON jadwalkelas.id_mapel=pelajaran.id_mapel WHERE nama_mapel=@hapusidmapel) AND jadwalkelas.kelas=@hapuskelas AND jadwalkelas.hari=@hapushari";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@hapusnipguru", row.Cells[0].Text);
                command.Parameters.AddWithValue("@hapusidmapel", row.Cells[1].Text);
                command.Parameters.AddWithValue("@hapuskelas", row.Cells[2].Text);
                command.Parameters.AddWithValue("@hapushari", row.Cells[3].Text);
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Jadwal Sukses Dihapus','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Gagal','Data Jadwal Sukses Dihapus','error')", true);
                }
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