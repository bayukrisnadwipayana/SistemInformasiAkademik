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
    public partial class Pembayaran : System.Web.UI.Page
    {
        Controller controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                datapembayaran.DataSource = controller.DisplayDataTable("SELECT siswa.nis, siswa.namasiswa, siswa.alamat, siswa.jeniskelamin, status.kode_status FROM siswa INNER JOIN kota ON siswa.kode_kota = kota.kode_kota INNER JOIN panitia ON siswa.id_panitia = panitia.id_panitia INNER JOIN pembayaran ON pembayaran.nis=siswa.nis INNER JOIN status ON status.kode_status=pembayaran.kode_status");
                //datapembayaran.DataSource = controller.DisplayDataSiswa("SELECT*FROM siswa OUTER JOIN pembayaran ON siswa.nis=pembayaran.nis");
                datapembayaran.DataBind();
            }
        }

        protected void status_event(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as CheckBox).NamingContainer as RepeaterItem;
            CheckBox cek = item.FindControl("checkbox_status") as CheckBox;
            Label status = item.FindControl("statusbayar") as Label;
            Label nis = item.FindControl("nissiswa") as Label;
            if (cek.Checked)
            {
                string query = "INSERT INTO pembayaran VALUES(@nis,@kodestatus)";
                SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    koneksi.Open();
                    command.Connection = koneksi;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.Add("@nis", SqlDbType.VarChar).Value = nis.Text;
                    command.Parameters.Add("@kodestatus", SqlDbType.VarChar).Value = "1";
                    command.ExecuteNonQuery();
                    status.Text = "Lunas";
                    cek.Enabled = false;
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
            else
            {
                status.Text = "Tunggakan";
            }
        }
    }
}
