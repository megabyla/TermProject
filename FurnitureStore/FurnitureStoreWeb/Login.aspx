<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link href="CSS/login_styling.css" rel="stylesheet" />
   
    <title></title>
</head>
<body>
   
      <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://mdbootstrap.com/img/Photos/new-templates/bootstrap-login-form/draw2.png" class="img-fluid"
          alt="Sample image">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form runat="server">


          <div class="divider d-flex align-items-center my-4">
            <p class="text-center fw-bold mx-3 mb-0"><img src="Images/logo/logo.png" /></p>
          </div>

          <!-- Username input -->
          <div class="form-outline mb-4">
              <asp:Label ID="lblUsername" runat="server" Text="Username: " class="col-form-label-lg"></asp:Label>
              <asp:TextBox ID="txtUsername" runat="server" class="form-control form-control-lg"></asp:TextBox>
          </div>

          <!-- Password input -->
         <div class="form-outline mb-4">
              <asp:Label ID="lblPassword" runat="server" Text="Password: " class="col-form-label-lg"></asp:Label>
              <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg"></asp:TextBox>
          </div>

          <div class="d-flex justify-content-between align-items-center">
            <!-- Checkbox -->
            <div class="form-check mb-0">
                <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Me?" class="form-check-label" />
             
            </div>
          </div>

          <div class="text-center text-lg-start mt-4 pt-2">
              <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;" OnClick="btnLogin_Click2" /> 
           
             
            <p class="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="Register.aspx"
                class="link-danger">Register</a></p>
          </div>

        </form>
      </div>
    </div>
  </div>
  <div class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5 bg-primary">
    <!-- Copyright -->
    <div class="text-white mb-3 mb-md-0">
      Copyright © 2021. All rights reserved.
    </div>
    <!-- Copyright -->

    <!-- Right -->
    <div>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-facebook-f"></i>
      </a>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-twitter"></i>
      </a>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-google"></i>
      </a>
      <a href="#!" class="text-white">
        <i class="fab fa-linkedin-in"></i>
      </a>
    </div>
    <!-- Right -->
  </div>
</section>
    
</body>
</html>
