
    <%@ Page Title="Example Log&nbsp;TelerikRadCreate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleLogTelerikRadCreate.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.ExampleLogs.ExampleLogTelerikRadCreate" %>
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
    <asp:Label ID="LabelLogMessage" AssociatedControlID="TextBoxLogMessage"  CssClass="form-label" Text="Log Message:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <telerik:RadTextBox ID="TextBoxLogMessage" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server"></telerik:RadTextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLogMessage" ControlToValidate="TextBoxLogMessage" runat="server" ErrorMessage="This Log Message is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorLogMessage" ControlToValidate="TextBoxLogMessage" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,2000}$" ErrorMessage="Log Message cannot be null or empty or only have white space or 2000 characters maximum." Text="*"  CssClass="text-danger"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../ExampleLogs/ExampleLogTelerikRadGrid2.aspx'; return false;" />
    &nbsp;
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Create" />
    </div>
    </section>
    </main>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
  