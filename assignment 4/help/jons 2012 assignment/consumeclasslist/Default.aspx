<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<h1>Consuming the ClassList Web Service</h1>



<asp:ListBox ID="lstStudents" runat="server" Height="93px" Width="179px">
</asp:ListBox>
<br />
<br />
<asp:GridView ID="gvStudents" runat="server" CellPadding="4" 
  ForeColor="#333333" GridLines="None" Height="122px" Width="348px">
  <AlternatingRowStyle BackColor="White" />
  <EditRowStyle BackColor="#7C6F57" />
  <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
  <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
  <RowStyle BackColor="#E3EAEB" />
  <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
  <SortedAscendingCellStyle BackColor="#F8FAFA" />
  <SortedAscendingHeaderStyle BackColor="#246B61" />
  <SortedDescendingCellStyle BackColor="#D4DFE1" />
  <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>



</form>
</body>
</html>
