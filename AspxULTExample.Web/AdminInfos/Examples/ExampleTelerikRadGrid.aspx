
    <%@ Page Title="Example&nbsp;RadGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleTelerikRadGrid.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.Examples.ExampleTelerikRadGrid" %>
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
    HorizontalAlign="NotSet" EditMode="PopUp" DataKeyNames="ExampleID">
    <Columns>
    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn" EditText="Edit">
    <ItemStyle CssClass="btn btn-info MyImageButton" />
    </telerik:GridEditCommandColumn>

    
    <telerik:GridBoundColumn UniqueName="ExampleID" HeaderText="Example ID" DataField="ExampleID" ReadOnly="True"></telerik:GridBoundColumn>
  

    <telerik:GridNumericColumn DataField="ExampleUserInfoStatusID" HeaderText="Example User Info Status ID" UniqueName="ExampleUserInfoStatusID" DecimalDigits="0" MinValue="1">
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This Example User Info Status ID is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridNumericColumn>
  

    <telerik:GridNumericColumn DataField="ExampleUserInfoCompanyID" HeaderText="Example User Info Company ID" UniqueName="ExampleUserInfoCompanyID" DecimalDigits="0" MinValue="1">
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This Example User Info Company ID is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridNumericColumn>
  

    <telerik:GridBoundColumn UniqueName="Title" HeaderText="Title" DataField="Title" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Title is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridNumericColumn DataField="Release" HeaderText="Release" UniqueName="Release" DecimalDigits="0" MinValue="1">
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This Release is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridNumericColumn>
  

    <telerik:GridDateTimeColumn DataField="ReleaseDateTime" DataType="System.DateTime" PickerType="DateTimePicker" DataFormatString="{0:M/d/yyyy HH:mm:ss}" EditDataFormatString="M/d/yyyy HH:mm:ss" HeaderText="Release Date Time" UniqueName="ReleaseDateTime" >
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This Release Date Time is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridDateTimeColumn>
  

    <telerik:GridBoundColumn UniqueName="Genre" HeaderText="Genre" DataField="Genre" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Genre is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridNumericColumn DataField="Price" HeaderText="Price" UniqueName="Price" DecimalDigits="2" MinValue="0.01">
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This Price is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridNumericColumn>
  

    <telerik:GridCheckBoxColumn UniqueName="PriceYesNo" HeaderText="Price Yes No" DataField="PriceYesNo">
    </telerik:GridCheckBoxColumn>
  

    <telerik:GridDateTimeColumn DataField="ReleaseDate" DataType="System.DateTime" PickerType="DatePicker" DataFormatString="{0:M/d/yyyy}" EditDataFormatString="M/d/yyyy" HeaderText="Release Date" UniqueName="ReleaseDate" >
    <ColumnValidationSettings EnableModelErrorMessageValidation="true" EnableRequiredFieldValidation="true">
    <RequiredFieldValidator ErrorMessage="This Release Date is required." ForeColor="Red" Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridDateTimeColumn>
  

    <telerik:GridTemplateColumn DataField="ReleaseTime" HeaderText="Release Time" DataType="System.TimeSpan"  UniqueName="ReleaseTime">
    <ItemTemplate>
    <asp:Label runat="server" ID="LabelReleaseTime" Text='<%# String.Format("{0:hh\\:mm\\:ss}",Eval("ReleaseTime")) %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
    <telerik:RadTimePicker ID="TextBoxReleaseTime" DbSelectedDate='<%# Bind("ReleaseTime") %>' runat="server">
    <DateInput
    DateFormat="HH:mm:ss"
    DisplayDateFormat="HH:mm:ss">
    </DateInput>
    <TimeView TimeFormat="HH:mm:ss" Interval="00:10:00" Columns="6"></TimeView>
    </telerik:RadTimePicker>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseTime" ControlToValidate="TextBoxReleaseTime" runat="server" ErrorMessage="This Release Time is required." Text="*" BackColor="Red"></asp:RequiredFieldValidator>
    </EditItemTemplate>
    <InsertItemTemplate>
    <telerik:RadTimePicker ID="TextBoxReleaseTime" DbSelectedDate='<%# Bind("ReleaseTime") %>' runat="server">
    <DateInput
    DateFormat="HH:mm:ss"
    DisplayDateFormat="HH:mm:ss">
    </DateInput>
    <TimeView TimeFormat="HH:mm:ss" Interval="00:10:00" Columns="6"></TimeView>
    </telerik:RadTimePicker>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorReleaseTime" ControlToValidate="TextBoxReleaseTime" runat="server" ErrorMessage="This Release Time is required." Text="*" BackColor="Red"></asp:RequiredFieldValidator>
    </InsertItemTemplate>
    </telerik:GridTemplateColumn>
  

    <telerik:GridBoundColumn UniqueName="Message" HeaderText="Message" DataField="Message" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Message is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="Message2" HeaderText="Message2" DataField="Message2" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Message2 is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="PhoneNumber" HeaderText="Phone Number" DataField="PhoneNumber" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Phone Number is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="EmailAddress" HeaderText="Email Address" DataField="EmailAddress" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Email Address is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="CreditCard" HeaderText="Credit Card" DataField="CreditCard" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Credit Card is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="Password" HeaderText="Password" DataField="Password" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Password is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridBoundColumn UniqueName="Url" HeaderText="Url" DataField="Url" DataType="System.String">
    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This Url is required." Text="*"></RequiredFieldValidator>
    <ModelErrorMessage BackColor="Red" />
    </ColumnValidationSettings>
    </telerik:GridBoundColumn>
  

    <telerik:GridCheckBoxColumn UniqueName="ExampleActiveYesNo" HeaderText="Example Active Yes No" DataField="ExampleActiveYesNo">
    </telerik:GridCheckBoxColumn>
  

    <telerik:GridButtonColumn ConfirmTextFormatString="Delete this {0}?" ConfirmTextFields="ExampleID" ConfirmDialogType="RadWindow"
    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
    UniqueName="DeleteColumn" ConfirmText="Delete">
    <ItemStyle HorizontalAlign="Center" CssClass="btn btn-info MyImageButton" />
    </telerik:GridButtonColumn>
    </Columns>
    <EditFormSettings CaptionFormatString="Edit ExampleID: {0}" CaptionDataField="ExampleID">
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
  