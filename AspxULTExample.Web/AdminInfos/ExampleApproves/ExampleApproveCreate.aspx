
    <%@ Page Title="Example Approve&nbsp;Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleApproveCreate.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.ExampleApproves.ExampleApproveCreate" %>
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
    <asp:Label ID="LabelExampleID" AssociatedControlID="TextBoxExampleID"  CssClass="form-label" Text="Example ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxExampleID" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorExampleID" ControlToValidate="TextBoxExampleID" runat="server" ErrorMessage="This Example ID is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorExampleID" ControlToValidate="TextBoxExampleID" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="Example ID cannot be zero." Text="*"  CssClass="text-danger"/>
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
    <asp:Label ID="LabelUserInfoJobTitle" AssociatedControlID="TextBoxUserInfoJobTitle"  CssClass="form-label" Text="User Info Job Title:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxUserInfoJobTitle" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoJobTitle" ControlToValidate="TextBoxUserInfoJobTitle" runat="server" ErrorMessage="This User Info Job Title is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoJobTitle" ControlToValidate="TextBoxUserInfoJobTitle" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Job Title cannot be null or empty or only have white space or 50 characters maximum." Text="*" CssClass="text-danger" />
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../ExampleApproves/ExampleApproveGridView.aspx'; return false;" />
    &nbsp;
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Create" />
    </div>
    </main>
    </asp:Content>
  