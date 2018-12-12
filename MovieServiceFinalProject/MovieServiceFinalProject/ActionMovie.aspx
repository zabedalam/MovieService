<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionMovie.aspx.cs" Inherits="MovieServiceFinalProject.SearchIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxSearch" runat="server" Width="231px" OnTextChanged="TextBoxSearch_TextChanged"></asp:TextBox>
            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" style="text-align: left" />
            <br />
            <asp:ListBox ID="ListBoxMovieDisplay" runat="server" OnSelectedIndexChanged="ListBoxMovieDisplay_SelectedIndexChanged" Height="155px" Width="319px"></asp:ListBox>
            <br />
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
            <asp:Image ID="ImagePoster" runat="server" Height="319px" ImageUrl="~/MyFiles/titanic.jpg" Width="320px" />
            <br />
            <br />
            <br />
            <br />
                <br />
            <br />
            <asp:Xml ID="XmltoXmlCommercial" runat="server" DocumentSource="~/XMLCommercial.xml" TransformSource="~/XSLTCommercial.xslt"></asp:Xml>
        
            <br />
            <br />
        
            <br/>
            <iframe id="youTubeTrailer" runat="server" width="560" height="315" frameborder="2" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen= "allowfullscreen"></iframe>
            <br />
            <asp:Label ID="LabelTralier" runat="server" Text="Tralier's status"></asp:Label>
            <br />
            <br />
        </div>

    </form>
</body>
</html>
