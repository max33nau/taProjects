<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengePhunWithStrings.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            1. Reverse the name &quot;Bob Tabor&quot;<br />
            <br />
            Output =
            <asp:Label ID="reverseNameLabel" runat="server"></asp:Label>
            <br />
            <br />
            2. Reverse this sequence: &quot;Luke,Leia, Han,Chewbacca&quot;<br />
            <br />
            Output =
            <asp:Label ID="reverseSequenceLabel" runat="server"></asp:Label>
            <br />
            <br />
            3. Use the sequence to create ascii art:<br />
            <br />
            Output:<br />
            <br />
            <asp:Label ID="asciiLabel" runat="server"></asp:Label>
            <br />
            <br />
            4. Solve the puzzle<br />
            <br />
            Output:&nbsp;&nbsp;
            <asp:Label ID="puzzleLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
