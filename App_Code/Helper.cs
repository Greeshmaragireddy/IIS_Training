using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
	public Helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IISTrainingDB"].ConnectionString;
        return connection;
    }
}