
    <%@ Page Title="User Info Access Level&nbsp;TelerikRadGrid2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoAccessLevelTelerikRadGrid2.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoAccessLevels.UserInfoAccessLevelTelerikRadGrid2" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../UserInfoAccessLevels/UserInfoAccessLevelTelerikRadCreate.aspx'; return false;" />
    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="table-responsive">
    <asp:GridView ID="ResultGridView" runat="server" AutoGenerateColumns="False" ShowFooter="False"
    DataKeyNames="UserInfoAccessLevelID"
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
    
    <asp:BoundField DataField="UserInfoAccessLevelID" HeaderText="User Info Access Level ID" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoAccessLevelID" />
  

    <asp:BoundField DataField="UserInfoAccessLevelName" HeaderText="User Info Access Level Name" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoAccessLevelName" />
  

    <asp:BoundField DataField="UserInfoAccessLevelNum" HeaderText="User Info Access Level Num" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoAccessLevelNum" />
  

    <asp:CheckBoxField DataField="UserInfoAccessLevelActiveYesNo" HeaderText="User Info Access Level Active Yes No" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoAccessLevelActiveYesNo" />
  

    <asp:HyperLinkField DataNavigateUrlFields="UserInfoAccessLevelID" DataNavigateUrlFormatString="../UserInfoAccessLevels/UserInfoAccessLevelTelerikRadDetails.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
    <asp:HyperLinkField DataNavigateUrlFields="UserInfoAccessLevelID" DataNavigateUrlFormatString="../UserInfoAccessLevels/UserInfoAccessLevelTelerikRadEditDelete.aspx?id={0}" HeaderText="Edit" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-pencil-square'></i>&nbsp;Edit</span>" />
    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" DeleteText="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-trash3'></i>&nbsp;Delete</span>" />
    </Columns>
    </asp:GridView>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
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
  