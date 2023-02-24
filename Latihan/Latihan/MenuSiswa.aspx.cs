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

namespace Latihan
{
    public partial class MenuSiswa : System.Web.UI.Page
    {
        Controller controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                datapendaftaran.DataSource = controller.DisplayDataSiswa("SELECT siswa.nis, siswa.namasiswa, siswa.alamat, siswa.jeniskelamin, siswa.asalsekolah, kota.namakota, panitia.nama_panitia FROM siswa INNER JOIN kota ON siswa.kode_kota = kota.kode_kota INNER JOIN panitia ON siswa.id_panitia = panitia.id_panitia");
                datapendaftaran.DataBind();
            }
            text_search.Attributes.Add("onkeyup", "kata()");
        }

        /*
        protected void BindData()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            string query = "SELECT siswa.nis, siswa.namasiswa, siswa.alamat, siswa.jeniskelamin, siswa.asalsekolah, kota.namakota, panitia.nama_panitia FROM siswa INNER JOIN kota ON siswa.kode_kota = kota.kode_kota INNER JOIN panitia ON siswa.id_panitia = panitia.id_panitia";
            int val = Convert.ToInt16(hidden_value.Value);
            if (val <= 0)
                val = 0;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, val, 5, "siswa");
            datapendaftaran.DataSource = ds;
            datapendaftaran.DataBind();
            if (val <= 0)
            {
                link_preview.Visible = false;
                link_next.Visible = true;
            }

            if (val >= 5)
            {
                link_next.Visible = false;
                link_preview.Visible = true;
            }
        }
          
        protected void link_preview_click(object sender, EventArgs e)
        {
            hidden_value.Value = Convert.ToString(Convert.ToInt16(hidden_value.Value) - 5);
            BindData();
        }

        protected void link_next_click(object sender, EventArgs e)
        {
            hidden_value.Value = Convert.ToString(Convert.ToInt16(hidden_value.Value) + 5);
            BindData();
        }
        */

        protected void GetValueByNis(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string nis = (item.FindControl("nissiswa") as Label).Text;
            Response.Redirect("EditDataSiswa.aspx?nis=" + nis);
        }

        protected void DeleteValueByNis(object sender, EventArgs e)
        {
            string nis = ((sender as LinkButton).NamingContainer.FindControl("nissiswa") as Label).Text;
            if (controller.DeleteDataSiswa(nis) > 0)
            {
                Response.Write("<script>Data Siswa Sukses Dihapus</script>");
                Response.Redirect("MenuSiswa.aspx");
            }
            else
            {
                Response.Write("<script>Data Siswa Gagal Dihapus</script>");
            }
        }

        protected void SearchDataSiswa(object sender, EventArgs e)
        {
            string textsearch = text_search.Text;
            string query = "SELECT siswa.nis, siswa.namasiswa, siswa.alamat, siswa.jeniskelamin, siswa.asalsekolah, kota.namakota, panitia.nama_panitia FROM siswa INNER JOIN kota ON siswa.kode_kota = kota.kode_kota INNER JOIN panitia ON siswa.id_panitia = panitia.id_panitia WHERE nis LIKE '%" + textsearch.Trim() + "%' OR namasiswa LIKE '%" + textsearch.Trim() + "%'";
            datapendaftaran.DataSource = controller.DisplayDataSiswa(query);
            datapendaftaran.DataBind();
        }
    }
}
