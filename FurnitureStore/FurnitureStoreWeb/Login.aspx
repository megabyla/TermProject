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
                                <img src="Images/logo/logo.png" />
                            </p>
                        </div>


                        <!-- Username input -->
                        <div class="form-outline mb-4">
                            <asp:Label ID="lblUseremail" runat="server" Text="Email: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtUseremail" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>

                        <!-- Password input -->
                        <div class="form-outline mb-4">
                            <asp:Label ID="lblPassword" runat="server" Text="Password: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
                        </div>

                        <div class="d-flex justify-content-between align-items-center">
                            <!-- Checkbox -->
                            <div class="form-check mb-0">
                                <asp:CheckBox ID="ckRem" runat="server" Text=" Remember Me?" />

                            </div>
                        </div>

                        <div class="text-center text-lg-start mt-4 pt-2">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary btn-md" OnClick="btnLogin_Click2" />
                            &nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:Button ID="btnForgot" runat="server" Text="Forgot Password" CssClass="btn btn-primary btn-md" OnClick="btnForgot_Click1" />

                            <p class="small fw-bold mt-2 pt-1 mb-0">
                                Don't have an account? <a href="Register.aspx"
                                    class="link-danger">Register</a>
                                <br />

                                <asp:Label ID="lblMessage" runat="server" class="col-form-label-lg"></asp:Label>

                            </p>



                            <div id="cookies">

                                <input class="form-check-input" type="checkbox" value="" id="checkCookies" runat="server" />
                                <label class="form-check-label" for="checkCookies">
                                    <small><b>Faster login:</b> Check to store account creditentials</small>
                                </label>

                            </div>
                            <br />


                        </div>
                    </form>

                </div>

            </div>
        </div>


    </section>

</body>
</html>
