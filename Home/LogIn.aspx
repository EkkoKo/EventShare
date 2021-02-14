<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="EventShare.Home.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
  <head runat="server">
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1, shrink-to-fit=no"
    />
    <title>Log in</title>
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
              <asp:Panel ID="PanelNotLoggedIn" runat="server">
                <li class="nav-item dropdown">
                  <a class="nav-link nav-link-icon" href="LogIn.aspx">
                    <i class="ni ni-settings-gear-65"></i>
                    <span class="nav-link-inner--text scaleBigToText"></span>
                    Log in
                  </a>
                </li>
                <li class="nav-item dropdown">
                  <a class="nav-link nav-link-icon" href="Register.aspx">
                    <i class="ni ni-settings-gear-65"></i>
                    <span class="nav-link-inner--text scaleBigToText"></span>
                    Register
                  </a>
                </li>
              </asp:Panel>
            </ul>
          </div>
        </div>
      </nav>
      <!-- End of navbar -->

      <!--Login Panel-->
      <div class="container text-center bg-secondary containerForm">
          <h2 class="display-2"><u>Sign To Your Account</u></h2>
          <asp:TextBox ID="TxtUsername" placeholder="Username" CssClass="form-control text-center txt"  runat="server" required="true"></asp:TextBox>
          <asp:TextBox ID="TxtPassword" placeholder="Password" CssClass="form-control text-center txt"  runat="server" required="true" TextMode="Password"></asp:TextBox>
          <asp:Button ID="btnLogin" runat="server" Text="Login!" CssClass="btn btn-info" OnClick="btnLogin_Click" />
          <div class="alert alert-danger" role="alert" runat="server" id="DangerAlert">
                <strong>Sorry!</strong> but you have entered wrong credentials!
          </div>


      </div>

      <!-- Core -->
      <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>
      <script src="../assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
      
      <script src="../assets/js/argon.min.js"></script>
     </form>
</body>
</html>
