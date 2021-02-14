<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="EventShare.Home.CreateEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head runat="server">
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1, shrink-to-fit=no"
    />
    <title>Create Event</title>
    <link href="../assets/img/brand/favicon.png" rel="icon" type="image/png" />

    <!-- Fonts -->
    <link
      href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700"
      rel="stylesheet"
    />

    <!-- Icons -->
    <link href="../assets/vendor/nucleo/css/nucleo.min.css" rel="stylesheet" />
    <link
      href="../assets/vendor/@fortawesome/fontawesome-free/css/all.min.css"
      rel="stylesheet"
    />

    
    <link type="text/css" href="../assets/css/argon.min.css" rel="stylesheet" />

    <!--My css -->
    <link type="text/css" href="Register.css" rel="stylesheet" />
  </head>
  <body style="margin:0;padding:0;">
    <form id="form1" runat="server">
      <!-- Navbar -->
      <nav
        class="navbar navbar-horizontal navbar-expand-lg navbar-dark bg-danger"
      >
        <div class="container">
          <a
            class="navbar-brand scaleBigToText"
            href="Welcome.aspx"
            style="font-size: 24px"
            ><strong>EventShare</strong></a
          >
          <button
            class="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbar-default"
            aria-controls="navbar-default"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbar-default">
            <div class="navbar-collapse-header">
              <div class="row">
                <div class="col-6 collapse-brand">
                  <a href="javascript:void(0)">
                    <h1><u>EventShare</u></h1>
                  </a>
                </div>
                <div class="col-6 collapse-close">
                  <button
                    type="button"
                    class="navbar-toggler"
                    data-toggle="collapse"
                    data-target="#navbar-default"
                    aria-controls="navbar-default"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                  >
                    <span></span>
                    <span></span>
                  </button>
                </div>
              </div>
            </div>

            <ul class="navbar-nav ml-lg-auto">
             <asp:Panel ID="PanelLoggedIn" CssClass="navbar-nav ml-lg-auto" runat="server">
                <li class="nav-item">
                  <a class="nav-link nav-link-icon" href="MyProfile.aspx">
                    <i class="ni ni-notification-70"></i>
                    <span class="nav-link-inner--text scaleBigToText"
                      >Profile</span
                    >
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link nav-link-icon" href="MyEvents.aspx">
                    <i class="ni ni-notification-70"></i>
                    <span class="nav-link-inner--text scaleBigToText"
                      >My Events</span
                    >
                  </a>
                </li>
                <li class="nav-item dropdown">
                  <a class="nav-link nav-link-icon" href="CreateEvent.aspx">
                    <i class="ni ni-settings-gear-65"></i>
                    <span class="nav-link-inner--text scaleBigToText"></span>
                    Create Event
                  </a>
                </li>
                <li class="nav-item dropdown">
                  <a class="nav-link nav-link-icon" href="JoinAnEvent.aspx">
                    <i class="ni ni-settings-gear-65"></i>
                    <span class="nav-link-inner--text scaleBigToText"></span>
                    Join An Event
                  </a>
                </li>
                
              </asp:Panel>
            </ul>
          </div>
        </div>
      </nav>
      <!-- End of navbar -->

      <!--Create An Event Panel-->
      <div class="container text-center bg-secondary containerForm" style="align-content:center">
          <h2 class="display-2"><u>Create An Event</u></h2>
          <asp:TextBox ID="TxtEventName" placeholder="Event Name" CssClass="form-control text-center txt" runat="server" required="true"></asp:TextBox>
          <asp:TextBox ID="TxtEventLocation" placeholder="Event Location" CssClass="form-control text-center txt" runat="server" required="true"></asp:TextBox>
          <textarea id="TxtDescription" class="form-control text-center txt" placeholder="Description" cols="20" rows="2" runat="server"></textarea>
          <div style="margin-bottom: 10px;">
          <asp:Calendar ID="CalenderEventDate" runat="server" CssClass="table table-active table-default txt" OnDayRender="CalenderEventDate_DayRender" required="true"></asp:Calendar>
          </div>
          
         
          <div class="input-group">
            <asp:TextBox ID="TxtHour" placeholder="00" style="float:right" class="form-control text-center" runat="server" required="true"></asp:TextBox>
              <div class="input-group-prepend">
                <span class="input-group-text">:</span>
            </div>
            <asp:TextBox ID="TxtMinutes" placeholder="00" class="form-control text-center" runat="server" required="true"></asp:TextBox>
          </div>
          <asp:TextBox ID="TxtMaxGuests" CssClass="form-control text-center" placeholder="Max Guests" style="margin-top:8px" runat="server" required="true"></asp:TextBox>
          <asp:Button ID="btnCreateEvent" runat="server" style="margin-top:16px" Text="Create Event!" CssClass="btn btn-warning" OnClick="btnCreateEvent_Click" />
          <div class="alert alert-danger" role="alert" runat="server" id="DangerAlert">
                <strong>Sorry!</strong> but you missed some information!
          </div>
          <div class="alert alert-danger" role="alert" runat="server" id="DangerUsernameAlert">
                <strong>Sorry!</strong> but your username is taken already!
          </div>
          <div class="alert alert-danger" role="alert" runat="server" id="InvalidMaxUGuestsAlert">
                <strong>Sorry!</strong> Invalid Max Guests Number!
          </div>
          <div class="alert alert-danger" role="alert" runat="server" id="InvalidTimeAlert">
                <strong>Sorry!</strong> Invalid Time!
          </div>
          <div class="alert alert-success" role="alert" runat="server" id="SuccessAlert">
                <strong>Success!</strong> Your Event has been created successfully! Invite Code is: 
          </div>
          <div style="margin-bottom:20px;"></div>
      </div>

      <!-- Core -->
      <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>
      <script src="../assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
      
      <script src="../assets/js/argon.min.js"></script>
    </form>
  </body>
</html>
