<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <div>
        <asp:Image ID="image1" runat="server" />
        <asp:Image ID="image2" runat="server" />
        <asp:Image ID="image3" runat="server" />
    </div>
    <br />
    <br />
    <form id="form1" runat="server">
        <div>

            Your Bet:
            <asp:TextBox ID="betAmmountInput" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="pullLeverButton" runat="server" Text="Pull The Lever!" OnClick="pullLeverButton_Click" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            Player&#39;s Money:
            <asp:Label ID="playersTotalMoney" runat="server"></asp:Label>

        </div>
    </form>
    <h3>Game Details</h3>
    <p style="margin-top: 0px">
        1 Cherry - x2 Your Bet <br />
        2 Cherries - x3 Your Bet <br />
        3 Cherries - x4 Your Bet <br />
        3 7's - Jackpot - x100 Your Bet <br /> <br />
        <span class="auto-style1">
        <strong>HOWEVER</strong>... If there's even one BAR you win nothing.
    </span>
    </p>
</body>
</html>
