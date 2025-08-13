<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:700px; margin:auto; font-family:Arial; font-size:14px;">
            <h2>Insert Personal Details</h2>

            <table style="width:100%; border-spacing:10px;">
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <span style="color:red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name is required." ForeColor="Red" />
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td>Family Name</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <span style="color:red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Family Name is required." ForeColor="Red" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox2" ControlToCompare="TextBox1" ErrorMessage="Name must be different from Family Name." ForeColor="Red" Operator="NotEqual" />
                    </td>
                    <td><span style="color:gray">differs from name</span></td>
                </tr>

                <tr>
                    <td>Address</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <span style="color:red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Address is required." ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ValidationExpression=".{2,}" ErrorMessage="Address must have at least 2 characters." ForeColor="Red" />
                    </td>
                    <td><span style="color:gray">at least 2 chars</span></td>
                </tr>

                <tr>
                    <td>City</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <span style="color:red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="City is required." ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox4" ValidationExpression=".{2,}" ErrorMessage="City must have at least 2 characters." ForeColor="Red" />
                    </td>
                    <td><span style="color:gray">at least 2 chars</span></td>
                </tr>

                <tr>
                    <td>Zip Code</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <span style="color:red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Zip Code is required." ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox5" ValidationExpression="^\d{5}$" ErrorMessage="Zip Code must be 5 digits." ForeColor="Red" />
                    </td>
                    <td><span style="color:gray">(xxxxx)</span></td>
                </tr>

                <tr>
                    <td>Phone</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        <span style="color:red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="Phone is required." ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox6" ValidationExpression="^\d{2}-\d{8}$|^\d{3}-\d{8}$" ErrorMessage="Phone must follow the format XX-XXXXXXXX or XXX-XXXXXXXX." ForeColor="Red" />
                    </td>
                    <td><span style="color:gray">(xx-xxxxxxxx / xxx-xxxxxxxx)</span></td>
                </tr>

                <tr>
                    <td>E-Mail</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        <span style="color:red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox7" ErrorMessage="Email is required." ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox7" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationExpressionOptions="IgnoreCase" ErrorMessage="Enter a valid email address." ForeColor="Red" />
                    </td>
                    <td><span style="color:gray">example@example.com</span></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check" />
                    </td>
                    <td></td>
                </tr>

                <tr>
    <td></td>
    <td>
        <span style="color:red; font-weight:bold;">ValidationSum:</span><br />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="True" 
            ShowSummary="False" 
            ForeColor="Red" />

        <ul style="color:red; margin-top:5px;">
            <li>Name</li>
            <li>Family</li>
            <li>Address</li>
            <li>City</li>
            <li>Pin</li>
        </ul>
    </td>
</tr>

            </table>
        </div>
    </form>
</body>
</html>
