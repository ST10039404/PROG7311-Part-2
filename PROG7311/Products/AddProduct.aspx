<%@ Page Title="Add Product" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddProduct.aspx.cs" Inherits="PROG7311.AddProduct" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div style="width:25%;">
            <div class="form-group">
                <label for="ProductName">Product Name: </label>
                <asp:TextBox ID="ProductName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="ProductName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Required, insert the name of your product." runat="server" />
            </div>
            <br />
            <div class="form-group">
                <label for="Category">Product Category: </label>
                <asp:TextBox ID="Category" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="Category" CssClass="text-danger" Display="Dynamic" ErrorMessage="Required, insert a reasonable category of your choosing." runat="server" />
            </div>
            <br />
            <div class="form-group">
                <label for="ProductPrice">Product Price: </label>
                <asp:TextBox ID="ProductPrice" runat="server" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator ControlToValidate="ProductPrice" CssClass="text-danger" Display="Dynamic" ErrorMessage="Required, insert the price you'd like to list your product under." runat="server" />
            </div>
            <br />
            <div class="form-group">
                <label for="ProductionDate">Product Date: </label>
                <asp:TextBox ID="ProductionDate" runat="server" CssClass="form-control" TextMode="Date" />
                <asp:RequiredFieldValidator ControlToValidate="ProductionDate" CssClass="text-danger" Display="Dynamic" ErrorMessage="Requiried, insert the date your product was produced." runat="server" />
            </div>
            <br />
            <div class="form-group">
                <label for="ProductImage">Product Image: </label>
                <asp:FileUpload ID="ProductImage" runat="server" CssClass="form-control-file" accept=".png,.jpg,.jpeg"/>
            </div>
            <br />
            <div>
                <asp:Button ID="AddProductButton" runat="server" Text="Add Product" CssClass="btn btn-primary" OnClick="AddNewProductButton_Click" />
            </div>
        </div>
</asp:Content>