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
            <asp:Button ID="ButtonMovieAction" runat="server" Text="Action Movie" OnClick="ButtonMovieAction_Click" />
            <asp:Button ID="ButtonAnimation" runat="server" Text="Animation Movie" />
            <asp:Button ID="ButtonThrillerMovie" runat="server" Text="Thriller Movie" />
            <asp:Button ID="ButtonScienceFictionMovie" runat="server" Text="Science Fiction Movie" />
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server" Text="Movie Info"></asp:Label>
            <br />
            <asp:Label ID="LabelResult" runat="server" Text="Result"></asp:Label>
            <br />
            <asp:Label ID="LabelYear" runat="server" Text="Year"></asp:Label>
            <br />
            <asp:Label ID="LabelActors" runat="server" Text="Actors"></asp:Label>
            <br />
            <asp:Label ID="LabelDirector" runat="server" Text="Director"></asp:Label>
            <br />
            <asp:Label ID="LabelWriter" runat="server" Text="Writer"></asp:Label>
            <br />
            <asp:Image ID="ImagePoster" runat="server" Height="302px" ImageUrl="~/MyFiles/titanic.jpg" Width="399px" />
            <br />
            <br />
            <asp:Xml ID="XmltoXmlCommercial" runat="server" DocumentSource="~/XMLCommercial.xml" TransformSource="~/XSLTCommercial.xslt"></asp:Xml>
        </div>
    </form>
</body>
</html>
