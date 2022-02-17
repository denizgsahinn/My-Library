<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyLibrary.Manager.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/itemsLayout.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="contentTitle"><label>KİTAPLAR</label></div>
    <%--<div class="container">
        <img src="../images/bookk.jpg" />
        <div class="bookTitle">
            <label class="lbl">Deneme</label>
        </div>
        <div class="info">
            <p>Yazar:</p>
            <p>Sayfa Sayısı:</p>
            <p>Yayıncı:</p>
            <p>Tür:</p>
        </div>
    </div>--%>
        <div class="container">
                <asp:Repeater ID="rt_books" runat="server">
                    <ItemTemplate>
                        <div class="box">
                            <img src="../images/bookk.jpg" />
                            <div class="bookTitle">
                                <label class="bName"><%# Eval("Name") %></label>
                            </div>
                            <div class="info">
                                <span class="spn">Writer:</span><label class="lbl"><%# Eval("WriterName") %></label>
                                <div><span class="spn">Number Of Page:</span><label class="lbl"><%# Eval("NumberOfPage") %></label></div>
                                <div><span class="spn">Publisher:</span><label class="lbl"><%# Eval("PublisherName") %></label></div>
                                <div><span class="spn">Category:</span><label class="lbl"><%# Eval("CategoryName") %></label></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
    
    
    

</asp:Content>

