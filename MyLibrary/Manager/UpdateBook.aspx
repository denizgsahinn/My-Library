﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="UpdateBook.aspx.cs" Inherits="MyLibrary.Manager.UpdateBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="formContainer">
        <div class="formtitle">
            <h3>Update Book</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_succesful" runat="server" CssClass="successfulMessage" Visible="false">
                <label>Updating book process is successful.</label>
            </asp:Panel>
             <asp:Panel ID="pnl_failed" runat="server" CssClass="failedMessage" Visible="false">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
            </asp:Panel>
             <div class="row">
                <label>Book ID</label><br />
                <asp:TextBox ID="tb_ID" runat="server" CssClass="formInput" Enabled="false"></asp:TextBox>
            </div>
            <div class="row">
                <label>Name</label><br />
                <asp:TextBox ID="tb_name" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <label>Writer ID</label><br />
                <asp:TextBox ID="tb_writer" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
             <div class="row">
                <label>Number Of Page</label><br />
                <asp:TextBox ID="tb_numPage" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <label>Category ID</label><br />
                <asp:TextBox ID="tb_category" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <label>Publisher ID</label><br />
                <asp:TextBox ID="tb_publisher" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_add" runat="server" OnClick="lbtn_add_Click" CssClass="formButton">Update Book</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
