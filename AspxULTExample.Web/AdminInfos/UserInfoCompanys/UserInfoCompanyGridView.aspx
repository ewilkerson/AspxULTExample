
    <%@ Page Title="User Info Company&nbsp;GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoCompanyGridView.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoCompanys.UserInfoCompanyGridView" %>
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
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoCompanys/UserInfoCompanyCreate.aspx'; return false;" />    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <div class="table-responsive">
    <asp:GridView ID="ResultGridView" runat="server"
    AutoGenerateColumns="False"
    ShowFooter="False"
    DataKeyNames="UserInfoCompanyID"
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
    
    <asp:BoundField DataField="UserInfoCompanyID" HeaderText="User Info Company ID" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyID" />
  

    <asp:TemplateField HeaderText="User Info Company EIN" SortExpression="UserInfoCompanyEIN">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCompanyEIN" Width="100px" runat="server" Text='<%# Bind("UserInfoCompanyEIN") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyEIN" ControlToValidate="txtUserInfoCompanyEIN" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyEIN" ControlToValidate="txtUserInfoCompanyEIN" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Company EIN cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCompanyEIN" runat="server" Text='<%# Bind("UserInfoCompanyEIN") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Company Name" SortExpression="UserInfoCompanyName">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCompanyName" TextMode="multiline" Columns="50" Rows="3" runat="server" Text='<%# Bind("UserInfoCompanyName") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyName" ControlToValidate="txtUserInfoCompanyName" runat="server" ErrorMessage="This 200 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyName" ControlToValidate="txtUserInfoCompanyName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,200}$" ErrorMessage="User Info Company Name cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCompanyName" runat="server" Text='<%# Bind("UserInfoCompanyName") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Company Address1" SortExpression="UserInfoCompanyAddress1">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCompanyAddress1" Width="100px" runat="server" Text='<%# Bind("UserInfoCompanyAddress1") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyAddress1" ControlToValidate="txtUserInfoCompanyAddress1" runat="server" ErrorMessage="This 60 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyAddress1" ControlToValidate="txtUserInfoCompanyAddress1" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,60}$" ErrorMessage="User Info Company Address1 cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCompanyAddress1" runat="server" Text='<%# Bind("UserInfoCompanyAddress1") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Company Address2" SortExpression="UserInfoCompanyAddress2">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCompanyAddress2" Width="100px" runat="server" Text='<%# Bind("UserInfoCompanyAddress2") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyAddress2" ControlToValidate="txtUserInfoCompanyAddress2" runat="server" ErrorMessage="This 60 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyAddress2" ControlToValidate="txtUserInfoCompanyAddress2" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,60}$" ErrorMessage="User Info Company Address2 cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCompanyAddress2" runat="server" Text='<%# Bind("UserInfoCompanyAddress2") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Company City State Zip" SortExpression="UserInfoCompanyCityStateZip">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCompanyCityStateZip" Width="100px" runat="server" Text='<%# Bind("UserInfoCompanyCityStateZip") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyCityStateZip" ControlToValidate="txtUserInfoCompanyCityStateZip" runat="server" ErrorMessage="This 60 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyCityStateZip" ControlToValidate="txtUserInfoCompanyCityStateZip" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,60}$" ErrorMessage="User Info Company City State Zip cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCompanyCityStateZip" runat="server" Text='<%# Bind("UserInfoCompanyCityStateZip") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Company Telephone" SortExpression="UserInfoCompanyTelephone">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCompanyTelephone" Width="100px" runat="server" Text='<%# Bind("UserInfoCompanyTelephone") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyTelephone" ControlToValidate="txtUserInfoCompanyTelephone" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyTelephone" ControlToValidate="txtUserInfoCompanyTelephone" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Company Telephone cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCompanyTelephone" runat="server" Text='<%# Bind("UserInfoCompanyTelephone") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Company Email Address" SortExpression="UserInfoCompanyEmailAddress">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCompanyEmailAddress" Width="100px" runat="server" Text='<%# Bind("UserInfoCompanyEmailAddress") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCompanyEmailAddress" ControlToValidate="txtUserInfoCompanyEmailAddress" runat="server" ErrorMessage="This User Info Company Email Address is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCompanyEmailAddress" ControlToValidate="txtUserInfoCompanyEmailAddress" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="User Info Company Email Address cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCompanyEmailAddress" runat="server" Text='<%# Bind("UserInfoCompanyEmailAddress") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Company Website Address" SortExpression="UserCompanyWebsiteAddress">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserCompanyWebsiteAddress" Width="100px" runat="server" Text='<%# Bind("UserCompanyWebsiteAddress") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserCompanyWebsiteAddress" ControlToValidate="txtUserCompanyWebsiteAddress" runat="server" ErrorMessage="This User Company Website Address is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserCompanyWebsiteAddress" ControlToValidate="txtUserCompanyWebsiteAddress" ValidationExpression="^(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$" ErrorMessage="User Company Website Address cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserCompanyWebsiteAddress" runat="server" Text='<%# Bind("UserCompanyWebsiteAddress") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Countries ID" SortExpression="UserInfoCountriesID">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCountriesID" Width="100px" runat="server" Text='<%# Bind("UserInfoCountriesID") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCountriesID" ControlToValidate="txtUserInfoCountriesID" runat="server" ErrorMessage="This User Info Countries ID is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorUserInfoCountriesID" ControlToValidate="txtUserInfoCountriesID" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="User Info Countries ID cannot be zero." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCountriesID" runat="server" Text='<%# Bind("UserInfoCountriesID") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Company Active Yes No" SortExpression="UserInfoCompanyActiveYesNo">
    <EditItemTemplate>
    <asp:CheckBox ID="CheckBoxUserInfoCompanyActiveYesNo" runat="server" Checked='<%# Bind("UserInfoCompanyActiveYesNo") %>' />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:CheckBox ID="CheckBoxUserInfoCompanyActiveYesNo" runat="server" Checked='<%# Bind("UserInfoCompanyActiveYesNo") %>' Enabled="False" />
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:HyperLinkField DataNavigateUrlFields="UserInfoCompanyID" DataNavigateUrlFormatString="../UserInfoCompanys/UserInfoCompanyDetails.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
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
  