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

public class Registration
{
    public string EmailID { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
   
    public string Sex { get; set; }
    public DateTime? DOB { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}

public partial class Regiser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Registration registration = new Registration();

        registration.EmailID = txtEmailID.Text.Trim();
        registration.Password = txtPassword.Text.Trim();
        registration.FirstName = txtFirstName.Text.Trim();
        registration.LastName = txtLastName.Text.Trim();
        registration.Sex = rdbSex.Text.Trim();

        if (txtDOB.Text.Trim().Length > 0)
            registration.DOB = Convert.ToDateTime(txtDOB.Text.Trim()); //TODO: Add Client Side Validation to check valid date

        registration.Address1 = txtAddress1.Text.Trim();
        registration.Address2 = txtAddress2.Text.Trim();
        registration.City = ddlCity.Text.Trim();

        registration.State = ddlState.Text.Trim();
        registration.Country = ddlCountry.Text.Trim();

        bool register = RegisterUser(registration);
        if (register)
        {
            Session["EmailID"] = txtEmailID.Text;
            Response.Redirect("Index.aspx");

        }
            
        else
            Response.Write("Registration Failed");

    }

    public bool RegisterUser(Registration registration)
    {
        //SqlConnection connection = new SqlConnection();
        //connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IISTrainingDB"].ConnectionString;
        SqlConnection connection = Helper.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "usp_RegisterUser";
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add("@EmailID", SqlDbType.VarChar, 50).Value = registration.EmailID;
        command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = registration.Password;
        command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = registration.FirstName;
        command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = registration.LastName;
        command.Parameters.Add("@Sex", SqlDbType.VarChar, 6).Value = registration.Sex;

        if(registration.DOB.HasValue)
            command.Parameters.Add("@DOB", SqlDbType.DateTime).Value =  registration.DOB;
        else
            command.Parameters.Add("@DOB", SqlDbType.DateTime).Value =  DBNull.Value;
        
        command.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = registration.Address1;
        command.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = registration.Address2;
        command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = registration.City;
        command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = registration.State;
        command.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = registration.Country;

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        command.Dispose();

        return true;

    }

}

        

    
