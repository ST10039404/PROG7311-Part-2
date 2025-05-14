<%@ Page Title="Register + Login" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PROG7311._Default" %>

<form id="form1" runat="server" method="post">
    
    <style>
        .inputs {width:100%;}
    </style>

<main>
    <div style="background-color:beige; width:30%; border:thin; margin:auto">
        <div style="margin:auto; width:100%; align-content:center;">
        <center><h1>Login</h1></center>
        <font size="3px"></font>
    </div>
    <div style="margin-left:50px; width:400px">
        <div >
            <br />Email<br /><input id="Email" name="Email" runat="server" type="text" class="inputs" placeholder="youremail@email"/><br />
            <br />Password<br /><input id="Password" name="Password" runat="server" type="password" class="inputs" placeholder="enter your password"/>
        </div>
        <div style="margin:auto; width:100%;">
            <br />
            <center><button runat="server"  OnServerClick="LoginButton_Click">Login</button></center>
        </div>
    </div>
    </div>
    
       
</main>
</form>

