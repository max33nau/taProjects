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
            <asp:TextBox ID="widthInput" runat="server" AutoPostBack="True" OnTextChanged="widthInput_TextChanged"></asp:TextBox>
&nbsp;
            <br />
            Height:
            <asp:TextBox ID="heightInput" runat="server" AutoPostBack="True" OnTextChanged="heightInput_TextChanged"></asp:TextBox>
&nbsp;<br />
            Length:
            <asp:TextBox ID="lengthInput" runat="server" AutoPostBack="True" OnTextChanged="lengthInput_TextChanged"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:RadioButton ID="groundRadio" runat="server" AutoPostBack="True" GroupName="shipping_type" OnCheckedChanged="groundRadio_CheckedChanged" Text="Ground" />
            <br />
            <asp:RadioButton ID="airRadio" runat="server" AutoPostBack="True" GroupName="shipping_type" OnCheckedChanged="airRadio_CheckedChanged" Text="Air" />
            <br />
            <asp:RadioButton ID="nextDayRadio" runat="server" AutoPostBack="True" GroupName="shipping_type" OnCheckedChanged="nextDayRadio_CheckedChanged" Text="Next Day" />
            <br />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
           
        </div>
    </form>
</body>
</html>
