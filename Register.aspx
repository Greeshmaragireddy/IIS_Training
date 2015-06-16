<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Regiser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            EmailID<asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" Please enter emailid" ControlToValidate="txtemailid"></asp:RequiredFieldValidator><br />
            Password<asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator><br />
            ConfirmPassword<asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter valid password" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
            <asp:CompareValidator CssClass="errormsg" ID="CompareValidator1" runat="server" ErrorMessage="Password doesn't match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"></asp:CompareValidator><br />
            FirstName<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
            LastName<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
          
            Sex <asp:RadioButtonList ID="rdbSex" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList><br />
            DOB<asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
            <br />
            
            Address1
            <asp:TextBox ID="txtAddress1" runat="server" TextMode="MultiLine" Columns="10"></asp:TextBox><br />
            Address2<asp:TextBox ID="txtAddress2" runat="server" TextMode="MultiLine" Columns="10"></asp:TextBox><br />
            City
             <asp:DropDownList ID="ddlCity" runat="server">
                 <asp:ListItem>Scramento</asp:ListItem>
                 <asp:ListItem>Fremont</asp:ListItem>
                 <asp:ListItem>SanFransisco</asp:ListItem>
                 <asp:ListItem>Dublin</asp:ListItem>
                 <asp:ListItem>SantaClara</asp:ListItem>
             </asp:DropDownList><br />
           State
           <asp:DropDownList ID="ddlState" runat="server">
               <asp:ListItem>Califonia</asp:ListItem>
               <asp:ListItem>Texas</asp:ListItem>
               <asp:ListItem>Neveda</asp:ListItem>
               <asp:ListItem>LosAngeles</asp:ListItem>
               <asp:ListItem>LasVegas</asp:ListItem>
           </asp:DropDownList><br />

           Country
           <asp:DropDownList ID="ddlCountry" runat="server">
               <asp:ListItem>India</asp:ListItem>
               <asp:ListItem>Usa</asp:ListItem>
               <asp:ListItem>UK</asp:ListItem>
               <asp:ListItem>Canada</asp:ListItem>
               <asp:ListItem>Australia</asp:ListItem>
           </asp:DropDownList><br /><br />

            <asp:Button ID="btnRegister" runat="server" Text="Submit" OnClick="btnRegister_Click" />


        </div>
    </form>
</body>
</html>
