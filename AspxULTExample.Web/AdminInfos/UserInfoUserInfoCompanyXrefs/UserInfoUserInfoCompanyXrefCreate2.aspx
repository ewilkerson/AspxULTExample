
    <%@ Page Title="User Info User Info Company Xref&nbsp;Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoUserInfoCompanyXrefCreate2.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoUserInfoCompanyXrefs.UserInfoUserInfoCompanyXrefCreate2" %>
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
    <asp:Label ID="LabelUserInfoID" AssociatedControlID="TextBoxUserInfoID"  CssClass="form-label" Text="User Info ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxUserInfoID" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoID" ControlToValidate="TextBoxUserInfoID" runat="server" ErrorMessage="This User Info ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoID" ControlToValidate="TextBoxUserInfoID" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="User Info ID cannot be zero." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyID" AssociatedControlID="TextBoxUserInfoCompanyID"  CssClass="form-label" Text="User Info Company ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxUserInfoCompanyID" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyID" ControlToValidate="TextBoxUserInfoCompanyID" runat="server" ErrorMessage="This User Info Company ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyID" ControlToValidate="TextBoxUserInfoCompanyID" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="User Info Company ID cannot be zero." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo" AssociatedControlID="CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"  CssClass="form-label" Text="User Info User Info Company Xref Email Address Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:CheckBox ID="CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo" CssClass="form-control" runat="server" />
    </div>
    </div>
    <section class="row">
    <br />
    </section>
  

    <div class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoUserInfoCompanyXrefActiveYesNo" AssociatedControlID="CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo"  CssClass="form-label" Text="User Info User Info Company Xref Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:CheckBox ID="CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo" CssClass="form-control" runat="server" />
    </div>
    </div>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefGridView2.aspx'; return false;" />
    &nbsp;
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Create" />
    </div>
    </main>
    </asp:Content>
  