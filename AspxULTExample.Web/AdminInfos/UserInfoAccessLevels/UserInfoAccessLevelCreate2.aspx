
    <%@ Page Title="User Info Access Level&nbsp;Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoAccessLevelCreate2.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoAccessLevels.UserInfoAccessLevelCreate2" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="text-bg-danger p-3" HeaderText="You must enter a value in the following fields:" runat="server" />
    </section>
    <section class="row">
    <br />
    </section>
    
    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoAccessLevelName" AssociatedControlID="TextBoxUserInfoAccessLevelName"  CssClass="form-label" Text="User Info Access Level Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxUserInfoAccessLevelName" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoAccessLevelName" ControlToValidate="TextBoxUserInfoAccessLevelName" runat="server" ErrorMessage="This User Info Access Level Name is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoAccessLevelName" ControlToValidate="TextBoxUserInfoAccessLevelName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Access Level Name cannot be null or empty or only have white space or 50 characters maximum." Text="*" CssClass="text-danger" />
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoAccessLevelNum" AssociatedControlID="TextBoxUserInfoAccessLevelNum"  CssClass="form-label" Text="User Info Access Level Num:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxUserInfoAccessLevelNum" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoAccessLevelNum" ControlToValidate="TextBoxUserInfoAccessLevelNum" runat="server" ErrorMessage="This User Info Access Level Num is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoAccessLevelNum" ControlToValidate="TextBoxUserInfoAccessLevelNum" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="User Info Access Level Num cannot be zero." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoAccessLevelActiveYesNo" AssociatedControlID="CheckBoxUserInfoAccessLevelActiveYesNo"  CssClass="form-label" Text="User Info Access Level Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:CheckBox ID="CheckBoxUserInfoAccessLevelActiveYesNo" CssClass="form-control" runat="server" />
    </div>
    </div>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoAccessLevels/UserInfoAccessLevelGridView2.aspx'; return false;" />
    &nbsp;
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Create" />
    </div>
    </main>
    </asp:Content>
  