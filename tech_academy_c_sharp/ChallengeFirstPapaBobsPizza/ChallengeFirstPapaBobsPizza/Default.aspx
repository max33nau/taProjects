<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeFirstPapaBobsPizza.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style2 {
            color: #FF6600;
        }
    </style>
</head>
<body>
   <h1>
        <asp:Image ID="Image1" runat="server" Height="266px" ImageUrl="Assets/PapaBob.png" Width="248px" />
        <span class="auto-style1">Papa Bob&#39;s Pizza and Software</span></h1>
    <form id="form1" runat="server">
        <div>

            <br />
            <asp:RadioButton ID="babyRadioButton" runat="server" GroupName="pizza_size" Text="Baby Bob Size (10&quot;) - $10" />
&nbsp;<br />
            <asp:RadioButton ID="mamaRadioButton" runat="server" GroupName="pizza_size" Text="Mama Bob Size (13&quot;) - $13" />
&nbsp;<br />
            <asp:RadioButton ID="papaRadioButton" runat="server" GroupName="pizza_size" Text="Papa Bob Size (16&quot;) - $16" />
            <br />
            <br />
            <asp:RadioButton ID="thinCrustRadioButton" runat="server" GroupName="pizza_crust" Text="Thin Crust" />
            <br />
            <asp:RadioButton ID="deepDishCrustRadioButton" runat="server" GroupName="pizza_crust" Text="Deep Dish (+$2)" />
            <br />
            <br />
            <asp:CheckBox ID="pepperoniCheckbox" runat="server" Text="Pepperoni (+$1.5)" />
            <br />
            <asp:CheckBox ID="onionsCheckbox" runat="server" Text="Onions (+$0.75)" />
            <br />
            <asp:CheckBox ID="greenPeppersCheckbox" runat="server" Text="Green Peppers (+$0.50)" />
            <br />
            <asp:CheckBox ID="redPeppersCheckbox" runat="server" Text="Red Peppers (+$0.75)" />
            <br />
            <asp:CheckBox ID="anchoviesCheckbox" runat="server" Text="Anchovies (+$2)" />
            <br />
            <h3 style="font-family: Arial, Helvetica, sans-serif">Papa Bob&#39;s <span class="auto-style2">Special Deal</span></h3>
            <p>
                &nbsp;Save $2.00 when you add Pepperoni, Green Peppers and Anchovies OR Pepperoni, Red Peppers and Onions to your pizza.</p>
            <asp:Button ID="purchaseButton" runat="server" OnClick="purchaseButton_Click" Text="Purchase" />
            <br />
            <asp:Label ID="errorLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            <p>
                Total:&nbsp;&nbsp;&nbsp; $<asp:Label ID="totalLabel" runat="server" Text="0.00"></asp:Label>
            </p>
            <p>
                Sorry, at this time you can only order one pizza online, and pick-up only ... we need a better website!</p>

        </div>
    </form>
</body>
</html>
