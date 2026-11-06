
    <%@ Page Title="Dmv Study Prac Question&nbsp;GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="DmvStudyPracQuestionGridView.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions.DmvStudyPracQuestionGridView" %>
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
    <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../DmvStudyPracQuestions/DmvStudyPracQuestionCreate.aspx'; return false;" />    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <div class="table-responsive">
    <asp:GridView ID="ResultGridView" runat="server"
    AutoGenerateColumns="False"
    ShowFooter="False"
    DataKeyNames="DmvStudyPracQuestionID"
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
    
    <asp:BoundField DataField="DmvStudyPracQuestionID" HeaderText="Dmv Study Prac Question ID" InsertVisible="False"
    ReadOnly="True" SortExpression="DmvStudyPracQuestionID" />
  

    <asp:TemplateField HeaderText="Dmv Study Prac ID" SortExpression="DmvStudyPracID">
    <EditItemTemplate>
    <asp:TextBox ID="txtDmvStudyPracID" Width="100px" runat="server" Text='<%# Bind("DmvStudyPracID") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDmvStudyPracID" ControlToValidate="txtDmvStudyPracID" runat="server" ErrorMessage="This Dmv Study Prac ID is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidatorDmvStudyPracID" ControlToValidate="txtDmvStudyPracID" ValidationExpression="^(?=.*\d)(?=.*[1-9]).{1,}$" ErrorMessage="Dmv Study Prac ID cannot be zero." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelDmvStudyPracID" runat="server" Text='<%# Bind("DmvStudyPracID") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Dmv Study Prac Question Text" SortExpression="DmvStudyPracQuestionText">
    <EditItemTemplate>
    <asp:TextBox ID="txtDmvStudyPracQuestionText" TextMode="multiline" Columns="50" Rows="3" runat="server" Text='<%# Bind("DmvStudyPracQuestionText") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDmvStudyPracQuestionText" ControlToValidate="txtDmvStudyPracQuestionText" runat="server" ErrorMessage="This Dmv Study Prac Question Text is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorDmvStudyPracQuestionText" ControlToValidate="txtDmvStudyPracQuestionText" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,500}$" ErrorMessage="Dmv Study Prac Question Text cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelDmvStudyPracQuestionText" runat="server" Text='<%# Bind("DmvStudyPracQuestionText") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Dmv Study Prac Question Answer Text" SortExpression="DmvStudyPracQuestionAnswerText">
    <EditItemTemplate>
    <asp:TextBox ID="txtDmvStudyPracQuestionAnswerText" TextMode="multiline" Columns="50" Rows="3" runat="server" Text='<%# Bind("DmvStudyPracQuestionAnswerText") %>'></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDmvStudyPracQuestionAnswerText" ControlToValidate="txtDmvStudyPracQuestionAnswerText" runat="server" ErrorMessage="This Dmv Study Prac Question Answer Text is required." Text="*"  ></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorDmvStudyPracQuestionAnswerText" ControlToValidate="txtDmvStudyPracQuestionAnswerText" ValidationExpression="^[\w\s|!\u0022$%&\/\(\)\?\^\'\\\+\-\*=:;{}\[\]\.~`@#^,<>]{1,500}$" ErrorMessage="Dmv Study Prac Question Answer Text cannot be null or empty or only have white space." Text="*" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="LabelDmvStudyPracQuestionAnswerText" runat="server" Text='<%# Bind("DmvStudyPracQuestionAnswerText") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Dmv Study Prac Question Pics Yes No" SortExpression="DmvStudyPracQuestionPicsYesNo">
    <EditItemTemplate>
    <asp:CheckBox ID="CheckBoxDmvStudyPracQuestionPicsYesNo" runat="server" Checked='<%# Bind("DmvStudyPracQuestionPicsYesNo") %>' />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:CheckBox ID="CheckBoxDmvStudyPracQuestionPicsYesNo" runat="server" Checked='<%# Bind("DmvStudyPracQuestionPicsYesNo") %>' Enabled="False" />
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:TemplateField HeaderText="Dmv Study Prac Question Active Yes No" SortExpression="DmvStudyPracQuestionActiveYesNo">
    <EditItemTemplate>
    <asp:CheckBox ID="CheckBoxDmvStudyPracQuestionActiveYesNo" runat="server" Checked='<%# Bind("DmvStudyPracQuestionActiveYesNo") %>' />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:CheckBox ID="CheckBoxDmvStudyPracQuestionActiveYesNo" runat="server" Checked='<%# Bind("DmvStudyPracQuestionActiveYesNo") %>' Enabled="False" />
    </ItemTemplate>
    </asp:TemplateField>
  

    <asp:HyperLinkField DataNavigateUrlFields="DmvStudyPracQuestionID" DataNavigateUrlFormatString="../DmvStudyPracQuestions/DmvStudyPracQuestionDetails.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
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
  