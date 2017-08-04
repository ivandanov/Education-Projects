<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsExam.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Youtube Playlists</p>
    </div>
    <asp:Repeater 
        runat="server"
        ID="PalylistRepeater"
        ItemType="WebFormsExam.Models.Playlist"
        SelectMethod="PalylistRepeater_GetData">
        <HeaderTemplate>
            <h2>Popular Playlists</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="row">
                <h3>
                    <a href="/ViewPlaylist.aspx?id=<%# Item.Id %>"><%#: Item.Title %></a> 
                    <small>Category: <%#: Item.Category.Name %></small>
                </h3>
                <p>
                    Descrtiption: <%#: Item.Description.Length >= 300 ? Item.Description.Substring(0, 300) + "..." : Item.Description%>
                </p>
                <p>Average rating: <%# Item.Rating.Count == 0 ? 0 : Item.Rating.Average(r => r.Value) %></p>
                <div>
                    <i>by <%#: Item.Creator.UserName %></i>
                    <i>created on: <%# Item.CreationDate %></i>
                </div>
            </div>
        </ItemTemplate>

    </asp:Repeater>


</asp:Content>
