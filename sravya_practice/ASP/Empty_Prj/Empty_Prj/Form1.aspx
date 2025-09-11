<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Empty_Prj.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="myform1" runat="server">
        <div>
            <asp:TextBox ID="txt1" runat ="server" Text="click" />
            <asp:Button ID="btnclick" Text="click" runat="server" OnClick="btnclick_Click" />
            <br /><br />
            <input type="button" id="btn1" runat="server"/>
        </div>
    </form>
</body>
</html>
