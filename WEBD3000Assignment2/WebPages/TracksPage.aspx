<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TracksPage.aspx.cs" Inherits="WEBD3000Assignment2.WebPages.Tracks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="chinookDatasource" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ChinookConnectionString %>" 
    
    SelectCommand="SELECT Album.AlbumId AS AlbumAlbumId, Album.Title, Album.ArtistId, MediaType.MediaTypeId AS MeditaTypeMediaTypeId, MediaType.Name AS MediaTypeName, Genre.GenreId AS GenreGenreId, Genre.Name AS GenreName, Artist.ArtistId AS ArtistArtistId, Artist.Name AS ArtisitName, Track.* FROM Genre INNER JOIN Track ON Genre.GenreId = Track.GenreId INNER JOIN Album INNER JOIN Artist ON Album.ArtistId = Artist.ArtistId ON Track.AlbumId = Album.AlbumId INNER JOIN MediaType ON Track.MediaTypeId = MediaType.MediaTypeId">
</asp:SqlDataSource>
<asp:GridView ID="trackListView" runat="server" 
    DataSourceID="chinookDatasource" AllowPaging="True" AllowSorting="True" 
    AutoGenerateColumns="False" CellPadding="4" 
    DataKeyNames="AlbumAlbumId,MeditaTypeMediaTypeId,GenreGenreId,ArtistArtistId,TrackId" 
    ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="trackListView_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Track Name" 
            SortExpression="Name" />
        <asp:BoundField DataField="Title" HeaderText="Album" SortExpression="Title" />
        <asp:BoundField DataField="ArtisitName" HeaderText="Artisit" 
            SortExpression="ArtisitName" />
        <asp:BoundField DataField="GenreName" HeaderText="Genre" 
            SortExpression="GenreName" />
        <asp:BoundField DataField="Composer" HeaderText="Composer" 
            SortExpression="Composer" />
        <asp:BoundField DataField="Milliseconds" HeaderText="Milliseconds" 
            SortExpression="Milliseconds" />
        <asp:BoundField DataField="Bytes" HeaderText="Bytes" SortExpression="Bytes" />
        <asp:BoundField DataField="MediaTypeName" HeaderText="Media Type" 
            SortExpression="MediaTypeName" />
        <asp:BoundField DataField="Popularity" HeaderText="Popularity" 
            SortExpression="Popularity" />
        <asp:BoundField DataField="UnitPrice" HeaderText="Price" 
            SortExpression="UnitPrice" />
        <asp:CommandField ShowSelectButton="True" SelectText="Buy Now!" />
        <asp:HyperLinkField DataNavigateUrlFields="TrackId" 
            DataNavigateUrlFormatString="~/WebPages/VotePage.aspx?trackId={0}" 
            Text="Vote" />
    </Columns>
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F8FAFA" />
    <SortedAscendingHeaderStyle BackColor="#246B61" />
    <SortedDescendingCellStyle BackColor="#D4DFE1" />
    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
</asp:Content>
