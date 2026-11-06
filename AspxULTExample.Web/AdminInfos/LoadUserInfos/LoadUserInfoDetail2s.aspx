<%@ Page Title="Load User Info&nbsp;Detail2s" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="LoadUserInfoDetail2s.aspx.cs" Inherits="AspxULTExample.Web.AdminInfos.LoadUserInfos.LoadUserInfoDetail2s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <section class="row">
            <h5 id="title">
                <asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
        </section>
        <section class="row">
            <br />
        </section>
        <section class="row">
            <br />
        </section>

        <section class="row">
            <div class="col-auto">
                <asp:HiddenField ID="HiddenField_UserInfoID" runat="server" />
                <asp:Label ID="LabelDisplayNameForUserInfoID" CssClass="form-label" Text="User Info ID:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>


        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoUserIdentityName" CssClass="form-label" Text="User Info User Identity Name:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoUserIdentityName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>


        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoUserName" CssClass="form-label" Text="User Info User Name:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoUserName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>


        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoFullName" CssClass="form-label" Text="User Info Full Name:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoFullName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>


        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoEmailAddress" CssClass="form-label" Text="User Info Email Address:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoEmailAddress" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>


        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoJobTitle" CssClass="form-label" Text="User Info Job Title:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoJobTitle" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>


        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoActiveYesNo" CssClass="form-label" Text="User Info Active Yes No:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoActiveYesNo" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>


        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoAccessLevelID" CssClass="form-label" Text="User Info Access Level ID:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoAccessLevelID" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>

        <section class="row">
            <div class="col-auto">
                <asp:Label ID="LabelDisplayNameForUserInfoAccessLevelName" CssClass="form-label" Text="User Info Access Level Name:" runat="server"></asp:Label>
            </div>
            <div class="col-auto">
                <asp:Label ID="LabelDisplayForUserInfoAccessLevelName" CssClass="form-label" Font-Bold="True" runat="server"></asp:Label>
            </div>
        </section>
        <section class="row">
            <br />
        </section>



        <div>
            <asp:LinkButton runat="server" ID="LinkButtonBackToList" Text="<i class='bi bi-arrow-bar-left'></i>&nbsp;Back&nbsp;to&nbsp;List" CssClass="btn btn-info" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="window.location='../LoadUserInfos/LoadUserInfoGridView2.aspx'; return false;" />
        </div>
    </main>
</asp:Content>
