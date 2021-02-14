using EventShare.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EventShare.Home
{
    public partial class MyEvents : System.Web.UI.Page
    {
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] == null)
            {
                Response.Redirect("Welcome.aspx");
            }
            username = Request.Cookies["Username"].Value;
            NoEventsFoundAlert.Visible = false;
            if (!IsPostBack)
            {
                string query = "Select EventName, EventLocation, EventTime, EventDescription, MaxGuests, Canceled, EventCode From tblEvent Where EventOwner=" + UserMethods.IdNumber(username) + ";";
                ChangeGrid(query, false);
            }
            
        }

        protected void ShowMyEventsBtn_Click(object sender, EventArgs e)
        {
            ShowJoinedEventsBtn.BackColor = Color.White;
            ShowJoinedEventsBtn.ForeColor = ColorTranslator.FromHtml("#5e72e4");
            ShowMyEventsBtn.BackColor = ColorTranslator.FromHtml("#5e72e4");
            ShowMyEventsBtn.ForeColor = Color.White;
            string query = "Select EventName, EventLocation, EventTime, EventDescription, MaxGuests, Canceled, EventCode From tblEvent Where EventOwner=" + UserMethods.IdNumber(username) + ";";
            ChangeGrid(query,false);
        }

        protected void ShowJoinedEventsBtn_Click(object sender, EventArgs e)
        {
            ShowJoinedEventsBtn.BackColor = ColorTranslator.FromHtml("#5e72e4");
            ShowJoinedEventsBtn.ForeColor = Color.White;
            ShowMyEventsBtn.BackColor = Color.White;
            ShowMyEventsBtn.ForeColor = ColorTranslator.FromHtml("#5e72e4");
            string query = "SELECT tblEvent.EventName, tblEvent.EventLocation, tblEvent.EventTime, tblEvent.EventDescription, tblEvent.MaxGuests, tblEvent.Canceled, tblEvent.EventCode, tblEventUsers.Username FROM tblEvent INNER JOIN tblEventUsers ON tblEvent.EventId = tblEventUsers.Event WHERE tblEventUsers.Username=" + UserMethods.IdNumber(username) + ";";
            ChangeGrid(query, true);
        }

        protected void ChangeGrid(string query, bool NotYours)
        {
            DataSet ds = UserMethods.ReturnDS(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridEvents.DataSource = ds;
                GridEvents.DataBind();
                if (NotYours)
                {
                    
                    for (int i = 0; i < GridEvents.Rows.Count; i++)
                    {
                        GridEvents.Rows[i].Cells[9].Text = UserMethods.FromIdReturnUsername(TokenCode.ReturnEventOwnerFromToken(GridEvents.Rows[i].Cells[8].Text));
                    }
                    GridEvents.HeaderRow.Cells[0].Visible = false;
                    for (int i = 0; i < GridEvents.Rows.Count; i++)
                    {
                        GridEvents.Rows[i].Cells[0].Visible = false;
                    }

                }
                GridEvents.Visible = true;
                NoEventsFoundAlert.Visible = false;
            }
            else
            {
                GridEvents.Visible = false;
                NoEventsFoundAlert.Visible = true;
            }
        }

        protected void GridEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Delete")
            {
                
                EventMethods.RemoveEvent(username, GridEvents.Rows[index].Cells[8].Text);
                string query = "Select EventName, EventLocation, EventTime, EventDescription, MaxGuests, Canceled, EventCode From tblEvent Where EventOwner=" + UserMethods.IdNumber(username) + ";";
                ChangeGrid(query, false);
                Response.Redirect(Request.RawUrl);

            }
            if(e.CommandName == "Select")
            {
                Response.Redirect("Event.aspx?Code=" + GridEvents.Rows[index].Cells[8].Text);
            }
            
        }
    }
}