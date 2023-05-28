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

namespace Latihan
{
    public partial class LoginSiswa : System.Web.UI.Page
    {
        siswa siswa = new siswa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["siswa"] != null)
                {
                    Response.Redirect("AkunSiswa.aspx");
                }
            }

        }

        protected void EventLoginAkunSiswa(object sender, EventArgs e)
        {
            if (siswa.GetUserAndPassword(usernamesiswa.Value, passwordsiswa.Value))
            {
                Session["siswa"] = usernamesiswa.Value;
                Response.Redirect("AkunSiswa.aspx");
            }
            else
            {
                Response.Redirect("LoginSiswa.aspx");
            }
        }
    }
}
