
    <%@ Page Title="Example&nbsp;Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ViewExampleCreate2.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.ViewExamples.ViewExampleCreate2" %>
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
    <asp:HiddenField ID="HiddenField_ExampleUserInfoStatusID" runat="server" />
    <asp:Label ID="LabelExampleUserInfoStatusID" CssClass="form-label" Text="Status:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelExampleStatusName" CssClass="form-label" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelExampleUserInfoCompanyID" AssociatedControlID="DropDownListExampleUserInfoCompanyID"  CssClass="form-label" Text="Example User Info Company ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:DropDownList id="DropDownListExampleUserInfoCompanyID" CssClass="form-select"
    runat="server"  DropDownAutoWidth="Enabled"></asp:DropDownList>
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
    <asp:TextBox ID="TextBoxTitle" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxTitle" runat="server" ErrorMessage="This Title is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorTitle" ControlToValidate="TextBoxTitle" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="Title cannot be null or empty or only have white space or 50 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxRelease" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRelease" ControlToValidate="TextBoxRelease" runat="server" ErrorMessage="This Release is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorRelease" ControlToValidate="TextBoxRelease" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="Release cannot be zero." Text="*"  CssClass="text-danger"/>
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
    <asp:TextBox ID="TextBoxReleaseDateTime" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseDateTime" ControlToValidate="TextBoxReleaseDateTime" runat="server" ErrorMessage="This Release Date Time is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorReleaseDateTime" ControlToValidate="TextBoxReleaseDateTime" ValidationExpression="^(?:(?:(?:0?[1-9]|1[0-2])\/(?:0?[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])\/(?:29|30)|(?:0[13578]|1[02])\/31)\/[1-9]\d{3}|0?2\/29(?:\/[1-9]\d(?:0[48]|[2468][048]|[13579][26])|(?:[2468][048]|[13579][26])00))\s(2[0-3]|[01]?[0-9]):([0-5]?[0-9])(:([0-5]?[0-9]))?$" ErrorMessage="Release Date Time cannot be date and time." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxGenre" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGenre" ControlToValidate="TextBoxGenre" runat="server" ErrorMessage="This Genre is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorGenre" ControlToValidate="TextBoxGenre" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,1}$" ErrorMessage="Genre cannot be null or empty or only have white space or 1 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxPrice" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="TextBoxPrice" runat="server" ErrorMessage="This Price is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPrice" ControlToValidate="TextBoxPrice" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,})?\s*$" ErrorMessage="Price cannot be zero." Text="*" CssClass="text-danger" />
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div class="row">
    <div class="col-auto">
    <asp:Label ID="LabelPriceYesNo" AssociatedControlID="CheckBoxPriceYesNo"  CssClass="form-label" Text="Price Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:CheckBox ID="CheckBoxPriceYesNo" CssClass="form-control" runat="server" />
    </div>
    </div>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelReleaseDate" AssociatedControlID="TextBoxReleaseDate"  CssClass="form-label" Text="Release Date:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxReleaseDate" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseDate" ControlToValidate="TextBoxReleaseDate" runat="server" ErrorMessage="This Release Date is required." Text="*" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorReleaseDate" ControlToValidate="TextBoxReleaseDate" ValidationExpression="^(?:(?:(?:0?[1-9]|1[0-2])\/(?:0?[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])\/(?:29|30)|(?:0[13578]|1[02])\/31)\/[1-9]\d{3}|0?2\/29(?:\/[1-9]\d(?:0[48]|[2468][048]|[13579][26])|(?:[2468][048]|[13579][26])00))$" ErrorMessage="Release Date cannot be date." Text="*" />
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
    <asp:TextBox ID="TextBoxReleaseTime" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseTime" ControlToValidate="TextBoxReleaseTime" runat="server" ErrorMessage="This Release Time is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorReleaseTime" ControlToValidate="TextBoxReleaseTime" ValidationExpression="^(2[0-3]|[01]?[0-9]):([0-5]?[0-9])(:([0-5]?[0-9]))?$" ErrorMessage="Release Time cannot be time." Text="*" CssClass="text-danger"/>
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
    <asp:TextBox ID="TextBoxMessage" TextMode="multiline" Columns="50" Rows="3" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" ControlToValidate="TextBoxMessage" runat="server" ErrorMessage="This Message is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorMessage" ControlToValidate="TextBoxMessage" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,4000}$" ErrorMessage="Message cannot be null or empty or only have white space or 4000 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxMessage2" TextMode="multiline" Columns="50" Rows="3" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage2" ControlToValidate="TextBoxMessage2" runat="server" ErrorMessage="This Message2 is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorMessage2" ControlToValidate="TextBoxMessage2" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,8000}$" ErrorMessage="Message2 cannot be null or empty or only have white space or 8000 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxPhoneNumber" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" ControlToValidate="TextBoxPhoneNumber" runat="server" ErrorMessage="This Phone Number is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPhoneNumber" ControlToValidate="TextBoxPhoneNumber" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ErrorMessage="Phone Number cannot be null or empty or only have white space or 100 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxEmailAddress" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" ControlToValidate="TextBoxEmailAddress" runat="server" ErrorMessage="This Email Address is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorEmailAddress" ControlToValidate="TextBoxEmailAddress" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="Email Address cannot be null or empty or only have white space or 100 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxCreditCard" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreditCard" ControlToValidate="TextBoxCreditCard" runat="server" ErrorMessage="This Credit Card is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorCreditCard" ControlToValidate="TextBoxCreditCard" ValidationExpression="^(?:(4[0-9]{12}(?:[0-9]{3})?)|(5[1-5][0-9]{14})|(6(?:011|5[0-9]{2})[0-9]{12})|(3[47][0-9]{13})|(3(?:0[0-5]|[68][0-9])[0-9]{11})|((?:2131|1800|35[0-9]{3})[0-9]{11}))$" ErrorMessage="Credit Card cannot be null or empty or only have white space or 100 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxPassword" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ControlToValidate="TextBoxPassword" runat="server" ErrorMessage="This Password is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPassword" ControlToValidate="TextBoxPassword" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,100}$" ErrorMessage="Password cannot be null or empty or only have white space or 100 characters maximum." Text="*" CssClass="text-danger" />
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
    <asp:TextBox ID="TextBoxUrl" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUrl" ControlToValidate="TextBoxUrl" runat="server" ErrorMessage="This Url is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUrl" ControlToValidate="TextBoxUrl" ValidationExpression="^(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$" ErrorMessage="Url cannot be null or empty or only have white space or 100 characters maximum." Text="*" CssClass="text-danger" />
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div class="row">
    <div class="col-auto">
    <asp:Label ID="LabelExampleActiveYesNo" AssociatedControlID="CheckBoxExampleActiveYesNo"  CssClass="form-label" Text="Example Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:CheckBox ID="CheckBoxExampleActiveYesNo" CssClass="form-control" runat="server" />
    </div>
    </div>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../ViewExamples/ViewExampleGridView2.aspx'; return false;" />
    &nbsp;
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Create" />
    </div>
    </main>
    </asp:Content>
  