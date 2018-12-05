<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexPopulateMovie.aspx.cs" Inherits="MovieServiceFinalProject.IndexPopulateMovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ButtonActionMovie" runat="server" Text="Action Movie" />
            <asp:Button ID="ButtonAnimationMovie" runat="server" Text="Animation Movie" />
            <asp:Button ID="ButtonThrillerMovie" runat="server" Text="Thriller Movie" />
            <asp:Button ID="ButtonScienceFictionMovie" runat="server" Text="Science Fiction Movie" />
            <br />
            <br />
            <asp:ListBox ID="ListBoxPopulateMovie" runat="server"></asp:ListBox>
            <br />
            <asp:Button ID="ButtonFindMovie" runat="server" Text="Find Movie" />
            <br />
            <br />
            <asp:Label ID="LabelMovieInfo" runat="server" Text="Movie Info"></asp:Label>
            <br />
            <asp:Label ID="LabelRatings" runat="server" Text="Ratings"></asp:Label>
            <br />
            <asp:Label ID="LabelYear" runat="server" Text="Year"></asp:Label>
            <br />
            <asp:Label ID="LabelActors" runat="server" Text="Actors"></asp:Label>
            <br />
            <asp:Label ID="LabelDirector" runat="server" Text="Director"></asp:Label>
            <br />
            <asp:Label ID="LabelWriter" runat="server" Text="Writer"></asp:Label>
            <br />
            <asp:Image ID="Image1" runat="server" />
            <br />
            <asp:Label ID="LabelMessages" runat="server" Text="No Messages"></asp:Label>
        </div>
    </form>
</body>
</html>
