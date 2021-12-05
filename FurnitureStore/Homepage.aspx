<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.Homepage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <script lang="javascript" type="text/javascript">
        var furnitureInfo;

        function pageLoad() {
            SOAPWebServices.GetFurnitureByType(document.getElementById('ddlFilter').value, onComplete, onTimeout, onError);
        }
        function GetList() {

        }
        </script>
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
                    <a href="#" class="nav-item nav-link active">Home</a>
                    <a href="#" class="nav-item nav-link">Profile</a>
                    <a href="#" class="nav-item nav-link">Messages</a>
                    <a href="Reservations.aspx" class="nav-item nav-link">Reservations</a>
                </div>
                <div class="navbar-nav ms-auto">
                    <a href="Login.aspx" class="nav-item nav-link">Logout</a>
                </div>
            </div>
        </div>
    </nav>
</div>

    <form id="form1" runat="server">
        <center><h1 class="display-4" style="font-size:calc(1.475rem + 1.2vw);">Furniture</h1></center>
        <div>
            <br>
            <br>
            <center>Filter:&nbsp;&nbsp; 
                <asp:DropDownList ID="ddlFliter" runat="server">
                <asp:ListItem Value="blank_type">Select a Type</asp:ListItem>
                <asp:ListItem Value="bedroom">Bedroom</asp:ListItem>
                <asp:ListItem Value="living_room">Living Room</asp:ListItem>
                <asp:ListItem Value="dining_room">Dining Room</asp:ListItem>
            </asp:DropDownList></center>
            
        </div>
    </form>
</body>
</html>
