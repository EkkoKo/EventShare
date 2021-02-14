using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace EventShare.Utils
{
    public class EventMethods
    {
        public static string CreateEvent(string EventName, string EventLocation, string EventTime, int MaxGuests, string username, string desc)
        {
            string EventCode = TokenCode.GenerateToken();
            while (TokenCode.TokenExist(EventCode))
            {
                EventCode = TokenCode.GenerateToken();
            }
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "Insert into tblEvent (EventName,EventLocation,EventTime, EventOwner, MaxGuests, Canceled,EventCode,EventDescription) VALUES('" + EventName + "','" + EventLocation + "','" + EventTime + "', "+UserMethods.IdNumber(username)+", "+MaxGuests+",'No','"+EventCode+"','"+desc+"');";
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            return EventCode;
        }

        public static bool CheckIfEventExist(string EventCode)
        {
            DBCon Conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(Conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader read = null;
            string query = "Select EventCode From tblEvent Where EventCode='" + EventCode + "';";
            cmd.CommandText = query;
            con.Open();
            cmd.Connection = con;
            read = cmd.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count++;
            }
            if (count == 0)
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }



        public static bool JoinEvent(string username, string EventCode)
        {
            if(EventParticipants(EventCode) < EventMaxParticipants(EventCode))
            {
                DBCon conpath = new DBCon();
                OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                string query = "Insert into tblEventUsers (Username,Event,Accepted) VALUES(" + UserMethods.IdNumber(username) + "," + EventIdNumber(EventCode) + ",'Yes');";
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            return false;
            
        }


        public static int EventParticipants(string EventCode)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "SELECT Count(tblEventUsers.Id), tblEvent.EventId FROM tblEvent INNER JOIN tblEventUsers ON tblEvent.EventId = tblEventUsers.Event GROUP BY tblEvent.EventId HAVING tblEvent.EventId="+EventIdNumber(EventCode)+";";
            cmd.CommandText = query;
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            if (!rd.HasRows)
            {
                return 0;
            }
            return int.Parse(rd[0].ToString());
        }

        public static int EventMaxParticipants(string EventCode)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "SELECT MaxGuests FROM tblEvent WHERE EventCode='"+ EventCode +"';";
            cmd.CommandText = query;
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            return int.Parse(rd[0].ToString());
        }
        public static string EventIdNumber(string EventCode)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "Select EventId From tblEvent Where EventCode='" + EventCode + "';";
            cmd.CommandText = query;
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            return rd[0].ToString();
        }

        public static bool CheckIfUserCreatedTheEvent(string username, string EventCode)
        {
            DBCon Conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(Conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader read = null;
            string query = "Select EventCode From tblEvent Where EventCode='" + EventCode + "' AND EventOwner="+UserMethods.IdNumber(username)+";";
            cmd.CommandText = query;
            con.Open();
            cmd.Connection = con;
            read = cmd.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count++;
            }
            if (count == 0)
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }

        public static bool AlreadyJoinedTheEvent(string username, string EventCode)
        {
            DBCon Conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(Conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader read = null;
            string query = "Select * From tblEventUsers Where Event=" + EventIdNumber(EventCode) + " AND Username=" + UserMethods.IdNumber(username) + ";";
            cmd.CommandText = query;
            con.Open();
            cmd.Connection = con;
            read = cmd.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count++;
            }
            if (count == 0)
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }

        public static void RemoveEvent(string username, string eventCode)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "Delete FROM tblEvent Where EventOwner="+UserMethods.IdNumber(username)+" AND EventCode='"+eventCode+"';";
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void LeaveEvent(string username, string eventCode)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "DELETE FROM tblEventUsers Where Username=" + UserMethods.IdNumber(username) + " AND Event=" + EventIdNumber(eventCode) + ";";
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}