using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Latihan;
using System.Security.Cryptography;
using System.Text;

namespace SistemAkademik
{
    public partial class LoginGuru : System.Web.UI.Page
    {
        guru guru = new guru();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["guru"] != null)
                {
                    Response.Redirect("AkunGuru.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {

            }
        }

        protected void EventLoginGuru(object sender, EventArgs e)
        {
            if (guru.GetUserAndPassword(usernameguru.Value, passwordguru.Value))
            {
                Session["guru"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(usernameguru.Value));
                Session.Timeout = 10;
                Response.Redirect("AkunGuru.aspx");
            }
            else
            {
                Response.Redirect("LoginGuru.aspx");
            }
        }
    }
}