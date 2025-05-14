<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListingItem.ascx.cs" Inherits="PROG7311.UserControls.ProductListingItem" %>

<style>
* {margin: 0; padding: 0;}
#container {width:755px; height:65px; border:groove;}
.imageSeperator {display: inline-block; width: 65px; height:65px;}
.seperator {display: inline-block; width: 172px; height:65px;}
.label {margin:0px 15px 0px 15px; height:auto;}
</style>

<div id="container">
    <div class="imageSeperator">
        <asp:Image ID="Product_ImageDetails" runat="server" Height="42px" Width="42px" style="margin: 12px 13px 11px 13px"/>
    </div>
    <div class="seperator">
        <div style="height:32px">
            <asp:Label ID="Product_Name" runat="server" Text="Product Name" class="label"/>
        </div>
        <div style="height:33px">
            <asp:Label ID="Product_NameDetail" runat="server" Text="" class="label"/>
        </div>
    </div>
    <div class="seperator">
        <div style="height:32px">
            <asp:Label ID="Product_Category" runat="server" Text="Category" class="label"/>
        </div>
        <div style="height:33px">
            <asp:Label ID="Product_CategoryDetail" runat="server" Text="" class="label"/>
        </div>
    </div>
    <div class="seperator">
        <div style="height:32px">
            <asp:Label ID="Product_Date" runat="server" Text="Date" class="label"/>
        </div>
        <div style="height:33px">
            <asp:Label ID="Product_DateDetail" runat="server" Text="" class="label"/>
        </div>
    </div>
    <div class="seperator">
        <div style="height:32px">
            <asp:Label ID="Product_Price" runat="server" Text="Pricing" class="label"/>
        </div>
        <div style="height:33px">
            <asp:Label ID="Product_PriceDetail" runat="server" Text="" class="label"/>
        </div>
    </div>
</div>