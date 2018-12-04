using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace MovieServiceFinalProject
{
    public partial class SearchIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string result = "";

            // substitute " " with "+"
            string myselection = TextBoxSearch.Text.Replace(' ', '+');
            result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&apikey=" + Token.token);
            File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.json"), result);

            // A simple example. Treat json as a string
            string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

            if (mysplit[1] != "False")
            {
                LabelMessage.Text = "Movie found";

                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Poster")
                    {
                        ImagePoster.ImageUrl = mysplit[++i];
                        break;
                    }
                }
                LabelResult.Text = "Ratings : ";
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Ratings")
                    {
                        while (mysplit[++i] == "Source")
                        {
                            if (mysplit[i - 1] != "Ratings") LabelResult.Text += "; ";
                            LabelResult.Text += mysplit[i + 3] + " from " + mysplit[i + 1];
                            i = i + 3;
                        }
                        break;
                    }
                }
                //LabelResult.Text = "year : ";
                ////for (int i = 0; i < mysplit.Length; i++)
                ////{
                ////    if (mysplit[i] == "year")
                ////    {
                ////        while (mysplit[++i] == "Source")
                ////        {
                ////            if (mysplit[i - 1] != "year") LabelResult.Text += "; ";
                ////            LabelResult.Text += mysplit[i + 3] + " from " + mysplit[i + 1];
                ////            i = i + 3;
                ////        }
                //for (int i = 0; i < mysplit.Length; i++)
                //{
                //    if (mysplit[i] == "year")
                //    {
                //        LabelResult.Text = mysplit[++i];
                //        i = i + 3;
                //        break;
                //    }
                //}

            }


            else
            {
                LabelMessage.Text = "Movie not found";
                ImagePoster.ImageUrl = "~/MyFiles/titanic.jpg";
                LabelResult.Text = "Result";
            }
        }

    }
}
    
