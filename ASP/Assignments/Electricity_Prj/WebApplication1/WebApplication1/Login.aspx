<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Admin Login</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <br />
        <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" />
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </form>
</body>
</html>
