<%@ Page Title="View Example File Upload2&nbsp;GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ViewExampleFileUpload2GridView.aspx.cs" Inherits="AspxULTExample.Web.HomeInfos.ViewExampleFileUpload2s.ViewExampleFileUpload2GridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <section class="row">
            <h5 id="title">
                <asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
        </section>
        <section class="row">
            <br />
        </section>
        <div>
            <h4>Select a file to upload:</h4>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:LinkButton runat="server" ID="UploadButton" OnClick="UploadButton_Click" CssClass="btn btn-info" Text="<i class='bi bi-upload'></i> &nbsp;Upload&nbsp;file" />
        </div>
        <section class="row">
            <br />
        </section>
        <section class="row">
            <section class="col-auto">

                <div class="table-responsive">
                    <asp:GridView ID="ResultGridView" runat="server" AutoGenerateColumns="False" ShowFooter="False"
                        DataKeyNames="ExampleFileUpload2ID"
                        AllowPaging="False"
                        CellPadding="3"
                        CellSpacing="2"
                        OnPageIndexChanging="ResultGridView_PageIndexChanging"
                        OnRowDeleting="ResultGridView_RowDeleting"
                        OnRowDataBound="ResultGridView_OnRowDataBound"
                        PageSize="10"
                        GridLines="Vertical"
                        CssClass="display"
                        ShowHeaderWhenEmpty="true">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <EmptyDataTemplate>No data found</EmptyDataTemplate>
                        <EmptyDataRowStyle HorizontalAlign="Center" />

                        <Columns>

                            <asp:BoundField DataField="ExampleFileUpload2ID" HeaderText="ExampleFileUpload2ID" InsertVisible="False"
                                ReadOnly="True" SortExpression="ExampleFileUpload2ID" />


                            <asp:BoundField DataField="FileName" HeaderText="FileName" InsertVisible="False"
                                ReadOnly="True" SortExpression="FileName" />


                            <asp:BoundField DataField="FileContentType" HeaderText="FileContentType" InsertVisible="False"
                                ReadOnly="True" SortExpression="FileContentType" />


                            <asp:BoundField DataField="FileContentLength" HeaderText="FileContentLength" InsertVisible="False"
                                ReadOnly="True" SortExpression="FileContentLength" />


                            <asp:BoundField DataField="FileContentLengthKbMb" HeaderText="FileContentLengthKbMb" InsertVisible="False"
                                ReadOnly="True" SortExpression="FileContentLengthKbMb" DataFormatString="{0} Kg" />
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DownloadLink" runat="server" HeaderText="Download" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-download'></i>&nbsp;Download</span>" OnClick="DownloadData" CommandArgument='<%# Eval("ExampleFileUpload2ID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" DeleteText="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-trash3'></i>&nbsp;Delete</span>" />
                        </Columns>
                    </asp:GridView>
                </div>

            </section>
        </section>
        <section class="row">
            <br />
        </section>
        <div>
            <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;Home&nbsp;Info" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../HomeInfo.aspx'; return false;" />
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

