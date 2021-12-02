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
</style>
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

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
