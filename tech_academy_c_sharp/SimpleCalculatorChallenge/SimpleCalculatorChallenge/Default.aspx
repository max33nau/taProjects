<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleCalculatorChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: "Comic Sans MS";
        }
        .input-label {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="newStyle1">Simple Calculator</h1>
            <br />
            <asp:Label ID="Label2" runat="server" CssClass="input-label" Font-Names="Arial" Text="First Value:"></asp:Label>
&nbsp;<asp:TextBox ID="firstValueInput" runat="server"></asp:TextBox>
&nbsp;
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" CssClass="input-label" Font-Names="Arial" Text="Second Value:"></asp:Label>
&nbsp;<asp:TextBox ID="secondValueInput" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="+" Width="40px" />
&nbsp;
            <asp:Button ID="subtractButton" runat="server" OnClick="subtractButton_Click" Text="-" Width="40px" />
&nbsp;
            <asp:Button ID="multiplyButton" runat="server" OnClick="multiplyButton_Click" Text="*" Width="40px" />
&nbsp;
            <asp:Button ID="divideButton" runat="server" OnClick="divideButton_Click" Text="/" Width="40px" />
&nbsp;<br />
            <br />
            <asp:Label ID="resultLabel" runat="server" BackColor="#33CCFF" Font-Bold="True" Font-Size="Larger" ForeColor="#CC0000" style="font-family: 'Comic Sans MS'"></asp:Label>
        </div>
    </form>
</body>
</html>
