<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VotePage.aspx.cs" Inherits="WEBD3000Assignment2.WebPages.VotePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="voteDetailsView" runat="server" AutoGenerateRows="False" 
        DataKeyNames="TrackId" DataSourceID="chinookDataSource" Height="50px" 
        Width="450px">
        <Fields>
            <asp:BoundField DataField="TrackName" HeaderText="TrackName" 
                SortExpression="TrackName" />
            <asp:BoundField DataField="Name" HeaderText="Artist" SortExpression="Name" />
            <asp:BoundField DataField="Title" HeaderText="Album" SortExpression="Title" />
            <asp:BoundField DataField="GenreName" HeaderText="GenreName" 
                SortExpression="GenreName" />
            <asp:BoundField DataField="Composer" HeaderText="Composer" 
                SortExpression="Composer" />
            <asp:BoundField DataField="Milliseconds" HeaderText="Milliseconds" 
                SortExpression="Milliseconds" />
            <asp:BoundField DataField="Bytes" HeaderText="Bytes" 
                SortExpression="Bytes" />
            <asp:BoundField DataField="MediaTypeName" HeaderText="MediaType" 
                SortExpression="MediaTypeName" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                SortExpression="UnitPrice" />
            <asp:BoundField DataField="Popularity" HeaderText="Popularity" 
                SortExpression="Popularity" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="chinookDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ChinookConnectionString %>" SelectCommand="SELECT Artist.Name, MediaType.Name AS MediaTypeName, Track.TrackId, Track.Name AS TrackName, Track.AlbumId, Track.MediaTypeId, Track.GenreId, Track.Composer, Track.Milliseconds, Track.Bytes, Track.UnitPrice, Track.Popularity, Genre.Name AS GenreName, Album.Title FROM Track INNER JOIN Album INNER JOIN Artist ON Album.ArtistId = Artist.ArtistId ON Track.AlbumId = Album.AlbumId INNER JOIN Genre ON Track.GenreId = Genre.GenreId INNER JOIN MediaType ON Track.MediaTypeId = MediaType.MediaTypeId
WHERE Track.TrackId = @trackId">
        <SelectParameters>
            <asp:QueryStringParameter Name="trackId" QueryStringField="TrackId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="voteUpButton" runat="server" onclick="voteUpButton_Click" 
        Text="Vote For" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="voteDownButton" runat="server" onclick="voteDownButton_Click" 
        Text="Vote Against" />
</asp:Content>
