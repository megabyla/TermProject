<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FurnitureDisplay.ascx.cs" Inherits="FurnitureStore.FurnitureDisplay" %>
<asp:Label ID="lblFurnitureName" runat="server"></asp:Label>
<br />
<asp:Image ID="imgFurniture" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblFurnitureDesc" runat="server"></asp:Label>
<p>
    <asp:Label ID="lblFurnitureType" runat="server"></asp:Label>
</p>
<p>
    <asp:Label ID="lblFurniturePrice" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnReserve" runat="server" Text="Reserve" Width="70px" />
</p>

