<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.Reservations" %>

<%@ Register src="../FurnitureDisplay.ascx" tagname="FurnitureDisplay" tagprefix="fdisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservations</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <div class="m-4">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a href="#" class="navbar-brand">
                <img src="Images/logo/logo.png" height="85" alt="Luxury Furniture"/>
            </a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav">
                    <a href="#" class="nav-item nav-link">Home</a>
                    <a href="#" class="nav-item nav-link">Profile</a>
                    <a href="#" class="nav-item nav-link">Messages</a>
                    <a href="Reservations.aspx" class="nav-item nav-link active">Reservations</a>
                </div>
                <div class="navbar-nav ms-auto">
                    <a href="Login.aspx" class="nav-item nav-link">Login</a>
                </div>
            </div>
        </div>
    </nav>
</div>
    <form id="form1" runat="server">
        <div>
            <fdisplay:FurnitureDisplay ID="FurnitureDisplay1" runat="server" />
        </div>
    </form>
</body>
</html>
