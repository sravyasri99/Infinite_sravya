<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillEntry.aspx.cs" Inherits="WebApplication1.BillEntry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Step-by-Step Bill Entry</title>
    <style>
        body { font-family: Arial; margin: 20px; }
        .panel { margin-bottom: 20px; padding: 10px; border: 1px solid #ccc; }
        label { display: block; margin-top: 10px; }
        input[type="text"] { width: 300px; padding: 5px; }
        .btn { margin-top: 10px; padding: 5px 10px; }
        .output { margin-top: 20px; font-weight: bold; color: darkgreen; }
    </style>
</head>
<body>
    <form id="form1" runat="server">


        <div class="panel" id="pnlStep1" runat="server">
            <label>Enter Number of Bills To Be Added:</label>
            <asp:TextBox ID="txtTotalBills" runat="server" />
            <asp:Button ID="btnStep1" runat="server" Text="Next" CssClass="btn" OnClick="btnStep1_Click" />
        </div>

        <!-- Step 2: Consumer Number -->
<div class="panel" id="pnlStep2" runat="server" Visible="false">
    <asp:Label ID="lblStep2Info" runat="server" Text="" />
    <label>Enter Consumer Number:</label>
    <asp:TextBox ID="txtCno" runat="server" />
    <asp:Button ID="btnStep2" runat="server" Text="Next" CssClass="btn" OnClick="btnStep2_Click" />
</div>

<!-- Step 3: Consumer Name -->
<div class="panel" id="pnlStep3" runat="server" Visible="false">
    <asp:Label ID="lblStep3Info" runat="server" Text="" />
    <label>Enter Consumer Name:</label>
    <asp:TextBox ID="txtCname" runat="server" />
    <asp:Button ID="btnStep3" runat="server" Text="Next" CssClass="btn" OnClick="btnStep3_Click" />
</div>

<!-- Step 4: Units -->
<div class="panel" id="pnlStep4" runat="server" Visible="false">
    <asp:Label ID="lblStep4Info" runat="server" Text="" />
    <label>Enter Units Consumed:</label>
    <asp:TextBox ID="txtUnits" runat="server" />
    <asp:Button ID="btnStep4" runat="server" Text="Add Bill" CssClass="btn" OnClick="btnStep4_Click" />
</div>


      
                <!-- Step 1: Number of Bills -->
       <div id="pnlLastN" runat="server" class="panel">
    <label>Enter Last 'N' Number of Bills To Generate:</label>
    <asp:TextBox ID="txtLastN" runat="server" />
    <asp:Button ID="btnGetLast" runat="server" Text="Generate Last N Bills" CssClass="btn" OnClick="btnGetLast_Click" />
</div>
          <div class="output">
            <asp:Label ID="lblResult" runat="server" Text="" />
        </div>
    </form>
</body>
</html>
