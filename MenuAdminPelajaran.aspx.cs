using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemAkademik
{
    public partial class MenuAdminPelajaran : System.Web.UI.Page
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();
        string idmapel = "P";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateIDMapel();
                DisplayMataPelajaranGridview();
            }
        }

        //membuat id mapel otomatis
        protected void GenerateIDMapel()
        {
            string query = "SELECT COUNT(id_mapel) FROM pelajaran";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                int i = (int)command.ExecuteScalar();
                i++;
                id_mapel.Text = idmapel + i.ToString();
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

        protected void DisplayMataPelajaranGridview()
        {
            string query = "SELECT * FROM pelajaran";
            SqlDataAdapter dataadapter;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                dataadapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "pelajaran");
                datamatapelajaran.DataSource = ds.Tables["pelajaran"];
                datamatapelajaran.DataBind();
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

        //menambah mata pelajaran
        protected void EventSimpanMataPelajaran(object sender,EventArgs e)
        {
            string query = "INSERT INTO pelajaran VALUES(@idmapel,@namamapel)";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@idmapel", id_mapel.Text);
                command.Parameters.AddWithValue("@namamapel", namamapel.Text);
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Mata Pelajaran Sukses Disimpan','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Gagal','Data Mata Pelajaran Gagal Disimpan','error')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                DisplayMataPelajaranGridview();
            }
        }

        //hapus mata pelajaran
        protected void EventHapusMataPelajaran(object sender, GridViewDeleteEventArgs e)
        {
            string query = "DELETE FROM pelajaran WHERE id_mapel=@id_mapel";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@id_mapel", datamatapelajaran.DataKeys[e.RowIndex].Value.ToString());
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Sukses Disimpan','success')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Sukses Disimpan','success')", true);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                DisplayMataPelajaranGridview();
            }
        }

        //penomeran halaman
        protected void EventPenomeranHalaman(object sender, GridViewPageEventArgs e)
        {
            datamatapelajaran.PageIndex = e.NewPageIndex;
            DisplayMataPelajaranGridview();
        }
    }
}