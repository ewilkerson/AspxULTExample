
    <%@ Page Title="Temperature Converter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="AspxULTExample.Web._Default" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
    <section class="row">
    <h5 id="title"><asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="text-bg-danger p-3" HeaderText="You must enter a value in the following fields:" runat="server" />
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelTemperature" AssociatedControlID="TextBoxTemperature"  CssClass="form-label" Text="Enter Temperature:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:TextBox ID="TextBoxTemperature" CssClass="form-control" required runat="server"></asp:TextBox>
    </div>
    <div class="col-auto">
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" ControlToValidate="TextBoxTemperature" runat="server" ErrorMessage="This Temperature is required." Text="*" CssClass="text-danger" ></asp:RequiredFieldValidator>
    <asp:RangeValidator id="RangeValidatorTemperature"
    ControlToValidate="TextBoxTemperature"
    MinimumValue="-459.67"
    MaximumValue="932.00"
    Type="Double"
    EnableClientScript="false"
    ErrorMessage="The temperature must be from −459.67 to 932.00 degrees Celsius, degree Fahrenheit or degrees Kelvin!"
    Text="*"
    CssClass="text-danger"
    runat="server"/>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelTemperatureUnit" AssociatedControlID="DropDownListTemperatureUnit"  CssClass="form-label" Text="Unit:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:DropDownList id="DropDownListTemperatureUnit" CssClass="form-select"
    runat="server"  DropDownAutoWidth="Enabled">
    </asp:DropDownList>
    </div>
    </section>
    <section class="row">
    <br />
    </section>
    <div>
    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-info" Text="<i class='bi bi-plus-square'></i>&nbsp;Convert" UseSubmitBehavior="false" CausesValidation="false" OnClick="ConvertTemperatureCFK" />
    </div>
    <section class="row">
    <br />
    </section>
    <section class="row">
    <div class="col-auto">
    <asp:Label ID="LabelResult1" CssClass="form-label" Text="Result:" runat="server"></asp:Label>
    </div>
    <div class="col-auto">
    <asp:Label id="LabelResult2" CssClass="form-label" runat="server"></asp:Label>
    </div>
    </section>
    </main>
    </asp:Content>
  