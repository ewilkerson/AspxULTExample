
    <%@ Page Title="Example Approve&nbsp;TelerikRadEdit&nbsp;and&nbsp;TelerikRadDelete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleApproveTelerikRadEditDelete.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.ExampleApproves.ExampleApproveTelerikRadEditDelete" %>
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
    <asp:HiddenField ID="HiddenField_ExampleApproveID" runat="server" />
    <asp:Label ID="LabelID" CssClass="form-label" Text="ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelExampleApproveID" CssClass="form-label" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelExampleID" AssociatedControlID="TextBoxExampleID"  CssClass="form-label" Text="Example ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxExampleID" CssClass="form-control" Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" runat="server" ></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorExampleID" ControlToValidate="TextBoxExampleID" runat="server" ErrorMessage="This Example ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelUserInfoID" AssociatedControlID="TextBoxUserInfoID"  CssClass="form-label" Text="User Info ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadNumericTextBox ID="TextBoxUserInfoID" CssClass="form-control" Type="Number" DataType="System.Int32" NumberFormat-DecimalDigits="0" runat="server" ></telerik:RadNumericTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoID" ControlToValidate="TextBoxUserInfoID" runat="server" ErrorMessage="This User Info ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
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
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../ExampleApproves/ExampleApproveTelerikRadGrid2.aspx'; return false;" />
    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="<i class='bi bi-pencil-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Edit" />
    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-info" Text="<i class='bi bi-trash3'></i>&nbsp;Delete" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="javascript:return DeleteConfirm();" OnClick="Submit_Delete" />
    </div>
    </section>
    </main>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
  