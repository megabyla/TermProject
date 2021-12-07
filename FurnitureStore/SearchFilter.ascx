<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchFilter.ascx.cs" Inherits="FurnitureStore.SearchFilter" %>
<center>
<asp:Label ID="lblSearch" runat="server" Text="Search: " Font-Size="Larger"></asp:Label>
&nbsp;&nbsp;
<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-success" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblFilter" runat="server" Text="Filter: " Font-Size="Larger"></asp:Label>

<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" style="position: relative; top: 0px; left: 0px; width: 125px">
    <asp:ListItem Value="null" Selected="True">Select a Type</asp:ListItem>
    <asp:ListItem>Bed Room</asp:ListItem>
    <asp:ListItem>Living Room</asp:ListItem>
    <asp:ListItem>Dining Room</asp:ListItem>
</asp:DropDownList>
    </center>

