<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebFormsExam.Web.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="fvProfile"
        ItemType="WebFormsExam.Models.ApplicationUser"
        SelectMethod="fvProfile_GetItem">
        <ItemTemplate>
            <div class="row">
                <p>
                    <h2>Name: <%#: Item.UserName %> </h2>
                </p>
                <p>
                    <h2>Email: <%#: Item.Email %> </h2>
                </p>
                <p>
                    <h2>FacebookUrl: <%#: Item.FacebookUrl == null ? "no url" : Item.FacebookUrl %> </h2>
                </p>
                <p>
                    <h2>YoutubeUrl: <%#: Item.YoutubeUrl == null ? "no url" : Item.YoutubeUrl %> </h2>
                </p>
                <p>
                    <h2>Avatar: <%#: Item.Avatar %> </h2>
                </p>
            </div>
            <div class="row">
                <p>
                    <h2>Playlists: </h2>
                </p>
                <asp:GridView runat="server" ID="gvPlaylists"
                    ItemType="WebFormsExam.Models.Playlist"
                    SelectMethod="gvPlaylists_GetData"
                    DataKeyNames="Id"
                    AutoGenerateColumns="false"
                    DeleteMethod="gvPlaylists_DeleteItem">
                    <Columns>
                        <asp:BoundField SortExpression="Title" HeaderText="Title" DataField="Title" />
                    </Columns>
                </asp:GridView>
            </div>
        </ItemTemplate>
    </asp:FormView>


</asp:Content>
