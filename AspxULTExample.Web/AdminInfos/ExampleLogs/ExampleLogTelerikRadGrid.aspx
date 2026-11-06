
    <%@ Page Title="Example Log&nbsp;RadGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleLogTelerikRadGrid.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.ExampleLogs.ExampleLogTelerikRadGrid" %>
    <asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    </asp:Content>
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
    <section class="row">
    <section class="col-auto">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="ValidationSummary1">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="ValidationSummary1" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    <telerik:AjaxSetting AjaxControlID="RadGrid1">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
    <telerik:RadGrid ID="RadGrid1" GridLines="None" runat="server" AllowSorting="True"
    PageSize="10"
    AllowPaging="True"
    AutoGenerateColumns="False"
    OnDataBound="RadGrid1_DataBound"
    OnUpdateCommand="RadGrid1_UpdateCommand"
    OnInsertCommand="RadGrid1_InsertCommand"
    OnDeleteCommand="RadGrid1_DeleteCommand"
    AllowFilteringByColumn="True"
    OnNeedDataSource="RadGrid1_NeedDataSource">
    <PagerStyle Mode="NextPrevAndNumeric" />
    <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom"
    HorizontalAlign="NotSet" EditMode="PopUp" DataKeyNames="ExampleLogID">
    <Columns>
    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn" EditText="Edit">
    <ItemStyle CssClass="btn btn-info MyImageButton" />
    </telerik:GridEditCommandColumn>

    
    <telerik:GridBoundColumn UniqueName="ExampleLogID" HeaderText="Example Log ID" DataField="ExampleLogID" ReadOnly="True"></telerik:GridBoundColumn>
  

    <telerik:GridNumericColumn DataField="ExampleID" HeaderText="Example ID" UniqueName="ExampleID" DecimalDigits="0" MinValue="1">
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This Example ID is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridNumericColumn>
  

    <telerik:GridBoundColumn UniqueName="LogMessage" HeaderText="Log Message" DataField="LogMessage" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Log Message is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridButtonColumn ConfirmTextFormatString="Delete this {0}?" ConfirmTextFields="ExampleLogID" ConfirmDialogType="RadWindow"
    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
    UniqueName="DeleteColumn" ConfirmText="Delete">
    <ItemStyle HorizontalAlign="Center" CssClass="btn btn-info MyImageButton" />
    </telerik:GridButtonColumn>
    </Columns>
    <EditFormSettings CaptionFormatString="Edit ExampleLogID: {0}" CaptionDataField="ExampleLogID">
    <FormTableItemStyle Wrap="False"></FormTableItemStyle>
    <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
    <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
    Width="100%" />
    <FormTableStyle CellSpacing="0" CellPadding="2" Height="110px" BackColor="White" />
    <FormTableAlternatingItemStyle Wrap="False" BackColor="#F5F5F5"></FormTableAlternatingItemStyle>
    <EditColumn ButtonType="LinkButton" EditText="Edit"
    UniqueName="EditCommandColumn1" CancelText="Cancel">
    </EditColumn>
    <FormStyle Width="100%" BorderColor="black" BorderWidth="2" BackColor="#DCDCDC"></FormStyle>
    <PopUpSettings></PopUpSettings>
    <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
    </EditFormSettings>
    </MasterTableView>
    </telerik:RadGrid>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
    </telerik:RadAjaxPanel>
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
  