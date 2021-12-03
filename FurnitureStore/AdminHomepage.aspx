<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomepage.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.AdminHomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <style>
table,th,td {
  border : 1px solid black;
  border-collapse: collapse;
}
th,td {
  padding: 5px;
}

</style></head>

 <form id="form1" runat="server">
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
      
            <asp:LinkButton ID="btnAdd" runat="server" >Add Furniture</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btnRemove" runat="server">Remove Furniture</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btnResvRequest" runat="server" OnClick="btnAdoptionRequest_Click">Furniture Reservation Requests</asp:LinkButton>
                    <a href="Reservations.aspx" class="nav-item nav-link">Reservations</a>
                </div>
                <div class="navbar-nav ms-auto">
                    <a href="Login.aspx" class="nav-item nav-link">Logout</a>
                </div>
            </div>
        </div>
    </nav>
</div>
<%--    ajax button--%>
<button type="button" onclick="loadDoc()">View Pending Furnitures</button>
<br><br>
<table id="demo"></table>

<script>
function loadDoc() {
  const xhttp = new XMLHttpRequest();
  xhttp.onload = function() {
    myFunction(this);
  }
  xhttp.open("GET", "furniture.xml");
  xhttp.send();
}
function myFunction(xml) {
  const xmlDoc = xml.responseXML;
  const x = xmlDoc.getElementsByTagName("CD");
    let table ="<tr><th>Furniture Name</th><th>Type</th>";
  for (let i = 0; i <x.length; i++) { 
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




   
         <%--This main div is the div where the gridviews will be displayed. We're going to use the APIs to get all of our results. He does it in on of the web api lecture so watch that for reference.--%>
        <div class="main" style="width:800px; margin:0 auto;">
            <div runat="server" id ="displayDiv" visible="true">
                All Furniture:<asp:Label ID="lblMessageDisplay" runat="server" Text="Label"></asp:Label>
                &nbsp;<asp:GridView ID="gvAllFurniture" runat="server" AutoGenerateColumns="False" >
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

             <div runat="server" id="deleteDiv" visible=" false">
                Enter the ID of the Furniture you want to delete:
                <br />
                <asp:TextBox ID="txtFurnitureID" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="btnDeleteFurniture" runat="server" Text="Delete" CssClass="btn btn-danger" />
                <br />
                <asp:Label ID="lblDeleteMessage" runat="server" Text="Label" Visible="false"></asp:Label>
                <br />
            </div>

              <div runat="server" id="modifiyDiv" visible="false">

                <asp:Image ID="furnitureImage" Height="250px" Width ="250px" runat="server" />
                <br />
                <asp:FileUpload ID="imgUpload" runat="server" Height="41px" Width="309px" />
                <br />
                <asp:TextBox runat="server" id="txtName" type="text" Text="" ReadOnly="True"></asp:TextBox><br />
                
                <br />
                <asp:Label ID="lblfurnitureId" runat="server" Text="Furniture ID:  "></asp:Label> <br />
                <asp:TextBox runat="server" id="txtfurnitureidDisplay" type="text" Text="" ReadOnly="True"></asp:TextBox><br />


                <asp:Label ID="lblType" runat="server" Text="Furniture Type: "></asp:Label> <br />
                <asp:TextBox runat="server" id="txtType" type="text" Text="" ReadOnly="True"></asp:TextBox><br />

                <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label><br />
                <asp:TextBox runat="server" id="txtPrice" type="text" Text="" ReadOnly="True"></asp:TextBox><br />

                <asp:Label ID="lblPieces" runat="server" Text="Pieces: "></asp:Label><br />
                <asp:TextBox runat="server" id="txtPieces" type="text" Text="" ReadOnly="True"></asp:TextBox>
                  <br />
                <asp:Button ID="btnModify" runat="server" Text="Modify" class="btn btn-primary"/>
                &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" />
                  <br />
                <asp:Label ID="lblModifyMessage" runat="server" Text=""></asp:Label>
                <br /><br />
            </div>


             <div runat="server" visible ="false" id ="requestDiv" >
                <asp:GridView ID="gvResvRequests" runat="server" AutoGenerateColumns="False" Visible="False" >
                <Columns>
                    <asp:BoundField DataField="RequestId" HeaderText="Request ID" />
                    <asp:BoundField DataField="FurnitureId" HeaderText="Furniture ID" />
                    <asp:BoundField DataField="FurnitureName" HeaderText="Name" />
                    <asp:BoundField DataField="userID" HeaderText="Requester Id" />
                    <asp:CommandField ShowSelectButton="True" UpdateText="View" />
                </Columns>
            </asp:GridView>
                <asp:Label ID="lblrequestMessage" runat="server" Text="Label"></asp:Label>
            </div>

              <div runat ="server" id="acceptDiv" visible ="false">
                <asp:Label ID="lblRequestId" runat="server" Text="Request ID:  "></asp:Label> <br />
                <asp:TextBox runat="server" id="txtRequestId" type="text" Text="" ReadOnly="True"></asp:TextBox><br />


                <asp:Label ID="lblReqfurnitureId" runat="server" Text="Furniture ID:"></asp:Label> <br />
                <asp:TextBox runat="server" id="txtReqfurnitureId" type="text" Text="" ReadOnly="True"></asp:TextBox><br />

                <asp:Label ID="lblReqfurnitureName" runat="server" Text="Furniture Name: "></asp:Label><br />
                <asp:TextBox runat="server" id="txtReqfurnitureName" type="text" Text="" ReadOnly="True"></asp:TextBox><br />

                <asp:Label ID="lblRequesterId" runat="server" Text="Requester ID: "></asp:Label><br />
                <asp:TextBox runat="server" id="txtRequesterId" type="text" Text="" ReadOnly="True"></asp:TextBox><br />
                  &nbsp;&nbsp;
                <br />
                <asp:Button ID="btnAccept" runat="server" Text="Accept" class="btn btn-primary" />
               &nbsp;&nbsp;
                <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" />
            </div>

        </div>
    </form>
</body>
</html>
