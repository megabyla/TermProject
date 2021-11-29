<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.ForgotPass" %>

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

                        <asp:Label ID="lblSuccess" class="float-right alert alert-success" runat="server" Text="Password reset successful!" Visible="false"></asp:Label>


                        <h2 class="card-title mb-4 mt-1">Reset Password</h2>
                        <div class="form-outline mb-4">
                            <asp:Label ID="lblEmail" runat="server" Text="Email: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblDisplay" class="float-left" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnSubmit" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" BackColor="CornflowerBlue" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>

                        <div id="securityQuestion" runat="server" visible="false">
                            <hr />
                            <div class="form-group">
                                <label><b>1. What city were you born in?</b></label>
                                <asp:TextBox ID="txtQuestion1" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group">
                                <label><b>2. What is your favorite TV show?</b></label>
                                <asp:TextBox ID="txtQuestion2" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group">
                                <label><b>3. What is your middle name?</b></label>
                                <asp:TextBox ID="txtQuestion3" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblAnswer" class="float-left" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSubmit2" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" BackColor="CornflowerBlue" Text="Submit" OnClick="btnSubmit2_Click" />
                            </div>
                        </div>

                        <div id="resetPassword" runat="server" visible="false">
                            <hr />
                            <div class="form-group">
                                <label><b>New Password: </b></label>
                                <asp:TextBox ID="txtNewPassword" class="form-control" runat="server" type="password" />
                            </div>
                            <div class="form-group">
                                <label><b>Confirm Password:</b></label>
                                <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" type="password" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblPassword" class="float-left" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSubmit3" class="btn btn-warning btn-block" runat="server" Style="border: 1px solid grey;" BackColor="CornflowerBlue" Text="Submit" OnClick="btnSubmit3_Click" />
                            </div>
                        </div>
                    </form>
                    <hr />
                    <div class="form-group">
                        <a href="Login.aspx" class="btn btn-outline-dark btn-block" style="border: 1px solid grey;">Sign in</a>
                    </div>

                </div>
            </div>

        </div>

    </section>

</body>
</html>
