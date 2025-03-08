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
    public partial class InputNilaiSiswa : System.Web.UI.Page
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();

        protected void DisplayDataSiswa()
        {
            string query = "SELECT nis,namasiswa FROM siswa";
            SqlDataReader datareader;
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                datareader = command.ExecuteReader();
                tabeldatasiswa.DataSource = datareader;
                tabeldatasiswa.DataBind();
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

        protected void EventRedirectInputNilai(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string nis = (item.FindControl("nissiswa") as Label).Text;
            Response.Redirect("InputNilaiSiswa.aspx?nis=" + nis);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayDataSiswa();
            }
        }
    }
}