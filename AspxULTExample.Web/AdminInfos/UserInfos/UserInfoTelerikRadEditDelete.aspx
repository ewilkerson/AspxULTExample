
    <%@ Page Title="User Info&nbsp;TelerikRadEdit&nbsp;and&nbsp;TelerikRadDelete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoTelerikRadEditDelete.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfos.UserInfoTelerikRadEditDelete" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

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
    <asp:HiddenField ID="HiddenField_UserInfoID" runat="server" />
    <asp:Label ID="LabelID" CssClass="form-label" Text="ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoID" CssClass="form-label" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoUserIdentityName" AssociatedControlID="TextBoxUserInfoUserIdentityName"  CssClass="form-label" Text="User Info User Identity Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoUserIdentityName" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoUserIdentityName" ControlToValidate="TextBoxUserInfoUserIdentityName" runat="server" ErrorMessage="This User Info User Identity Name is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoUserIdentityName" ControlToValidate="TextBoxUserInfoUserIdentityName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info User Identity Name cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoUserName" AssociatedControlID="TextBoxUserInfoUserName"  CssClass="form-label" Text="User Info User Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoUserName" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoUserName" ControlToValidate="TextBoxUserInfoUserName" runat="server" ErrorMessage="This User Info User Name is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoUserName" ControlToValidate="TextBoxUserInfoUserName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info User Name cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoFullName" AssociatedControlID="TextBoxUserInfoFullName"  CssClass="form-label" Text="User Info Full Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoFullName" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoFullName" ControlToValidate="TextBoxUserInfoFullName" runat="server" ErrorMessage="This User Info Full Name is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoFullName" ControlToValidate="TextBoxUserInfoFullName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Full Name cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoEmailAddress" AssociatedControlID="TextBoxUserInfoEmailAddress"  CssClass="form-label" Text="User Info Email Address:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoEmailAddress" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoEmailAddress" ControlToValidate="TextBoxUserInfoEmailAddress" runat="server" ErrorMessage="This User Info Email Address is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoEmailAddress" ControlToValidate="TextBoxUserInfoEmailAddress" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="User Info Email Address cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoJobTitle" AssociatedControlID="TextBoxUserInfoJobTitle"  CssClass="form-label" Text="User Info Job Title:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoJobTitle" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoJobTitle" ControlToValidate="TextBoxUserInfoJobTitle" runat="server" ErrorMessage="This User Info Job Title is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoJobTitle" ControlToValidate="TextBoxUserInfoJobTitle" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Job Title cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoActiveYesNo" AssociatedControlID="CheckBoxUserInfoActiveYesNo"  CssClass="form-label" Text="User Info Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadCheckBox ID="CheckBoxUserInfoActiveYesNo" runat="server" Text="" CssClass="form-control" AutoPostBack="false" ></telerik:RadCheckBox>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfos/UserInfoTelerikRadGrid2.aspx'; return false;" />
    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="<i class='bi bi-pencil-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Edit" />
    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-info" Text="<i class='bi bi-trash3'></i>&nbsp;Delete" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="javascript:return DeleteConfirm();" OnClick="Submit_Delete" />
    </div>
    </section>
    </main>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
  