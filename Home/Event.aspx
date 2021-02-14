<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="EventShare.Home.Event" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head runat="server">
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1, shrink-to-fit=no"
    />
    <title>Event</title>
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
  <body>
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

      <!--Event Panel-->
      <div class="container text-center bg-secondary containerForm">
          <h1 class="display-1"><u>Event Details</u></h1>
          <h2 class="display-2" runat="server" id="EventName"></h2>
          <h3 class="display-3" runat="server" id="EventOwner"></h3>
          <h4 class="display-4 text-muted" runat="server" id="EventTime"></h4>
          <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-light"></asp:GridView>
          <asp:Button ID="BtnLeaveEvent" runat="server" Text="Leave Event" CssClass="btn btn-danger" OnClick="BtnLeaveEvent_Click" />
          <div class="alert alert-defualt" role="alert" runat="server" id="NoEventsFoundAlert">
                <strong>Sorry!</strong> It seems no one joined the event yet!
          </div>
      </div>

     
      <!-- Core -->
      <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>
      <script src="../assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
      
      <script src="../assets/js/argon.min.js"></script>
     </form>
</body>
</html>