
    <%@ Page Title="View Example&nbsp;TelerikRadDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ViewExampleTelerikRadDetails.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.ViewExamples.ViewExampleTelerikRadDetails" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <br />
    </section>
    
    <section class="row">
    <div class="col-auto">
    <asp:HiddenField ID="HiddenField_ExampleID" runat="server" />
    <asp:Label ID="LabelDisplayNameForExampleID" CssClass="form-label" Text="Example ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForExampleID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForExampleUserInfoStatusID" CssClass="form-label" Text="Example User Info Status ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForExampleUserInfoStatusID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForExampleUserInfoCompanyID" CssClass="form-label" Text="Example User Info Company ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForExampleUserInfoCompanyID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForTitle" CssClass="form-label" Text="Title:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForTitle" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForRelease" CssClass="form-label" Text="Release:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForRelease" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForReleaseDateTime" CssClass="form-label" Text="Release Date Time:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForReleaseDateTime" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForGenre" CssClass="form-label" Text="Genre:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForGenre" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForPrice" CssClass="form-label" Text="Price:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForPrice" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForPriceYesNo" CssClass="form-label" Text="Price Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForPriceYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForReleaseDate" CssClass="form-label" Text="Release Date:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForReleaseDate" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForReleaseTime" CssClass="form-label" Text="Release Time:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForReleaseTime" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForMessage" CssClass="form-label" Text="Message:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForMessage" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForMessage2" CssClass="form-label" Text="Message2:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForMessage2" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForPhoneNumber" CssClass="form-label" Text="Phone Number:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForPhoneNumber" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForEmailAddress" CssClass="form-label" Text="Email Address:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForEmailAddress" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForCreditCard" CssClass="form-label" Text="Credit Card:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForCreditCard" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForPassword" CssClass="form-label" Text="Password:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForPassword" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUrl" CssClass="form-label" Text="Url:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUrl" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForExampleActiveYesNo" CssClass="form-label" Text="Example Active Yes No:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForExampleActiveYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoCompanyName" CssClass="form-label" Text="User Info Company Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoCompanyName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelDisplayNameForUserInfoStatusName" CssClass="form-label" Text="User Info Status Name:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForUserInfoStatusName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../ViewExamples/ViewExampleTelerikRadGrid2.aspx'; return false;" />
    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <h5>
    <asp:Label ID="LabelApprove" runat="server">Approves</asp:Label>
    </h5>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <div class="table-responsive">
    <asp:GridView ID="ResultGridViewApproves" runat="server"
    AutoGenerateColumns="False"
    ShowFooter="False"
    DataKeyNames="ExampleApproveID"
    AllowPaging="False"
    CellPadding="3"
    CellSpacing="2"
    GridLines="Vertical"
    CssClass="display"
    ShowHeaderWhenEmpty="true">
    <Columns>
    <asp:BoundField DataField="ExampleApproveID" HeaderText="Example Approve ID" InsertVisible="False"
    ReadOnly="True" SortExpression="ExampleApproveID" />
    <asp:Imagefield DataImageUrlField="UserInfoID"
    DataImageUrlFormatString="~\Content\Signatures\{0}.jpg"
    AlternateText="Signatures"
    HeaderText="Signatures"
    ReadOnly="true"/>

    <asp:BoundField DataField="CreateFullName" HeaderText="Full Name" InsertVisible="False"
    ReadOnly="True" SortExpression="CreateFullName" />

    <asp:BoundField DataField="UserInfoJobTitle" HeaderText="Job Title" InsertVisible="False"
    ReadOnly="True" SortExpression="UserInfoJobTitle" />

    <asp:BoundField DataField="CreateDate" HeaderText="Date" InsertVisible="False"
    ReadOnly="True" SortExpression="CreateDate" DataFormatString="{0:M/d/yyyy HH:mm:ss}" />
    </Columns>
    </asp:GridView>
    </div>
    </section>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <h5>
    <asp:Label ID="LabelLog" runat="server">Logs</asp:Label>
    </h5>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <section class="col-auto">
    <div class="table-responsive">
    <asp:GridView ID="ResultGridViewLogs" runat="server"
    AutoGenerateColumns="False"
    ShowFooter="False"
    DataKeyNames="ExampleLogID"
    AllowPaging="False"
    CellPadding="3"
    CellSpacing="2"
    GridLines="Vertical"
    CssClass="display"
    ShowHeaderWhenEmpty="true">

    <Columns>

    <asp:BoundField DataField="ExampleLogID" HeaderText="Example Log ID" InsertVisible="False"
    ReadOnly="True" SortExpression="ExampleLogID" />


    <asp:BoundField DataField="LogMessage" HeaderText="Log Message" InsertVisible="False"
    ReadOnly="True" SortExpression="LogMessage" />


    <asp:BoundField DataField="CreateFullName" HeaderText="Full Name" InsertVisible="False"
    ReadOnly="True" SortExpression="CreateFullName" />


    <asp:BoundField DataField="CreateDate" HeaderText="Date" InsertVisible="False"
    ReadOnly="True" SortExpression="CreateDate" DataFormatString="{0:M/d/yyyy HH:mm:ss}" />


    </Columns>
    </asp:GridView>
    </div>
    </section>
    </section>
    </main>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script>
    $(document).ready(function () {

    $('#<%= ResultGridViewApproves.ClientID %>').DataTable({
    pagingType: 'full_numbers',
    scrollX: false,
    ordering: false
    });

    $('#<%= ResultGridViewLogs.ClientID %>').DataTable({
    pagingType: 'full_numbers',
    scrollX: false,
    ordering: false
    });

    });
    </script>
    </asp:Content>
  