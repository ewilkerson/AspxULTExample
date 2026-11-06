
    <%@ Page Title="Dmv Study Prac Question&nbsp;TelerikRadGrid2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="DmvStudyPracQuestionTelerikRadGrid2.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions.DmvStudyPracQuestionTelerikRadGrid2" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../DmvStudyPracQuestions/DmvStudyPracQuestionTelerikRadCreate.aspx'; return false;" />
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
    DataKeyNames="DmvStudyPracQuestionID"
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
    
    <asp:BoundField DataField="DmvStudyPracQuestionID" HeaderText="Dmv Study Prac Question ID" InsertVisible="False"
    ReadOnly="True" SortExpression="DmvStudyPracQuestionID" />
  

    <asp:BoundField DataField="DmvStudyPracID" HeaderText="Dmv Study Prac ID" InsertVisible="False"
    ReadOnly="True" SortExpression="DmvStudyPracID" />
  

    <asp:BoundField DataField="DmvStudyPracQuestionText" HeaderText="Dmv Study Prac Question Text" InsertVisible="False"
    ReadOnly="True" SortExpression="DmvStudyPracQuestionText" />
  

    <asp:BoundField DataField="DmvStudyPracQuestionAnswerText" HeaderText="Dmv Study Prac Question Answer Text" InsertVisible="False"
    ReadOnly="True" SortExpression="DmvStudyPracQuestionAnswerText" />
  

    <asp:CheckBoxField DataField="DmvStudyPracQuestionPicsYesNo" HeaderText="Dmv Study Prac Question Pics Yes No" InsertVisible="False"
    ReadOnly="True" SortExpression="DmvStudyPracQuestionPicsYesNo" />
  

    <asp:CheckBoxField DataField="DmvStudyPracQuestionActiveYesNo" HeaderText="Dmv Study Prac Question Active Yes No" InsertVisible="False"
    ReadOnly="True" SortExpression="DmvStudyPracQuestionActiveYesNo" />
  

    <asp:HyperLinkField DataNavigateUrlFields="DmvStudyPracQuestionID" DataNavigateUrlFormatString="../DmvStudyPracQuestions/DmvStudyPracQuestionTelerikRadDetails.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
    <asp:HyperLinkField DataNavigateUrlFields="DmvStudyPracQuestionID" DataNavigateUrlFormatString="../DmvStudyPracQuestions/DmvStudyPracQuestionTelerikRadEditDelete.aspx?id={0}" HeaderText="Edit" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-pencil-square'></i>&nbsp;Edit</span>" />
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
  