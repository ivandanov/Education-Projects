<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllPlaylists.aspx.cs" Inherits="WebFormsExam.Web.Private.AllPlaylists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Playlists</h2>
    <asp:GridView runat="server" ID="gvPlaylists"
        ItemType="WebFormsExam.Models.Playlist"
        SelectMethod="gvPlaylists_GetData"
        
        AllowPaging="true"
        PageSize="9"
        AllowSorting="true"
        DataKeyNames="Id"
        AutoGenerateColumns="false">
        
        <Columns>
            <asp:BoundField SortExpression="Title" HeaderText="Title" DataField="Title" />
            <asp:BoundField HeaderText="Category" DataField="Category.Name" />
            <asp:HyperLinkField DataNavigateUrlFields="CategoryId" DataNavigateUrlFormatString="ViewCategory.aspx?id={0}" Text="Category view" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/ViewPlaylist.aspx?id={0}" Text="Playlist view" />
            <asp:BoundField HeaderText="Creator" DataField="Creator.UserName" />
            <asp:BoundField SortExpression="CreationDate" HeaderText="CreationDate" DataField="CreationDate" />
            <%--<asp:BoundField SortExpression="Rating" HeaderText="Rating" DataField="Rating" />--%>
            
        </Columns>
    </asp:GridView>

    <asp:TextBox ID="tbSearch" runat="server" />
    <asp:Button Text="Search" ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-success" />

</asp:Content>
