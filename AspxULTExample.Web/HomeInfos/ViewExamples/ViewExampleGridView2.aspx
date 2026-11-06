<%@ Page Title="View Example&nbsp;GridView2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="ViewExampleGridView2.aspx.cs" Inherits="AspxULTExample.Web.HomeInfos.ViewExamples.ViewExampleGridView2" %>

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
            <asp:LinkButton runat="server" ID="LinkButtonAdd" Text="<i class='bi bi-plus-square'></i>&nbsp;Add&nbsp;New" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../ViewExamples/ViewExampleCreate2.aspx'; return false;" />
        </div>
        <section class="row">
            <br />
        </section>
        <section class="row">
            <section class="col-auto">
                <div class="table-responsive">
                    <asp:GridView ID="ResultGridView" runat="server"
                        AutoGenerateColumns="False"
                        ShowFooter="False"
                        DataKeyNames="ExampleID"
                        AllowPaging="False"
                        CellPadding="3"
                        CellSpacing="2"
                        OnPageIndexChanging="ResultGridView_PageIndexChanging"
                        GridLines="Vertical"
                        CssClass="display"
                        ShowHeaderWhenEmpty="true">
                        <Columns>

                            <asp:BoundField DataField="ExampleID" HeaderText="Example ID" InsertVisible="False"
                                ReadOnly="True" SortExpression="ExampleID" />


                            <asp:BoundField DataField="ExampleUserInfoStatusID" HeaderText="Example User Info Status ID" InsertVisible="False"
                                ReadOnly="True" SortExpression="ExampleUserInfoStatusID" />


                            <asp:BoundField DataField="ExampleUserInfoCompanyID" HeaderText="Example User Info Company ID" InsertVisible="False"
                                ReadOnly="True" SortExpression="ExampleUserInfoCompanyID" />


                            <asp:BoundField DataField="Title" HeaderText="Title" InsertVisible="False"
                                ReadOnly="True" SortExpression="Title" />


                            <asp:BoundField DataField="Release" HeaderText="Release" InsertVisible="False"
                                ReadOnly="True" SortExpression="Release" />


                            <asp:BoundField DataField="ReleaseDateTime" HeaderText="Release Date Time" InsertVisible="False"
                                ReadOnly="True" SortExpression="ReleaseDateTime" DataFormatString="{0:M/d/yyyy HH:mm:ss}" />


                            <asp:BoundField DataField="Genre" HeaderText="Genre" InsertVisible="False"
                                ReadOnly="True" SortExpression="Genre" />


                            <asp:BoundField DataField="Price" HeaderText="Price" InsertVisible="False"
                                ReadOnly="True" SortExpression="Price" />


                            <asp:CheckBoxField DataField="PriceYesNo" HeaderText="Price Yes No" InsertVisible="False"
                                ReadOnly="True" SortExpression="PriceYesNo" />


                            <asp:BoundField DataField="ReleaseDate" HeaderText="Release Date" InsertVisible="False"
                                ReadOnly="True" SortExpression="ReleaseDate" DataFormatString="{0:M/d/yyyy}" />


                            <asp:BoundField DataField="ReleaseTime" HeaderText="Release Time" InsertVisible="False"
                                ReadOnly="True" SortExpression="ReleaseTime" DataFormatString="{0:hh\:mm\:ss}" />


                            <asp:BoundField DataField="Message" HeaderText="Message" InsertVisible="False"
                                ReadOnly="True" SortExpression="Message" />


                            <asp:BoundField DataField="Message2" HeaderText="Message2" InsertVisible="False"
                                ReadOnly="True" SortExpression="Message2" />


                            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" InsertVisible="False"
                                ReadOnly="True" SortExpression="PhoneNumber" />


                            <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" InsertVisible="False"
                                ReadOnly="True" SortExpression="EmailAddress" />


                            <asp:BoundField DataField="CreditCard" HeaderText="Credit Card" InsertVisible="False"
                                ReadOnly="True" SortExpression="CreditCard" />


                            <asp:BoundField DataField="Password" HeaderText="Password" InsertVisible="False"
                                ReadOnly="True" SortExpression="Password" />


                            <asp:BoundField DataField="Url" HeaderText="Url" InsertVisible="False"
                                ReadOnly="True" SortExpression="Url" />


                            <asp:CheckBoxField DataField="ExampleActiveYesNo" HeaderText="Example Active Yes No" InsertVisible="False"
                                ReadOnly="True" SortExpression="ExampleActiveYesNo" />


                            <asp:BoundField DataField="UserInfoCompanyName" HeaderText="User Info Company Name" InsertVisible="False"
                                ReadOnly="True" SortExpression="UserInfoCompanyName" />


                            <asp:BoundField DataField="UserInfoStatusName" HeaderText="User Info Status Name" InsertVisible="False"
                                ReadOnly="True" SortExpression="UserInfoStatusName" />


                            <asp:HyperLinkField DataNavigateUrlFields="ExampleID" DataNavigateUrlFormatString="../ViewExamples/ViewExampleDetail2s.aspx?id={0}" HeaderText="Details" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-card-list'></i>&nbsp;Details</span>" />
                            <asp:HyperLinkField DataNavigateUrlFields="ExampleID" DataNavigateUrlFormatString="../ViewExamples/ViewExampleEditDelete.aspx?id={0}" HeaderText="Edit" Text="<span class='btn btn-info' style='white-space: nowrap;'><i class='bi bi-pencil-square'></i>&nbsp;Edit</span>" />
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
