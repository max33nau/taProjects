<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeWar.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3> Lets Play War!</h3>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="startGameButton" runat="server" OnClick="startGameButton_Click" Text="Start the Game" />
            <br />
            <br />
            <asp:Label ID="dealCardsLabel" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="beginBattleLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
