<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinAnEvent.aspx.cs" Inherits="EventShare.Home.JoinEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head runat="server">
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1, shrink-to-fit=no"
    />
    <title>Join Event</title>
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

      <!--Join an Event Panel-->
      <div class="container text-center bg-secondary containerForm">
          <h2 class="display-2"><u>Enter Event Code</u></h2>
          <asp:TextBox ID="TxtEventCode" placeholder="Event Code" CssClass="form-control text-center txt"  runat="server" required="true"></asp:TextBox>
          <asp:Button ID="btnJoin" runat="server" Text="Join!" CssClass="btn btn-success" OnClick="btnJoin_Click" />
          <div class="alert alert-danger" role="alert" runat="server" id="DangerAlert">
                <strong>Sorry!</strong> but the code for the event is invalid!
          </div>
          <div class="alert alert-danger" role="alert" runat="server" id="JoinDangerAlert">
                <strong>Sorry!</strong> but you cannot join your own event!
          </div>
          <div class="alert alert-success" role="alert" runat="server" id="JoinedSuccessAlert">
                <strong>Success!</strong> You have successfully joined an event!
          </div>
          <div class="alert alert-warning" role="alert" runat="server" id="AlreayJoinedAlert">
                <strong>Sorry!</strong> But it seems you have already joined this event!
          </div>
          <div class="alert alert-warning" role="alert" runat="server" id="EventIsFullAlert">
                <strong>Sorry!</strong> But it seems the event you are trying to join is already full!
          </div>
      </div>

      <!-- Event Details -->
      <div class="modal fade" id="eventDetailsModal" tabindex="-1" role="dialog" aria-labelledby="modal-default" aria-hidden="true">
            <div class="modal-dialog modal- modal-dialog-centered modal-" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title display-1" style="font-size:26px;" id="ModalEventName" runat="server">Event Name</h1>
                        
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
            
                <div class="modal-body">
            	    <h3 runat="server" id="ModalEventTime" class="text-muted">Event Time: </h3>
                    <h4 runat="server" id="ModalEventLocation">Event Location: </h4>
                    <p runat="server" id="ModalEventDescription">Event Description: </p>
                    <h5 runat="server" id="ModalEventOwner">Event Owner Name: </h5>
                </div>
            
                <div class="modal-footer">
                    <asp:Button ID="BtnJoinEvent" CssClass="btn btn-success" runat="server" Text="Join Event!" OnClick="BtnJoinEvent_Click" UseSubmitBehavior="false" data-dismiss="eventDetailsModal" />
                    <button type="button" class="btn btn-link  ml-auto" data-dismiss="modal">Close</button>
                </div>
            
                </div>
            </div>
        </div>
      <!-- Core -->
      <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>
      <script src="../assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
      
      <script src="../assets/js/argon.min.js"></script>
     </form>
</body>
</html>