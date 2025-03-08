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
            string query = "SELECT raport.kelas,raport.semester,raport.NIS,pelajaran.nama_mapel,raport.tugas,raport.kuis,raport.ujian,(raport.tugas+raport.kuis+raport.ujian)/3 AS rata_rata FROM raport INNER JOIN pelajaran ON raport.id_mapel=pelajaran.id_mapel WHERE raport.nis=@nis ORDER BY raport.semester ASC";
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
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
