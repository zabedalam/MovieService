<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchIndex.aspx.cs" Inherits="MovieServiceFinalProject.SearchIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxSearch" runat="server" Width="231px"></asp:TextBox>
            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" />
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server" Text="Message"></asp:Label>
            <br />
            <asp:Label ID="LabelResult" runat="server" Text="Result"></asp:Label>
            <br />
            <asp:Image ID="ImagePoster" runat="server" Height="232px" ImageUrl="~/MyFiles/titanic.jpg" Width="399px" />
        </div>
    </form>
</body>
</html>
