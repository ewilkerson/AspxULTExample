
    <%@ Page Title="User Info Status&nbsp;Edit&nbsp;and&nbsp;Delete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoStatusEditDelete.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoStatuss.UserInfoStatusEditDelete" %>
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
    <asp:HiddenField ID="HiddenField_UserInfoStatusID" runat="server" />
    <asp:Label ID="LabelID" CssClass="form-label" Text="ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoStatusID" CssClass="form-label" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoStatusName" AssociatedControlID="TextBoxUserInfoStatusName"  CssClass="form-label" Text="User Info Status Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxUserInfoStatusName" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoStatusName" ControlToValidate="TextBoxUserInfoStatusName" runat="server" ErrorMessage="This User Info Status Name is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoStatusName" ControlToValidate="TextBoxUserInfoStatusName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Status Name cannot be null or empty or only have white space or 50 characters maximum." Text="*" CssClass="text-danger" />
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoStatusActiveYesNo" AssociatedControlID="CheckBoxUserInfoStatusActiveYesNo"  CssClass="form-label" Text="User Info Status Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:CheckBox ID="CheckBoxUserInfoStatusActiveYesNo" CssClass="form-control" runat="server" />
    </div>
    </div>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoStatuss/UserInfoStatusGridView2.aspx'; return false;" />
    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="<i class='bi bi-pencil-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Edit" />
    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-info" Text="<i class='bi bi-trash3'></i>&nbsp;Delete" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="javascript:return DeleteConfirm();" OnClick="Submit_Delete" />
    </div>
    </main>
    </asp:Content>
  