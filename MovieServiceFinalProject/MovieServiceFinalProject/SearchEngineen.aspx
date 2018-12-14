<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEngineen.aspx.cs" Inherits="MovieServiceFinalProject.SearchEngineen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 259px">
            <asp:Label ID="LabelMessages" runat="server" Text="Messages"></asp:Label>
            <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelRatings" runat="server" Text="Ratings"></asp:Label>
            <br />
            <asp:Label ID="LabelYear" runat="server" Text="Release Year"></asp:Label>
            <br />
            <asp:Label ID="LabelWriter" runat="server" Text="Writer"></asp:Label>
            <br />
            <asp:Label ID="LabelDirector" runat="server" Text="Director"></asp:Label>
            <br />
            <asp:Label ID="LabelActors" runat="server" Text="Actors"></asp:Label>
            <br />
            <asp:Image ID="ImagePoster" runat="server" />
        </div>
    </form>
</body>
</html>
