using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Xsl;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieServiceFinalProject
{
    public partial class SearchIndex : System.Web.UI.Page

    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            show();
            //just for test
            TransformXslt();
        }
        public void show()
        {
            MovieContainer action1 = new MovieContainer();
            action1.ActionMovie(ListBoxMovieDisplay);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            //WebClient client = new WebClient();
            string result = "";

            // substitute " " with "+"
            //string myselection = TextBoxSearch.Text.Replace(' ', '+');
            //result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + Token.token);
            if (TextBoxSearch.Text == "") TextBoxSearch.Text = "No Name";
            APIConnection getmovie = new APIConnection();
            result= getmovie.SearchAPI(TextBoxSearch.Text);
            File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.xml"), result);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);

            if (doc.SelectSingleNode("/root/@response").InnerText == "True")
            {
                LabelMessage.Text = "Movie found";
                XmlNodeList nodelist = doc.SelectNodes("/root/movie");
                foreach (XmlNode node in nodelist)
                {
                    string id = node.SelectSingleNode("@poster").InnerText;
                    ImagePoster.ImageUrl = id;
                }
                //var Items = nodelist[0].SelectSingleNode("@items").InnerText;
                //var videoId = nodelist[0].SelectSingleNode("@videoId").InnerText;
                //var Year = nodelist[0].SelectSingleNode("@year").InnerText;
                var Title = nodelist[0].SelectSingleNode("@title").InnerText;
                var ImageLink = nodelist[0].SelectSingleNode("@poster").InnerText;
                LabelResult.Text = " Rating " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                LabelResult.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
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
                DBUtility conn=new DBUtility();

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

                WebClient client = new WebClient();
                string result1 = "";
                var year = "";
                var searchName = TextBoxSearch.Text.Trim() + year.ToString() + "Movie Trailer";
                string youTubeApi = $"https://www.googleapis.com/youtube/v3/search?&part=snippet&q={searchName}&type=tralier&key={Token.trailerToken}";
                result1 = client.DownloadString(youTubeApi);
               
                var movieSearchResult = JsonConvert.DeserializeObject<JObject>(result1);
                var items = movieSearchResult["items"];
                var videoId = items[0]["id"]["videoId"];
                string checkVideo = videoId == null ? "" : videoId.ToString();

                    if (checkVideo != "")
                    {
                        LabelTralier.Text = "This movie tralier found";
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
                LabelMessage.Text = "Movie not found";
                ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
                // LabelResult.Text = "Result";
            }
        }

        //Transform XSLT
        public void TransformXslt()
        {
            string sourcefile1 = Server.MapPath("XMLCommercial.xml");
            string xsltfile1 = Server.MapPath("XSLTCommercial.xslt");
            string destinationfile1 = Server.MapPath("CommercialTransformed.xml");
            XML xslt1 = new XML(sourcefile1, xsltfile1, destinationfile1);
            xslt1.Transform();
        }


        protected void ButtonMovieAction_Click(object sender, EventArgs e)
        {


        }

        protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
           // TextBoxSearch.Text = ListBoxMovieDisplay.SelectedValue;
        }

        protected void ListBoxMovieDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxSearch.Text = ListBoxMovieDisplay.SelectedValue;
        }
    }
}


    
