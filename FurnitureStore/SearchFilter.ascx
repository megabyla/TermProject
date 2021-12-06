<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchFilter.ascx.cs" Inherits="FurnitureStore.SearchFilter" %>
<center>
<asp:Label ID="lblSearch" runat="server" Text="Search: "></asp:Label>
&nbsp;&nbsp;
<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-primary" Text="Search" />
<br /><br />
<asp:Label ID="lblFilter" runat="server" Text="Filter: "></asp:Label>

<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
    <asp:ListItem Value="null" Selected="True">Select a Type</asp:ListItem>
    <asp:ListItem>Bed Room</asp:ListItem>
    <asp:ListItem>Living Room</asp:ListItem>
    <asp:ListItem>Dining Room</asp:ListItem>
</asp:DropDownList>
    </center>

