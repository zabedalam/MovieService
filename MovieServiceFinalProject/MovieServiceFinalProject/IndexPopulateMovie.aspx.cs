using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieServiceFinalProject
{
    public partial class IndexPopulateMovie : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {

                PopulateListBox.Populate(ListBoxPopulateMovie);
                ListBoxPopulateMovie.AutoPostBack = true;
                
            }

            
        }
        

        protected void ButtonActionMovie_Click(object sender, EventArgs e)
        {
            // Response.Redirect("ActionMovie.aspx");
            ListBoxPopulateMovie.Items.Clear();
            MovieContainer action = new MovieContainer();
            action.ActionMovie(ListBoxPopulateMovie);

        }

        protected void ListBoxPopulateMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxInput.Text = ListBoxPopulateMovie.SelectedValue;
        }

        protected void ButtonFindMovie_Click(object sender, EventArgs e)
        {
            //WebClient client = new WebClient();
            string result = "";

            // substitute " " with "+"
            //string myselection = TextBoxSearch.Text.Replace(' ', '+');
            //result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + Token.token);
            if (TextBoxInput.Text == "") TextBoxInput.Text = "No Name";
            APIConnection getmovie = new APIConnection();
            result = getmovie.SearchAPI(TextBoxInput.Text);
            File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.xml"), result);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);

            if (doc.SelectSingleNode("/root/@response").InnerText == "True")
            {
                LabelMessages.Text = "Movie found";
                XmlNodeList nodelist = doc.SelectNodes("/root/movie");
                foreach (XmlNode node in nodelist)
                {
                    string id = node.SelectSingleNode("@poster").InnerText;
                    ImagePoster.ImageUrl = id;
                }
                //var Items = nodelist[0].SelectSingleNode("@items").InnerText;
                //var videoId = nodelist[0].SelectSingleNode("@videoID").InnerText;
                //var Year = nodelist[0].SelectSingleNode("@year").InnerText;


                var Title = nodelist[0].SelectSingleNode("@title").InnerText;
                var ImageLink = nodelist[0].SelectSingleNode("@poster").InnerText;
                LabelRatings.Text = " Rating " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                LabelRatings.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
                LabelYear.Text += " " + nodelist[0].SelectSingleNode("@year").InnerText;
                LabelActors.Text += " " + nodelist[0].SelectSingleNode("@actors").InnerText;
                LabelDirector.Text += " " + nodelist[0].SelectSingleNode("@director").InnerText;
                LabelWriter.Text += " " + nodelist[0].SelectSingleNode("@writer").InnerText;

                //INCREASE NUMBER OF VISITED MOVIE AND DOWNLOAD POSTER OF MOVIE
                SqlCommand counter = null;
                SqlCommand poster = null;
                SqlDataReader rdr = null;
                string UpdateCounter = "";
                string SetPoster = "";
                DBUtility conn = new DBUtility();

                try
                {
                    conn.GetConnection();
                    UpdateCounter = "update Movie set Visit_Counter=Visit_Counter+1 where MovieName=@MovieName ";
                    SetPoster = "update Movie set Picture=@Picture where MovieName=@MovieName";
                    counter = new SqlCommand(UpdateCounter, conn.GetConnection());
                    counter.Parameters.AddWithValue("@MovieName", Title);
                    poster = new SqlCommand(SetPoster, conn.GetConnection());
                    poster.Parameters.AddWithValue("@Picture", ImageLink);
                    poster.Parameters.AddWithValue("@MovieName", Title);
                    counter.ExecuteNonQuery();
                    poster.ExecuteNonQuery();
                    rdr.Close();
                }
                catch (Exception)
                {
                    Title = "not found";
                    //LabelMessages.Text = ex.Message;
                }
                finally
                {
                    DBUtility close = new DBUtility();
                    close.CloseConnection();
                }

                //MOVIE TRAILER
                //string result = "";
                //result = UtilityClass.TrailerAPI(name.ToString(), Convert.ToInt32(year));
                //var movieSearchResult = JsonConvert.DeserializeObject<JObject>(result);
                //File.WriteAllText(Server.MapPath("~/MyFiles/LatestTrailer.json"), result);
                //var items = movieSearchResult["items"];
                //var videoId = items[0]["id"]["videoId"];
                //string checkVideo = videoId == null ? "" : videoId.ToString();
                //............

                //string trailerresult = "";

                //APIConnection trailer = new APIConnection();
                //trailerresult = trailer.SearchTrailerAPI(Title.ToString(), Convert.ToInt32(Year));
                //var movieSearchResult = JsonConvert.DeserializeObject<JObject>(trailerresult);
                //File.WriteAllText(Server.MapPath("~/MyFiles/LatestTrailer.json"), trailerresult);
                //var items = movieSearchResult["items"];
                //var videoId = items[0]["id"]["videoId"];
                //string checkVideo = videoId == null ? "" : videoId.ToString();
                //..................
                WebClient client = new WebClient();
                string result1 = "";
                var year = "";
                var searchName = TextBoxInput.Text.Trim() + year.ToString() + "Movie Trailer";
                string youTubeApi = $"https://www.googleapis.com/youtube/v3/search?&part=snippet&q={searchName}&type=tralier&key={Token.trailerToken}";
                result1 = client.DownloadString(youTubeApi);

                var movieSearchResult = JsonConvert.DeserializeObject<JObject>(result1);
                var items = movieSearchResult["items"];
                var videoId = items[0]["id"]["videoId"];
                string checkVideo = videoId == null ? "" : videoId.ToString();

                if (checkVideo != "")
                {
                    //LabelTralier.Text = "This movie tralier found";
                    youTubeTrailer.Src = $"https://www.youtube.com/embed/{checkVideo}";
                }
                else
                {
                    youTubeTrailer.Src = "";
                    LabelTralier.Text = "This movie tralier not found";
                }

            }


            else
            {
                LabelMessages.Text = "Movie not found";
                ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
                // LabelResult.Text = "Result";
            }
            //................................................//
            //Response.Redirect("SearchEngineen.aspx");
            //WebClient client = new WebClient();
            //string result = "";

            //// substitute " " with "+"
            //string myselection = TextBoxInput.Text.Replace(' ', '+');
            //result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + Token.token);
            //File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.xml"), result);
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(result);

            //if (doc.SelectSingleNode("/root/@response").InnerText == "True")
            //{
            //    LabelMessages.Text = "Movie found";
            //    XmlNodeList nodelist = doc.SelectNodes("/root/movie");
            //    foreach (XmlNode node in nodelist)
            //    {
            //        string id = node.SelectSingleNode("@poster").InnerText;
            //        ImagePoster.ImageUrl = id;
            //    }
            //    var Title = nodelist[0].SelectSingleNode("@title").InnerText;
            //    var ImageLink= nodelist[0].SelectSingleNode("@poster").InnerText;
            //    LabelRatings.Text = " Rating " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
            //    LabelRatings.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
            //    LabelYear.Text += " " + nodelist[0].SelectSingleNode("@year").InnerText;
            //    LabelActors.Text += " " + nodelist[0].SelectSingleNode("@actors").InnerText;
            //    LabelDirector.Text += " " + nodelist[0].SelectSingleNode("@director").InnerText;
            //    LabelWriter.Text += " " + nodelist[0].SelectSingleNode("@writer").InnerText;

            //    //INCREASE NUMBER OF VISITED MOVIE AND DOWNLOAD POSTER OF MOVIE
            //    SqlConnection conn = new SqlConnection(@"data source = .\Sqlexpress; integrated security = true; database = MovieFlex");
            //    SqlCommand cmd = null;
            //    SqlCommand cmd1 = null;
            //    SqlDataReader rdr = null;

            //    string sqlsel = "";
            //    string sqlsel1 = "";
            //    try
            //    {
            //        conn.Open();

            //        sqlsel = "update Movie set Visit_Counter=Visit_Counter+1 where MovieName=@MovieName ";
            //        sqlsel1 = "update Movie set Picture=@Picture where MovieName=@MovieName";


            //        cmd1 = new SqlCommand(sqlsel1, conn);

            //        cmd = new SqlCommand(sqlsel, conn);
            //        cmd.Parameters.AddWithValue("@MovieName", Title);
            //        cmd1 = new SqlCommand(sqlsel1, conn);
            //        cmd1.Parameters.AddWithValue("@Picture", ImageLink);
            //        cmd1.Parameters.AddWithValue("@MovieName", Title);
            //        cmd.ExecuteNonQuery();
            //        cmd1.ExecuteNonQuery();
            //        rdr.Close();
            //    }
            //    catch (Exception)
            //    {
            //        Title = "not found";
            //        //LabelMessages.Text = ex.Message;
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }

            //}


            //else
            //{
            //    LabelMessages.Text = "Movie not found";
            //    ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
            //   // LabelResult.Text = "Result";
            //}


        }

        protected void ButtonAnimationMovie_Click(object sender, EventArgs e)
        {
            ListBoxPopulateMovie.Items.Clear();
            MovieContainer animation = new MovieContainer();
            animation.AnimationMovie(ListBoxPopulateMovie);
            
        }

        protected void ButtonThrillerMovie_Click(object sender, EventArgs e)
        {
            ListBoxPopulateMovie.Items.Clear();
            MovieContainer thi = new MovieContainer();
            thi.ThrillerMovie(ListBoxPopulateMovie);
            
        }

        protected void ButtonScienceFictionMovie_Click(object sender, EventArgs e)
        {

            ListBoxPopulateMovie.Items.Clear();
            MovieContainer sci = new MovieContainer();
            sci.ScienceMovie(ListBoxPopulateMovie);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        
                
                
        }

        protected void TextBoxInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

