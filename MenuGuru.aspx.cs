﻿using System;
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
using System.Web.Services;
using System.Data.SqlClient;
using Latihan;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Latihan
{
    public partial class MenuGuru : System.Web.UI.Page
    {
        Controller controller = new Controller();
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();
        string id="NIP";
        double tahun = Convert.ToDouble(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tabelguru.DataSource = controller.DisplayDataTable("SELECT nip,namaguru,nama_mapel FROM guru INNER JOIN pelajaran ON guru.id_mapel=pelajaran.id_mapel");
                tabelguru.DataBind();
                Load_DataMapel();
                AutoGenerateNIPGuru();
            }
        }

        protected void AutoGenerateNIPGuru()
        {
            string query = "SELECT COUNT(nip) FROM guru";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                int i = Convert.ToInt32(command.ExecuteScalar());
                i++;
                nipguru.Text = id + tahun + i.ToString();
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
        protected void Load_DataMapel()
        {
            dropdownmapel.DataSource = controller.DisplayDataTable("SELECT * FROM pelajaran");
            dropdownmapel.DataTextField = "nama_mapel";
            dropdownmapel.DataValueField = "id_mapel";
            dropdownmapel.DataBind();
        }

        protected void FormEdit_DropdownEditMapel()
        {
            dropdowneditmapel.DataSource = controller.DisplayDataTable("SELECT * FROM pelajaran");
            dropdowneditmapel.DataTextField = "nama_mapel";
            dropdowneditmapel.DataValueField = "id_mapel";
            dropdowneditmapel.DataBind();
        }

        protected static string CreateMD5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] getinputbytes = Encoding.ASCII.GetBytes(input);
            byte[] hashbytes = md5.ComputeHash(getinputbytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashbytes.Length; i++)
            {
                sb.Append(hashbytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        [WebMethod]
        public static void CheckPrimaryKeySiswa(string input)
        {

        }

        [WebMethod]
        public static void SaveDataGuru(string nip, string nama, string md5password, string idmapel)
        {
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand command = new SqlCommand();
            string query = "INSERT INTO guru VALUES(@nip,@nama,@password,@idmapel)";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nip", SqlDbType.VarChar).Value = nip;
                command.Parameters.Add("@nama", SqlDbType.VarChar).Value = nama;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = CreateMD5(md5password);
                command.Parameters.Add("@idmapel", SqlDbType.VarChar).Value = idmapel;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
        }

        [WebMethod]
        public static string DisplayDataGuru()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            string query = "SELECT * FROM SELECT nip,namaguru,nama_mapel FROM guru INNER JOIN pelajaran ON guru.id_mapel=pelajaran.id_mapel";
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dataadapter.Fill(ds);
                return ds.GetXml();
            }
            catch(Exception e)
            {
                e.ToString();
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        protected string GetPasswordGuru(string nip)
        {
            SqlDataReader datareader;
            string query = "SELECT password FROM guru WHERE nip=@nip";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nip", SqlDbType.VarChar).Value = nip;
                datareader = command.ExecuteReader();
                while(datareader.Read())
                {
                    if (datareader.HasRows)
                    {
                        return datareader["password"].ToString();
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
            }
            return null;
        }

        protected void EditDataGuru(object sender, EventArgs e)
        {
            FormEdit_DropdownEditMapel();
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            editnipguru.Text = row.Cells[0].Text;
            editnamaguru.Text = row.Cells[1].Text;
            dropdowneditmapel.Items.FindByText(row.Cells[2].Text).Selected = true;
            //editpassword.Text = GetPasswordGuru(row.Cells[0].Text);
            this.PopupEdit.Show();
        }

        protected void UpdateDataGuru(object sender, EventArgs e)
        {
            string query = "UPDATE guru SET namaguru=@nama,id_mapel=@id WHERE nip=@nip";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nip", SqlDbType.VarChar).Value = editnipguru.Text;
                command.Parameters.Add("@nama", SqlDbType.VarChar).Value = editnamaguru.Text;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = dropdowneditmapel.SelectedValue;
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Update','Data Guru Sukses Diupdate','success')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                tabelguru.DataSource = controller.DisplayDataTable("SELECT nip,namaguru,nama_mapel FROM guru INNER JOIN pelajaran ON guru.id_mapel=pelajaran.id_mapel");
                tabelguru.DataBind();
            }
        }

        protected void EventHapusGuru(object sender, GridViewDeleteEventArgs e)
        {
            string query = "DELETE FROM guru WHERE nip=@nip";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nip", SqlDbType.VarChar).Value = (tabelguru.DataKeys[e.RowIndex].Value).ToString();
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    tabelguru.DataSource = controller.DisplayDataTable("SELECT nip,namaguru,nama_mapel FROM guru INNER JOIN pelajaran ON guru.id_mapel=pelajaran.id_mapel");
                    tabelguru.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                tabelguru.DataSource = controller.DisplayDataTable("SELECT nip,namaguru,nama_mapel FROM guru INNER JOIN pelajaran ON guru.id_mapel=pelajaran.id_mapel");
                tabelguru.DataBind();
            }
        }
    }
}
