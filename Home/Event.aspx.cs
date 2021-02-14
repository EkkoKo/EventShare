using EventShare.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventShare.Home
{
    public partial class Event : System.Web.UI.Page
    {
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] == null)
            {
                Response.Redirect("Welcome.aspx");
            }
            if(Request.QueryString["Code"] == null)
            {
                Response.Redirect("MyEvents.aspx");
            }
            username = Request.Cookies["Username"].Value;
            BtnLeaveEvent.Visible = false;
            NoEventsFoundAlert.Visible = false;
            string query = "SELECT tblUser.Username, tblUser.Email, tblEventUsers.Accepted FROM tblUser INNER JOIN tblEventUsers ON tblUser.UserId = tblEventUsers.Username WHERE tblEventUsers.Event="+EventMethods.EventIdNumber(Request.QueryString["Code"])+";";
            DataSet ds = UserMethods.ReturnDS(query);
            if(ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                EventName.InnerHtml = EventOwner.InnerHtml = "Event Name: <u>" + TokenCode.ReturnEventNameFromToken(Request.QueryString["Code"]) + "</u>";
                EventOwner.InnerHtml =  "Event Owner: <u>" + UserMethods.FromIdReturnUsername(TokenCode.ReturnEventOwnerFromToken(Request.QueryString["Code"])) + "</u>";
                EventTime.InnerHtml = "Event Time: <u>" + TokenCode.ReturnEventTimeFromToken(Request.QueryString["Code"]) + "</u> <hr />";
            }
            else
            {
                NoEventsFoundAlert.Visible = true;
            }
            if(EventOwner.InnerText != username && !string.IsNullOrEmpty(EventOwner.InnerText))
            {
                BtnLeaveEvent.Visible = true;
            }
        }

        protected void BtnLeaveEvent_Click(object sender, EventArgs e)
        {
            EventMethods.LeaveEvent(username, Request.QueryString["Code"]);
            Response.Redirect("MyEvents.aspx");
        }
    }
}