<%@ Page Title="Duplicable" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddFarmer.aspx.cs" Inherits="PROG7311.Duplicable" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <main>
       <div style="margin-left: 10%; width:500px;">
           Email<br /><input id="Email" type="text" style="width:100%"/><br />
           Password<br /><input id="Password" type="password" style="width:100%"/><br />
           Contact Details<br /><input id="ContactDetails" type="text" style="width:100%"/><br />
           Location<br /><input id="Location" type="text" style="width:100%"/><br />
           <br />
           <div style="margin-left:34%">
               <button runat="server" onclick="RegisterButton_Click" style="width:40%">Register</button>
           </div>
           
       </div>
</main>
    
</asp:Content>
