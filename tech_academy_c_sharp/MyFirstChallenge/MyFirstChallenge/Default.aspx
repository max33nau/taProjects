<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyFirstChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            How old are you?
            <asp:TextBox ID="yourAgeTextBox" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;
            <br />
            <br />
            How much change do you have in your pocket?
            <asp:TextBox ID="yourChangeTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Click Me To See Your Fortune" />
            <br />
            <br />
            <asp:Label ID="yourFortuneLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
