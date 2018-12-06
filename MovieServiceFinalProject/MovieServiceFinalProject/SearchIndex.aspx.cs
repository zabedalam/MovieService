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








namespace MovieServiceFinalProject
{
    public partial class SearchIndex : System.Web.UI.Page

    {
        //public object ListBoxPopulateMovie { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //just for test
            TransformXslt();
        }


        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string result = "";

            // substitute " " with "+"
            string myselection = TextBoxSearch.Text.Replace(' ', '+');
            
            result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + Token.token);
            
            
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
                LabelResult.Text = " Rating " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                LabelResult.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
                LabelYear.Text += " " + nodelist[0].SelectSingleNode("@year").InnerText;
                LabelActors.Text += " " + nodelist[0].SelectSingleNode("@actors").InnerText;
                LabelDirector.Text += " " + nodelist[0].SelectSingleNode("@director").InnerText;
                LabelWriter.Text += " " + nodelist[0].SelectSingleNode("@writer").InnerText;
               
            }

            else
            {
                LabelMessage.Text = "Movie not found";
                ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
                //LabelResult.Text = "Result";
            }
        }

        //Transform XSLT
        public  void TransformXslt()
        {
            
            string sourcefile1 = Server.MapPath("XMLCommercial.xml");
            string xsltfile1 = Server.MapPath("XSLTCommercial.xslt");
            string destinationfile1 = Server.MapPath("CommercialTransformed.xml");
            XML xslt1 = new XML(sourcefile1, xsltfile1, destinationfile1);
            xslt1.Transform();



        }
       

        protected void ButtonMovieAction_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("IndexPopulateMovie.aspx", true);
            IndexPopulateMovie.ListBoxPopulateMovie.Items.Clear();
            ActionMovie action = new ActionMovie();
            ListBox ListBoxPopulateMovie = null;
            action.Action(ListBoxPopulateMovie);
            //SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
            //ActionMovie action = new ActionMovie();
            //try
            //{
            //    ListBox ListBoxPopulateMovie = null;
            //    action.Action(ListBoxPopulateMovie);
            //}
            //catch (Exception ex)
            //{
            //    //LabelMessages.Text = ex.Message;
            //}
            //finally
            //{
            //    conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
            //}
        }
    }

}
    
