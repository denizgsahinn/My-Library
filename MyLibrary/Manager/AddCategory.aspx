<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="MyLibrary.Manager.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formtitle">
            <h3>Add Category</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_successful" runat="server" CssClass="successfulMessage" Visible="false">
                <label>Adding category process is successful.</label>
            </asp:Panel>
             <asp:Panel ID="pnl_failed" runat="server" CssClass="failedMessage" Visible="false">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Category Name</label><br />
                <asp:TextBox ID="tb_name" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_add" runat="server" OnClick="lbtn_add_Click" CssClass="formButton">Add Category</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
