using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace SistemAkademik
{
    public partial class MasterpageGuru : System.Web.UI.MasterPage
    {
        SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlCommand command = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["guru"] != null)
                {
                    labelguru.Text = Encoding.UTF8.GetString(Convert.FromBase64String(Session["guru"].ToString()));                   
                    Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    Response.ClearHeaders();
                    Response.AddHeader("Cache-Control", "no-cache,no-store,max-age=0,must-revalidate");
                    Response.AddHeader("Pragma", "no-cache");
                }
                else
                {
                    Session.Abandon();
                    Response.Redirect("LoginGuru.aspx");
                }
            }
        }

        protected void EventLogoutAkunGuru(object sender,EventArgs e)
        {
            try
            {
                if (Session["guru"] != null)
                {
                    Session.Clear();
                    Session.RemoveAll();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                Response.Redirect("LoginGuru.aspx");
            }
        }
    }
}