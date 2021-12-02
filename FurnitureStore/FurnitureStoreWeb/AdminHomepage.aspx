<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomepage.aspx.cs" Inherits="FurnitureStore.FurnitureStoreWeb.AdminHomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
