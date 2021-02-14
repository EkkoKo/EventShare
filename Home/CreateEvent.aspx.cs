using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EventShare.Utils;

namespace EventShare.Home
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] == null)
            {
                Response.Redirect("Welcome.aspx");
            }
            username = Request.Cookies["Username"].Value;
            DangerAlert.Visible = false;
            DangerUsernameAlert.Visible = false;
            SuccessAlert.Visible = false;
            InvalidTimeAlert.Visible = false;
            InvalidMaxUGuestsAlert.Visible = false;
        }

        protected void CalenderEventDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date <= DateTime.Now)
            {

                e.Cell.BackColor = ColorTranslator.FromHtml("#a9a9a9");

                e.Day.IsSelectable = false;

            }
        }

        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(TxtEventName.Text) && !string.IsNullOrEmpty(TxtEventLocation.Text) && !string.IsNullOrEmpty(CalenderEventDate.SelectedDate.ToString()) && !string.IsNullOrEmpty(TxtHour.Text) && !string.IsNullOrEmpty(TxtMinutes.Text) && !string.IsNullOrEmpty(TxtMinutes.Text) && !string.IsNullOrEmpty(TxtDescription.InnerText))
                {
                    int hour, minutes;
                    if(int.TryParse(TxtHour.Text,out hour) && int.TryParse(TxtMinutes.Text, out minutes))
                    {
                        if(hour < 25 && minutes < 61)
                        {
                            int MaxGuests;
                            if (int.TryParse(TxtMaxGuests.Text, out MaxGuests))
                            {
                                string EventTime = CalenderEventDate.SelectedDate.ToString("dd/MM/yyyy") + " " + hour + ":" + minutes;
                                string EventCode = EventMethods.CreateEvent(TxtEventName.Text, TxtEventLocation.Text, EventTime, MaxGuests, username, TxtDescription.InnerText);
                                SuccessAlert.InnerHtml += "<strong> " + EventCode + "</strong>"; 
                                SuccessAlert.Visible = true;
                            }
                            else
                            {
                                InvalidMaxUGuestsAlert.Visible = true;
                            }
                        }
                        else
                        {
                            InvalidTimeAlert.Visible = true;
                        }
                    }
                    else
                    {
                        InvalidTimeAlert.Visible = true;
                    }
                }
            }
            catch
            {
                DangerAlert.Visible = true;
            }
        }
    }
}