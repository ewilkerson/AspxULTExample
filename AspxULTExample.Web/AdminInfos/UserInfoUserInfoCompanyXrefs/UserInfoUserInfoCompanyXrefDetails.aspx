
    <%@ Page Title="User Info User Info Company Xref&nbsp;Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoUserInfoCompanyXrefDetails.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoUserInfoCompanyXrefs.UserInfoUserInfoCompanyXrefDetails" %>
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
    <asp:HiddenField ID="HiddenField_UserInfoUserInfoCompanyXrefID" runat="server" />
    <asp:Label ID="LabelDisplayNameForUserInfoUserInfoCompanyXrefID" CssClass="form-label" Text="User Info User Info Company Xref ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoUserInfoCompanyXrefID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
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
    <asp:Label ID="LabelDisplayNameForUserInfoCompanyID" CssClass="form-label" Text="User Info Company ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoCompanyID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo" CssClass="form-label" Text="User Info User Info Company Xref Email Address Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoUserInfoCompanyXrefActiveYesNo" CssClass="form-label" Text="User Info User Info Company Xref Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoUserInfoCompanyXrefActiveYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefGridView.aspx'; return false;" />
    </div>
    </main>
    </asp:Content>
  