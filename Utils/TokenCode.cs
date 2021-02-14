using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace EventShare.Utils
{
    public class TokenCode
    {
        public static string GenerateToken()
        {
            string token = "";
            string ev = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789?!@#$%";
            //string ev = "0123456789";
            Random Rand = new Random();
            int digits = Rand.Next(4, 8);
            //int digits = Rand.Next(4, 8);
            for (int i = 0; i < digits; i++)
            {

                int numchar = Rand.Next(0, ev.Length);
                token = token + ev[numchar];

            }
            return token;
        }

        public static bool TokenExist(string token)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "Select EventCode from tblEvent Where EventCode='" + token + "'";
                OleDbDataReader reader = null;
                reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        public static string ReturnEventOwnerFromToken(string token)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            string query = "Select EventOwner from tblEvent Where EventCode='" + token + "'";
            cmd.CommandText = query;
            OleDbDataReader rd = null;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                return rd[0].ToString();
            }
            con.Close();

            return null;

        }

        public static string ReturnEventNameFromToken(string token)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            string query = "Select EventName from tblEvent Where EventCode='" + token + "'";
            cmd.CommandText = query;
            OleDbDataReader rd = null;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                return rd[0].ToString();
            }
            con.Close();

            return null;

        }

        public static string ReturnEventTimeFromToken(string token)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            string query = "Select EventTime from tblEvent Where EventCode='" + token + "'";
            cmd.CommandText = query;
            OleDbDataReader rd = null;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                return rd[0].ToString();
            }
            con.Close();

            return null;

        }

    }
}