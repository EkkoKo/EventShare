<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="EventShare.Home.MyProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head runat="server">
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1, shrink-to-fit=no"
    />

    <!-- Favicon -->
    <title>My Profile</title>
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

    <!--My css-->
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

      <!-- My Profile Panel-->
      <div class="container text-center bg-secondary containerForm">
          <h2 class="display-2"><u>Your Information:</u></h2>
          <asp:TextBox ID="TxtEmail" placeholder="Email Address" CssClass="form-control text-center txt" runat="server" TextMode="Email" required="true"></asp:TextBox>
          <asp:TextBox ID="TxtUsername" placeholder="Username" CssClass="form-control text-center txt"  runat="server" required="true"></asp:TextBox>
          <asp:TextBox ID="TxtPassword" placeholder="Password" CssClass="form-control text-center txt"  runat="server" TextMode="Password"></asp:TextBox>
          <asp:Button ID="btnChangedInfo" runat="server" Text="Save Changes!" CssClass="btn btn-success" OnClick="btnChangedInfo_Click" />
          <div class="alert alert-danger" role="alert" runat="server" id="DangerAlert">
                <strong>Sorry!</strong> but you missed some information!
          </div>
          <div class="alert alert-danger" role="alert" runat="server" id="DangerUsernameAlert">
                <strong>Sorry!</strong> but the username is already taken!
          </div>
          <div class="alert alert-success" role="alert" runat="server" id="SuccessAlert">
                <strong>Success!</strong> Your Account details has been changed successfully!
          </div>
          
          <asp:Button ID="LogoutBtn" runat="server" Text="Log out" CssClass="btn btn-warning" OnClick="LogoutBtn_Click" />
      </div>
    </form>

    <!-- Core -->
    <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>
    <script src="../assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    
    <script src="../assets/js/argon.min.js"></script>
    <!--My scripts-->
    <script src="Welcome.js"></script>
  </body>
</html>
