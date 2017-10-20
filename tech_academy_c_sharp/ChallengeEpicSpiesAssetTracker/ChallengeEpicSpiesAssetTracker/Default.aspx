<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeEpicSpiesAssetTracker.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
        }
    </style>
</head>
<body>
    <asp:Image ID="Image1" runat="server" ImageUrl="Assets/epic-spies-logo.jpg" Height="150px" />
    <h2>     
        <span class="auto-style1">Asset Performance Tracker</span>
    </h2>
    <form id="form1" runat="server">
        <div>

            Asset Name:
            <asp:TextBox ID="assetNameInput" runat="server"></asp:TextBox>
&nbsp;<br />
            <br />
            Elections Rigged:
            <asp:TextBox ID="electionsRiggedInput" runat="server"></asp:TextBox>
            <br />
            <br />
            Acts of Subterfuge Performed:
            <asp:TextBox ID="actsOfSubterfugeInput" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addAssetButton" runat="server" OnClick="addAssetButton_Click" Text="Add Asset" />

        </div>
        <p>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
