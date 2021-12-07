<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FurnitureDisplay.ascx.cs" Inherits="FurnitureStore.FurnitureDisplay" %>

<div class="form-row">
    <div class="col">
            <center>
                <h3><asp:Label ID="lblFurnitureName" runat="server" Font-Bold="false" ></asp:Label></h3>
            <br />
            <asp:Image ID="imgFurniture" runat="server" Height="300px" Width="300px" style="border: 5px solid #555;"/> 
                <br />
               <h5> <label>Furniture Type:  </label>
                <asp:Label ID="lblFurnitureType" runat="server" > </asp:Label></h5>
                
                 <h5> <label>Furniture Price:  </label>
            <asp:Label ID="lblFurniturePrice" runat="server"></asp:Label></h5>
            <asp:Button ID="btnSelect" runat="server" Text="Select" Width="70px" CssClass="btn btn-primary" OnClick="btnSelect_Click" />
                </center></div>
        </div>
        
<hr style="width: 90%; margin: auto; margin-top: 20px; margin-bottom: 20px">