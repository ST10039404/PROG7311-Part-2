<%@ Page Title="Duplicable" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddFarmer.aspx.cs" Inherits="PROG7311.AddFarmer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <main>
       <div style="margin-left: 10%; width:500px;">
           Email<br /><input runat="server" id="Email" name="Email" type="text" style="width:100%"/><br />
           Password<br /><input runat="server" id="Password" name="Password" type="password" style="width:100%"/><br />
           Contact Details<br /><input runat="server" id="ContactDetails" name="ContactDetails" type="text" style="width:100%"/><br />
           Location<br /><input runat="server" id="Location" name="Location" type="text" style="width:100%"/><br />
           <br />
           <div style="margin-left:34%">
               <button runat="server" onclick="RegisterButton_Click" style="width:40%">Register</button>
           </div>
           
       </div>
</main>
    
</asp:Content>
