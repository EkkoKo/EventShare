using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace EventShare.Utils
{
    public class UserMethods
    {
        public static bool UsernameDoesNotExist(string Username)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "Select Username From tblUser Where Username='" + Username + "'";
            cmd.CommandText = query;
            cmd.Connection = con;
            OleDbDataReader rd = null;
            rd = cmd.ExecuteReader();
            int count = 0;
            while (rd.Read())
            {
                count++;
            }
            if (count == 0)
            {
                return true;
            }

            return false;
        }


        public static bool AccountExist(string Username, string Password)
        {
            DBCon Conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(Conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader read = null;
            string query = "Select Username From tblUser Where Username='" + Username + "' AND Pwd='" + Password + "'";
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
                return false;
            }
            return true;
        }

        public static void CreateAccount(string Username, string Password, string Email)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "Insert into tblUser (Username,Pwd,Email) VALUES('"+ Username+"','"+Password+"','"+Email+"');";
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }

        public static void ChangeDetailsOfAccount(string ogUsername,string Username, string Password, string Email)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "UPDATE tblUser SET Username='"+Username+"', Pwd='"+Password+"', Email='"+Email+"' Where Username='"+ogUsername+"';";
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        
        public static string ReturnEmail(string username)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            string query = "Select Email From tblUser Where Username='" + username + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            string Email = rd[0].ToString();
            return Email;
        }

        public static string ReturnPassword(string username)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            string query = "Select Pwd From tblUser Where Username='" + username + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            string Password = rd[0].ToString();
            return Password;
        }

        public static string IdNumber(string username)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "Select UserId From tblUser Where Username='"+username+"';";
            cmd.CommandText = query;
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            return rd[0].ToString();
        }

        public static DataSet ReturnDS(string query)
        {
            DBCon conpath = new DBCon();
            DataSet ds = new DataSet();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
            Da.Fill(ds);
            return ds;
        }

        public static string FromIdReturnUsername(string id)
        {
            DBCon conpath = new DBCon();
            OleDbConnection con = new OleDbConnection(conpath.ReturnAddress());
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            string query = "Select Username From tblUser Where UserId=" + id + ";";
            cmd.CommandText = query;
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            return rd[0].ToString();
        }
    }
}