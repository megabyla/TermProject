<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.Reservations" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservations</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
<%--    <script type="text/javascript">
        var xmlhttp;
        try {
            xmlhttp = new XMLHttpRequest();

        }
        catch (try_older_microsoft) {
            try {
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
            }
            catch (other) {
                xmlhttp = false;
                alert("Browser does not support AJAX!")
            }
        }
        function getFurniture(button) {
            var id = button.getAttribute("data-tip");
            xmlhttp.open("GET", "https://localhost:44393/api/reservation/" + id, true);
            xmlhttp.onreadystatechange = onComplete;
            xmlhttp.send();
        }

        function onComplete() {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                document.getElementById("content_area").innerHTML = xmlhttp.responseText;
            }
        
    </script>--%>
    

</head>


<body>
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
                        <a href="Homepage.aspx" class="nav-item nav-link">Home</a>
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
        <center>
            <h1 class="display-4" style="font-size: calc(1.475rem + 1.2vw);">Reservations</h1>
        </center>
        <br />
        <div>
            <center>
                This is where you can see all of the reservations you have made.
            <br />
                <br />

                Filter: &nbsp&nbsp<asp:DropDownList ID="ddlReservationFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReservationFilter_SelectedIndexChanged">
                    <asp:ListItem Value="null">Select a Type</asp:ListItem>
                    <asp:ListItem>Bedroom</asp:ListItem>
                    <asp:ListItem>Dining Room</asp:ListItem>
                    <asp:ListItem>Living Room</asp:ListItem>
                </asp:DropDownList>
            </center>
            <br />
        </div>
        <div id="tableDiv">

            <table class="table">
                <tr>                                                
<%--                    <th scope="col">Select</th>--%>
                    <th scope="col">Reservation ID</th>
                    <th scope="col">Furniture ID</th>
                    <th scope="col">Reservation Date</th>
                    <th scope="col">Reservation Time</th>
                    <th scope="col">Furniture Count</th>
                    <th scope="col">Edit</th>
                    <th scope="col">Delete</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
<%--                            <td>
                                <asp:Button ID="btnSelect" runat="server" AutoPostBack="false" Text="Select" data-tip='<%# DataBinder.Eval(Container.DataItem, "FurnitureID") %>'
                                    OnClientClick="getFurniture(this);" />
                            </td>   --%>                         
                            <td>
                                <asp:Label ID="lblReservationID" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ReservationID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFurnitureID" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FurnitureID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblReservationDate" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ReservationDate", "{0: dd/MM/yyyy}") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblReservationTime" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ReservationTime") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblReservationCount" runat="server" Text='<%# Bind("ReservationCount") %>'></asp:Label>
                                <asp:TextBox ID="txtCountEdit" runat="server" Width="120" Text='<%# Eval("ReservationCount") %>' Visible="False" />
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("ReservationID") %>'>Edit</asp:LinkButton>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%# Eval("ReservationID") %>' Visible="False">Update</asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" runat="server" CommandName="cancel" CommandArgument='<%# Eval("ReservationID") %>' Visible="False">Cancel</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" OnClientClick="return confirm('Confirm Deletion?')" CommandArgument='<%# Eval("ReservationID") %>'>Delete</asp:LinkButton>
                            </td>
                        </tr>

                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <center>
            <asp:Label ID="lblStatus" runat="server" Style="text-align: center" Font-Bold="True" Font-Italic="False" Font-Size="20px" ForeColor="#990000"></asp:Label></center>
            <asp:Label ID="content_area" runat="server" Style="text-align: center" Font-Bold="True" Font-Italic="False" Font-Size="20px" ForeColor="#990000"></asp:Label></center>
    </form>
</body>
</html>
