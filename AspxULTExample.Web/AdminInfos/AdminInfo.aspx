<%@ Page Title="Admin&nbsp;Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="AdminInfo.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.AdminInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <section class="row">
            <h5 id="title"><%: Title %></h5>
            <br />
            <br />
        </section>
        <div class="row">
            <ul class="list-group">

                <li class="list-group-item">
                    <h6>Dmv Study Prac Q Opts</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQOpts/DmvStudyPracQOptGridView.aspx">DmvStudyPracQOpt&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQOpts/DmvStudyPracQOptGridView2.aspx">DmvStudyPracQOpt&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQOpts/DmvStudyPracQOptTelerikRadGrid.aspx">DmvStudyPracQOpt&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQOpts/DmvStudyPracQOptTelerikRadGrid2.aspx">DmvStudyPracQOpt&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>Dmv Study Prac Questions</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQuestions/DmvStudyPracQuestionGridView.aspx">DmvStudyPracQuestion&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQuestions/DmvStudyPracQuestionGridView2.aspx">DmvStudyPracQuestion&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQuestions/DmvStudyPracQuestionTelerikRadGrid.aspx">DmvStudyPracQuestion&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQuestions/DmvStudyPracQuestionTelerikRadGrid2.aspx">DmvStudyPracQuestion&nbsp;TelerikRadGrid2</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQuestions/DmvStudyPracQuestionRepeaterQOptTen.aspx">The&nbsp;Knowledge&nbsp;Exam.&nbsp;Part&nbsp;one:&nbsp;10&nbsp;road&nbsp;sign&nbsp;questions</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracQuestions/DmvStudyPracQuestionRepeaterQOptThirty.aspx">The&nbsp;Knowledge&nbsp;Exam.&nbsp;Part&nbsp;two:&nbsp;30&nbsp;general&nbsp;knowledge&nbsp;questions</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>Dmv Study Practs</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracts/DmvStudyPractGridView.aspx">DmvStudyPract&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracts/DmvStudyPractGridView2.aspx">DmvStudyPract&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracts/DmvStudyPractTelerikRadGrid.aspx">DmvStudyPract&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/DmvStudyPracts/DmvStudyPractTelerikRadGrid2.aspx">DmvStudyPract&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>Examples</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/Examples/ExampleGridView.aspx">Example&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/Examples/ExampleGridView2.aspx">Example&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/Examples/ExampleTelerikRadGrid.aspx">Example&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/Examples/ExampleTelerikRadGrid2.aspx">Example&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>Example Approves</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/ExampleApproves/ExampleApproveGridView.aspx">ExampleApprove&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/ExampleApproves/ExampleApproveGridView2.aspx">ExampleApprove&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/ExampleApproves/ExampleApproveTelerikRadGrid.aspx">ExampleApprove&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/ExampleApproves/ExampleApproveTelerikRadGrid2.aspx">ExampleApprove&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>Example File Upload2s</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/ExampleFileUpload2s/ExampleFileUpload2GridView.aspx">ExampleFileUpload2&nbsp;GridView</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>Example Logs</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/ExampleLogs/ExampleLogGridView.aspx">ExampleLog&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/ExampleLogs/ExampleLogGridView2.aspx">ExampleLog&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/ExampleLogs/ExampleLogTelerikRadGrid.aspx">ExampleLog&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/ExampleLogs/ExampleLogTelerikRadGrid2.aspx">ExampleLog&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>Load User Infos</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/LoadUserInfos/LoadUserInfoGridView2.aspx">LoadUserInfo&nbsp;GridView2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>User Infos</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/UserInfos/UserInfoGridView.aspx">UserInfo&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfos/UserInfoGridView2.aspx">UserInfo&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfos/UserInfoTelerikRadGrid.aspx">UserInfo&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfos/UserInfoTelerikRadGrid2.aspx">UserInfo&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>User Info Access Levels</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/UserInfoAccessLevels/UserInfoAccessLevelGridView.aspx">UserInfoAccessLevel&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoAccessLevels/UserInfoAccessLevelGridView2.aspx">UserInfoAccessLevel&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoAccessLevels/UserInfoAccessLevelTelerikRadGrid.aspx">UserInfoAccessLevel&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoAccessLevels/UserInfoAccessLevelTelerikRadGrid2.aspx">UserInfoAccessLevel&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>User Info Companys</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCompanys/UserInfoCompanyGridView.aspx">UserInfoCompany&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCompanys/UserInfoCompanyGridView2.aspx">UserInfoCompany&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCompanys/UserInfoCompanyTelerikRadGrid.aspx">UserInfoCompany&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCompanys/UserInfoCompanyTelerikRadGrid2.aspx">UserInfoCompany&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>User Info Countriess</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCountriess/UserInfoCountriesGridView.aspx">UserInfoCountries&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCountriess/UserInfoCountriesGridView2.aspx">UserInfoCountries&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCountriess/UserInfoCountriesTelerikRadGrid.aspx">UserInfoCountries&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoCountriess/UserInfoCountriesTelerikRadGrid2.aspx">UserInfoCountries&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>User Info Statuss</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/UserInfoStatuss/UserInfoStatusGridView.aspx">UserInfoStatus&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoStatuss/UserInfoStatusGridView2.aspx">UserInfoStatus&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoStatuss/UserInfoStatusTelerikRadGrid.aspx">UserInfoStatus&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoStatuss/UserInfoStatusTelerikRadGrid2.aspx">UserInfoStatus&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>User Info User Info Access Level Xrefs</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefGridView.aspx">UserInfoUserInfoAccessLevelXref&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefGridView2.aspx">UserInfoUserInfoAccessLevelXref&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefTelerikRadGrid.aspx">UserInfoUserInfoAccessLevelXref&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefTelerikRadGrid2.aspx">UserInfoUserInfoAccessLevelXref&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>User Info User Info Company Xrefs</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefGridView.aspx">UserInfoUserInfoCompanyXref&nbsp;GridView</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefGridView2.aspx">UserInfoUserInfoCompanyXref&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefTelerikRadGrid.aspx">UserInfoUserInfoCompanyXref&nbsp;TelerikRadGrid</a></li>
                        <li><a runat="server" href="~/AdminInfos/UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefTelerikRadGrid2.aspx">UserInfoUserInfoCompanyXref&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>View Examples</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/ViewExamples/ViewExampleGridView2.aspx">ViewExample&nbsp;GridView2</a></li>
                        <li><a runat="server" href="~/AdminInfos/ViewExamples/ViewExampleTelerikRadGrid2.aspx">ViewExample&nbsp;TelerikRadGrid2</a></li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <h6>View Example File Upload2s</h6>
                    <ul>
                        <li><a runat="server" href="~/AdminInfos/ViewExampleFileUpload2s/ViewExampleFileUpload2GridView.aspx">ViewExampleFileUpload2&nbsp;GridView</a></li>
                    </ul>
                </li>

            </ul>
        </div>
    </main>
</asp:Content>
