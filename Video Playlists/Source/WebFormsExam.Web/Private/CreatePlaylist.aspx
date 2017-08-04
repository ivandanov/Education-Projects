<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePlaylist.aspx.cs" Inherits="WebFormsExam.Web.Private.CreatePlaylist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PlaylistTitle" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PlaylistTitle" CssClass="form-control" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CategoryName" CssClass="col-md-2 control-label">Category Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CategoryName" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="VideoUrl" CssClass="col-md-2 control-label">Video Url</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="VideoUrl" CssClass="form-control" />
            </div>
        </div>
       
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreatePlaylist_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
   </div>
</asp:Content>
