using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Latihan;
using SistemAkademik.localhost;
using System.IO;
using System.Text;

namespace Latihan
{
    public partial class AkunSiswa : System.Web.UI.Page
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();
        Controller controller = new Controller();
        protected void InformasiAkun()
        {
            string query = "SELECT * FROM siswa WHERE nis=@nis";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = Session["siswa"].ToString();
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    labelnis.Text = datareader["nis"].ToString();
                    labelnamasiswa.Text = datareader["namasiswa"].ToString();
                    labelalamat.Text = datareader["alamat"].ToString();
                    labeljeniskelamin.Text = datareader["jeniskelamin"].ToString();
                    inputnis.Text = datareader["nis"].ToString();
                    inputnama.Text = datareader["namasiswa"].ToString();
                    inputalamat.Text = datareader["alamat"].ToString();
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["siswa"] == null)
                {
                    Response.Write("<script>alert('Your Session Has Expired');window.location.href='LoginSiswa.aspx'</script>");
                }
                else
                {
                    labelnama.Text = controller.GetNamaAkun(Session["siswa"].ToString());
                    InformasiAkun();
                    Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    Response.ClearHeaders();
                    Response.AddHeader("Cache-Control", "no-cache,no-store,max-age=0,must-revalidate");
                    Response.AddHeader("Pragma", "no-cache");
                    WebServiceAkademik wsa = new WebServiceAkademik();
                    daftar_transkip.DataSource = wsa.GetTranskripNilai(Session["siswa"].ToString());
                    daftar_transkip.DataBind();
                    DisplaySuratSiswa(Session["siswa"].ToString());
                }
            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache,no-store,max-age=0,must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
        }

        protected void DisplaySuratSiswa(string nis)
        {
            string query = "SELECT surat.nis,siswa.namasiswa,siswa.alamat,surat.keterangan,surat.tgl_upload FROM surat INNER JOIN siswa ON siswa.nis=surat.nis WHERE surat.nis=@nis1";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@nis1", nis);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "surat");
                gridviewsurat.DataSource = ds.Tables["surat"];
                gridviewsurat.DataBind();
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
        protected void KirimSurat(object sender, EventArgs e)
        {
            string query = "INSERT INTO surat VALUES(@nis,@surat,@tglupload,@content,@namafile,@keterangan)";
            string namafile = uploadfilesurat.PostedFile.FileName;
            string jenisfile = uploadfilesurat.PostedFile.ContentType;
            Stream strimfile = uploadfilesurat.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(strimfile);
            byte[] surat = br.ReadBytes((Int32)strimfile.Length);
            try
            {
                if (uploadfilesurat.HasFile)
                {
                    string ekstensifile = Path.GetExtension(uploadfilesurat.FileName);
                    if (ekstensifile.ToLower() == ".pdf" || ekstensifile.ToLower() == ".jpeg" || ekstensifile.ToLower() == ".jpg" || ekstensifile.ToLower() == ".png")
                    {
                        koneksi.Open();
                        command.Connection = koneksi;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        command.Parameters.Add("@nis", SqlDbType.VarChar).Value = inputnis.Text;
                        command.Parameters.Add("@surat", SqlDbType.VarBinary).Value = surat;
                        command.Parameters.Add("@tglupload", SqlDbType.VarChar).Value = Request.Form["tanggalupload"];
                        command.Parameters.Add("@content", SqlDbType.VarChar).Value = jenisfile;
                        command.Parameters.Add("@namafile", SqlDbType.VarChar).Value = namafile;
                        command.Parameters.Add("@keterangan", SqlDbType.VarChar).Value = keterangansurat.SelectedValue.ToString();
                        int record = command.ExecuteNonQuery();
                        if (record > 0)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Surat Sukses Terkirim','success')", true);
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Gagal','Surat Gagal Terkirim','error')", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Gagal','Upload File Dalam Format PDF, JPEG, JPG, PNG','warning')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                DisplaySuratSiswa(Session["siswa"].ToString());
            }
        }

        protected void EventHapusSurat(object sender, EventArgs e)
        {
            string query = "DELETE FROM surat WHERE nis=@nis AND tgl_upload=@tgl_upload AND keterangan=@keterangansurat";
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = row.Cells[0].Text;
                command.Parameters.Add("@tgl_upload", SqlDbType.VarChar).Value = row.Cells[4].Text;
                command.Parameters.Add("@keterangansurat", SqlDbType.VarChar).Value = row.Cells[3].Text;
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Surat Sukses Dihapus','success')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                DisplaySuratSiswa(Session["siswa"].ToString());
            }
        }

        protected void EventDownloadSurat(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            byte[] bytes;
            string namafile, jenisfile;
            using (koneksi)
            {
                using (command)
                {
                    koneksi.Open();
                    command.Connection = koneksi;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT surat,content_type,nama_file FROM surat WHERE nis=@nis AND tgl_upload=@tgl_upload AND keterangan=@keterangan";
                    command.Parameters.Add("@nis", SqlDbType.VarChar).Value = row.Cells[0].Text;
                    command.Parameters.Add("@tgl_upload", SqlDbType.VarChar).Value = row.Cells[4].Text;
                    command.Parameters.Add("@keterangan", SqlDbType.VarChar).Value = row.Cells[3].Text;
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        datareader.Read();
                        bytes = (byte[])datareader["surat"];
                        jenisfile = datareader["content_type"].ToString();
                        namafile = datareader["nama_file"].ToString();
                    }
                    koneksi.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = jenisfile;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + namafile);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void EventLogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session["siswa"] = null;
            Session.RemoveAll();
            Response.Redirect("LoginSiswa.aspx");
        }
    }
}
