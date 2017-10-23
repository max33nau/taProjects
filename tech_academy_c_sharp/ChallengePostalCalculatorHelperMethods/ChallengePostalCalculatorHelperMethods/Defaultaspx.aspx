<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaultaspx.aspx.cs" Inherits="ChallengePostalCalculatorHelperMethods.Defaultaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Postal Calculator</h2>
    <form id="form1" runat="server">
        <div>
           
            Width:
            <asp:TextBox ID="widthInput" runat="server" AutoPostBack="True" OnTextChanged="handleChanged"></asp:TextBox>
&nbsp;
            <br />
            Height:
            <asp:TextBox ID="heightInput" runat="server" AutoPostBack="True" OnTextChanged="handleChanged"></asp:TextBox>
&nbsp;<br />
            Length:
            <asp:TextBox ID="lengthInput" runat="server" AutoPostBack="True" OnTextChanged="handleChanged"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:RadioButton ID="groundRadio" runat="server" AutoPostBack="True" GroupName="shipping_type" OnCheckedChanged="handleChanged" Text="Ground" />
            <br />
            <asp:RadioButton ID="airRadio" runat="server" AutoPostBack="True" GroupName="shipping_type" OnCheckedChanged="handleChanged" Text="Air" />
            <br />
            <asp:RadioButton ID="nextDayRadio" runat="server" AutoPostBack="True" GroupName="shipping_type" OnCheckedChanged="handleChanged" Text="Next Day" />
            <br />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
           
        </div>
    </form>
</body>
</html>
