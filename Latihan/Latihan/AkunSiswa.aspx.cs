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
                    WebServiceAkademik service = new WebServiceAkademik();
                    daftar_transkip.DataSource = service.GetTranskripNilai(Session["siswa"].ToString());
                    daftar_transkip.DataBind();
                }
            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache,no-store,max-age=0,must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
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
