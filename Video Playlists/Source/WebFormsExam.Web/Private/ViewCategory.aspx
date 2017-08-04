<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCategory.aspx.cs" Inherits="WebFormsExam.Web.Private.ViewCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="fvCategory"
        ItemType="WebFormsExam.Models.Category"
        SelectMethod="fvCategory_GetItem">
        <ItemTemplate>
            <div class="row">
                <h2>Name: <%#: Item.Name %> </h2>
            </div>
            <div class="row">
                <asp:Repeater
                    runat="server"
                    ID="PlaylistRepeater"
                    ItemType="WebFormsExam.Models.Playlist"
                    SelectMethod="PlaylistRepeater_GetData">
                    <HeaderTemplate>
                        Playlist in this category:
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-4">
                                Title: <%# Item.Title %>
                            </div>
                            <div class="col-md-4">
                                Rating: <%# Item.Rating.Count == 0 ? 0 : Item.Rating.Average(r => r.Value) %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
