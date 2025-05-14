<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductListing.aspx.cs" Inherits="PROG7311.ProductListing" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div style="width:95%; margin:auto;">
            <div>
                <asp:Label runat="server" Text="Product List: " style="margin:50px;" Font-Size="24px"/>
                <br />
                <br />
            </div>
            <div style="width:95%; margin:auto;">
                <textbox style="width:100%; height:100%; ">Search Bar:</textbox>
                <input id="SearchBar" name="SearchBar" runat="server" placeholder="farmer email" style="margin-left:30px;"/>
                <asp:Button ID="Search" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchbarRun" />
                <asp:Button ID="ShowMine" runat="server" Text="Show Mine" CssClass="btn btn-primary" OnClick="showMeMyProducts" />
                <asp:Button ID="addProduct" runat="server" Text="New Product" CssClass="btn btn-primary" OnClick="addANewProduct" />
            </div>
            <br />
            <div style="width:95%; margin:auto;">
                
                <asp:Panel ID="pnlProducts" runat="server"></asp:Panel>
            </div>
            <div>

            </div>
        </div>
        
    </main>
</asp:Content>
