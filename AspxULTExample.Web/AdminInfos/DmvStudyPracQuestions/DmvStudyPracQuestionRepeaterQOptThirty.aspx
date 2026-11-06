<%@ Page Title="The&nbsp;Knowledge&nbsp;Exam.&nbsp;Part&nbsp;two:&nbsp;30&nbsp;general&nbsp;knowledge&nbsp;questions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="DmvStudyPracQuestionRepeaterQOptThirty.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions.DmvStudyPracQuestionRepeaterQOptThirty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <section class="row">
            <h5 id="title">
                <asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label>
            </h5>
        </section>
        <%
            if (qNAResultsYesNo)
            {
        %>
        <section class="row">
            <br />
        </section>
        <section class="row">
            <div class="border border-primary p-2 mb-2">
                <h5>
                    <asp:Label ID="LabelResults" runat="server"></asp:Label>
                </h5>
            </div>
        </section>
        <%
            }
        %>
        <section class="row">
            <section class="col-auto">
                <asp:Repeater ID="rptQNA" runat="server" OnItemDataBound="OnItemDataBound">
                    <HeaderTemplate>
                        <table class="table">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <section class="row">
                                    <br />
                                </section>
                                <section class="row">
                                    <div>
                                        <asp:HiddenField runat="server" ID="hdnQuestionId" Value='<%# Eval("DmvStudyPracQuestionID") %>' />
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("DmvStudyPracQuestionText") %>'></asp:Label>
                                        <br />
                                        <div runat="server" visible='<%# Eval("DmvStudyPracQuestionPicsYesNo") %>'>
                                            <img src='../../Content/StudyPracQuestion/<%# Eval("DmvStudyPracQuestionID") %>.jpg' style="vertical-align: middle">
                                            <br />
                                        </div>
                                        <%
                                            if (!qNAResultsYesNo)
                                            {
                                        %>
                                        <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1"
                                            runat="server"
                                            ControlToValidate="rblOptions"
                                            ErrorMessage="Please select a option."
                                            ForeColor="Red"
                                            Display="Dynamic" />
                                        <asp:RadioButtonList ID="rblOptions" runat="server" BorderStyle="None">
                                        </asp:RadioButtonList>
                                        <%
                                            }
                                            else
                                            {
                                        %>
                                        <span>Answer</span><br />
                                        <asp:Label ID="LabelDmvStudyPracQuestionAnswerText" runat="server" Text='<%# Eval("DmvStudyPracQuestionAnswerText") %>'></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="LabelSelectedText" runat="server"></asp:Label>
                                        <%
                                            }
                                        %>
                                    </div>
                                </section>
                                <section class="row">
                                    <br />
                                </section>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </section>
        </section>
        <section class="row">
            <br />
        </section>
        <div>
            <%
                if (!qNAResultsYesNo)
                {
            %>
            <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="<i class='bi bi-pencil-square'></i>&nbsp;Submit" UseSubmitBehavior="false" CausesValidation="false" OnClick="btnSubmit_Click" />
            <%
                }
            %>
            <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;Admin&nbsp;Info" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../AdminInfo.aspx'; return false;" />
        </div>
    </main>
</asp:Content>
