<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPlaylist.aspx.cs" Inherits="WebFormsExam.Web.ViewPlaylist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="fvPlaylist"
        ItemType="WebFormsExam.Models.Playlist"
        SelectMethod="fvPlaylist_GetItem">
        <ItemTemplate>
            <div class="row">
                <%--<div>
                                <div class="like-control col-md-1">
                                    <newsSystem:LikeHate runat="server" ID="likeHateControl"/>
                                </div>
                            </div>--%>
                <h2>Title: <%#: Item.Title %> <small>Category: <%# Item.Category.Name %></small></h2>
                <p>
                    Description: <%#: Item.Description %>
                </p>
                <p>
                    Average Rating: <%#: Item.Rating.Count == 0 ? 0 : Item.Rating.Average(r => r.Value) %>
                </p>
                <p>
                    <span>Author: <%#: Item.Creator.UserName %></span>
                    <span class="pull-right"><%# Item.CreationDate %></span>
                </p>
            </div>
            <div class="row">
                <asp:GridView runat="server" ID="gvPlaylists"
                    ItemType="WebFormsExam.Models.Video"
                    SelectMethod="gvPlaylists_GetData"
                    DataKeyNames="Id"
                    AutoGenerateColumns="false"
                    DeleteMethod="gvPlaylists_DeleteItem">
                    <Columns>
                        <asp:BoundField SortExpression="Url" HeaderText="Url" DataField="Url" />
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
