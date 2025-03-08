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
    public partial class Pendaftaran : System.Web.UI.Page
    {
        Controller controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 10;
            if (!IsPostBack)
            {
                kodekota.DataSource = controller.GetDataKota("SELECT * FROM KOTA");
                kodekota.DataTextField = "namakota";
                kodekota.DataValueField = "kode_kota";
                kodekota.DataBind();
                
            }
        }
        //tombol daftar di klik
        protected void Event_Daftar(object sender, EventArgs e)
        {
            if (controller.InsertDataSiswa(nis.Text, namasiswa.Text, alamat.Text, jeniskelamin.SelectedValue, kodekota.SelectedValue, asalsekolah.Text, Session["user"].ToString()) > 0)
            {
                Response.Write("<script>alert('data sukses disimpan')</script>");
            }
            else
            {
                Response.Write("<script>alert('data gagal disimpan')</script>");
            }
            nis.Text = string.Empty;
            namasiswa.Text = string.Empty;
            alamat.Text = string.Empty;
            jeniskelamin.SelectedIndex = 0;
            kodekota.SelectedIndex = 0;
            asalsekolah.Text = string.Empty;
        }
    }
}