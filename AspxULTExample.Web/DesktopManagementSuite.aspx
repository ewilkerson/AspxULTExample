<%@ Page Title="Desktop Management Suite - Master Property Inventory & Management Dashboard" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="DesktopManagementSuite.aspx.cs" Inherits="AspxULTExample.Web.Desktop" %>

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
        .master_pro tbody tr:hover {
            background-color: #d1e3ed; /* Highlights row on mouse hover */
        }

        .myColorPadding {
            background-color: #d1e3ed; /* Highlights row on mouse hover */
            padding: 10px;
        }


        .paddingSearch {
            padding: 0 0 0 360px;
        }

        .paddingResult {
            padding: 0 0 0 280px;
        }

        .master_pro table, tr, td {
            height: auto !important;
        }

        .myPadding {
            padding: 10px;
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
                    <img src="/Svg/google-meet.svg" alt="Aspx ULT Example Logo" width="28" height="28" class="d-inline-block align-text-top">&nbsp;UMGC&nbsp;Property&nbsp;Rentals&nbsp;-&nbsp;Staff&nbsp;Desktop&nbsp;Suite&nbsp;v3.1</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1"></ul>
                    <p class="navbar-text navbar-right"><i class="bi bi-x-circle"></i></p>
                    </div>
            </div>
        </nav>
        <div class="row myPadding">
            <div class="col-auto">
                <span class="promo-text">File</span>
                <span class="promo-text">Edit</span>
                <span class="promo-text">View</span>
                <span class="promo-text">Properties</span>
                <span class="promo-text">Features</span>
                <span class="promo-text">Reports</span>
                <span class="promo-text">Help</span>
            </div>
        </div>
        <div class="row myPadding">
            <div class="col-auto">
                <button class="btn btn-info"><i class="bi bi-plus-square"></i>&nbsp;Add&nbsp;Property</button>
                <button class="btn btn-info"><i class="bi bi-pencil-square"></i>&nbsp;Edit Selected</button>
                <button class="btn btn-info"><i class="bi bi-trash3"></i>&nbsp;Delete</button>
            </div>
            <div class="col-auto paddingSearch">
                <div class="row">
                    <div class="col-auto">
                        Search:
                    </div>
                    <div class="col-auto">
                        <input type="text" class="form-control" />
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-info"><i class="bi bi-search"></i>&nbsp;Search</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="row myPadding">
            <div class="col-6">
                <h6>FILTERS</h6>
                <br />
                <div class="row">
                    <div class="col-auto">
                        Property Type:
                    </div>
                    <div class="col-auto">
                        <select class="form-select mb-3" aria-label="select example">
                            <option selected>All</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        Bedrooms:
                    </div>
                    <div class="col-auto">
                        <select class="form-select mb-3" aria-label="select example">
                            <option selected>All</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        Full/Half Baths:
                    </div>
                    <div class="col-auto">
                        <select class="form-select mb-3" aria-label="select example">
                            <option selected>All</option>
                            <option value="1">1</option>
                            <option value="1">1.5</option>
                            <option value="2">2</option>
                            <option value="1">2.5</option>
                            <option value="3">3</option>
                            <option value="1">3.5</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        Max Rent:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="$3000">
                    </div>
                </div>
                <br />
                Features:<br />
                <br />
                <input class="form-check-input" type="checkbox" value="" id="checkChecked3" checked>
                Garage&nbsp;<input class="form-check-input" type="checkbox" value="" id="checkChecked4">
                Pool&nbsp;<input class="form-check-input" type="checkbox" value="" id="checkChecked5">
                Washer/Dryer In Unit<br />
                <button class="btn btn-info">Clear Filters</button><br />
                <br />
                <h6>MASTER FEATURE CATALOG MANAGER</h6>
                <button class="btn btn-info">Manage Master Feature List</button>

            </div>
            <div class="col-6">
                <div>
                    <h6>MASTER PROPERTY INVENTORY TABLE</h6>
                    <table class="master_pro">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Type</th>
                                <th>Address</th>
                                <th>SqFt</th>
                                <th>Beds</th>
                                <th>Baths</th>
                                <th>Rent/Mo</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1001</td>
                                <td>House</td>
                                <td>123 Main</td>
                                <td>2400</td>
                                <td>4</td>
                                <td>2.5</td>
                                <td>$2,400</td>
                            </tr>
                            <tr>
                                <td>1002</td>
                                <td>Apartment</td>
                                <td>456 Oak</td>
                                <td>850</td>
                                <td>1</td>
                                <td>1.0</td>
                                <td>$1,250</td>
                            </tr>
                            <tr>
                                <td>1003</td>
                                <td>Apartment</td>
                                <td>789 Pine</td>
                                <td>1100</td>
                                <td>2</td>
                                <td>1.5</td>
                                <td>$1,600</td>
                            </tr>
                            <tr>
                                <td>1004</td>
                                <td>House</td>
                                <td>321 Elm</td>
                                <td>3100</td>
                                <td>5</td>
                                <td>3.5</td>
                                <td>$3,200</td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="7" class="weightResult">
                                    <div class="row">
                                        <div class="col-6">Showing 1-4 of 48 properties</div>
                                        <div class="col-6">< Previous&nbsp;&nbsp;&nbsp;&nbsp;[1] 2 3 &sdot;&sdot;&sdot; 12&nbsp;&nbsp;&nbsp;&nbsp;Next ></div>
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <br />
                <h6>SELECTED PROPERTY PREVIEW PANEL</h6>
                Address: 123 Main St, Upper Marlboro, MD<br />
                Photos:
                <img src="/Content/images/image1.jpg" alt="My photo 1" width="28" height="28">
                <img src="/Content/images/image2.jpg" alt="My photo 2" width="28" height="28">
                <button class="btn btn-info"><i class="bi bi-upload"></i>&nbsp;Upload Photos</button>
            </div>
        </div>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm bg-info s">
            <div class="container">
                <span>Status: Connected to Server (Latency: 12ms)</span>
                <span>Active Filters: 2</span>
                <span>Selected: ID #1001</span>
            </div>
        </nav>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
