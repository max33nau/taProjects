<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConditionalRadioButtonChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4 class="auto-style1">Your Note Taking Preferences </h4>
            <p>
                <asp:RadioButton ID="pencilRadioButton" runat="server" GroupName="note_taking_preference" Text="Pencil" />
&nbsp;
                <br />
                <asp:RadioButton ID="penRadioButton" runat="server" GroupName="note_taking_preference" Text="Pen" />
&nbsp;<br />
                <asp:RadioButton ID="phoneRadioButton" runat="server" GroupName="note_taking_preference" Text="Phone" />
                <br />
                <asp:RadioButton ID="tabletRadioButton" runat="server" GroupName="note_taking_preference" Text="Tablet" />
            </p>
            <p>
                <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="Ok" />
            </p>
            <p>
                <asp:Label ID="resultLabel" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Image ID="resultImage" runat="server" />
&nbsp;&nbsp;&nbsp;
            </p>
        </div>
    </form>
</body>
</html>
