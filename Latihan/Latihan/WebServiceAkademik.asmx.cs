using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemAkademik
{
    /// <summary>
    /// Summary description for WebServiceAkademik
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceAkademik : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public int penjumlahan(int angka1, int angka2)
        {
            return angka1 + angka2;
        }

        [WebMethod]
        public DataTable GetTranskripNilai(string nis)
        {
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand command = new SqlCommand();
            string query = "SELECT * FROM raport WHERE nis=@nis ORDER BY semester ASC";
            try
            {
                koneksi.Open();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add("@nis", SqlDbType.VarChar).Value = nis;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dt.TableName = "raport";
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                koneksi.Close();
            }
            return null;
        }
    }
}
