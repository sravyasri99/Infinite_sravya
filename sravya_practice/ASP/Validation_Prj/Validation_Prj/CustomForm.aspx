<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomForm.aspx.cs" Inherits="Validation_Prj.CustomForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Custom Validation - Login Form</title>
<style>
        body {
            font-family: Arial;
            margin: 40px;
        }
        table {
            border-collapse: separate;
            border-spacing: 10px;
        }
        td {
            padding: 5px;
        }
</style>
<script type="text/javascript">
    function validateLoginName(source, args) {
        var len = args.Value.length;
        args.IsValid = (len >= 6 && len <= 10) || len > 8;
    }

    function validatePassword(source, args) {
        var len = args.Value.length;
        args.IsValid = (len >= 3 && len <= 10);
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<h2>Login Form</h2>
<asp:ValidationSummary ID="vsSummary" runat="server" ForeColor="Red" HeaderText="Please fix the following errors:" />
 
        <table>
<tr>
<td><asp:Label ID="lblLoginName" runat="server" Text="Login Name:" /></td>
<td><asp:TextBox ID="txtLoginName" runat="server" /></td>
<td>
<asp:CustomValidator ID="cvLoginName" runat="server"
                        ControlToValidate="txtLoginName"
                        ErrorMessage="Login Name must be between 6 and 10 characters"
                        ClientValidationFunction="validateLoginName"
                        OnServerValidate="cvLoginName_ServerValidate"
                        ValidateEmptyText="True"
                        ForeColor="Red" />
</td>
</tr>
<tr>
<td><asp:Label ID="lblPassword" runat="server" Text="Password:" /></td>
<td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></td>
<td>
<asp:CustomValidator ID="cvPassword" runat="server"
                        ControlToValidate="txtPassword"
                        ErrorMessage="Password must be between 3 and 10 characters."
                        ClientValidationFunction="validatePassword"
                        OnServerValidate="cvPassword_ServerValidate"
                        ValidateEmptyText="True"
                        ForeColor="Red" />
</td>
</tr>
<tr>
<td colspan="3" style="text-align:center;">
<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
</td>
</tr>
<tr>
<td colspan="3" style="text-align:center;">
<asp:Label ID="lblmsg" runat="server" Font-Bold="True" />
</td>
</tr>
</table>
</form>
</body>
</html>

