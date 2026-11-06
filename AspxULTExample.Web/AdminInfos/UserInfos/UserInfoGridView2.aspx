
    <%@ Page Title="User Info&nbsp;GridView2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoGridView2.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfos.UserInfoGridView2" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfos/UserInfoCreate2.aspx'; return false;" />
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
    DataKeyNames="UserInfoID"
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
    
    <asp:BoundField DataField="UserInfoID" HeaderText="User Info ID" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoID" />
  

    <asp:BoundField DataField="UserInfoUserIdentityName" HeaderText="User Info User Identity Name" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoUserIdentityName" />
  

    <asp:BoundField DataField="UserInfoUserName" HeaderText="User Info User Name" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoUserName" />
  

    <asp:BoundField DataField="UserInfoFullName" HeaderText="User Info Full Name" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoFullName" />
  

    <asp:BoundField DataField="UserInfoEmailAddress" HeaderText="User Info Email Address" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoEmailAddress" />
  

    <asp:BoundField DataField="UserInfoJobTitle" HeaderText="User Info Job Title" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoJobTitle" />
  

    <asp:CheckBoxField DataField="UserInfoActiveYesNo" HeaderText="User Info Active Yes No" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoActiveYesNo" />
  

    <asp:HyperLinkField DataNavigateUrlFields="UserInfoID" DataNavigateUrlFormatString="../UserInfos/UserInfoDetail2s.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
    <asp:HyperLinkField DataNavigateUrlFields="UserInfoID" DataNavigateUrlFormatString="../UserInfos/UserInfoEditDelete.aspx?id={0}" HeaderText="Edit" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-pencil-square'></i>&nbsp;Edit</span>" />
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
  