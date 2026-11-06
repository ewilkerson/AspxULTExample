
    <%@ Page Title="Home&nbsp;Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="HomeInfo.aspx.cs" Inherits="AspxULTExample.Web.HomeInfos.HomeInfo" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><%: Title %></h5>
    <br /><br />
    </section>
    <div class="row">
    <ul class="list-group">
    
    <li class="list-group-item">
    <h6>View Examples</h6>
    <ul>
    <li><a runat="server" href="~/HomeInfos/ViewExamples/ViewExampleGridView2.aspx">ViewExample&nbsp;GridView2</a></li>
    <li><a runat="server" href="~/HomeInfos/ViewExamples/ViewExampleTelerikRadGrid2.aspx">ViewExample&nbsp;TelerikRadGrid2</a></li>
    </ul>
    </li>
  
    <li class="list-group-item">
    <h6>View Example File Upload2s</h6>
    <ul>
    <li><a runat="server" href="~/HomeInfos/ViewExampleFileUpload2s/ViewExampleFileUpload2GridView.aspx">ViewExampleFileUpload2&nbsp;GridView</a></li>
    </ul>
    </li>
  
    </ul>
    </div>
    </main>
    </asp:Content>
  