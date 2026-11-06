
    <%@ Page Title="User Info Countries&nbsp;GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoCountriesGridView.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoCountriess.UserInfoCountriesGridView" %>
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
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoCountriess/UserInfoCountriesCreate.aspx'; return false;" />    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <div class="table-responsive">
    <asp:GridView ID="ResultGridView" runat="server"
    AutoGenerateColumns="False"
    ShowFooter="False"
    DataKeyNames="UserInfoCountriesID"
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
    
    <asp:BoundField DataField="UserInfoCountriesID" HeaderText="User Info Countries ID" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCountriesID" />
  

    <asp:TemplateField HeaderText="User Info Countries Name" SortExpression="UserInfoCountriesName">
    <EditItemTemplate>
    <asp:TextBox ID="txtUserInfoCountriesName" Width="100px" runat="server" Text='<%# Bind("UserInfoCountriesName") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserInfoCountriesName" ControlToValidate="txtUserInfoCountriesName" runat="server" ErrorMessage="This 50 is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorUserInfoCountriesName" ControlToValidate="txtUserInfoCountriesName" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,50}$" ErrorMessage="User Info Countries Name cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelUserInfoCountriesName" runat="server" Text='<%# Bind("UserInfoCountriesName") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="User Info Countries Active Yes No" SortExpression="UserInfoCountriesActiveYesNo">
    <EditItemTemplate>
    <asp:CheckBox ID="CheckBoxUserInfoCountriesActiveYesNo" runat="server" Checked='<%# Bind("UserInfoCountriesActiveYesNo") %>' />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:CheckBox ID="CheckBoxUserInfoCountriesActiveYesNo" runat="server" Checked='<%# Bind("UserInfoCountriesActiveYesNo") %>' Enabled="False" />
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:HyperLinkField DataNavigateUrlFields="UserInfoCountriesID" DataNavigateUrlFormatString="../UserInfoCountriess/UserInfoCountriesDetails.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
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
  