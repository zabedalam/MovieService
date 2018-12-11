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
                var ImageLink= nodelist[0].SelectSingleNode("@poster").InnerText;
                LabelRatings.Text = " Rating " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                LabelRatings.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
                LabelYear.Text += " " + nodelist[0].SelectSingleNode("@year").InnerText;
                LabelActors.Text += " " + nodelist[0].SelectSingleNode("@actors").InnerText;
                LabelDirector.Text += " " + nodelist[0].SelectSingleNode("@director").InnerText;
                LabelWriter.Text += " " + nodelist[0].SelectSingleNode("@writer").InnerText;
                //.....................
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
                    cmd = new SqlCommand(sqlsel, conn);
                    cmd.Parameters.AddWithValue("@MovieName", Title);
                    cmd1 = new SqlCommand(sqlsel1, conn);
                    cmd1.Parameters.AddWithValue("@Picture", ImageLink);
                    cmd1.Parameters.AddWithValue("@MovieName", Title);


                    // rdr = cmd.ExecuteReader();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();


                    //while (rdr.Read())
                    //{
                    //    //ListBoxrdr.Items.Add("Product = " + rdr[0] + ", Id of category =" + rdr["categoryid"]);
                    //    lb.Items.Add(rdr["MovieName"].ToString());
                    //}
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
                //................
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
    }
}
    

