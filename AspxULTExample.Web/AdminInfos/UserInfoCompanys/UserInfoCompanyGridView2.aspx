
    <%@ Page Title="User Info Company&nbsp;GridView2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoCompanyGridView2.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoCompanys.UserInfoCompanyGridView2" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoCompanys/UserInfoCompanyCreate2.aspx'; return false;" />
    </div>
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
    OnRowDataBound="ResultGridView_OnRowDataBound"
    GridLines="Vertical"
    CssClass="display"
    ShowHeaderWhenEmpty="true">
    <Columns>
    
    <asp:BoundField DataField="UserInfoCompanyID" HeaderText="User Info Company ID" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyID" />
  

    <asp:BoundField DataField="UserInfoCompanyEIN" HeaderText="User Info Company EIN" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyEIN" />
  

    <asp:BoundField DataField="UserInfoCompanyName" HeaderText="User Info Company Name" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyName" />
  

    <asp:BoundField DataField="UserInfoCompanyAddress1" HeaderText="User Info Company Address1" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyAddress1" />
  

    <asp:BoundField DataField="UserInfoCompanyAddress2" HeaderText="User Info Company Address2" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyAddress2" />
  

    <asp:BoundField DataField="UserInfoCompanyCityStateZip" HeaderText="User Info Company City State Zip" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyCityStateZip" />
  

    <asp:BoundField DataField="UserInfoCompanyTelephone" HeaderText="User Info Company Telephone" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyTelephone" />
  

    <asp:BoundField DataField="UserInfoCompanyEmailAddress" HeaderText="User Info Company Email Address" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyEmailAddress" />
  

    <asp:BoundField DataField="UserCompanyWebsiteAddress" HeaderText="User Company Website Address" InsertVisible="False"
    ReadOnly="True" SortExpression="UserCompanyWebsiteAddress" />
  

    <asp:BoundField DataField="UserInfoCountriesID" HeaderText="User Info Countries ID" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCountriesID" />
  

    <asp:CheckBoxField DataField="UserInfoCompanyActiveYesNo" HeaderText="User Info Company Active Yes No" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoCompanyActiveYesNo" />
  

    <asp:HyperLinkField DataNavigateUrlFields="UserInfoCompanyID" DataNavigateUrlFormatString="../UserInfoCompanys/UserInfoCompanyDetail2s.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
    <asp:HyperLinkField DataNavigateUrlFields="UserInfoCompanyID" DataNavigateUrlFormatString="../UserInfoCompanys/UserInfoCompanyEditDelete.aspx?id={0}" HeaderText="Edit" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-pencil-square'></i>&nbsp;Edit</span>" />
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
  