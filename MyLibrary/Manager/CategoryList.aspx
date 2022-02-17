<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="MyLibrary.Manager.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
       <div class="formtitle">
           <h3>Categories</h3>
       </div>
       <div class="formContent contenttable">
            <asp:Panel ID="pnl_failed" runat="server" CssClass="failedMessage" Visible="false">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_categories" runat="server" OnItemCommand="lv_categories_ItemCommand">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>ID</th>
                           <th>Name</th>
                           <th>Options</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <td><%# Eval("ID") %></td>
                       <td><%# Eval("Name") %></td>

                       <td>
                           <a href='UpdateCategory.aspx?kid=<%# Eval("ID") %>' class="tablebutton update">Update</a>

                           <asp:LinkButton ID="lbtn_delete" runat="server" CommandName="deletee" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Delete</asp:LinkButton>
                       </td>
                      
                   </tr>
               </ItemTemplate>
           </asp:ListView>
       </div>
   </div>
</asp:Content>
