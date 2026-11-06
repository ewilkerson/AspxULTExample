<%@ Page Title="Web Application Portal - Tenant Search & Rental Listings Marketplace" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="WebApplicationPortal.aspx.cs" Inherits="AspxULTExample.Web.WebApplicationPortal" %>

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
        <div class="row myPadding">
            <div class="col-auto">
                <h6>HERO SEARCH BANNER</h6>
                <div class="row align-items-center">
                    <div class="col-auto">
                        Find Your Next Home:
                    </div>
                    <div class="col-auto">
                        <input type="text" class="form-control" id="usernameInput" placeholder="Enter Address, City, Zip..." />
                    </div>
                    <div class="col-auto">
                        Property Type:
                    </div>
                    <div class="col-auto">
                        <select class="form-select" aria-label="select example">
                            <option selected>All</option>
                        </select>
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-info"><i class="bi bi-search"></i>&nbsp;Search</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="row myPadding">
            <div class="col-5">
                <h6>FILTER SIDEBAR (Facet)</h6>
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
                <br />
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
                <br />
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
                <br />
                Monthly Rent:<br />
                <div class="row">
                    <div class="col-auto">
                        Min:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="$500">
                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        Max:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="$3500">
                    </div>
                </div>
                <br />
                Features:<br />

                <input class="form-check-input" type="checkbox" value="" id="checkChecked3" checked>
                Central A/C<br />
                <input class="form-check-input" type="checkbox" value="" id="checkChecked4" checked>
                In-Unit W/D<br />
                <input class="form-check-input" type="checkbox" value="" id="checkChecked5">
                Pet Friendly<br />
                <input class="form-check-input" type="checkbox" value="" id="checkChecked6">
                Garage
            </div>
            <div class="col-7">
                <h6>PROPERTY LISTINGS CATALOG (4 Results Found)</h6>
                <div class="row">
                    <div class="col-6">
                        <div class="border border-primary myPadding">
                            <div class="text-center">
                                <img src="/Content/images/ellison-museum-district-richmond.jpg" alt="Kitchen_View.jpg" width="100" height="70">
                            </div>
                            <div class="text-center weightResult">
                                <div>Photos: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                            </div>
                            $1,850 / mo<br />
                            10400 Campus Way S, Largo, MD<br />  
                            2 Beds | 2.0 Full | 1.0 Half<br />
                            Sq Ft: 1,250 sq ft (Apartment)<br />
                            Features: Central A/C, Balcony<br />
                            <button class="btn btn-info">View Details</button>
                            <button class="btn btn-info">Ask Staff</button>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="border border-primary myPadding">
                            <div class="text-center">
                                <img src="/Content/images/3025-glenan-dr-richmond-va-building-photo.jpg" alt="Kitchen_View.jpg" width="100" height="70">
                            </div>
                            <div class="text-center weightResult">
                                <div>Photo: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                            </div>
                            $2,400 / mo<br />
                            123 Main St, Upper Marlboro, MD<br />
                            4 Beds | 2.0 Full | 1.0 Half<br />
                            Sq Ft: 2,400 sq ft (House)<br />
                            Features: Garage, Pool <br />
                            <button class="btn btn-info">View Details</button>
                            <button class="btn btn-info">Ask Staff</button>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="border border-primary myPadding">
                            <div class="text-center">
                                <img src="/Content/images/the-icon-richmond-va-building-photo.jpg" alt="Kitchen_View.jpg" width="100" height="70">
                            </div>
                            <div class="text-center weightResult">
                                <div>Photos: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                            </div>
                            $1,250 / mo<br />
                            456 Oak Ave, Bowie, MD<br />
                            1 Bed | 1.0 Full | 0.0 Half<br />
                            Sq Ft: 850 sq ft (Apartment)<br />
                            Features: In-Unit W/D, Parking<br />
                            <button class="btn btn-info">View Details</button>
                            <button class="btn btn-info">Ask Staff</button>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="border border-primary myPadding">
                            <div class="text-center">
                                <img src="/Content/images/1252-w-moore-st-richmond-va-building-photo.jpg" alt="Kitchen_View.jpg" width="100" height="70">
                            </div>
                            <div class="text-center weightResult">
                                <div>Photo: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                            </div>
                            $3,200 / mo<br />
                            321 Elm St, Annapolis, MD<br />
                            5 Beds | 3.0 Full | 1.0 Half<br />
                            Sq Ft: 3,100 sq ft (House) <br />
                            Features: Waterfront, Patio<br />
                            <button class="btn btn-info">View Details</button>
                            <button class="btn btn-info">Ask Staff</button>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row weightResult">
                    <div class="col-auto">Pagination: </div>
                    <div class="col-auto">< Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                </div>

            </div>
        </div>
    </main>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
