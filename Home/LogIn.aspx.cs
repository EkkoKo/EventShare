using EventShare.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventShare.Home
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Request.Cookies["Username"] != null)
            {
                Response.Redirect("MyProfile.aspx");
            }

            DangerAlert.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try { 
            if(!string.IsNullOrEmpty(TxtUsername.Text) && !string.IsNullOrEmpty(TxtPassword.Text))
            {
                    if (UserMethods.AccountExist(TxtUsername.Text, TxtPassword.Text))
                    {
                       HttpCookie cookie = new HttpCookie("Username");
                       cookie.Value = TxtUsername.Text;
                       Response.Cookies.Add(cookie);
                       Response.Redirect("MyProfile.aspx");
                    }
                    else
                    {
                        DangerAlert.Visible = true;
                    }
                }
                else
                {
                    DangerAlert.Visible = true;
                }
            }
            catch
            {
                DangerAlert.Visible = true;
            }

        }
    }
}