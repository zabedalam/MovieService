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
using System.Configuration;
using System.Data.Common;

namespace MovieServiceFinalProject
{
    public partial class IndexPopulateMovie : System.Web.UI.Page
    {
        //private DbDataReader dtComm;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ListBoxPopulateMovie.AutoPostBack = true;

            }
            //TransformXslt();
            commmercialInfo();
            showCommercial();
            showOnPageLoad();
        }

        public void showOnPageLoad()
        {
            MovieContainer action = new MovieContainer();
            action.ActionMovie(ListBoxPopulateMovie);
        }

        private void DoSearch()
        {
            string result = "";
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
                var ImageLink = nodelist[0].SelectSingleNode("@poster").InnerText;
                var Year = nodelist[0].SelectSingleNode("@year").InnerText;
                var Title = nodelist[0].SelectSingleNode("@title").InnerText;
                LabelRatings.Text = " Rating " + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                LabelRatings.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
                LabelYear.Text = " " + nodelist[0].SelectSingleNode("@year").InnerText;
                LabelActors.Text = " " + nodelist[0].SelectSingleNode("@actors").InnerText;
                LabelDirector.Text = " " + nodelist[0].SelectSingleNode("@director").InnerText;
                LabelWriter.Text = " " + nodelist[0].SelectSingleNode("@writer").InnerText;

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
                catch (Exception ex)
                {
                    //Title = "not found";
                    LabelMessages.Text = ex.Message;
                }
                finally
                {
                    DBUtility close = new DBUtility();
                    close.CloseConnection();
                }

                //MOVIE TRAILER
                string trailerresult = "";
                APIConnection trailer = new APIConnection();
                trailerresult = trailer.SearchTrailerAPI(Title.ToString(), Convert.ToInt32(Year));
                var searchResult = JsonConvert.DeserializeObject<JObject>(trailerresult);
                File.WriteAllText(Server.MapPath("~/MyFiles/LatestTrailer.json"), trailerresult);
                var items = searchResult["items"];
                var videoId = items[0]["id"]["videoId"];
                string checkVideo = videoId == null ? "" : videoId.ToString();
                if (checkVideo != "")
                {
                    youTubeTrailer.Src = $"https://www.youtube.com/embed/{checkVideo}";
                    LabelTralier.Text = "Tralier found";
                }
                else
                {
                    youTubeTrailer.Src = "";
                    LabelTralier.Text = "Tralier not found";
                }

            }
            else
            {
                LabelMessages.Text = "Movie not found";
                ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
                LabelRatings.Text = "";
                LabelYear.Text = "";
                LabelActors.Text = "";
                LabelDirector.Text = "";
                LabelWriter.Text = "";
            }
        }
        protected void ListBoxPopulateMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxInput.Text = ListBoxPopulateMovie.SelectedValue;
            if (ListBoxPopulateMovie.SelectedIndex != -1)
            {
                ButtonFindMovie.Enabled = true;
                DoSearch();

            }
            else
            {
                LabelMessages.Text = "no";
            }
        }

        protected void ButtonFindMovie_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        protected void ButtonActionMovie_Click(object sender, EventArgs e)
        {

            ListBoxPopulateMovie.Items.Clear();
            MovieContainer action = new MovieContainer();
            action.ActionMovie(ListBoxPopulateMovie);

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

        //Transform XSLT
        //public void TransformXslt()
        //{
        //    string sourcefile1 = Server.MapPath("XMLCommercial.xml");
        //    string xsltfile1 = Server.MapPath("XSLTCommercial.xslt");
        //    string destinationfile1 = Server.MapPath("CommercialTransformed.xml");
        //    XML xslt1 = new XML(sourcefile1, xsltfile1, destinationfile1);
        //    xslt1.Transform();

        //}

        protected void TextBoxInput_TextChanged(object sender, EventArgs e)
        {

        }
        public void showCommercial()
        {
            Commercial advertisement = new Commercial();
            advertisement.commercialShow(GridViewCommercial);

        }

        public void commmercialInfo() {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/CommercialTransformed.xml"));
                DataTable dtComm = ds.Tables["commercial"];
                con.Open();

                using (SqlBulkCopy bc = new SqlBulkCopy(con))
                {
                    bc.DestinationTableName = "CommercialTbl";
                    bc.ColumnMappings.Add("id", "CommercialID");
                    bc.ColumnMappings.Add("CompanyName", "CompanyName");
                    bc.ColumnMappings.Add("Website", "Website");
                    bc.ColumnMappings.Add("Address", "Address");

                    bc.WriteToServer(dtComm);
                }

            }
        }
        //protected void ButtonCommercial_Click(object sender, EventArgs e)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {

        //        DataSet ds = new DataSet();
        //        ds.ReadXml(Server.MapPath("~/CommercialTransformed.xml"));
        //        DataTable dtComm = ds.Tables["commercial"];
        //        con.Open();

        //        using (SqlBulkCopy bc = new SqlBulkCopy(con))
        //        {
        //            bc.DestinationTableName = "CommercialTbl";
        //            bc.ColumnMappings.Add("id", "CommercialID");
        //            bc.ColumnMappings.Add("CompanyName", "CompanyName");
        //            bc.ColumnMappings.Add("Website", "Website");
        //            bc.ColumnMappings.Add("Address", "Address");

        //            bc.WriteToServer(dtComm);
        //        }

        //    }

        //}
    }
}

        

