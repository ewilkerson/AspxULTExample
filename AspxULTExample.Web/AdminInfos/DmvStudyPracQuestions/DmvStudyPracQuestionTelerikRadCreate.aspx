
    <%@ Page Title="Dmv Study Prac Question&nbsp;TelerikRadCreate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="DmvStudyPracQuestionTelerikRadCreate.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions.DmvStudyPracQuestionTelerikRadCreate" %>
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
    <asp:Label ID="LabelDmvStudyPracID" AssociatedControlID="TextBoxDmvStudyPracID"  CssClass="form-label" Text="Dmv Study Prac ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxDmvStudyPracID" CssClass="form-control" Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" runat="server" ></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDmvStudyPracID" ControlToValidate="TextBoxDmvStudyPracID" runat="server" ErrorMessage="This Dmv Study Prac ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDmvStudyPracQuestionText" AssociatedControlID="TextBoxDmvStudyPracQuestionText"  CssClass="form-label" Text="Dmv Study Prac Question Text:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxDmvStudyPracQuestionText" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDmvStudyPracQuestionText" ControlToValidate="TextBoxDmvStudyPracQuestionText" runat="server" ErrorMessage="This Dmv Study Prac Question Text is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorDmvStudyPracQuestionText" ControlToValidate="TextBoxDmvStudyPracQuestionText" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,500}$" ErrorMessage="Dmv Study Prac Question Text cannot be null or empty or only have white space or 500 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDmvStudyPracQuestionAnswerText" AssociatedControlID="TextBoxDmvStudyPracQuestionAnswerText"  CssClass="form-label" Text="Dmv Study Prac Question Answer Text:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxDmvStudyPracQuestionAnswerText" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDmvStudyPracQuestionAnswerText" ControlToValidate="TextBoxDmvStudyPracQuestionAnswerText" runat="server" ErrorMessage="This Dmv Study Prac Question Answer Text is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorDmvStudyPracQuestionAnswerText" ControlToValidate="TextBoxDmvStudyPracQuestionAnswerText" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,500}$" ErrorMessage="Dmv Study Prac Question Answer Text cannot be null or empty or only have white space or 500 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDmvStudyPracQuestionPicsYesNo" AssociatedControlID="CheckBoxDmvStudyPracQuestionPicsYesNo"  CssClass="form-label" Text="Dmv Study Prac Question Pics Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadCheckBox ID="CheckBoxDmvStudyPracQuestionPicsYesNo" runat="server" Text="" CssClass="form-control" AutoPostBack="false" ></telerik:RadCheckBox>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDmvStudyPracQuestionActiveYesNo" AssociatedControlID="CheckBoxDmvStudyPracQuestionActiveYesNo"  CssClass="form-label" Text="Dmv Study Prac Question Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadCheckBox ID="CheckBoxDmvStudyPracQuestionActiveYesNo" runat="server" Text="" CssClass="form-control" AutoPostBack="false" ></telerik:RadCheckBox>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../DmvStudyPracQuestions/DmvStudyPracQuestionTelerikRadGrid2.aspx'; return false;" />
    &nbsp;
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Create" />
    </div>
    </section>
    </main>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
  