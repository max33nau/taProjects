<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PapaBobs.OrderManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <h1 class="text-center"> Current Orders </h1>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="ordersGridView" runat="server" Width="577px" OnRowCommand="ordersGridView_RowCommand">
                <Columns>
                    <asp:ButtonField Text="Completed" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
