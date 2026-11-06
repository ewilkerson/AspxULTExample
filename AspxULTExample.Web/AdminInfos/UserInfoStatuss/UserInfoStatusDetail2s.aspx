
    <%@ Page Title="User Info Status&nbsp;Detail2s" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoStatusDetail2s.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoStatuss.UserInfoStatusDetail2s" %>
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
    <asp:HiddenField ID="HiddenField_UserInfoStatusID" runat="server" />
    <asp:Label ID="LabelDisplayNameForUserInfoStatusID" CssClass="form-label" Text="User Info Status ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoStatusID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoStatusName" CssClass="form-label" Text="User Info Status Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoStatusName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoStatusActiveYesNo" CssClass="form-label" Text="User Info Status Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoStatusActiveYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoStatuss/UserInfoStatusGridView2.aspx'; return false;" />
    </div>
    </main>
    </asp:Content>
  