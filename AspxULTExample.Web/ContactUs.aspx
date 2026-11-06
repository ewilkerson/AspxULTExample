
    <%@ Page Title="Contact&nbsp;Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ContactUs.aspx.cs" Inherits="AspxULTExample.Web.ContactUs" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title">
    <asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
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
    <h6>Questions or Comments</h6>
    <p>Do you have a question or comment? Use the form below.</p>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelFullName" AssociatedControlID="TextBoxFullName" CssClass="form-label" Text="Full Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxFullName" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFullName" ControlToValidate="TextBoxFullName" runat="server" ErrorMessage="This Full Name is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorFullName" ControlToValidate="TextBoxFullName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="Full Name cannot be null or empty or only have white space or 50 characters maximum." Text="*" CssClass="text-danger" />
    </div>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelEmailAddress" AssociatedControlID="TextBoxEmailAddress" CssClass="form-label" Text="Email Address:" runat="server"></asp:Label>
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
    <asp:Label ID="LabelComments" AssociatedControlID="TextBoxComments" CssClass="form-label" Text="Comments:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxComments" TextMode="multiline" Columns="50" Rows="3" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorComments" ControlToValidate="TextBoxComments" runat="server" ErrorMessage="This Comments is required." Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorComments" ControlToValidate="TextBoxComments" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,8000}$" ErrorMessage="Comments cannot be null or empty or only have white space or 8000 characters maximum." Text="*" CssClass="text-danger" />
    </div>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>Back&nbsp;to&nbsp;Home" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../'; return false;" />    
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="Submit_Create" />  
    </div>
    </main>
    </asp:Content>
  