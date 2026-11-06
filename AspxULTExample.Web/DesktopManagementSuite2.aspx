<%@ Page Title="Desktop Management Suite - Property Creation & Feature Catalog Editor Modal" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="DesktopManagementSuite2.aspx.cs" Inherits="AspxULTExample.Web.DesktopManagementSuite2" %>

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
                    <img src="/Svg/google-meet.svg" alt="Aspx ULT Example Logo" width="28" height="28" class="d-inline-block align-text-top">&nbsp;UMGC&nbsp;Property&nbsp;Rentals&nbsp;-&nbsp;Create&nbsp;New&nbsp;Property&nbsp;Record</a>
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
                <h6>GENERAL INFO  |  SPECIFICATIONS & PRICING  |  FEATURES & MEDIA</h6>
            </div>
        </div>
        <div class="row myPadding">
            <div class="col-auto">
                Property Type:<br />
                <br />
                <div class="row">
                    <div class="col-auto">
                        <input class="form-check-input" type="radio" name="radioDefault" id="radioDefault1" checked="">
                        Apartment
                    </div>
                    <div class="col-auto">
                        <input class="form-check-input" type="radio" name="radioDefault" id="radioDefault2">
                        House
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-auto">
                        Street Address:  
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="10400 Campus Way South">
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-auto">
                        City / State / Zip: 
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="Largo">
                    </div>

                    <div class="col-auto">
                        <select class="form-select mb-3" aria-label="select example">
                            <option selected>MD</option>
                        </select>

                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="20774">
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-auto">
                        Square Footage:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="1250">
                    </div>
                    <div class="col-auto">
                        Sq Ft
                    </div>
                    <div class="col-auto">
                        Rent per Month:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="$1850.00">
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-auto">
                        Bedrooms:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="number" value="2">
                    </div>
                    <div class="col-auto">
                        Full Baths:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="number" value="2">
                    </div>
                    <div class="col-auto">
                        Half Baths:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="number" value="1">
                    </div>
                </div>
                <br />
            </div>
        </div>
        <div class="row myPadding">
            <div class="col-auto">
                <h6>ASSIGNED FEATURES (Selected for this property):</h6>

                <div class="row">
                    <div class="col-3">
                        <input class="form-check-input" type="checkbox" value="" id="checkChecked1" checked>
                        Central A/C 
                    </div>
                    <div class="col-4">
                        <input class="form-check-input" type="checkbox" value="" id="checkChecked2" checked>
                        In-Unit Washer/Dryer
                    </div>
                    <div class="col-3">
                        <input class="form-check-input" type="checkbox" value="" id="checkChecked3" checked>
                        Balcony/Patio 
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <input class="form-check-input" type="checkbox" value="" id="checkChecked4">
                        Pet Friendly 
                    </div>
                    <div class="col-4">
                        <input class="form-check-input" type="checkbox" value="" id="checkChecked5">
                        Covered Parking
                    </div>
                    <div class="col-3">
                        <input class="form-check-input" type="checkbox" value="" id="checkChecked6">
                        Swimming Pool                        
                    </div>
                </div>
                <br />
                <h6>MASTER FEATURE LIST MANAGEMENT:</h6>

                <div class="row align-items-center">
                    <div class="col-auto">
                        Add New Feature to Master List:
                    </div>
                    <div class="col-auto">
                        <select class="form-select mb-3" aria-label="select example">
                            <option selected>EV Charging Station</option>
                        </select>
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-info">Add to Master Feature List</button>
                    </div>
                </div>
                <div class="row align-items-center">
                    <div class="col-auto">
                        Existing Feature Selected:
                    </div>
                    <div class="col-auto">
                        <select class="form-select mb-3" aria-label="select example">
                            <option selected>Swimming Pool</option>
                        </select>
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-info">Delete Selected Feature Tag</button>
                    </div>
                </div>

            </div>
        </div>
        <div class="row myPadding">
            <div class="col-auto">
                <h6>PHOTOS ATTACHED (1 or more required):</h6>
                <div class="row">
                    <div class="col-auto">
                        <div class="row">
                            <div class="col-auto">
                                <table class="master_pro">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Name</th>
                                            <th>Image</th>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td>Main_Living.jpg
                                            </td>
                                            <td>
                                                <img src="/Content/images/Main_Living.jpg" alt="Main_Living.jpg" width="28" height="28">
                                            </td>
                                            <td>
                                                <button class="btn btn-info">Set Primary</button></td>
                                            <td>
                                                <button class="btn btn-info">Remove</button></td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td>Kitchen_View.jpg
                                            </td>
                                            <td>
                                                <img src="/Content/images/Kitchen_View.jpg" alt="Kitchen_View.jpg" width="28" height="28">
                                            </td>
                                            <td>
                                                <button class="btn btn-info">Set Primary</button></td>
                                            <td>
                                                <button class="btn btn-info">Remove</button></td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="6">
                                                <div class="row weightResult">
                                                    <div class="col-6">Showing 1-2 of 2 properties</div>
                                                    <div class="col-6">< Previous&nbsp;&nbsp;&nbsp;&nbsp;[1] &nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-auto">

                        <div class="row">
                            <div class="col-auto">
                                <label for="formFile" class="form-label">Select a file to upload:</label>
                                <input class="form-control" type="file" id="formFile">
                                <button class="btn btn-info"><i class="bi bi-upload"></i>&nbsp;Upload Photos</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="row myPadding">
            <div class="col-auto">
                <br />
                <br />
                <div class="row">
                    <div class="col-auto">
                        <button class="btn btn-info"><i class="bi bi-arrow-bar-left"></i>&nbsp;Cancel</button>&nbsp;
                    <button class="btn btn-info"><i class="bi bi-plus-square"></i>&nbsp;Save&nbsp;&amp;&nbsp;Publish&nbsp;Listing</button>
                    </div>
                </div>
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
