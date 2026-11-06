
    <%@ Page Title="Example&nbsp;GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleGridView.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.Examples.ExampleGridView" %>
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
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../Examples/ExampleCreate.aspx'; return false;" />    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <div class="table-responsive">
    <asp:GridView ID="ResultGridView" runat="server"
    AutoGenerateColumns="False"
    ShowFooter="False"
    DataKeyNames="ExampleID"
    AllowPaging="False"
    CellPadding="3"
    CellSpacing="2"
    OnPageIndexChanging="ResultGridView_PageIndexChanging"
    OnRowDeleting="ResultGridView_RowDeleting"
    OnRowEditing="ResultGridView_RowEditing"
    OnRowUpdating="ResultGridView_RowUpdating"
    OnRowCancelingEdit="ResultGridView_RowCancelingEdit"
    OnRowDataBound="ResultGridView_OnRowDataBound"
    GridLines="Vertical"
    CssClass="display"
    ShowHeaderWhenEmpty="true">
    <Columns>
    
    <asp:BoundField DataField="ExampleID" HeaderText="Example ID" InsertVisible="False"
    ReadOnly="True" SortExpression="ExampleID" />
  

    <asp:TemplateField HeaderText="Example User Info Status ID" SortExpression="ExampleUserInfoStatusID">
    <EditItemTemplate>
    <asp:TextBox ID="txtExampleUserInfoStatusID" Width="100px" runat="server" Text='<%# Bind("ExampleUserInfoStatusID") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorExampleUserInfoStatusID" ControlToValidate="txtExampleUserInfoStatusID" runat="server" ErrorMessage="This Example User Info Status ID is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorExampleUserInfoStatusID" ControlToValidate="txtExampleUserInfoStatusID" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="Example User Info Status ID cannot be zero." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelExampleUserInfoStatusID" runat="server" Text='<%# Bind("ExampleUserInfoStatusID") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Example User Info Company ID" SortExpression="ExampleUserInfoCompanyID">
    <EditItemTemplate>
    <asp:TextBox ID="txtExampleUserInfoCompanyID" Width="100px" runat="server" Text='<%# Bind("ExampleUserInfoCompanyID") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorExampleUserInfoCompanyID" ControlToValidate="txtExampleUserInfoCompanyID" runat="server" ErrorMessage="This Example User Info Company ID is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorExampleUserInfoCompanyID" ControlToValidate="txtExampleUserInfoCompanyID" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="Example User Info Company ID cannot be zero." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelExampleUserInfoCompanyID" runat="server" Text='<%# Bind("ExampleUserInfoCompanyID") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Title" SortExpression="Title">
    <EditItemTemplate>
    <asp:TextBox ID="txtTitle" Width="100px" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="txtTitle" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorTitle" ControlToValidate="txtTitle" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="Title cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Release" SortExpression="Release">
    <EditItemTemplate>
    <asp:TextBox ID="txtRelease" Width="100px" runat="server" Text='<%# Bind("Release") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRelease" ControlToValidate="txtRelease" runat="server" ErrorMessage="This Release is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorRelease" ControlToValidate="txtRelease" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="Release cannot be zero." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelRelease" runat="server" Text='<%# Bind("Release") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Release Date Time" SortExpression="ReleaseDateTime">
    <EditItemTemplate>
    <asp:TextBox ID="txtReleaseDateTime" Width="100px" runat="server" Text='<%# String.Format("{0:M/d/yyyy HH:mm:ss}",Eval("ReleaseDateTime")) %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseDateTime" ControlToValidate="txtReleaseDateTime" runat="server" ErrorMessage="This Release Date Time is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorReleaseDateTime" ControlToValidate="txtReleaseDateTime" ValidationExpression="^(?:(?:(?:0?[1-9]|1[0-2])\/(?:0?[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])\/(?:29|30)|(?:0[13578]|1[02])\/31)\/[1-9]\d{3}|0?2\/29(?:\/[1-9]\d(?:0[48]|[2468][048]|[13579][26])|(?:[2468][048]|[13579][26])00))\s(2[0-3]|[01]?[0-9]):([0-5]?[0-9])(:([0-5]?[0-9]))?$" ErrorMessage="Release Date Time cannot be date and time." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelReleaseDateTime" runat="server" Text='<%# String.Format("{0:M/d/yyyy HH:mm:ss}",Eval("ReleaseDateTime")) %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Genre" SortExpression="Genre">
    <EditItemTemplate>
    <asp:TextBox ID="txtGenre" Width="100px" runat="server" Text='<%# Bind("Genre") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGenre" ControlToValidate="txtGenre" runat="server" ErrorMessage="This 1 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorGenre" ControlToValidate="txtGenre" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,1}$" ErrorMessage="Genre cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelGenre" runat="server" Text='<%# Bind("Genre") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Price" SortExpression="Price">
    <EditItemTemplate>
    <asp:TextBox ID="txtPrice" Width="100px" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="txtPrice" runat="server" ErrorMessage="This Price is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorPrice" ControlToValidate="txtPrice" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,})?\s*$" ErrorMessage="Price cannot be zero." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Price Yes No" SortExpression="PriceYesNo">
    <EditItemTemplate>
    <asp:CheckBox ID="CheckBoxPriceYesNo" runat="server" Checked='<%# Bind("PriceYesNo") %>' />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:CheckBox ID="CheckBoxPriceYesNo" runat="server" Checked='<%# Bind("PriceYesNo") %>' Enabled="False" />
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Release Date" SortExpression="ReleaseDate">
    <EditItemTemplate>
    <asp:TextBox ID="txtReleaseDate" Width="100px" runat="server" Text='<%# String.Format("{0:M/d/yyyy}",Eval("ReleaseDate")) %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseDate" ControlToValidate="txtReleaseDate" runat="server" ErrorMessage="This Release Date is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorReleaseDate" ControlToValidate="txtReleaseDate" ValidationExpression="^(?:(?:(?:0?[1-9]|1[0-2])\/(?:0?[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])\/(?:29|30)|(?:0[13578]|1[02])\/31)\/[1-9]\d{3}|0?2\/29(?:\/[1-9]\d(?:0[48]|[2468][048]|[13579][26])|(?:[2468][048]|[13579][26])00))$" ErrorMessage="Release Date cannot be date." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelReleaseDate" runat="server" Text='<%# String.Format("{0:M/d/yyyy}",Eval("ReleaseDate")) %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Release Time" SortExpression="ReleaseTime">
    <EditItemTemplate>
    <asp:TextBox ID="txtReleaseTime" Width="100px" runat="server" Text='<%# String.Format("{0:hh\\:mm\\:ss}",Eval("ReleaseTime")) %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseTime" ControlToValidate="txtReleaseTime" runat="server" ErrorMessage="This Release Time is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorReleaseTime" ControlToValidate="txtReleaseTime" ValidationExpression="^(2[0-3]|[01]?[0-9]):([0-5]?[0-9])(:([0-5]?[0-9]))?$" ErrorMessage="Release Time cannot be time." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelReleaseTime" runat="server" Text='<%# String.Format("{0:hh\\:mm\\:ss}",Eval("ReleaseTime")) %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Message" SortExpression="Message">
    <EditItemTemplate>
    <asp:TextBox ID="txtMessage" TextMode="multiline" Columns="50" Rows="3" runat="server" Text='<%# Bind("Message") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" ControlToValidate="txtMessage" runat="server" ErrorMessage="This 4000 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorMessage" ControlToValidate="txtMessage" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,4000}$" ErrorMessage="Message cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelMessage" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Message2" SortExpression="Message2">
    <EditItemTemplate>
    <asp:TextBox ID="txtMessage2" TextMode="multiline" Columns="50" Rows="3" runat="server" Text='<%# Bind("Message2") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage2" ControlToValidate="txtMessage2" runat="server" ErrorMessage="This 8000 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorMessage2" ControlToValidate="txtMessage2" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,8000}$" ErrorMessage="Message2 cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelMessage2" runat="server" Text='<%# Bind("Message2") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Phone Number" SortExpression="PhoneNumber">
    <EditItemTemplate>
    <asp:TextBox ID="txtPhoneNumber" Width="100px" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" ControlToValidate="txtPhoneNumber" runat="server" ErrorMessage="This Phone Number is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPhoneNumber" ControlToValidate="txtPhoneNumber" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ErrorMessage="Phone Number cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Email Address" SortExpression="EmailAddress">
    <EditItemTemplate>
    <asp:TextBox ID="txtEmailAddress" Width="100px" runat="server" Text='<%# Bind("EmailAddress") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" ControlToValidate="txtEmailAddress" runat="server" ErrorMessage="This Email Address is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorEmailAddress" ControlToValidate="txtEmailAddress" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="Email Address cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelEmailAddress" runat="server" Text='<%# Bind("EmailAddress") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Credit Card" SortExpression="CreditCard">
    <EditItemTemplate>
    <asp:TextBox ID="txtCreditCard" Width="100px" runat="server" Text='<%# Bind("CreditCard") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreditCard" ControlToValidate="txtCreditCard" runat="server" ErrorMessage="This Credit Card is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorCreditCard" ControlToValidate="txtCreditCard" ValidationExpression="^(?:(4[0-9]{12}(?:[0-9]{3})?)|(5[1-5][0-9]{14})|(6(?:011|5[0-9]{2})[0-9]{12})|(3[47][0-9]{13})|(3(?:0[0-5]|[68][0-9])[0-9]{11})|((?:2131|1800|35[0-9]{3})[0-9]{11}))$" ErrorMessage="Credit Card cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelCreditCard" runat="server" Text='<%# Bind("CreditCard") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Password" SortExpression="Password">
    <EditItemTemplate>
    <asp:TextBox ID="txtPassword" Width="100px" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ControlToValidate="txtPassword" runat="server" ErrorMessage="This Password is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPassword" ControlToValidate="txtPassword" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,100}$" ErrorMessage="Password cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelPassword" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Url" SortExpression="Url">
    <EditItemTemplate>
    <asp:TextBox ID="txtUrl" Width="100px" runat="server" Text='<%# Bind("Url") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUrl" ControlToValidate="txtUrl" runat="server" ErrorMessage="This Url is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUrl" ControlToValidate="txtUrl" ValidationExpression="^(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$" ErrorMessage="Url cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUrl" runat="server" Text='<%# Bind("Url") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Example Active Yes No" SortExpression="ExampleActiveYesNo">
    <EditItemTemplate>
    <asp:CheckBox ID="CheckBoxExampleActiveYesNo" runat="server" Checked='<%# Bind("ExampleActiveYesNo") %>' />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:CheckBox ID="CheckBoxExampleActiveYesNo" runat="server" Checked='<%# Bind("ExampleActiveYesNo") %>' Enabled="False" />
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:HyperLinkField DataNavigateUrlFields="ExampleID" DataNavigateUrlFormatString="../Examples/ExampleDetails.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
    <asp:TemplateField HeaderText="Edit" ShowHeader="False">
    <EditItemTemplate>
    <span style="white-space: nowrap;">
    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="<span class='btn btn-info'><i class='bi bi-pencil-square'></i>&nbsp;Update</span>"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="<span class='btn btn-info'><i class='bi bi-x-square'></i>&nbsp;Cancel</span>"></asp:LinkButton>
    </span>
    </EditItemTemplate>
    <ItemTemplate>
    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-pencil-square'></i>&nbsp;Edit</span>"></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" DeleteText="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-trash3'></i>&nbsp;Delete</span>"/>
    </Columns>
    </asp:GridView>
    </div>
    </section>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;Admin&nbsp;Info" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../AdminInfo.aspx'; return false;" />
    </div>
    </main>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script>
    $(document).ready(function () {

    $('#<%= ResultGridView.ClientID %>').DataTable({
    pagingType: 'full_numbers',
    scrollX: true,
    ordering: false
    });
    });
    </script>
    </asp:Content>
  