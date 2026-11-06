<%@ Page Title="Web Application Portal - Detailed Property View & Inquiry Modal" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="WebApplicationPortal2.aspx.cs" Inherits="AspxULTExample.Web.WebApplicationPortal2" %>

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
        <section class="row">
            <div>
            <button class="btn btn-info"><i class="bi bi-arrow-bar-left"></i>&nbsp;Back to Search Results</button>
            </div>
        </section>
        <section class="row">
            <br />
        </section>
        <div class="row myPadding">
            <div class="col-auto">
                10400 Campus Way South, Largo, MD 20774<br />
                Apartment | $1,850 / month | 1,250 Sq Ft | 2 Beds | 2 Full Baths | 1 Half Bath 
            </div>
        </div>

        <div class="row myPadding">
            <div class="col-auto">
                <h6>PHOTO GALLERY & LIGHTBOX PLAYER</h6>
                <div class="row">
                    <div class="col-auto">
                        <div class="text-center">
                            <img src="/Content/images/ellison-museum-district-richmond.jpg" alt="Kitchen_View.jpg" height="200">
                        </div>
                        <div class="text-center weightResult">
                            <div>Photos: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                        </div>
                    </div>
                    <div class="col-auto">
                        <div class="text-center">
                            <img src="/Content/images/luxury_apartments_richmond_14.jpeg" alt="Living Room" width="28" height="28">
                        </div>
                        <div class="text-center">
                            <div>Living Room</div>
                        </div>
                        <div class="text-center">
                            <img src="/Content/images/luxury_apartments_richmond_13.jpeg" alt="Kitchen" width="28" height="28">
                        </div>
                        <div class="text-center">
                            <div>Kitchen</div>
                        </div>
                        <div class="text-center">
                            <img src="/Content/images/luxury_apartments_richmond_33.jpeg" alt="Bedroom" width="28" height="28">
                        </div>
                        <div class="text-center">
                            <div>Bedroom</div>
                        </div>
                        <div class="text-center">
                            <img src="/Content/images/luxury_apartments_richmond_va_9.jpeg" alt="Balcony" width="28" height="28">
                        </div>
                        <div class="text-center">
                            <div>Balcony</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row myPadding">
            <div class="col-5">
                <h6>PROPERTY OVERVIEW & FEATURES</h6>
                Property Specs:
                <br />
                - Type: Apartment
                <br />
                - Size: 1,250 Square Feet
                <br />
                - Bedrooms: 2  
                <br />
                - Bathrooms: 2 Full, 1 Half<br />
                - Monthly Rent: $1,850.00 
                <br /><br />

                Included Features & Amenities:<br />
                <span class="badge text-bg-secondary">Central A/C</span>&nbsp;&nbsp;<span class="badge text-bg-secondary">In-Unit W/D</span><br />
                <span class="badge text-bg-secondary">Balcony/Patio</span>&nbsp;&nbsp;<span class="badge text-bg-secondary">Off-Street</span>
                <br />
                
            </div>
            <div class="col-7">
                <h6>INQUIRE ABOUT THIS PROPERTY</h6>
                <div class="row">
                    <div class="col-auto">
                        Name:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="Jane Smith">
                    </div>
                </div>
                <br />

                <div class="row">
                    <div class="col-auto">
                        Email: 
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="janesmith@example.com">
                    </div>
                </div>
                <br />

                <div class="row">
                    <div class="col-auto">
                        Phone:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="(301) 555-0199">
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="col-auto">
                        Move Date:
                    </div>
                    <div class="col-auto">
                        <input class="form-control" type="text" value="09/01/2026">
                    </div>
                </div>
                <br />

                <div class="row">
                    <div class="col-auto">
                        Message:
                    </div>
                    <div class="col-auto">
                        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3">I am interested in scheduling a tour for this apartment...</textarea>
                    </div>
                </div>
                <br />
                <button class="btn btn-info">Send Inquiry to UMGC Office Staff</button>
                <br />
                <br />
                Status: Staff typically responds within 2 hours.
            </div>
        </div>
        <div class="row myPadding">
            <div class="col-auto">
                <h6>Location Map</h6>
                <div class="row">
                <div class="col-auto">
                    <img src="/Content/images/copy10400CampusWaySouthLargoMD20774.jpg" alt="10400 Campus Way South, Largo, MD 20774" height="500">
                </div>
                </div>
            </div>
        </div>
 
    </main>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
