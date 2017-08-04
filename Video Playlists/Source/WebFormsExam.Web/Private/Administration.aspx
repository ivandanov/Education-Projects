<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="WebFormsExam.Web.Private.Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Playlists</h2>
    <asp:GridView runat="server" ID="gvCategories"
        ItemType="WebFormsExam.Models.Category"
        SelectMethod="gvCategories_GetData"
        AllowPaging="true"
        PageSize="5"
        AllowSorting="true"
        DataKeyNames="Id"
        AutoGenerateColumns="false"
        UpdateMethod="gvCategories_UpdateItem">
        <Columns>
            <asp:BoundField SortExpression="Id" ReadOnly="true" HeaderText="Id" DataField="Id" />
            <asp:BoundField SortExpression="Name" HeaderText="Name" DataField="Name" />
            <asp:BoundField SortExpression="Count" ReadOnly="true"  HeaderText="Count" DataField="Playlists.Count" />
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
        </Columns>
    </asp:GridView>
    <asp:TextBox ID="tbInsertName" runat="server" />
    <asp:Button Text="Insert" ID="btnInsert" runat="server" OnClick="btnInsert_Click" CssClass="btn btn-success" />

</asp:Content>
