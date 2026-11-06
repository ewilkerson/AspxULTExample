
    <%@ Page Title="User Info Countries&nbsp;TelerikRadDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoCountriesTelerikRadDetails.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoCountriess.UserInfoCountriesTelerikRadDetails" %>
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
    <asp:HiddenField ID="HiddenField_UserInfoCountriesID" runat="server" />
    <asp:Label ID="LabelDisplayNameForUserInfoCountriesID" CssClass="form-label" Text="User Info Countries ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoCountriesID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoCountriesName" CssClass="form-label" Text="User Info Countries Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoCountriesName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoCountriesActiveYesNo" CssClass="form-label" Text="User Info Countries Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoCountriesActiveYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoCountriess/UserInfoCountriesTelerikRadGrid2.aspx'; return false;" />
    </div>
    </main>
    </asp:Content>
  