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
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                 <HeaderTemplate>
                <table class="mytable">
                    <tr>
                        
                        <td class="myheader">MovieName</td>
                        <%--<td class="myheader">ReleaseYear</td>--%>
                        
                        <td class="myheader">Picture</td>
                    </tr>
                
            </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        
                        <td class="myItem"><%#Eval("MovieName") %></td>
                        <%--<td class="myItem"><%#Eval("ReleaseYear") %></td>--%>
                        <%--<div class="col-sm-6"></div>--%>
                        <td class="myItem"><img src="<%#Eval("Picture") %>" alt="Movie"/></td>


                    </tr>

                </ItemTemplate>
                 <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieFlexConnectionString2 %>" SelectCommand="SELECT top 6 [MovieName], [Picture] FROM [Movie] where FilmCategoryID=1  order by Visit_Counter desc"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Xml ID="XmltoXmlCommercial" runat="server" DocumentSource="~/XMLCommercial.xml" TransformSource="~/XSLTCommercial.xslt"></asp:Xml>
        </div>
    </form>
</body>
</html>
