<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FurnitureInfo.aspx.cs" Inherits="FurnitureStore.FurnitureInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Furniture Information</title>
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>

	<script lang="javascript" type="text/javascript">

		var stats;          // global variable used to store the fetched data before it's needed
		var request;        // global variable used to store the XMLHttpRequest object used to handle AJAX.
		try {
			request = new XMLHttpRequest();
		}

		catch (try_older_microsoft) {
			try {
				request = new ActiveXObject("Microsoft.XMLHTTP");
			}

			catch (other) {
				request = false;
				alert("Your browser doesn't support AJAX!");
			}
		}
		window.onload = function () {

			var int = getParameterByName('id');
			request.open("GET", "https://localhost:44393/api/reservation/GetReservationCount/" + int, true);
			//xmlhttp.setRequestHeader("Access-Control-Allow-Origin", "*");
			request.onreadystatechange = onComplete;
			request.send();

		} // end of page load event

		function GetInfo() {
			document.getElementById("countContent").innerHTML = "Current number of sets reserved: " + stats;
		}

		// Callback function used to perform some action when an asynchronous request is completed

		function onComplete() {

			if (request.readyState == 4 && request.status == 200) {

				// store the fetched data in the global variable until it's needed
				stats = request.responseText;
			}
		}

		function getParameterByName(name, url = window.location.href) {
			name = name.replace(/[\[\]]/g, '\\$&');
			var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
				results = regex.exec(url);
			if (!results) return null;
			if (!results[2]) return '';
			return decodeURIComponent(results[2].replace(/\+/g, ' '));
		}

	</script>
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
						<a href="Homepage.aspx" class="nav-item nav-link active">Home</a>
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
		<center><h1 class="display-4" style="font-size:calc(1.475rem + 1.2vw);">Furniture Information</h1>
			<br/>
			<asp:Label runat="server" class="display-4" style="font-size:calc(1.2rem + 0.9vw);" ID="lblFurnitureName"></asp:Label>
			<br />
			            <asp:Image ID="imgFurniture" runat="server" Height="300px" Width="300px" style="border: 5px solid #555;"/> 

		</center>
		
		<br />
		<div>
			<center>
			   <asp:Label ID="lblFurniturePiece" runat="server"></asp:Label><br/>
				<asp:Label ID="lblFurnitureType" runat="server"></asp:Label>
				<br />            
				<asp:Label ID="lblDescription" runat="server"></asp:Label>

				<br />
				<asp:Label ID="lblFurniturePrice" runat="server"></asp:Label>
				<br/>
				<asp:Button ID="btnReserve" runat="server" Text="Reserve" CssClass="btn btn-primary" OnClick="btnReserve_Click" />
				<br />

				<br/>
				<br/>
				Click here to see how many have reserved this: &nbsp;
				<input id="btnGetCount" type="button" value="Get Count" class="btn btn-primary" onclick="GetInfo();" />
				<div id="countContent">
				</div>
			</center>
		</div>
		<br />
        <center><asp:Label ID="lblStatus" runat="server"></asp:Label></center>
		<br />

	</form>
</body>
</html>
