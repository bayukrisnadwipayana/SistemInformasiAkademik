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
using Latihan;
using System.Data.SqlClient;

namespace Latihan
{
    public partial class MenuUtama1 : System.Web.UI.MasterPage
    {
        Controller controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    label_session.Value = controller.GetNamaPanitia(Session["user"].ToString());
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
                    Response.Redirect("Login.aspx");
                }
            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache,no-store,max-age=0,must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
        }

        protected void Logout_Event(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Session.Clear();
                    Session.RemoveAll();                
                }
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}