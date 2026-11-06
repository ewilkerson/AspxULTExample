
    <%@ Page Title="User Info&nbsp;RadGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoTelerikRadGrid.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfos.UserInfoTelerikRadGrid" %>
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
    HorizontalAlign="NotSet" EditMode="PopUp" DataKeyNames="UserInfoID">
    <Columns>
    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn" EditText="Edit">
    <ItemStyle CssClass="btn btn-info MyImageButton" />
    </telerik:GridEditCommandColumn>

    
    <telerik:GridBoundColumn UniqueName="UserInfoID" HeaderText="User Info ID" DataField="UserInfoID" ReadOnly="True"></telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoUserIdentityName" HeaderText="User Info User Identity Name" DataField="UserInfoUserIdentityName" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info User Identity Name is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoUserName" HeaderText="User Info User Name" DataField="UserInfoUserName" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info User Name is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoFullName" HeaderText="User Info Full Name" DataField="UserInfoFullName" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Full Name is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoEmailAddress" HeaderText="User Info Email Address" DataField="UserInfoEmailAddress" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Email Address is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoJobTitle" HeaderText="User Info Job Title" DataField="UserInfoJobTitle" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Job Title is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridCheckBoxColumn UniqueName="UserInfoActiveYesNo" HeaderText="User Info Active Yes No" DataField="UserInfoActiveYesNo">
    </telerik:GridCheckBoxColumn>
  

    <telerik:GridButtonColumn ConfirmTextFormatString="Delete this {0}?" ConfirmTextFields="UserInfoID" ConfirmDialogType="RadWindow"
    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
    UniqueName="DeleteColumn" ConfirmText="Delete">
    <ItemStyle HorizontalAlign="Center" CssClass="btn btn-info MyImageButton" />
    </telerik:GridButtonColumn>
    </Columns>
    <EditFormSettings CaptionFormatString="Edit UserInfoID: {0}" CaptionDataField="UserInfoID">
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
  