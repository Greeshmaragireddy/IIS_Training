using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string EmailID = Request.QueryString["EmailID"];
        string EmailID = Session["EmailID"].ToString();

        try
        {
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IISTrainingDB"].ConnectionString;
            SqlConnection connection = Helper.GetConnection();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_GetUserInfoByEmailID";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = EmailID;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            //FirstName,LastName,DOB,Sex,Address1,Address2,City,[State],Country
            Response.Write("FirstName: " + reader[0] + "<br>");
            Response.Write("LastName: " + reader[1] + "<br>");
            Response.Write("DOB: " + reader[3] + "<br>");
            Response.Write("Sex: " + reader[4] + "<br>");
            Response.Write("Address1: " + reader[5] + "<br>");
            Response.Write("Address2: " + reader[6] + "<br>");
            Response.Write("City: " + reader[7] + "<br>");
            Response.Write("State: " + reader[8] + "<br>");
            Response.Write("Country: " + reader[9] + "<br>");

            connection.Close();
            command.Dispose();
        }
        catch (SqlException ex) {
            Response.Write("Sql Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }
}
