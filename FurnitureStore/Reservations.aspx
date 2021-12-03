<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.Reservations" %>

<%@ Register src="FurnitureDisplay.ascx" tagname="FurnitureDisplay" tagprefix="fdisplay" %>

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
                    <a href="Login.aspx" class="nav-item nav-link">Logout</a>
                </div>
            </div>
        </div>
    </nav>
</div>
    <form id="form1" runat="server">
        <center><h1 class="display-4" style="font-size:calc(1.475rem + 1.2vw);">Reservations</h1></center>
        <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>

                    <tr>

                        <td>

                            <asp:Label ID="lblFurnitureID" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FurnitureId") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReservationDate" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ReservationDate") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReservationTime" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ReservationTime") %>'></asp:Label>

                        </td>
                        <td> 
                            <asp:Label ID="lblReservationCount" runat="server" Text='<%# Bind("ReservationCount") %>'></asp:Label>

                        </td>

                    </tr>               

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
