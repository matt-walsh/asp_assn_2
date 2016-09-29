<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PopularityPage.aspx.cs" Inherits="WEBD3000Assignment2.WebPages.PopularityPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Popularity Statistics</h1>
    <p>
        Choose from the following to view popularity stats.
    </p>
        
        <table>
            <thead>
                <tr>
                    <th>Album</th>
                    <th>Artist</th>
                    <th>Genre</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>    
                        <asp:DropDownList ID="albumDropDown" runat="server" 
                            DataSourceID="albumDataSource" DataTextField="Title" 
                            DataValueField="AlbumId" Width="120px" AutoPostBack="True" 
                            onselectedindexchanged="albumDropDown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>    
                        <asp:DropDownList ID="artistDropDown" runat="server" 
                            DataSourceID="artistDataSource" DataTextField="Name" 
                            DataValueField="ArtistId" Width="120px" AutoPostBack="True" 
                            onselectedindexchanged="artistDropDown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>    
                        <asp:DropDownList ID="genreDropDown" runat="server" 
                            DataSourceID="genreDataSource" DataTextField="Name" 
                            DataValueField="GenreId" AutoPostBack="True" 
                            onselectedindexchanged="genreDropDown_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </tbody>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <p>
            <asp:Label ID="titleLabel" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="popularityLabel" runat="server"></asp:Label>
    </p>
    <asp:SqlDataSource ID="genreDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ChinookConnectionString %>" 
        SelectCommand="SELECT * FROM [Genre]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="artistDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ChinookConnectionString %>" 
        SelectCommand="SELECT * FROM [Artist]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="albumDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ChinookConnectionString %>" 
        SelectCommand="SELECT [Title], [AlbumId] FROM [Album]"></asp:SqlDataSource>
</asp:Content>
