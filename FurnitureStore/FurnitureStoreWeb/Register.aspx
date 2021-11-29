<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.Register" %>

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
  <%--error message lables--%>
                            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>

<div class="form-outline mb-4">                          
                            <asp:Label ID="lblUsertype" runat="server" Text="Account Type: " class="col-form-label-lg"></asp:Label>

                                <asp:RadioButtonList ID="RadioBtnUserType" runat="server" required="required">
                                    <asp:ListItem Value="User" ID="rdlUser" Selected="True">User</asp:ListItem>
                                    <asp:ListItem Value="Admin" ID="rdlAdmin">Administrator</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                        <!-- Registration input -->
                        <div class="form-outline mb-4">
                            <asp:Label ID="lblUsername" runat="server" Text="Username: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtUsername" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:Label ID="lblEmail" runat="server" Text="Email: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>



                        <div class="form-outline mb-4">
                            <asp:Label ID="lblPassword" runat="server" Text="Password: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>
                        <div class="form-outline mb-4">
                            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>



                        <div class="form-group">
                            <label><b>Security Question</b></label>
                            <br />
                            Security question 1:<br />
                            <label>What city were you born in?</label>
                            <asp:TextBox ID="txtSq1" class="form-control" runat="server"></asp:TextBox><br />
                            Security Question 2:<br />
                            <label>What is your favorite TV show?</label>
                            <asp:TextBox ID="txtSq2" class="form-control" runat="server"></asp:TextBox><br />
                            Security Question 3:<br />
                            <label>What is your middle name?</label>
                            <asp:TextBox ID="txtSq3" class="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblSq" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
                            <br />

                            <div id="buttons">
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary btn-md" OnClick="btnSubmit_Click1" />
                                &nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnRegister" runat="server" Text="Login" class="btn btn-primary btn-md"
                             OnClick="btnRegister_Click" />
                                <br />
                            </div>
                        </div>

                        <br />


                    </form>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />


            </div>

        </div>



    </section>

</body>
</html>
