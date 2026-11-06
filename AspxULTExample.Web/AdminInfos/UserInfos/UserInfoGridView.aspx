
    <%@ Page Title="User Info&nbsp;GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoGridView.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfos.UserInfoGridView" %>
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
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfos/UserInfoCreate.aspx'; return false;" />    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <div class="table-responsive">
    <asp:GridView ID="ResultGridView" runat="server"
    AutoGenerateColumns="False"
    ShowFooter="False"
    DataKeyNames="UserInfoID"
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
    
    <asp:BoundField DataField="UserInfoID" HeaderText="User Info ID" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoID" />
  

    <asp:TemplateField HeaderText="User Info User Identity Name" SortExpression="UserInfoUserIdentityName">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoUserIdentityName" Width="100px" runat="server" Text='<%# Bind("UserInfoUserIdentityName") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoUserIdentityName" ControlToValidate="txtUserInfoUserIdentityName" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoUserIdentityName" ControlToValidate="txtUserInfoUserIdentityName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info User Identity Name cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoUserIdentityName" runat="server" Text='<%# Bind("UserInfoUserIdentityName") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info User Name" SortExpression="UserInfoUserName">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoUserName" Width="100px" runat="server" Text='<%# Bind("UserInfoUserName") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoUserName" ControlToValidate="txtUserInfoUserName" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoUserName" ControlToValidate="txtUserInfoUserName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info User Name cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoUserName" runat="server" Text='<%# Bind("UserInfoUserName") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Full Name" SortExpression="UserInfoFullName">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoFullName" Width="100px" runat="server" Text='<%# Bind("UserInfoFullName") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoFullName" ControlToValidate="txtUserInfoFullName" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoFullName" ControlToValidate="txtUserInfoFullName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Full Name cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoFullName" runat="server" Text='<%# Bind("UserInfoFullName") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Email Address" SortExpression="UserInfoEmailAddress">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoEmailAddress" Width="100px" runat="server" Text='<%# Bind("UserInfoEmailAddress") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoEmailAddress" ControlToValidate="txtUserInfoEmailAddress" runat="server" ErrorMessage="This User Info Email Address is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoEmailAddress" ControlToValidate="txtUserInfoEmailAddress" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="User Info Email Address cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoEmailAddress" runat="server" Text='<%# Bind("UserInfoEmailAddress") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Job Title" SortExpression="UserInfoJobTitle">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoJobTitle" Width="100px" runat="server" Text='<%# Bind("UserInfoJobTitle") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoJobTitle" ControlToValidate="txtUserInfoJobTitle" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoJobTitle" ControlToValidate="txtUserInfoJobTitle" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Job Title cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoJobTitle" runat="server" Text='<%# Bind("UserInfoJobTitle") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Active Yes No" SortExpression="UserInfoActiveYesNo">
    <EditItemTemplate>
    <asp:CheckBox ID="CheckBoxUserInfoActiveYesNo" runat="server" Checked='<%# Bind("UserInfoActiveYesNo") %>' />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:CheckBox ID="CheckBoxUserInfoActiveYesNo" runat="server" Checked='<%# Bind("UserInfoActiveYesNo") %>' Enabled="False" />
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:HyperLinkField DataNavigateUrlFields="UserInfoID" DataNavigateUrlFormatString="../UserInfos/UserInfoDetails.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
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
  