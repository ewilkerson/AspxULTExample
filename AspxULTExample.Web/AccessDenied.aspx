
    <%@ Page Title="AspxULTExample&nbsp;Access&nbsp;Denied" Language="C#" AutoEventWireup="True" CodeBehind="AccessDenied.aspx.cs" Inherits="AspxULTExample.Web.AccessDenied" %>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title>Access Denied</title>
    <link href="~/Content/Site.css" rel="Stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="Stylesheet" type="text/css" />
    <link href="~/Content/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    </head>
    <body>
    <form id="form1" runat="server">
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm bg-info">
    <div class="container">
    <a class="navbar-brand" runat="server" href="~/"><img src="/Svg/google-drive.svg" alt="ViewExampleFileUpload2 Logo" width="28" height="28" class="d-inline-block align-text-top">ViewExampleFileUpload2</a>
    <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
    aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
    <ul class="navbar-nav flex-grow-1">
    <li class="nav-item"><a class="nav-link text-dark" runat="server" href="~/">Home</a></li>
    </ul>
    <p class="navbar-text navbar-right">
    Hello,
    <asp:LoginName runat="server" />
    !
    </p>
    </div>
    </div>
    </nav>
    <div class="container body-content">
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
    <b>You do not have sufficient permissions to access this application. If you believe you should have access to this application, please send an email to <a href="mailto:earl.wilkerson.jr@gmail.com?subject=AspxULTExample => Access Request" title="Click here to email AspxULTExample => Access Request" target="_blank">AspxULTExample => Access Request</a>.</b>
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
    <hr />
    <footer>
    <p>&copy; <%: DateTime.Now.Year %> - ViewExampleFileUpload2</p>
    </footer>
    </div>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    </form>
    </body>
    </html>
  