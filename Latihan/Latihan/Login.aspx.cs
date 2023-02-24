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
    public partial class Login : System.Web.UI.Page
    {
        Controller controller = new Controller();        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Response.Redirect("MenuHome.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }
            finally
            {

            }
        }
        protected void login_click(object sender, EventArgs e)
        {
            if(controller.GetUserAndPassword(email.Text,password.Text))
            {
                Session["user"] = email.Text;
                Session.Timeout = 10;
                Response.Redirect("MenuHome.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
}
