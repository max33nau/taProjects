<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobs.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Papa Bobs Mega Challenge</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <h1 class="display-3">Papa Bob's Pizza</h1>
            <p class="lead">Pizza to Code By</p>
        </div>
    </div>
    <div class="container-fluid">
       <form id="form1" runat="server">
            <h3>Pizza Details</h3>
            <div class="row">
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <label> <strong> Size: </strong></label>
                        <asp:DropDownList ID="sizeDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="getTotalPrice">
                            <asp:ListItem Value="0">Choose One...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <label> <strong> Crust: </strong></label>
                        <asp:DropDownList ID="crustDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="getTotalPrice">
                            <asp:ListItem Value="0">Choose One...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <label> <strong> Toppings: </strong></label>
                        <asp:CheckBoxList ID="toppingsCheckBoxList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="getTotalPrice"></asp:CheckBoxList>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label> <strong> Special Order requests: </strong></label>
                        <asp:TextBox ID="notesTextBox" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <h3>Deliver To</h3>
            <div class="row">
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <label> <strong> Name: </strong></label>
                        <asp:TextBox ID="nameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <label> <strong> Address: </strong></label>
                        <asp:TextBox ID="addressTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <label> <strong> Zip: </strong></label>
                        <asp:TextBox ID="zipTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <label> <strong> Phone: </strong></label>
                        <asp:TextBox ID="phoneTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <h3>Payment Type</h3>
            <div class="row">
                <div class="col-xs-12 col-sm-6">
                    <div class="form-group">
                        <asp:RadioButtonList ID="paymentTypesRadio" runat="server"></asp:RadioButtonList>
                    </div>
                </div>
            </div>
           <asp:Button ID="submitOrder" runat="server" Text="Order" CssClass="btn btn-primary" OnClick="submitOrder_Click" />
       </form>

        <h2 style="margin-bottom: 100px;">
             <asp:Label ID="resultLabel" runat="server" Text="Total Price: $0.00"></asp:Label>
        </h2>
    </div>
</body>
</html>
