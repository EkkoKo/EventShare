using EventShare.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventShare.Home
{
    public partial class MyProfile : System.Web.UI.Page
    {
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            
            
            DangerAlert.Visible = false;
            DangerUsernameAlert.Visible = false;
            SuccessAlert.Visible = false;

            if (!IsPostBack)
            {
                username = Request.Cookies["Username"].Value;
                TxtEmail.Text = UserMethods.ReturnEmail(username);
                TxtPassword.Text = UserMethods.ReturnPassword(username);
                TxtUsername.Text = username;
            }
            
        }

        protected void btnChangedInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TxtEmail.Text) && !string.IsNullOrEmpty(TxtPassword.Text) && !string.IsNullOrEmpty(TxtUsername.Text))
                {
                    if (UserMethods.UsernameDoesNotExist(TxtUsername.Text) || TxtUsername.Text == username)
                    {
                        UserMethods.ChangeDetailsOfAccount(username,TxtUsername.Text, TxtPassword.Text, TxtEmail.Text);
                        Request.Cookies["Username"].Value = TxtUsername.Text;
                        SuccessAlert.Visible = true;
                    }
                    else
                    {
                        DangerUsernameAlert.Visible = true;
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

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1d);
            Response.Redirect(Request.RawUrl);
        }
    }
}