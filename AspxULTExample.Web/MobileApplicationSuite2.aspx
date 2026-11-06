<%@ Page Title="Mobile Application Suite - Mobile Property Detail & Direct Inquiry Screen" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="MobileApplicationSuite2.aspx.cs" Inherits="AspxULTExample.Web.MobileApplicationSuite2" %>

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
                    <img src="/Svg/google-meet.svg" alt="Aspx ULT Example Logo" width="28" height="28" class="d-inline-block align-text-top">&nbsp;UMGC&nbsp;Property&nbsp;Details</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item"><a class="nav-link text-dark" runat="server" href="~/">Share</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <section class="row">
            <div>
                <button class="btn btn-info"><i class="bi bi-arrow-bar-left"></i>&nbsp;Back to Search Results</button>
            </div>
        </section>
        <section class="row">
            <br />
        </section>
        <div class="row  myPadding">
            <div class="col-auto">
                <div class="text-center">
                    <img src="/Content/images/ellison-museum-district-richmond.jpg" alt="Kitchen_View.jpg" height="200">
                </div>
                <div class="text-center weightResult">
                    <div>Photos: < Previous&nbsp;&nbsp;&nbsp;&nbsp;[1]&nbsp;for&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;Next > </div>
                </div>
                $1,850 / mo<br />
                10400 Campus Way S, Largo, MD<br />
                Property Type: Apartment    
            </div>
        </div>
        <div class="row  myPadding">
            <div class="col-auto">
                <h6>QUICK SPECS GRID</h6>
                <table class="master_pro">
                    <thead>
                        <tr>
                            <th>Sq Feet</th>
                            <th>Bedrooms</th>
                            <th>Baths</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1,250</td>
                            <td>2 Beds</td>
                            <td>2.5</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row  myPadding">
            <div class="col-auto">
                <h6>BATHROOM BREAKDOWN</h6>
                Full Bathrooms: 2   <br/>            
                Half Bathrooms: 1               
            </div>
        </div>
        <div class="row  myPadding">
            <div class="col-auto">
                <h6>FEATURES & AMENITIES</h6>
                <span class="badge text-bg-secondary">Central A/C</span>&nbsp;&nbsp;<span class="badge text-bg-secondary">In-Unit W/D</span><br />
                <span class="badge text-bg-secondary">Balcony/Patio</span>&nbsp;&nbsp;<span class="badge text-bg-secondary">Off-Street</span>
            </div>
        </div>

        <div class="row  myPadding">
            <div class="col-auto">
                <h6>INQUIRE / ASK QUESTIONS</h6>
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
                        Questions:
                    </div>
                    <div class="col-auto">
                        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3">I am interested in scheduling a tour for this apartment...</textarea>
                    </div>
                </div>
                <br />
                <button class="btn btn-info">Submit Inquiry to Staff</button>
            </div>
        </div>
        <div class="row  myPadding">
            <div class="col-auto">
                <h6>STICKY ACTION BAR</h6>
                <button class="btn btn-info">Call Office</button>&nbsp;
                <button class="btn btn-info">Send Inquiry</button>
            </div>
        </div>
    </main>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
