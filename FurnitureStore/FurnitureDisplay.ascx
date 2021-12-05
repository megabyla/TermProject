<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FurnitureDisplay.ascx.cs" Inherits="FurnitureStore.FurnitureDisplay" %>

<div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-md-9 col-lg-6 col-xl-5">
            <asp:Label ID="lblFurnitureName" runat="server"></asp:Label>

            <asp:Image ID="imgFurniture" runat="server" />
        </div>
        <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">

            <br />

            <br />
            <asp:Label ID="lblFurnitureType" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblFurniturePrice" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnSelect" runat="server" Text="Select" Width="70px" OnClick="btnSelect_Click" />
        </div>
    </div>
</div>
<hr style="width: 90%; margin: auto; margin-top: 20px; margin-bottom: 20px">