<%@ Page Title="Mobile Application Suite - Mobile Search & Map/List Explorer" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="MobileApplicationSuite.aspx.cs" Inherits="AspxULTExample.Web.MobileApplicationSuite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style>
        h6, .weightResult {
            font-weight: bold !important;
            padding: 10px 0;
        }

        .promo-text {
            color: #000080;
            font-weight: bold;
            background-color: #fff0eb;
            padding: 2px 6px;
            border-radius: 4px;
        }

        table {
            border-collapse: collapse;
            width: 100%;
            font-family: Arial, sans-serif;
        }

        .master_pro table {
            border-collapse: collapse;
            width: 100%;
            font-family: Arial, sans-serif;
        }

        /* 1. Styling the Table Header Section */
        .master_pro thead {
            background-color: #2c5e77; /* Dark blue background */
            color: #ffffff; /* White text color */
        }

        /* Styling cells inside the header */
        .master_pro th {
            padding: 12px;
            text-align: left;
            font-weight: bold;
        }

        /* 2. Styling the Table Body Section */
        .master_pro tbody {
            background-color: #f9f9f9; /* Default light gray for body */
            color: #333333; /* Charcoal text color */
        }

        /* Styling cells inside the body */
        .master_pro td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        /* 3. Optional: Zebra Striping (Alternating Row Colors) */
        .master_pro tbody tr:nth-child(even) {
            background-color: #e4f0f5; /* Light blue accent for even rows */
        }

        /* 4. Optional: Hover Effect */
        .master_pro tbody tr:hover, .myColor {
            background-color: #d1e3ed; /* Highlights row on mouse hover */
        }

        .paddingSearch {
            padding: 0 0 0 360px;
        }

        .paddingResult {
            padding: 0 0 0 360px;
        }

        .myPadding {
            padding: 10px;
        }

        .myHeight {
            height: 430px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <section class="row">
            <h5 id="title">
                <asp:Label ID="LabelPageTitle" runat="server"><%: Page.Title %></asp:Label></h5>
        </section>
        <section class="row">
            <br />
        </section>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm bg-info">
            <div class="container">
                <a class="navbar-brand" runat="server" href="~/">
                    <img src="/Svg/google-meet.svg" alt="Aspx ULT Example Logo" width="28" height="28" class="d-inline-block align-text-top">&nbsp;UMGC&nbsp;Property&nbsp;Rentals</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                </div>
            </div>
        </nav>
        <div class="row myPadding">
            <div class="col-auto">

                <div class="row">
                    <div class="col-auto">
                        <button class="btn btn-info">Filter</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        <div class="row align-items-center">
                            <div class="col-auto">
                                Find:
                            </div>
                            <div class="col-auto">
                                <input type="text" class="form-control" id="usernameInput" placeholder="Enter Address, City, Zip..." />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        Type:
                    </div>
                    <div class="col-auto">
                        <select class="form-select" aria-label="select example">
                            <option selected>All</option>
                        </select>
                    </div>
                    <div class="col-auto">
                        Price:
                    </div>
                    <div class="col-auto">
                        <select class="form-select" aria-label="select example">
                            <option selected>All</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        <button class="btn btn-info"><i class="bi bi-search"></i>&nbsp;Search</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="row myPadding">
            <div class="col-auto">
                <button class="btn btn-info">Map View</button>&nbsp;<button class="btn btn-info">List View</button>
            </div>
        </div>

        <div class="row  myPadding">
            <div class="col-auto">
                <div class="border border-primary myPadding">
                    <div class="text-center">
                        <img src="/Content/images/ellison-museum-district-richmond.jpg" alt="Kitchen_View.jpg" width="100" height="70">
                    </div>
                    <div class="text-center weightResult">
                        <div>Photos: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                    </div>
                    $1,850 / mo<br />
                    10400 Campus Way S, Largo, MD<br />
                    Apartment | Sq Ft: 1,250 sq ft
                    <br />
                    2 Beds | 2.0 Full | 1.0 Half<br />
                    Features: Central A/C, Balcony<br />
                    <button class="btn btn-info">View Details</button>
                    <button class="btn btn-info">Contact</button>
                </div>
            </div>
        </div>
        <div class="row  myPadding">
            <div class="col-auto">
                <div class="border border-primary myPadding">
                    <div class="text-center">
                        <img src="/Content/images/3025-glenan-dr-richmond-va-building-photo.jpg" alt="Kitchen_View.jpg" width="100" height="70">
                    </div>
                    <div class="text-center weightResult">
                        <div>Photo: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                    </div>
                    $2,400 / mo<br />
                    123 Main St, Upper Marlboro<br />
                    House | 2,400 Sq Ft<br />
                    4 Bed | 2.5 Full | 0.0 Half<br />
                    Features: Garage, Pool<br />
                    <button class="btn btn-info">View Details</button>
                    <button class="btn btn-info">Contact</button>
                </div>
            </div>
        </div>
        <div class="row  myPadding">
            <div class="col-auto">
                <button class="btn btn-info">Explore</button>&nbsp;
                <button class="btn btn-info">Saved</button>&nbsp;
                <button class="btn btn-info">Contact</button>
            </div>
        </div>

    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
