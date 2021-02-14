using EventShare.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventShare.Home
{
    public partial class JoinEvent : System.Web.UI.Page
    {
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] == null)
            {
                Response.Redirect("Welcome.aspx");
            }
            username = Request.Cookies["Username"].Value;
            DangerAlert.Visible = false;
            JoinDangerAlert.Visible = false;
            JoinedSuccessAlert.Visible = false;
            AlreayJoinedAlert.Visible = false;
            EventIsFullAlert.Visible = false;
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEventCode.Text))
            {
                if (EventMethods.CheckIfEventExist(TxtEventCode.Text))
                {
                    if(!EventMethods.CheckIfUserCreatedTheEvent(username, TxtEventCode.Text))
                    {
                        if(!EventMethods.AlreadyJoinedTheEvent(username, TxtEventCode.Text))
                        {
                            string query = "SELECT tblEvent.EventName, tblEvent.EventLocation, tblEvent.EventTime, tblEvent.EventDescription, tblUser.Username FROM tblUser INNER JOIN tblEvent ON tblUser.UserId = tblEvent.EventOwner WHERE tblEvent.EventCode='" + TxtEventCode.Text + "';";
                            DataSet ds = UserMethods.ReturnDS(query);
                            ModalEventName.InnerText = ds.Tables[0].Rows[0][0].ToString();
                            ModalEventTime.InnerText = "Event Time: " + ds.Tables[0].Rows[0][2].ToString();
                            ModalEventLocation.InnerText = "Event Location: " + ds.Tables[0].Rows[0][1].ToString();
                            ModalEventDescription.InnerText = "Event Description: " + ds.Tables[0].Rows[0][3].ToString();
                            ModalEventOwner.InnerText = "Event Owner: " + ds.Tables[0].Rows[0][4].ToString();
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "eventDetailsModal", "$('#eventDetailsModal').modal('show');", true);
                            
                        }
                        else
                        {
                            AlreayJoinedAlert.Visible = true;
                        }
                    }
                    else
                    {
                        JoinDangerAlert.Visible = true;
                    }
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

        protected void BtnJoinEvent_Click(object sender, EventArgs e)
        {
            bool canJoin = EventMethods.JoinEvent(username, TxtEventCode.Text);
            if (canJoin)
            {
                JoinedSuccessAlert.Visible = true;
                return;
            }
            EventIsFullAlert.Visible = true;
        }
    }
}