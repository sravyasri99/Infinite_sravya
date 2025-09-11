<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStateForm.aspx.cs" Inherits="StateManagement.ViewStateForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblusername" runat="server" Text="UserName"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtusername" runat="server" Width="170px"></asp:TextBox>
        <br />
        <asp:Label ID="lblpassword" runat="server" Text="Password" ></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="btnStore" runat="server" Text="Store Data" onClick="btnLoad_Click" />

    </form>
</body>
</html>
