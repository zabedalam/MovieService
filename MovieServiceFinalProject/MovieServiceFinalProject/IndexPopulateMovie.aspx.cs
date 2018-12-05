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
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
            ActionMovie action = new ActionMovie();
            try
            {
                action.Action(ListBoxPopulateMovie);
            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }
        }

        protected void ListBoxPopulateMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxInput.Text = ListBoxPopulateMovie.SelectedValue;
        }

        protected void ButtonFindMovie_Click(object sender, EventArgs e)
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
                LabelRatings.Text = " Rating " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                LabelRatings.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
                LabelYear.Text += " " + nodelist[0].SelectSingleNode("@year").InnerText;
                LabelActors.Text += " " + nodelist[0].SelectSingleNode("@actors").InnerText;
                LabelDirector.Text += " " + nodelist[0].SelectSingleNode("@director").InnerText;
                LabelWriter.Text += " " + nodelist[0].SelectSingleNode("@writer").InnerText;

            }

            else
            {
                LabelMessages.Text = "Movie not found";
                ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
               // LabelResult.Text = "Result";
            }
        }

        protected void ButtonAnimationMovie_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
            AnimationMovie animation = new AnimationMovie();
            try
            {
                animation.Animation(ListBoxPopulateMovie);
            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }
        }

        protected void ButtonThrillerMovie_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
            ThrillerMovie thriller = new ThrillerMovie();
            try
            {
                thriller.Thriller(ListBoxPopulateMovie);
            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }
        }

        protected void ButtonScienceFictionMovie_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
            ScienceFictionMovie ScienceFiction = new ScienceFictionMovie();
            try
            {
                ScienceFiction.ScienceFiction(ListBoxPopulateMovie);
            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }
        }
    }
}
    

