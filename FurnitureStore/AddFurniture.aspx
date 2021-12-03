<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFurniture.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.AddFurniture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link href="CSS/login_styling.css" rel="stylesheet" />

    <title></title>
</head>
<body>

    <form runat="server">

        <div class="m-4">
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                    <a href="#" class="navbar-brand">
                        <img src="Images/logo/logo.png" height="85" alt="Luxury Furniture" />
                    </a>
                    <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarCollapse">
                        <div class="navbar-nav">
                        </div>
                        <div class="navbar-nav ms-auto">
                            <a href="Login.aspx" class="nav-item nav-link">Logout</a>
                            <a href="AdminHomepage.aspx" class="nav-item nav-link"></a>
                        </div>
                    </div>
                </div>
            </nav>
        </div>

        <section class="vh-50">
            <div class="container-fluid h-custom">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                        <h2>Add New Furniture</h2>
                        <br />
                        <asp:Label ID="lblError" runat="server"></asp:Label>

                        <div class="form-outline mb-4">
                            <asp:Label ID="lblType" runat="server" Text="Furniture Type: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtFurnitureType" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:Label ID="lblPrice" runat="server" Text="Price: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtFurniturePrice" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:Label ID="lblName" runat="server" Text="Name: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtFurnitureName" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:Label ID="lblPieces" runat="server" Text="Pieces: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtFurniturePieces" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:Label ID="lblDesc" runat="server" Text="Description: " class="col-form-label-lg"></asp:Label>
                            <asp:TextBox ID="txtFurnitureDesc" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:Label ID="lblImage" runat="server" Text="Furniture Image: " class="col-form-label-lg"></asp:Label>
                            <asp:FileUpload ID="fileFurnitureImg" runat="server" class="form-control form-control-lg" ></asp:FileUpload>
                        </div>
                        <div class="form-outline mb-4">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            <br />

                            <asp:Button ID="btnSubmit_addfurniture" class="btn btn-dark" runat="server" Text="Add Furniture" Visible="true" OnClick="btnSubmit_addfurniture_Click"></asp:Button>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnGoHome" runat="server" class="btn btn-dark" Text="Return Home" Visible="true" OnClick="btnGoHome_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnAddMore" runat="server" class="btn btn-dark" Text="Add More" Visible="false" OnClick="btnAddMore_Click" />
                        </div>


                    </div>
                </div>
                </div>
        </section>
    </form>

</body>
</html>
