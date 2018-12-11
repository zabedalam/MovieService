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
                SqlConnection conn = new SqlConnection(@"data source = .\Sqlexpress; integrated security = true; database = MovieFlex");
                SqlCommand cmd = null;
                SqlCommand cmd1 = null;
                SqlDataReader rdr = null;

                string sqlsel = "";
                string sqlsel1 = "";
                try
                {
                    conn.Open();

                    sqlsel = "update Movie set Visit_Counter=Visit_Counter+1 where MovieName=@MovieName ";
                    sqlsel1 = "update Movie set Picture=@Picture where MovieName=@MovieName";


                    cmd1 = new SqlCommand(sqlsel1, conn);

                    cmd = new SqlCommand(sqlsel, conn);
                    cmd.Parameters.AddWithValue("@MovieName", Title);
                    cmd1 = new SqlCommand(sqlsel1, conn);
                    cmd1.Parameters.AddWithValue("@Picture", ImageLink);
                    cmd1.Parameters.AddWithValue("@MovieName", Title);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    rdr.Close();
                }
                catch (Exception)
                {
                    Title = "not found";
                    //LabelMessages.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
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