using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;



public class DBCon
{
    const string filename = "EventShareDB.mdb";

    public string ReturnAddress()
    {
        string a = HttpContext.Current.Server.MapPath("~/App_Data/" + filename);
        string path = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + a + ";Persist Security Info=True";
        return path;
    }


}
