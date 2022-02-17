<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="PublisherList.aspx.cs" Inherits="MyLibrary.Manager.PublisherList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
       <div class="formtitle">
           <h3>Publishers</h3>
       </div>
       <div class="formContent contenttable">
            <asp:Panel ID="pnl_failed" runat="server" CssClass="failedMessage" Visible="false">
                <asp:Label ID="lbl_message" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_publishers" runat="server" OnItemCommand="lv_publishers_ItemCommand">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>ID</th>
                           <th>Name</th>
                           <th>Phone</th>
                           <th>Address</th>
                           <th>Options</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <td><%# Eval("ID") %></td>
                       <td><%# Eval("Name") %></td>
                       <td><%# Eval("Phone") %></td>
                       <td><%# Eval("pAddress") %></td>

                       <td>
                           <a href='UpdatePublisher.aspx?pid=<%# Eval("ID") %>' class="tablebutton update">Update</a>

                           <asp:LinkButton ID="lbtn_delete" runat="server" CommandName="deletee" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Delete</asp:LinkButton>
                       </td>
                      
                   </tr>
               </ItemTemplate>
           </asp:ListView>
       </div>
   </div>
</asp:Content>
