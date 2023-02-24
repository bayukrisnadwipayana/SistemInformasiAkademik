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
    public partial class EditDataSiswa : System.Web.UI.Page
    {
        Controller controller = new Controller();
        protected void GetDataByNis()
        {
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand command = new SqlCommand();
            SqlDataReader datareader;
            string sql = "SELECT * FROM siswa WHERE nis=@nis";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = Request.QueryString["nis"];
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    editnis.Text = datareader.GetString(0);
                    editnamasiswa.Text = datareader.GetString(1);
                    editalamat.Text = datareader.GetString(2);
                    editasalsekolah.Text = datareader.GetString(5);
                }
                datareader.Close();
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                koneksi.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                editkodekota.DataSource = controller.GetDataKota("SELECT * FROM kota");
                editkodekota.DataTextField = "namakota";
                editkodekota.DataValueField = "kode_kota";
                editkodekota.DataBind();
                GetDataByNis();
            }
        }

        protected void Event_Update(object sender, EventArgs e)
        {
            if (controller.UpdateDataSiswa(editnis.Text, editnamasiswa.Text, editalamat.Text, editjeniskelamin.SelectedValue, editkodekota.SelectedValue, editasalsekolah.Text, Session["user"].ToString()) > 0)
            {
                Response.Write("<script>Data Siswa Sukses Diupdate</script>");
                
            }
            else
            {
                Response.Write("<script>Data Siswa Gagal Diupdate</script>");
            }
            Response.Write("<script>document.location.href='MenuSiswa.aspx'</script>)");
        }
    }
}
