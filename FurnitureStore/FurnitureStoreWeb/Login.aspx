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
                        alt="Sample image" />
                </div>
                <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                    <form runat="server">


                        <div class="divider d-flex align-items-center my-4">
                            <p class="text-center fw-bold mx-3 mb-0">
                                <img src="Images/logo/logo.png" /></p>
                        </div>

                        <fieldset class="form-group" runat="server">

                            <asp:Label ID="lblUsertype" runat="server" Text="User Type: " class="col-form-label-lg"></asp:Label>

                            <div class="form-check">
                                <input class="form-check-input" type="radio" name="userType" id="user" runat="server" checked />
                                <label class="form-check-label" for="user" runat="server">
                                    User
                                </label>
                            </div>
                            <div class="form-check">
                                <input class="form-check-input" type="radio" name="userType" id="admin" runat="server" />
                                <label class="form-check-label" for="admin" runat="server">
                                    Admin
                                </label>
                            </div>

                        </fieldset>

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
                                <asp:CheckBox ID="chkRemember" runat="server" Text=" Remember Me?" class="form-check-label" />

                            </div>
                        </div>

                        <div class="text-center text-lg-start mt-4 pt-2">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary btn-lg"
                                Style="padding-left: 2.5rem; padding-right: 2.5rem;" OnClick="btnLogin_Click2" />


                            <p class="small fw-bold mt-2 pt-1 mb-0">
                                Don't have an account? <a href="Register.aspx"
                                    class="link-danger">Register</a>

                                <br />

                                <asp:Button ID="btnForgot" runat="server" Text="Forgot Password" CssClass="btn btn-primary btn-sm" />
                            </p>


                            <div id="cookies">

                                <input class="form-check-input" type="checkbox" value="" id="checkCookies" runat="server" />
                                <label class="form-check-label" for="checkCookies">
                                    <small><b>Faster login:</b> Check to store account creditentials</small>
                                </label>

                            </div>
                            <br />


                        </div></form>
                    
                </div>

            </div>
        </div>
       

    </section>

</body>
</html>
