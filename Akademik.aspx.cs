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
            this.modalpopuphapus.Show();
        }

        protected void EventModalUpdateRaportKelas1Semester1(object sender, EventArgs e)
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
                    textupdatekelas.Text = (item.FindControl("labelkelas") as Label).Text;
                    textupdatesemester.Text = (item.FindControl("labelsemester") as Label).Text;
                    textupdatenis.Text = (item.FindControl("labelnis") as Label).Text;
                    textupdatepelajaran.Text = datareader["id_mapel"].ToString();
                    textupdatetugas.Text = (item.FindControl("labeltugas") as Label).Text;
                    textupdatekuis.Text = (item.FindControl("labelkuis") as Label).Text;
                    textupdateujian.Text = (item.FindControl("labelujian") as Label).Text;
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
            this.modalpopupupdate.Show();
        }

        protected void EventUpdateRaportKelas1Semester1(object sender, EventArgs e)
        {
            string query = "UPDATE raport SET tugas=@tugas,kuis=@kuis,ujian=@ujian WHERE kelas=@kelas AND semester=@semester AND nis=@nis AND id_mapel=@id_mapel";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@id_mapel", textupdatepelajaran.Text);
                command.Parameters.AddWithValue("@tugas", textupdatetugas.Text);
                command.Parameters.AddWithValue("@kuis", textupdatekuis.Text);
                command.Parameters.AddWithValue("@ujian", textupdateujian.Text);
                command.Parameters.AddWithValue("@kelas", textupdatekelas.Text);
                command.Parameters.AddWithValue("@semester", textupdatesemester.Text);
                command.Parameters.AddWithValue("@nis", textupdatenis.Text);
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Update','Data Sukses Terupdate','success')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                koneksi.Close();
                DisplayRaportKelas1Semester1("1", Request.Url.AbsoluteUri.Split('=')[1]);
            }
        }

        protected void EventHapusRaportKelas1Semester1(object sender, EventArgs e)
        {
            if (controller.EventHapusRaportKelas1Semester1(texthapuskelas1.Text, texthapussemester1.Text, texthapusnis.Text, texthapuspelajaran1.Text) > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Hapus','Data Sukses Dihapus','success')", true);
                DisplayRaportKelas1Semester1("1", Request.QueryString["nis"]);
            }
        }

        protected void EventDelete22(object sender, EventArgs e)
        {
            string query = "DELETE FROM raport FROM raport INNER JOIN pelajaran ON raport.id_mapel = pelajaran.id_mapel WHERE raport.kelas = @kelas22 AND raport.semester = @semester22 AND raport.nis = @nis22 AND pelajaran.nama_mapel = @mapel22";
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            
            try
            {
                koneksi.Open();
                command.Connection=koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@kelas22", SqlDbType.VarChar).Value = row.Cells[0].Text;
                command.Parameters.Add("@semester22", SqlDbType.VarChar).Value = row.Cells[1].Text;
                command.Parameters.Add("@nis22", SqlDbType.VarChar).Value = row.Cells[2].Text;
                command.Parameters.Add("@mapel22", SqlDbType.VarChar).Value = row.Cells[4].Text;
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

        protected void OpenModalPopupUpdate12(object sender, EventArgs e)
        {
            string query = "SELECT raport.id_mapel FROM raport INNER JOIN pelajaran ON raport.id_mapel=pelajaran.id_mapel WHERE pelajaran.nama_mapel=@namamapel";
            SqlDataReader datareader;
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@namamapel", SqlDbType.VarChar).Value = row.Cells[4].Text;
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    textkelas12.Text = row.Cells[0].Text;
                    textsemester12.Text = row.Cells[1].Text;
                    textnis12.Text = row.Cells[2].Text;
                    textpelajaran12.Text = datareader[0].ToString();
                    texttugas12.Text = row.Cells[5].Text;
                    textkuis12.Text = row.Cells[6].Text;
                    textujian12.Text = row.Cells[7].Text;
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
            this.modalgridviewupdate12.Show();
        }

        protected void EventUpdateRaportKelas1Semester2(object sender, EventArgs e)
        {
            string query = "UPDATE raport SET tugas=@tugas,kuis=@kuis,ujian=@ujian WHERE kelas=@kelas AND semester=@semester AND nis=@nis AND id_mapel=@id_mapel";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.AddWithValue("@tugas", texttugas12.Text);
                command.Parameters.AddWithValue("@kuis", textkuis12.Text);
                command.Parameters.AddWithValue("@ujian", textujian12.Text);
                command.Parameters.AddWithValue("@kelas", textkelas12.Text);
                command.Parameters.AddWithValue("@semester", textsemester12.Text);
                command.Parameters.AddWithValue("@nis", textnis12.Text);
                command.Parameters.AddWithValue("@id_mapel", textpelajaran12.Text);
                int record = command.ExecuteNonQuery();
                if (record > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire('Sukses','Data Sukses Terupdate','success')", true);
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
