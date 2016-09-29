<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="WEBD3000Assignment2.WebPages.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Your Shopping Cart</h2>
        <asp:GridView ID="shoppingCartGridView" runat="server" 
        onselectedindexchanged="shoppingCartGridView_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Remove" 
                    ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    Subtotal :
    <asp:Label ID="subtotalLabel" runat="server"></asp:Label>
    <br />
    Tax :
    <asp:Label ID="taxLabel" runat="server"></asp:Label>
    <br />
    Total :
    <asp:Label ID="totalLabel" runat="server"></asp:Label>
    <br />
    <asp:Button ID="downloadButton" runat="server" onclick="downloadButton_Click" 
        Text="Download Cart" />
    <asp:Button ID="uploadButton" runat="server" onclick="uploadButton_Click" 
        Text="Upload Cart" />
    <br />
</asp:Content>
