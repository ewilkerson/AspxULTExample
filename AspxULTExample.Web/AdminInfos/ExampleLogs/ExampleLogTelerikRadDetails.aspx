
    <%@ Page Title="Example Log&nbsp;TelerikRadDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ExampleLogTelerikRadDetails.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.ExampleLogs.ExampleLogTelerikRadDetails" %>
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
    <asp:HiddenField ID="HiddenField_ExampleLogID" runat="server" />
    <asp:Label ID="LabelDisplayNameForExampleLogID" CssClass="form-label" Text="Example Log ID:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForExampleLogID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <section class="row">
    <div class="col-auto">
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
    <asp:Label ID="LabelDisplayNameForLogMessage" CssClass="form-label" Text="Log Message:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label ID="LabelDisplayForLogMessage" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
  

    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../ExampleLogs/ExampleLogTelerikRadGrid2.aspx'; return false;" />
    </div>
    </main>
    </asp:Content>
  