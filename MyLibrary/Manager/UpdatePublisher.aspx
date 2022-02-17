﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="UpdatePublisher.aspx.cs" Inherits="MyLibrary.Manager.UpdatePublisher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formtitle">
            <h3>Update Publisher</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_succesful" runat="server" CssClass="successfulMessage" Visible="false">
                <label>Updating publisher process is successful.</label>
            </asp:Panel>
             <asp:Panel ID="pnl_failed" runat="server" CssClass="failedMessage" Visible="false">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
            </asp:Panel>
             <div class="row">
                <label>Publisher ID</label><br />
                <asp:TextBox ID="tb_ID" runat="server" CssClass="formInput" Enabled="false"></asp:TextBox>
            </div>
            <div class="row">
                <label>Name</label><br />
                <asp:TextBox ID="tb_name" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <label>Phone</label><br />
                <asp:TextBox ID="tb_phone" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <label>Address</label><br />
                <asp:TextBox ID="tb_address" runat="server" CssClass="formInput"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_add" runat="server" OnClick="lbtn_add_Click" CssClass="formButton">Update Publisher</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
