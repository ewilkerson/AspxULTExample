
    <%@ Page Title="Example&nbsp;TelerikRadEdit&nbsp;and&nbsp;TelerikRadDelete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleTelerikRadEditDelete.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.Examples.ExampleTelerikRadEditDelete" %>
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
    <asp:HiddenField ID="HiddenField_ExampleID" runat="server" />
    <asp:Label ID="LabelID" CssClass="form-label" Text="ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelExampleID" CssClass="form-label" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelExampleUserInfoStatusID" AssociatedControlID="TextBoxExampleUserInfoStatusID"  CssClass="form-label" Text="Example User Info Status ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxExampleUserInfoStatusID" CssClass="form-control" Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" runat="server" ></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorExampleUserInfoStatusID" ControlToValidate="TextBoxExampleUserInfoStatusID" runat="server" ErrorMessage="This Example User Info Status ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelExampleUserInfoCompanyID" AssociatedControlID="TextBoxExampleUserInfoCompanyID"  CssClass="form-label" Text="Example User Info Company ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxExampleUserInfoCompanyID" CssClass="form-control" Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" runat="server" ></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorExampleUserInfoCompanyID" ControlToValidate="TextBoxExampleUserInfoCompanyID" runat="server" ErrorMessage="This Example User Info Company ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelTitle" AssociatedControlID="TextBoxTitle"  CssClass="form-label" Text="Title:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxTitle" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxTitle" runat="server" ErrorMessage="This Title is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorTitle" ControlToValidate="TextBoxTitle" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="Title cannot be null or empty or only have white space or 50 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelRelease" AssociatedControlID="TextBoxRelease"  CssClass="form-label" Text="Release:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxRelease" CssClass="form-control" Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" runat="server" ></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRelease" ControlToValidate="TextBoxRelease" runat="server" ErrorMessage="This Release is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelReleaseDateTime" AssociatedControlID="TextBoxReleaseDateTime"  CssClass="form-label" Text="Release Date Time:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadDateTimePicker ID="TextBoxReleaseDateTime" CssClass="form-control"  runat="server">
    <DateInput DateFormat="M/d/yyyy HH:mm:ss" DisplayDateFormat="M/d/yyyy HH:mm:ss"  ></DateInput>
    </telerik:RadDateTimePicker>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseDateTime" ControlToValidate="TextBoxReleaseDateTime" runat="server" ErrorMessage="This Release Date Time is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelGenre" AssociatedControlID="TextBoxGenre"  CssClass="form-label" Text="Genre:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxGenre" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGenre" ControlToValidate="TextBoxGenre" runat="server" ErrorMessage="This Genre is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorGenre" ControlToValidate="TextBoxGenre" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,1}$" ErrorMessage="Genre cannot be null or empty or only have white space or 1 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelPrice" AssociatedControlID="TextBoxPrice"  CssClass="form-label" Text="Price:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxPrice" CssClass="form-control" Type="Number" DataType="System.Double" NumberFormat-DecimalDigits="2" runat="server"></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="TextBoxPrice" runat="server" ErrorMessage="This Price is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelPriceYesNo" AssociatedControlID="CheckBoxPriceYesNo"  CssClass="form-label" Text="Price Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadCheckBox ID="CheckBoxPriceYesNo" runat="server" Text="" CssClass="form-control" AutoPostBack="false" ></telerik:RadCheckBox>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelReleaseDate" AssociatedControlID="TextBoxReleaseDate"  CssClass="form-label" Text="Release Date:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadDatePicker ID="TextBoxReleaseDate" CssClass="form-control"   runat="server">
    <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy"></DateInput>
    </telerik:RadDatePicker>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseDate" ControlToValidate="TextBoxReleaseDate" runat="server" ErrorMessage="This Release Date is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelReleaseTime" AssociatedControlID="TextBoxReleaseTime"  CssClass="form-label" Text="Release Time:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTimePicker ID="TextBoxReleaseTime" CssClass="form-control"   runat="server">
    <DateInput DateFormat="HH:mm:ss" DisplayDateFormat="HH:mm:ss"></DateInput>
    <TimeView TimeFormat="HH\:mm\:ss" Interval="00:10:00" Columns="6"></TimeView>
    </telerik:RadTimePicker>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseTime" ControlToValidate="TextBoxReleaseTime" runat="server" ErrorMessage="This Release Time is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelMessage" AssociatedControlID="TextBoxMessage"  CssClass="form-label" Text="Message:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxMessage" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" ControlToValidate="TextBoxMessage" runat="server" ErrorMessage="This Message is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorMessage" ControlToValidate="TextBoxMessage" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,4000}$" ErrorMessage="Message cannot be null or empty or only have white space or 4000 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelMessage2" AssociatedControlID="TextBoxMessage2"  CssClass="form-label" Text="Message2:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxMessage2" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage2" ControlToValidate="TextBoxMessage2" runat="server" ErrorMessage="This Message2 is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorMessage2" ControlToValidate="TextBoxMessage2" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,8000}$" ErrorMessage="Message2 cannot be null or empty or only have white space or 8000 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelPhoneNumber" AssociatedControlID="TextBoxPhoneNumber"  CssClass="form-label" Text="Phone Number:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxPhoneNumber" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" ControlToValidate="TextBoxPhoneNumber" runat="server" ErrorMessage="This Phone Number is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPhoneNumber" ControlToValidate="TextBoxPhoneNumber" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ErrorMessage="Phone Number cannot be null or empty or only have white space or 100 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelEmailAddress" AssociatedControlID="TextBoxEmailAddress"  CssClass="form-label" Text="Email Address:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxEmailAddress" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" ControlToValidate="TextBoxEmailAddress" runat="server" ErrorMessage="This Email Address is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorEmailAddress" ControlToValidate="TextBoxEmailAddress" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="Email Address cannot be null or empty or only have white space or 100 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelCreditCard" AssociatedControlID="TextBoxCreditCard"  CssClass="form-label" Text="Credit Card:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxCreditCard" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreditCard" ControlToValidate="TextBoxCreditCard" runat="server" ErrorMessage="This Credit Card is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorCreditCard" ControlToValidate="TextBoxCreditCard" ValidationExpression="^(?:(4[0-9]{12}(?:[0-9]{3})?)|(5[1-5][0-9]{14})|(6(?:011|5[0-9]{2})[0-9]{12})|(3[47][0-9]{13})|(3(?:0[0-5]|[68][0-9])[0-9]{11})|((?:2131|1800|35[0-9]{3})[0-9]{11}))$" ErrorMessage="Credit Card cannot be null or empty or only have white space or 100 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelPassword" AssociatedControlID="TextBoxPassword"  CssClass="form-label" Text="Password:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxPassword" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ControlToValidate="TextBoxPassword" runat="server" ErrorMessage="This Password is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPassword" ControlToValidate="TextBoxPassword" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,100}$" ErrorMessage="Password cannot be null or empty or only have white space or 100 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUrl" AssociatedControlID="TextBoxUrl"  CssClass="form-label" Text="Url:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxUrl" CssClass="form-control"  runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUrl" ControlToValidate="TextBoxUrl" runat="server" ErrorMessage="This Url is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUrl" ControlToValidate="TextBoxUrl" ValidationExpression="^(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$" ErrorMessage="Url cannot be null or empty or only have white space or 100 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelExampleActiveYesNo" AssociatedControlID="CheckBoxExampleActiveYesNo"  CssClass="form-label" Text="Example Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadCheckBox ID="CheckBoxExampleActiveYesNo" runat="server" Text="" CssClass="form-control" AutoPostBack="false" ></telerik:RadCheckBox>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../Examples/ExampleTelerikRadGrid2.aspx'; return false;" />
    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="<i class='bi bi-pencil-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Edit" />
    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-info" Text="<i class='bi bi-trash3'></i>&nbsp;Delete" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="javascript:return DeleteConfirm();" OnClick="Submit_Delete" />
    </div>
    </section>
    </main>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
  