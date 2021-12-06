<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomepage.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.AdminHomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        th, td {
            padding: 5px;
        }
    </style>

</head>

<script>

    function loadDoc() {
        const xhttp = new XMLHttpRequest();
        xhttp.onload = function () {
            myFunction(this);
        }
        xhttp.open("GET", "furniture.xml");
        xhttp.send();
    }
    function myFunction(xml) {
        const xmlDoc = xml.responseXML;
        const x = xmlDoc.getElementsByTagName("CD");
        let table = "<tr><th>Furniture Name</th><th>Type</th>";
        for (let i = 0; i < x.length; i++) {
            table += "<tr><td>" +
                x[i].getElementsByTagName("FURNITURE")[0].childNodes[0].nodeValue +
                "</td><td>" +
                x[i].getElementsByTagName("TYPE")[0].childNodes[0].nodeValue +
                "</td></td>";

        }
        document.getElementById("demo").innerHTML = table;
    }
</script>
<body>
    <form id="form1" runat="server">
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

                            <a href="Login.aspx" class="nav-item nav-link">Logout</a>

                        </div>
                        <div class="navbar-nav ms-auto">

                            <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click2">Add Furniture</asp:LinkButton>&nbsp;&nbsp;
           
                            <asp:LinkButton ID="btnRemove" runat="server" OnClick="btnRemove_Click">Remove Furniture</asp:LinkButton>&nbsp;&nbsp;
           
                            <asp:LinkButton ID="btnResvRequest" runat="server" OnClick="btnResvRequest_Click">Furniture Reservation Requests</asp:LinkButton><br />
                            <br />
                        </div>
                    </div>
                </div>
            </nav>
        </div>



        <center>
            <h1 class="display-4" style="font-size: calc(1.475rem + 1.2vw);">Admin Homepage</h1>

            <br />
            This is where you can see all of the furniture of the store.<br />
            <small>After you have modified any furniture information, please refresh the page to see the changes.</small>
            <br />
            <br />

            <%--    ajax button--%>
            <center>
                <button type="button" id="btnPending" runat="server" onclick="loadDoc()">View Pending Furnitures</button>
                <br />
                <br />
                <table id="demo"></table>
            </center>


            <div runat="server" id="deleteDiv" visible=" false">
                <br />
                <br />
                Enter the ID of the Furniture you want to delete:
               
                        <br />
                <asp:TextBox ID="txtFurnitureID" runat="server"></asp:TextBox>&nbsp;&nbsp;
               
                        <asp:Button ID="btnDeleteFurniture" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDeleteFurniture_Click" />
                <br />
                <asp:Label ID="lblDeleteMessage" runat="server" Text="Label" Visible="false" Font-Size="20px" ForeColor="#990000"></asp:Label>
                <br />
            </div>
        </center>
        <div runat="server" id="displayDiv" visible="true" style="padding-left: 15px; padding-right: 15px; width: 100%;">
            <h3>All Furniture: </h3>
            <asp:Label ID="lblMessageDisplay" runat="server" Text="Label"></asp:Label>
            &nbsp;<asp:GridView ID="gvAllFurniture" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAllFurniture_SelectedIndexChanged" Height="550px" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="furnitureID" HeaderText="Furniture ID" />
                    <asp:BoundField DataField="furnitureName" HeaderText="Furniture Name" />
                    <asp:BoundField DataField="furnitureType" HeaderText="Furniture Type" />
                    <asp:BoundField DataField="furniturePrice" HeaderText="Price" />
                    <asp:BoundField DataField="furniturePieces" HeaderText="Pieces" />
                    <asp:BoundField DataField="furnitureDescription" HeaderText="Description" />
                    <asp:CommandField SelectText="Modify" ShowSelectButton="True" />
                </Columns>

            </asp:GridView>
            <br />
        </div>
        <center>

            <div runat="server" id="modifiyDiv" visible="false">

                <asp:Image ID="furnitureImage" Height="250px" Width="250px" runat="server" />
                <br />
                <br />
                <asp:FileUpload ID="imgUpload" runat="server" Height="41px" Width="309px" />
                <br />
                <asp:Label ID="lblfurnitureName" runat="server" Text="Furniture Name: "></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="txtName" type="text" Text=""></asp:TextBox><br />

                <br />
                <asp:Label ID="lblfurnitureId" runat="server" Text="Furniture ID:  "></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="txtfurnitureidDisplay" type="text" Text="" ReadOnly="True"></asp:TextBox><br />


                <asp:Label ID="lblType" runat="server" Text="Furniture Type: "></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="txtType" type="text" Text=""></asp:TextBox><br />

                <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label><br />
                <asp:TextBox runat="server" ID="txtPrice" type="text" Text=""></asp:TextBox><br />

                <asp:Label ID="lblPieces" runat="server" Text="Pieces: "></asp:Label><br />
                <asp:TextBox runat="server" ID="txtPieces" type="text" Text=""></asp:TextBox>
                <br />
                <asp:Label ID="lblDesc" runat="server" Text="Description: "></asp:Label><br />
                <asp:TextBox runat="server" ID="txtDesc" type="text" Text=""></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnModify" runat="server" Text="Modify" class="btn btn-primary" OnClick="btnModify_Click" />
                &nbsp;&nbsp;
                    
               

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                <br />
                <asp:Label ID="lblModifyMessage" runat="server" Font-Bold="true" Font-Size="20px" ForeColor="#990000"></asp:Label>
                <br />
                <br />
            </div>
            <asp:Label ID="lblrequestMessage" runat="server" Font-Bold="true" Font-Size="20px" ForeColor="#990000"></asp:Label>

            <div runat="server" visible="false" id="requestDiv" style="padding-left: 15px; padding-right: 15px;">
                <asp:GridView ID="gvResvRequests" runat="server" AutoGenerateColumns="False" Visible="False" OnSelectedIndexChanged="gvResvRequests_SelectedIndexChanged" Height="200px" Width="100%" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="reservationID" HeaderText="Request ID" />
                        <asp:BoundField DataField="furnitureID" HeaderText="Furniture ID" />
                        <asp:BoundField DataField="reservationDate" HeaderText="Date" />
                        <asp:BoundField DataField="reservationTime" HeaderText="Time" />
                        <asp:CommandField ShowSelectButton="True" UpdateText="View" />


                    </Columns>

                </asp:GridView>

            </div>

            <div runat="server" id="acceptDiv" visible="false">
                <asp:Label ID="lblResvId" runat="server" Text="Reservation ID:  "></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="txtResvId" type="text" Text="" ReadOnly="True"></asp:TextBox><br />


                <asp:Label ID="lblresvfurnitureId" runat="server" Text="Furniture ID:"></asp:Label>
                <br />
                <asp:TextBox runat="server" ID="txtresvfurnitureId" type="text" Text="" ReadOnly="True"></asp:TextBox><br />

                <asp:Label ID="lbldate" runat="server" Text="Date: "></asp:Label><br />
                <asp:TextBox runat="server" ID="txtdate" type="text" Text="" ReadOnly="True"></asp:TextBox><br />

                <asp:Label ID="lbltime" runat="server" Text="Time: "></asp:Label><br />
                <asp:TextBox runat="server" ID="txttime" type="text" Text="" ReadOnly="True"></asp:TextBox><br />
                &nbsp;&nbsp;
               
                        <br />
                <asp:Button ID="btnAccept" runat="server" Text="Accept" class="btn btn-primary" OnClick="btnAccept_Click" />
                &nbsp;&nbsp;
               
                        <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" OnClick="btnReject_Click" />
            </div>
        </center>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
