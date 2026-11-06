
    <%@ Page Title="User Info Company&nbsp;RadGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="UserInfoCompanyTelerikRadGrid.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.UserInfoCompanys.UserInfoCompanyTelerikRadGrid" %>
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
    HorizontalAlign="NotSet" EditMode="PopUp" DataKeyNames="UserInfoCompanyID">
    <Columns>
    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn" EditText="Edit">
    <ItemStyle CssClass="btn btn-info MyImageButton" />
    </telerik:GridEditCommandColumn>

    
    <telerik:GridBoundColumn UniqueName="UserInfoCompanyID" HeaderText="User Info Company ID" DataField="UserInfoCompanyID" ReadOnly="True"></telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoCompanyEIN" HeaderText="User Info Company EIN" DataField="UserInfoCompanyEIN" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Company EIN is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoCompanyName" HeaderText="User Info Company Name" DataField="UserInfoCompanyName" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Company Name is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoCompanyAddress1" HeaderText="User Info Company Address1" DataField="UserInfoCompanyAddress1" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Company Address1 is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoCompanyAddress2" HeaderText="User Info Company Address2" DataField="UserInfoCompanyAddress2" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Company Address2 is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoCompanyCityStateZip" HeaderText="User Info Company City State Zip" DataField="UserInfoCompanyCityStateZip" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Company City State Zip is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoCompanyTelephone" HeaderText="User Info Company Telephone" DataField="UserInfoCompanyTelephone" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Company Telephone is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserInfoCompanyEmailAddress" HeaderText="User Info Company Email Address" DataField="UserInfoCompanyEmailAddress" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Info Company Email Address is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="UserCompanyWebsiteAddress" HeaderText="User Company Website Address" DataField="UserCompanyWebsiteAddress" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This User Company Website Address is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridNumericColumn DataField="UserInfoCountriesID" HeaderText="User Info Countries ID" UniqueName="UserInfoCountriesID" DecimalDigits="0" MinValue="1">
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This User Info Countries ID is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridNumericColumn>
  

    <telerik:GridCheckBoxColumn UniqueName="UserInfoCompanyActiveYesNo" HeaderText="User Info Company Active Yes No" DataField="UserInfoCompanyActiveYesNo">
    </telerik:GridCheckBoxColumn>
  

    <telerik:GridButtonColumn ConfirmTextFormatString="Delete this {0}?" ConfirmTextFields="UserInfoCompanyID" ConfirmDialogType="RadWindow"
    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
    UniqueName="DeleteColumn" ConfirmText="Delete">
    <ItemStyle HorizontalAlign="Center" CssClass="btn btn-info MyImageButton" />
    </telerik:GridButtonColumn>
    </Columns>
    <EditFormSettings CaptionFormatString="Edit UserInfoCompanyID: {0}" CaptionDataField="UserInfoCompanyID">
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
  