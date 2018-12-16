<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexPopulateMovie.aspx.cs" Inherits="MovieServiceFinalProject.IndexPopulateMovie" %>--%><%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexPopulateMovie.aspx.cs" Inherits="MovieServiceFinalProject.IndexPopulateMovie" %>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=yes">

    <!-- Bootstrap CSS -->
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <title>MOVIE PROJECT</title>
  </head>
<body>
    <form id="form1" runat="server" style="background-color:#424242">
        <div class="container-fluid d-flex justify-content-center">
            
        <%--<div class="row">
            <div class="col-9  text-dark d-flex justify-content-around">--%>
                <img src="\Picture\movielogo.png" class="img-fluid w-25 h-75 " alt="Movie">
                <br />
            </div>
            
        <%--</div>  
    </div>
       --%>
        <div class="row">
            <div class="col-3 d-flex">

            </div>
            <div class="col-5 d-flex" >

           <%-- <div class="form-inline ml-auto col-sm-7" >--%>
               
                 <asp:TextBox ID="TextBoxInput" class="form-control mr-2 shadow-lg" placeholder="search movie" runat="server" Height="40px" OnTextChanged="TextBoxInput_TextChanged"></asp:TextBox>
</div>            
           <div class="col-4 d-flex" >
            <%--<div class="form-inline ml-auto col-sm-3" >--%>
               
            
                <asp:Button ID="ButtonFindMovie" runat="server" Class="btn btn-outline-yellow-green "   Text="Search" OnClick="ButtonFindMovie_Click" Width="60px" Height="40px" font-size="14px"/>
             </div>
            
      </div>
 
       
         <nav class="navbar navbar-expand-sm navbar-light bg-light">
         <div class="container col-6" >
        <ul class="navbar-nav">
            <li class="nav-item">
            
            <asp:Button ID="Button1" runat="server" Class="btn btn-outline-dark btn-md" Text="Action Movie" OnClick="ButtonActionMovie_Click"/>
</li>
            <li class="nav-item">
            <asp:Button ID="Button2" runat="server" Class="btn btn-outline-dark btn-md" Text="Animation Movie" OnClick="ButtonAnimationMovie_Click" />
</li>
             <li class="nav-item">
            <asp:Button ID="Button3" runat="server" Class="btn btn-outline-dark btn-md" Text="Thriller Movie" OnClick="ButtonThrillerMovie_Click" />
                 </li>
             <li class="nav-item">
            <asp:Button ID="Button4" runat="server" Class="btn btn-outline-dark btn-md" Text="Science Fiction Movie" OnClick="ButtonScienceFictionMovie_Click" />
                  </li>
            </ul>
        </div>
              </nav>
        <%--</div>--%>      

  <%--</div>--%>
        <div class="row">
            <div class="col-2 text-light" >

       <asp:Label ID="Label1" runat="server" Text="Select Movie" BorderStyle="None"></asp:Label>
            </div>
            </div>
        <div class="row">
                    <div class="col-2 d-flex" > 
                        
                        <asp:ListBox ID="ListBoxPopulateMovie" runat="server" 
                            OnSelectedIndexChanged="ListBoxPopulateMovie_SelectedIndexChanged" Height="430px" >
                        </asp:ListBox>
                    </div>
              <div class="col-3 d-flex">              
                   <asp:Image ID="ImagePoster" runat="server" DescriptionUrl="~/MyFiles/titanic.jpg" class="img-thumbnail shadow-lg" />
               </div>
                <div class="col-2 jumbotron h-auto">
                    <asp:Label ID="LabelMovieInfo" runat="server" Text="Movie Info" ></asp:Label>
             <br />
            <asp:Label ID="LabelRatings" runat="server" Text="Ratings" ></asp:Label>
             <br />
            <asp:Label ID="LabelYear" runat="server" Text="Year" ></asp:Label>
             <br />
            <asp:Label ID="LabelActors" runat="server" Text="Actors" ></asp:Label>
             <br />
            <asp:Label ID="LabelDirector" runat="server" Text="Director" ></asp:Label>
             <br />
            <asp:Label ID="LabelWriter" runat="server" Text="Writer" ></asp:Label>
            
                    </div>
                
           
               <div class="row">
                   <div class="col-3 text-warning d-flex">
                       <asp:GridView ID="GridViewCommercial" runat="server">
                       </asp:GridView>
                       <%--<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />--%>
                       <%--<asp:Button ID="Buttoncom" runat="server" OnClick="Buttoncom_Click1" Text="Button" />--%>
                       <%--<asp:Button ID="ButtonCommercial" runat="server" OnClick="ButtonCommercial_Click" Text="Button" />--%>
           </div>
                              </div>
        </div>
        </div>

        
            
            <br />
        <div class="row">
            <div class="col-2"></div>

        <div  class="embed-responsive embed-responsive-16by9 col-sm-8">
            
            <asp:Label ID="LabelMessages" runat="server" Text="No Messages"></asp:Label>
            <br />
             <iframe id="youTubeTrailer" runat="server"  frameborder="2" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen= "allowfullscreen"></iframe>
            <br />
            <asp:Label ID="LabelTralier" runat="server" Text="Tralier's status"></asp:Label>
                
            </div>
            </div>
         <div class="col-2"></div>
            <br />
        
            <br />
            <div class="container repeaterDiv col-sm-12 text-info">
                <asp:Label ID="LabelTopTen" runat="server" Text="Top Ten Movies"></asp:Label>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                 <HeaderTemplate>
                <table class="row container">
                    <tr>
                        
                        <%--<td class="myheader">MovieName</td>--%>
                        <%--<td class="myheader">ReleaseYear</td>--%>
                        
                        <%--<td class="myheader">Picture</td>--%>
                    </tr>
                
            </HeaderTemplate>
                 <ItemTemplate>
                     
                          
                    <tr class="col-2" style="display:inline-block;">
                        <div class="wrapper">
                        
                        <%--<td class="myItem"><%#Eval("MovieName") %></td>--%>
                        <%--<td class="myItem"><%#Eval("ReleaseYear") %></td>--%>
                        <%--<div class="col-sm-6"></div>--%>
                        <td class="poster" style="display:flex; justify-content:center;">
                            <%--<a class="caption" href="#" runat="server" id="anchor2" onserverclick="anchor2_ServerClick">
                                <%# DataBinder.Eval(Container.DataItem,"MovieName") %></a>--%>
                            <img src="<%# DataBinder.Eval(Container.DataItem,"Picture") %>" alt="Poster-url" width="180" height="200" />
                            <%--<img src="<%#Eval("Picture") %>" alt="Movie"/>--%></td>

                    </div>
                        
                    </tr>
                         </div>

                </ItemTemplate>
                 <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieFlexConnectionString %>" SelectCommand="SELECT top 10 [Picture], [ReleaseYear], [MovieName] FROM [Movie] order by Visit_Counter desc"></asp:SqlDataSource>
            <asp:SqlDataSource ID="action" runat="server"></asp:SqlDataSource>
        </div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
      </form>
</body>
</html>
