using EventShare.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventShare.Home
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] != null)
            {
                Response.Redirect("MyProfile.aspx");
            }
            DangerAlert.Visible = false;
            DangerUsernameAlert.Visible = false;
            SuccessAlert.Visible = false;
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try { 
                if(!string.IsNullOrEmpty(TxtEmail.Text) && !string.IsNullOrEmpty(TxtPassword.Text) && !string.IsNullOrEmpty(TxtUsername.Text))
                {
                    if (UserMethods.UsernameDoesNotExist(TxtUsername.Text))
                    {
                        UserMethods.CreateAccount(TxtUsername.Text, TxtPassword.Text, TxtEmail.Text);
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
    }
}