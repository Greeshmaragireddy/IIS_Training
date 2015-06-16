using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie myCookie = Request.Cookies["IISTrainingCookie"];

        // Read the cookie information and display it.
        if (myCookie != null)
            txtEmailID.Text = myCookie["EmailID"];
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IISTrainingDB"].ConnectionString;
            //SqlConnection connection = Helper.GetConnection();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_ValidateUser";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = txtEmailID.Text;
            command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = txtPassword.Text;

            connection.Open();

            int? userID = (int?)command.ExecuteScalar();

            //int userIDActual = 0;
            //object userID1 = command.ExecuteScalar();
            //if (userID != null)
            //{
            //    userIDActual = (int)userID;
            //}

            if (userID.HasValue)
            {
                //Response.Redirect("Index.aspx?Username=" + txtUsername.Text);
                Session["EmailID"] = txtEmailID.Text;

                if (chkRememberMe.Checked) {
                    HttpCookie myCookie = new HttpCookie("IISTrainingCookie");
                    DateTime now = DateTime.Now;

                    // Set the cookie value.
                    myCookie["EmailID"] = txtEmailID.Text;
                    // Set the cookie expiration date.
                    myCookie.Expires = now.AddDays(2); 
                }

                Response.Redirect("Index.aspx");
            }
            else
                Response.Write("Invalid Login");
        }
        catch (SqlException ex)
        {
            lblErrorMessage.Text = "Sql Exception: " + ex.Message;
        }
        catch (NullReferenceException ex)
        {
            lblErrorMessage.Text = "Null Reference Exception:" + ex.Message;
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = "Base Exception:" + ex.Message;
        }
        finally { 
            
        }

    }
    
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}