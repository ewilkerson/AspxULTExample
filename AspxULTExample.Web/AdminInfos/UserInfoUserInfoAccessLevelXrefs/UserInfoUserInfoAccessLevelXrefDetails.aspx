
    <%@ Page Title="User Info User Info Access Level Xref&nbsp;Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoUserInfoAccessLevelXrefDetails.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoUserInfoAccessLevelXrefs.UserInfoUserInfoAccessLevelXrefDetails" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <br />
    </section>
    
    <section class="row">
    <div class="col-auto">
    <asp:HiddenField ID="HiddenField_UserInfoUserInfoAccessLevelXrefID" runat="server" />
    <asp:Label ID="LabelDisplayNameForUserInfoUserInfoAccessLevelXrefID" CssClass="form-label" Text="User Info User Info Access Level Xref ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoUserInfoAccessLevelXrefID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoID" CssClass="form-label" Text="User Info ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoAccessLevelID" CssClass="form-label" Text="User Info Access Level ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoAccessLevelID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoUserInfoAccessLevelXrefActiveYesNo" CssClass="form-label" Text="User Info User Info Access Level Xref Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoUserInfoAccessLevelXrefActiveYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefGridView.aspx'; return false;" />
    </div>
    </main>
    </asp:Content>
  