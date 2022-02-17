﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="AddWriter.aspx.cs" Inherits="MyLibrary.Manager.AddWriter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formtitle">
            <h3>Add Writer</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_successful" runat="server" CssClass="successfulMessage" Visible="false">
                <label>Adding writer process is successful.</label>
            </asp:Panel>
             <asp:Panel ID="pnl_failed" runat="server" CssClass="failedMessage" Visible="false">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Name</label><br />
                <asp:TextBox ID="tb_name" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <label>Surname</label><br />
                <asp:TextBox ID="tb_surname" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <label>Title</label><br />
                <asp:TextBox ID="tb_title" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_add" runat="server" OnClick="lbtn_add_Click" CssClass="formButton">Add Writer</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
