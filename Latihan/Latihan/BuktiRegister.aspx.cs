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

namespace Latihan
{
    public partial class BuktiRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["nis"] != null && Session["siswa"] != null)
                {
                    label1.Text = Request.QueryString["nis"];
                }
                else
                {
                    Response.Redirect("LoginSiswa.aspx");
                }
            }
        }
    }
}
