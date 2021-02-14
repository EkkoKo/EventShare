using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventShare.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelNotLoggedIn.Visible = false;
            PanelLoggedIn.Visible = false;
            if (Request.Cookies["Username"] == null)
            {

                PanelNotLoggedIn.Visible = true;
            }
            else
            {
                PanelLoggedIn.Visible = true;

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1d);
            Response.Redirect(Request.RawUrl);
        }
    }
}