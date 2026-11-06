
    <%@ Page Title="AspxULTExample&nbsp;Not&nbsp;Found" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ErrorNotFound.aspx.cs" Inherits="AspxULTExample.Web.ErrorNotFound" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <table cellspacing="2" cellpadding="3" style="width: 800px;">
    <tr>
    <td>UserName: <span style="font-weight: bold;"><asp:LoginName runat="server" /></span></td>
    </tr>
    <tr>
    <td align="left">
    <b>Sorry, The Page, You are Looking for is not found.</b>
    </td>
    </tr>
    </table>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;Home" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../'; return false;" />
    </div>
    </main>
    </asp:Content>
  