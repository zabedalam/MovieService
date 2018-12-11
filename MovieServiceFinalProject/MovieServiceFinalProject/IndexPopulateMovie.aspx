<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexPopulateMovie.aspx.cs" Inherits="MovieServiceFinalProject.IndexPopulateMovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ButtonActionMovie" runat="server" Text="Action Movie" OnClick="ButtonActionMovie_Click" />
            <asp:Button ID="ButtonAnimationMovie" runat="server" Text="Animation Movie" OnClick="ButtonAnimationMovie_Click" />
            <asp:Button ID="ButtonThrillerMovie" runat="server" Text="Thriller Movie" OnClick="ButtonThrillerMovie_Click" />
            <asp:Button ID="ButtonScienceFictionMovie" runat="server" Text="Science Fiction Movie" OnClick="ButtonScienceFictionMovie_Click" />
            <br />
            <br />
            <asp:ListBox ID="ListBoxPopulateMovie" runat="server" OnSelectedIndexChanged="ListBoxPopulateMovie_SelectedIndexChanged"></asp:ListBox>
            <br />
            <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonFindMovie" runat="server" Text="Find Movie" OnClick="ButtonFindMovie_Click" />
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
            <asp:Image ID="ImagePoster" runat="server" DescriptionUrl="~/MyFiles/titanic.jpg" />
            <br />
            <asp:Label ID="LabelMessages" runat="server" Text="No Messages"></asp:Label>
            <br />
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                 <HeaderTemplate>
                <table class="mytable">
                    <tr>
                        
                        <td class="myheader">MovieName</td>
                        <td class="myheader">ReleaseYear</td>
                        
                        <td class="myheader">Picture</td>
                    </tr>
                
            </HeaderTemplate>
                 <ItemTemplate>
                    <tr>
                        
                        <td class="myItem"><%#Eval("MovieName") %></td>
                        <td class="myItem"><%#Eval("ReleaseYear") %></td>
                        <%--<div class="col-sm-6"></div>--%>
                        <td class="myItem"><img src="<%#Eval("Picture") %>" alt="Movie"/></td>


                    </tr>

                </ItemTemplate>
                 <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieFlexConnectionString %>" SelectCommand="SELECT top 10 [Picture], [ReleaseYear], [MovieName] FROM [Movie] order by Visit_Counter desc"></asp:SqlDataSource>
            <asp:SqlDataSource ID="action" runat="server"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
