using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using System.Data.SqlClient;


namespace MovieServiceFinalProject
{
    public partial class SearchEngineen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Search();
        }
        public void Search()
        {
            WebClient client = new WebClient();
            string result = "";

            // substitute " " with "+"
            string myselection = TextBoxInput.Text.Replace(' ', '+');
            result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + Token.token);
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

            }
            else
            {
                LabelMessages.Text = "Movie not found";
                ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
                // LabelResult.Text = "Result";
            }


        }
    }
}