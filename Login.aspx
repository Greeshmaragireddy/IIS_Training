<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        EmailID<asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox><br />
        Password<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" />
        <br />
        <br />
        
        <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" />
        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />

        <br /><br />
        <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="#FF3300"></asp:Label>
    
    </div>
    </form>
</body>
</html>
