
    <%@ Page Title="User Info Company&nbsp;TelerikRadEdit&nbsp;and&nbsp;TelerikRadDelete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoCompanyTelerikRadEditDelete.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoCompanys.UserInfoCompanyTelerikRadEditDelete" %>
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
    <asp:HiddenField ID="HiddenField_UserInfoCompanyID" runat="server" />
    <asp:Label ID="LabelID" CssClass="form-label" Text="ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyID" CssClass="form-label" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyEIN" AssociatedControlID="TextBoxUserInfoCompanyEIN"  CssClass="form-label" Text="User Info Company EIN:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoCompanyEIN" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyEIN" ControlToValidate="TextBoxUserInfoCompanyEIN" runat="server" ErrorMessage="This User Info Company EIN is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyEIN" ControlToValidate="TextBoxUserInfoCompanyEIN" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Company EIN cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyName" AssociatedControlID="TextBoxUserInfoCompanyName"  CssClass="form-label" Text="User Info Company Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoCompanyName" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyName" ControlToValidate="TextBoxUserInfoCompanyName" runat="server" ErrorMessage="This User Info Company Name is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyName" ControlToValidate="TextBoxUserInfoCompanyName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,200}$" ErrorMessage="User Info Company Name cannot be null or empty or only have white space or 200 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyAddress1" AssociatedControlID="TextBoxUserInfoCompanyAddress1"  CssClass="form-label" Text="User Info Company Address1:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoCompanyAddress1" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyAddress1" ControlToValidate="TextBoxUserInfoCompanyAddress1" runat="server" ErrorMessage="This User Info Company Address1 is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyAddress1" ControlToValidate="TextBoxUserInfoCompanyAddress1" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,60}$" ErrorMessage="User Info Company Address1 cannot be null or empty or only have white space or 60 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyAddress2" AssociatedControlID="TextBoxUserInfoCompanyAddress2"  CssClass="form-label" Text="User Info Company Address2:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoCompanyAddress2" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyAddress2" ControlToValidate="TextBoxUserInfoCompanyAddress2" runat="server" ErrorMessage="This User Info Company Address2 is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyAddress2" ControlToValidate="TextBoxUserInfoCompanyAddress2" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,60}$" ErrorMessage="User Info Company Address2 cannot be null or empty or only have white space or 60 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyCityStateZip" AssociatedControlID="TextBoxUserInfoCompanyCityStateZip"  CssClass="form-label" Text="User Info Company City State Zip:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoCompanyCityStateZip" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyCityStateZip" ControlToValidate="TextBoxUserInfoCompanyCityStateZip" runat="server" ErrorMessage="This User Info Company City State Zip is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyCityStateZip" ControlToValidate="TextBoxUserInfoCompanyCityStateZip" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,60}$" ErrorMessage="User Info Company City State Zip cannot be null or empty or only have white space or 60 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyTelephone" AssociatedControlID="TextBoxUserInfoCompanyTelephone"  CssClass="form-label" Text="User Info Company Telephone:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoCompanyTelephone" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyTelephone" ControlToValidate="TextBoxUserInfoCompanyTelephone" runat="server" ErrorMessage="This User Info Company Telephone is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyTelephone" ControlToValidate="TextBoxUserInfoCompanyTelephone" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Company Telephone cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyEmailAddress" AssociatedControlID="TextBoxUserInfoCompanyEmailAddress"  CssClass="form-label" Text="User Info Company Email Address:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserInfoCompanyEmailAddress" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyEmailAddress" ControlToValidate="TextBoxUserInfoCompanyEmailAddress" runat="server" ErrorMessage="This User Info Company Email Address is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyEmailAddress" ControlToValidate="TextBoxUserInfoCompanyEmailAddress" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="User Info Company Email Address cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserCompanyWebsiteAddress" AssociatedControlID="TextBoxUserCompanyWebsiteAddress"  CssClass="form-label" Text="User Company Website Address:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUserCompanyWebsiteAddress" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserCompanyWebsiteAddress" ControlToValidate="TextBoxUserCompanyWebsiteAddress" runat="server" ErrorMessage="This User Company Website Address is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserCompanyWebsiteAddress" ControlToValidate="TextBoxUserCompanyWebsiteAddress" ValidationExpression="^(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$" ErrorMessage="User Company Website Address cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCountriesID" AssociatedControlID="TextBoxUserInfoCountriesID"  CssClass="form-label" Text="User Info Countries ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxUserInfoCountriesID" CssClass="form-control" Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" runat="server" ></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCountriesID" ControlToValidate="TextBoxUserInfoCountriesID" runat="server" ErrorMessage="This User Info Countries ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoCompanyActiveYesNo" AssociatedControlID="CheckBoxUserInfoCompanyActiveYesNo"  CssClass="form-label" Text="User Info Company Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadCheckBox ID="CheckBoxUserInfoCompanyActiveYesNo" runat="server" Text="" CssClass="form-control" AutoPostBack="false" ></telerik:RadCheckBox>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoCompanys/UserInfoCompanyTelerikRadGrid2.aspx'; return false;" />
    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="<i class='bi bi-pencil-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Edit" />
    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-info" Text="<i class='bi bi-trash3'></i>&nbsp;Delete" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="javascript:return DeleteConfirm();" OnClick="Submit_Delete" />
    </div>
    </section>
    </main>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
  