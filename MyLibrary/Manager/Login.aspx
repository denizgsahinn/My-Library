<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyLibrary.Manager.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="Css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="FormContainer">
            <div class="ContainerTitle">  
                <h2> Manager Login </h2>
            </div>
            <div class="contentContainer">
                <div class="info"> 
                    <label class="Label">Mail / User Name</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="textBox" placeholder="demo@demo.com"> </asp:TextBox>
                </div>
                 <div class="info"> 
                    <label class="Label">Password</label><br />
                    <asp:TextBox ID="tb_password" runat="server" CssClass="textBox" TextMode="Password" placeholder="Your Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btn_login" runat="server" Text="Login" CssClass="loginButton" OnClick="btn_login_Click"/>
                </div>
                <asp:Panel ID="error_pnl" runat="server" CssClass="errorMessage" Visible="false" > 
                    <asp:Label ID="lbl_message" runat="server"> Error Message</asp:Label>
                </asp:Panel>
            </div>
            
        </div>
    </form>
</body>
</html>
